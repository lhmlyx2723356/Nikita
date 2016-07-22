using System;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using Helios.Net;
using Helios.Net.Bootstrap;
using Helios.Topology;
using Newtonsoft.Json;
using Nikita.Base.DbSchemaReader.DataSchema;
using Nikita.Base.HeliosCommon;
using Nikita.DataAccess4DBHelper;

namespace Nikita.Base.CacheStore
{
    public class CacheListener
    {
        private static IConnection _client;
        private static IConnection AppClient
        {
            get
            {
                if (_client == null)
                {
                    StartClient();
                }
                return _client;
            }
        }
        /// <summary>开始客户端
        /// 
        /// </summary>
        public static void StartClient()
        {
            var host = IPAddress.Loopback;
            const int port = 9991;
            var connectionFactory = new ClientBootstrap().SetTransport(TransportType.Tcp).Build();
            //New一个Client
            _client = connectionFactory.NewConnection(Node.Empty(), NodeBuilder.BuildNode().Host(host).WithPort(port));
            _client.OnConnection += (address, connection) =>
            {
                connection.BeginReceive(Received);
            };
            _client.OnDisconnection += (address, reason) => { };
            //建立连接
            _client.Open();
            //加入服务端组
            Join();
            //等待输入
            //WaitInput();
        }

        //public static void WaitInput(string input)
        //{
        //    while (true)
        //    { 
        //        if (string.IsNullOrEmpty(input)) continue;
        //        var message = MakeSendMessage(input);
        //        SendMessage(_client, message);
        //    }
        //}

        /// <summary>加入服务端组
        /// 
        /// </summary>
        private static void Join()
        {
            var message = MakeJoinMessage();
            SendMessage(_client, message);
        }
        /// <summary>发送消息
        /// 
        /// </summary>
        /// <param name="messageEntity"></param>
        public static void AddMessage(CacheMessageEntity messageEntity)
        {
            if (AppClient != null)
            {
                string strContent = JsonConvert.SerializeObject(messageEntity, Formatting.Indented);
                Message message = new Message { Command = Command.Send, Content = strContent };
                SendMessage(AppClient, message);
            }
        }


        /// <summary>处理接受到的消息
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="responseChannel"></param>
        public static void Received(NetworkData data, IConnection responseChannel)
        {
            try
            {
                var message = MessageConverter.ToMessage(data);
                if (message.Command == Command.Send)
                {
                    if (message.Content.Contains("join group successful"))
                    {
                        return;
                    }
                    CacheMessageEntity entity = JsonConvert.DeserializeObject<CacheMessageEntity>(message.Content);
                    string strKey = entity.CacheKey;
                    string strOperation = entity.Operation;
                    DataTable dtCacheTable = entity.DataTableCache;
                    //新增缓存配置，同步缓存
                    if (strOperation == "Add")
                    {
                        SynLocalCacheByCacheConfig(dtCacheTable);
                    }
                    //删除缓存配置，同步缓存
                    else if (strOperation == "Delete")
                    {
                        string strTableName = dtCacheTable.Rows[0]["TableName"].ToString();
                        string strId = dtCacheTable.Rows[0]["Id"].ToString();
                        IDbHelper helper = GlobalHelp.GetDataAccessSqliteHelper();
                        helper.CreateCommand("DELETE FROM CacheConfig WHERE Id=" + strId + "");
                        helper.ExecuteNonQuery();
                        helper.CreateCommand("DROP Table IF EXISTS [" + strTableName + "]");
                        helper.ExecuteNonQuery();
                        if (CacheManager.CacheDictionary.ContainsKey(strTableName))
                        {
                            CacheManager.CacheDictionary.Remove(strTableName);
                        }
                    }
                }
            }
            catch (Exception)
            {
            }

        }

        private static void SynLocalCacheByCacheConfig(DataTable dtCacheTable)
        {
            string strTableName = dtCacheTable.Rows[0]["TableName"].ToString();
            string strId = dtCacheTable.Rows[0]["Id"].ToString();
            string strConn = dtCacheTable.Rows[0]["ConnectionString"].ToString();
            DatabaseTable databaseTable = CacheManager.GetDatabaseTable(strConn, SqlType.SqlServer, strTableName);
            if (databaseTable != null)
            {
                string strDdl = CacheManager.RunTableDdl(databaseTable, SqlType.SQLite);
                strDdl += "; SELECT 'ok'";
                IDbHelper helper = GlobalHelp.GetDataAccessSqliteHelper();
                helper.CreateCommand("DROP Table IF EXISTS [" + strTableName + "]");
                helper.ExecuteNonQuery();
                helper.CreateCommand(strDdl);
                DataTable dtCache = helper.ExecuteQuery();
                if (dtCache.Rows.Count > 0 && dtCache.Rows[0][0].ToString().Trim() == "ok")
                {
                    //删除本地缓存设置表数据
                    helper.CreateCommand("DELETE FROM CacheConfig WHERE TableName ='" + strTableName + "' ");
                    helper.ExecuteNonQuery();
                    //获取服务器缓存表数据，并同步至本地缓存数据库
                    IDbHelper helperSql = new MSSQLHelper(strConn);
                    helperSql.CreateCommand("SELECT * FROM " + strTableName + " with(nolock)");
                    DataTable dtBatch = helperSql.ExecuteQuery();
                    dtBatch.TableName = strTableName;
                    for (int i = 0; i < dtBatch.Columns.Count; i++)
                    {
                        dtBatch.Columns[i].AutoIncrement = false;
                    }
                    helper.BatchInsert(dtBatch);
                    //同步本地缓存设置表数据
                    dtCacheTable.TableName = "CacheConfig";
                    for (int i = 0; i < dtCacheTable.Columns.Count; i++)
                    {
                        dtCacheTable.Columns[i].AutoIncrement = false;
                    }
                    for (int i = 0; i < dtCacheTable.Rows.Count; i++)
                    {
                        dtCacheTable.Rows[i]["ConnectionString"] = string.Empty;
                    }
                    helper.BatchInsert(dtCacheTable);
                    if (!CacheManager.CacheDictionary.ContainsKey(strTableName))
                    {
                        CacheManager.CacheDictionary.Add(strTableName, strTableName);
                    }
                }
            }
        }


        /// <summary>构造消息
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static Message MakeSendMessage(string input)
        {
            return new Message
            {
                Command = Command.Send,
                Content = input
            };
        }
        /// <summary>构造加入组的消息
        /// 
        /// </summary>
        /// <returns></returns>
        private static Message MakeJoinMessage()
        {
            string strContentName = Guid.NewGuid().ToString();
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
            if (interfaces.Length > 0)
            {
                strContentName = interfaces.First().Id;
            }
            //var message = new Message {Command = Command.Join, Content = Guid.NewGuid().ToString()}; 
            var message = new Message { Command = Command.Join, Content = strContentName };
            return message;
        }
        /// <summary>发送消息
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="message"></param>
        public static void SendMessage(IConnection connection, Message message)
        {
            var messageBytes = MessageConverter.ToBytes(message);
            connection.Send(new NetworkData { Buffer = messageBytes, Length = messageBytes.Length });
        }
    }
}
