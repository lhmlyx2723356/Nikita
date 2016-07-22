using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver; 

namespace Nikita.NoSQL.MongoDBCore
{
    public class MonogoDBHelper
    {
        /// <summary>
        /// 连接字符串
        /// </summary>
        private readonly string _connectionString = "mongodb://192.168.1.108:27017/ck_test_db";

        private const string DbName = "ck_test_db";
        private readonly MongoClient _client = null;

        public MonogoDBHelper()
        {
            if (_client == null)
            {
                _client = new MongoClient(_connectionString);
            }
        }

        public IMongoDatabase GetDataBase()
        {

            IMongoDatabase dbCollectiong = _client.GetDatabase(DbName);
            return dbCollectiong;

        }

        public IMongoCollection<BsonDocument> GetCollection()
        {

            IMongoDatabase dbCollectiong = _client.GetDatabase(DbName);
            IMongoCollection<BsonDocument> collection = dbCollectiong.GetCollection<BsonDocument>("blog");

            return collection;
        }

        public void InsertOne()
        {
            IMongoDatabase dbCollectiong = _client.GetDatabase(DbName);
            IMongoCollection<BsonDocument> collection = dbCollectiong.GetCollection<BsonDocument>("blog");
            BsonDocument docNew = new BsonDocument();
            docNew.Add("_id", "100");
            docNew.Add("title", "test");
            docNew.Add("content", "test");
            docNew.Add("date", new BsonDateTime(DateTime.Now));
            docNew.Add("comments", string.Empty);
            collection.InsertOneAsync(docNew);

        }
        public void InsertMany()
        {
            IMongoDatabase dbCollectiong = _client.GetDatabase(DbName);
            IMongoCollection<BsonDocument> collection = dbCollectiong.GetCollection<BsonDocument>("blog");

            List<BsonDocument> lst = new List<BsonDocument>();
            for (int i = 0; i < 10; i++)
            {
                BsonDocument docNew = new BsonDocument();
                docNew.Add("title", "test" + i);
                docNew.Add("content", "test" + i);
                docNew.Add("date", new BsonDateTime(DateTime.Now));
                docNew.Add("comments", i);
                lst.Add(docNew);
            } 
              collection.InsertManyAsync(lst);

        }

        public void ReplaceOne()
        {
            IMongoDatabase dbCollectiong = _client.GetDatabase(DbName);
            IMongoCollection<BsonDocument> collection = dbCollectiong.GetCollection<BsonDocument>("blog");
             
            BsonDocument docNew = new BsonDocument
            { 
                {"_id", "100"},//把ID传入后更新不了
                {"title", "哈哈哈"},
                {"content", "test"},
                {"date", new BsonDateTime(DateTime.Now)},
                {"comments", string.Empty}
            };
            var result =   collection.FindOneAndReplaceAsync(
                filter: new BsonDocument("title", "test9"),
                replacement: docNew);
        }

        public void UpdateOne()
        {
            IMongoDatabase dbCollectiong = _client.GetDatabase(DbName);
            IMongoCollection<BsonDocument> collection = dbCollectiong.GetCollection<BsonDocument>("blog");


            var filter = new BsonDocument
            {  
                {"title", "test8"} 
            };
            var update = new BsonDocument("$set", new BsonDocument("title", "哈哈哈8"));
            var result =   collection.UpdateOneAsync(filter, update);
        }


        public void Delete()
        {
            IMongoDatabase dbCollectiong = _client.GetDatabase(DbName);
            IMongoCollection<BsonDocument> collection = dbCollectiong.GetCollection<BsonDocument>("blog");

            var filter = new BsonDocument
            {
                {"_id", "100"}, 
            };
            var result = collection.DeleteOneAsync(
                filter );
        }
    }

    [Serializable]
    class bolg
    {
        public string title { set; get; }
        public string content { set; get; }
        public string date { set; get; }
        public string comments { set; get; }
    }
}
