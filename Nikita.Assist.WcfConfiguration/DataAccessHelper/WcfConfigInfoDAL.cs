using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace Nikita.Assist.WcfConfiguration.DAL
{
    /// <summary>WcfConfigInfo表数据访问类
    /// 作者:Luhm
    /// 创建时间:2016-01-02 21:51:08
    /// </summary>
    public partial class WcfConfigInfoDAL
    {
        public WcfConfigInfoDAL()
        { }
        /// <summary>增加一条数据
        /// 
        /// </summary>
        public int Add(Nikita.Assist.WcfConfiguration.Model.WcfConfigInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into WcfConfigInfo(");
            strSql.Append("WcfServiceName, WcfServiceClassName, WcfServiceInterfaceName, WcfServiceNameSpace, BseUrl, EnpointBindUrl, WcfType, Percentage, WcfGroup, Remark, State  )");
            strSql.Append(" values (");
            strSql.Append("@WcfServiceName, @WcfServiceClassName, @WcfServiceInterfaceName, @WcfServiceNameSpace, @BseUrl, @EnpointBindUrl, @WcfType, @Percentage, @WcfGroup, @Remark, @State  )");
            strSql.Append(";select @@IDENTITY");
            MSSQLHelper h = new MSSQLHelper(GlobalHelp.WcfConfigDbConnstr);
            h.CreateCommand(strSql.ToString());
            if (model.WcfServiceName == null)
            {
                 h.AddParameter("@WcfServiceName", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@WcfServiceName", model.WcfServiceName);
            }
            if (model.WcfServiceClassName == null)
            {
                 h.AddParameter("@WcfServiceClassName", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@WcfServiceClassName", model.WcfServiceClassName);
            }
            if (model.WcfServiceInterfaceName == null)
            {
                 h.AddParameter("@WcfServiceInterfaceName", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@WcfServiceInterfaceName", model.WcfServiceInterfaceName);
            }
            if (model.WcfServiceNameSpace == null)
            {
                 h.AddParameter("@WcfServiceNameSpace", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@WcfServiceNameSpace", model.WcfServiceNameSpace);
            }
            if (model.BseUrl == null)
            {
                 h.AddParameter("@BseUrl", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@BseUrl", model.BseUrl);
            }
            if (model.EnpointBindUrl == null)
            {
                 h.AddParameter("@EnpointBindUrl", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@EnpointBindUrl", model.EnpointBindUrl);
            }
            if (model.WcfType == null)
            {
                 h.AddParameter("@WcfType", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@WcfType", model.WcfType);
            }
            if (model.Percentage == null)
            {
                 h.AddParameter("@Percentage", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@Percentage", model.Percentage);
            }
            if (model.WcfGroup == null)
            {
                 h.AddParameter("@WcfGroup", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@WcfGroup", model.WcfGroup);
            }
            if (model.Remark == null)
            {
                 h.AddParameter("@Remark", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@Remark", model.Remark);
            }
            if (model.State == null)
            {
                 h.AddParameter("@State", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@State", model.State);
            }

            int result;
            string obj = h.ExecuteScalar();
            if (!int.TryParse(obj, out result))
            {
                return 0;
            }
            return result;
        }

        /// <summary>更新一条数据
        /// 
        /// </summary>
        public bool Update(Nikita.Assist.WcfConfiguration.Model.WcfConfigInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update WcfConfigInfo set ");
            strSql.Append("WcfServiceName=@WcfServiceName, WcfServiceClassName=@WcfServiceClassName, WcfServiceInterfaceName=@WcfServiceInterfaceName, WcfServiceNameSpace=@WcfServiceNameSpace, BseUrl=@BseUrl, EnpointBindUrl=@EnpointBindUrl, WcfType=@WcfType, Percentage=@Percentage, WcfGroup=@WcfGroup, Remark=@Remark, State=@State  ");
            strSql.Append(" where id=@id ");
            MSSQLHelper h = new MSSQLHelper(GlobalHelp.WcfConfigDbConnstr);
            h.CreateCommand(strSql.ToString());
            if (model.id == null)
            {
                 h.AddParameter("@id", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@id", model.id);
            }
            if (model.WcfServiceName == null)
            {
                 h.AddParameter("@WcfServiceName", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@WcfServiceName", model.WcfServiceName);
            }
            if (model.WcfServiceClassName == null)
            {
                 h.AddParameter("@WcfServiceClassName", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@WcfServiceClassName", model.WcfServiceClassName);
            }
            if (model.WcfServiceInterfaceName == null)
            {
                 h.AddParameter("@WcfServiceInterfaceName", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@WcfServiceInterfaceName", model.WcfServiceInterfaceName);
            }
            if (model.WcfServiceNameSpace == null)
            {
                 h.AddParameter("@WcfServiceNameSpace", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@WcfServiceNameSpace", model.WcfServiceNameSpace);
            }
            if (model.BseUrl == null)
            {
                 h.AddParameter("@BseUrl", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@BseUrl", model.BseUrl);
            }
            if (model.EnpointBindUrl == null)
            {
                 h.AddParameter("@EnpointBindUrl", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@EnpointBindUrl", model.EnpointBindUrl);
            }
            if (model.WcfType == null)
            {
                 h.AddParameter("@WcfType", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@WcfType", model.WcfType);
            }
            if (model.Percentage == null)
            {
                 h.AddParameter("@Percentage", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@Percentage", model.Percentage);
            }
            if (model.WcfGroup == null)
            {
                 h.AddParameter("@WcfGroup", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@WcfGroup", model.WcfGroup);
            }
            if (model.Remark == null)
            {
                 h.AddParameter("@Remark", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@Remark", model.Remark);
            }
            if (model.State == null)
            {
                 h.AddParameter("@State", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@State", model.State);
            }

            return h.ExecuteNonQuery();
        }

        /// <summary>删除一条数据
        /// 
        /// </summary>
        public bool Delete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from WcfConfigInfo ");
            strSql.Append(" where id=@id ");
            MSSQLHelper h = new MSSQLHelper(GlobalHelp.WcfConfigDbConnstr);
            h.CreateCommand(strSql.ToString());
            h.AddParameter("@id", id);
            return h.ExecuteNonQuery();
        }

        /// <summary>根据条件删除数据
        /// 
        /// </summary>
        public bool DeleteByCond(string cond)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from WcfConfigInfo ");
            if (!string.IsNullOrEmpty(cond))
            {
                strSql.Append(" where " + cond);
            }
            MSSQLHelper h = new MSSQLHelper(GlobalHelp.WcfConfigDbConnstr);
            h.CreateCommand(strSql.ToString());
            return h.ExecuteNonQuery();
        }

        /// <summary>得到一个对象实体
        /// 
        /// </summary>
        public Nikita.Assist.WcfConfiguration.Model.WcfConfigInfo GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from WcfConfigInfo ");
            strSql.Append(" where id=@id ");
            MSSQLHelper h = new MSSQLHelper(GlobalHelp.WcfConfigDbConnstr);
            h.CreateCommand(strSql.ToString());
            h.AddParameter("@id", id);
            Nikita.Assist.WcfConfiguration.Model.WcfConfigInfo model = null;
            using (IDataReader dataReader = h.ExecuteReader())
            {
                if (dataReader.Read())
                {
                    model = ReaderBind(dataReader);
                }
                h.CloseConn();
            }
            return model;
        }

        /// <summary>根据条件得到一个对象实体
        /// 
        /// </summary>
        public Nikita.Assist.WcfConfiguration.Model.WcfConfigInfo GetModelByCond(string cond)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from WcfConfigInfo ");
            if (!string.IsNullOrEmpty(cond))
            {
                strSql.Append(" where " + cond);
            }
            MSSQLHelper h = new MSSQLHelper(GlobalHelp.WcfConfigDbConnstr);
            h.CreateCommand(strSql.ToString());
            Nikita.Assist.WcfConfiguration.Model.WcfConfigInfo model = null;
            using (IDataReader dataReader = h.ExecuteReader())
            {
                if (dataReader.Read())
                {
                    model = ReaderBind(dataReader);
                }
                h.CloseConn();
            }
            return model;
        }

        /// <summary>获得数据列表
        /// 
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM WcfConfigInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            MSSQLHelper h = new MSSQLHelper(GlobalHelp.WcfConfigDbConnstr);
            h.CreateCommand(strSql.ToString());
            DataTable dt = h.ExecuteQuery();
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            return ds;
        }

		
        /// <summary>获得数据列表
        /// 
        /// </summary>
        public DataSet GetList(string strWhere, string Filds)
        {
            StringBuilder strSql = new StringBuilder(); 
			  strSql.Append("select " + Filds + " ");
            strSql.Append(" FROM WcfConfigInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            MSSQLHelper h = new MSSQLHelper(GlobalHelp.WcfConfigDbConnstr);
            h.CreateCommand(strSql.ToString());
            DataTable dt = h.ExecuteQuery();
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            return ds;
        }


        /// <summary>分页获取数据列表
        /// 
        /// </summary>
        public DataSet GetList(string fileds, string order, string ordertype, int PageSize, int PageIndex, string strWhere)
        {
            MSSQLHelper h = new MSSQLHelper(GlobalHelp.WcfConfigDbConnstr);
            h.CreateStoredCommand("[proc_SplitPage]");
            h.AddParameter("@tblName", "WcfConfigInfo");
            h.AddParameter("@strFields", fileds);
            h.AddParameter("@strOrder", order);
            h.AddParameter("@strOrderType", ordertype);
            h.AddParameter("@PageSize", PageSize);
            h.AddParameter("@PageIndex", PageIndex);
            h.AddParameter("@strWhere", strWhere);
            DataTable dt = h.ExecuteQuery();
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            return ds;
        }

        /// <summary>获得数据列表（比DataSet效率高，推荐使用）
        /// 
        /// </summary>
        public List<Nikita.Assist.WcfConfiguration.Model.WcfConfigInfo> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM WcfConfigInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            } 
            strSql.Append(" order by WcfGroup ");
            List<Nikita.Assist.WcfConfiguration.Model.WcfConfigInfo> list = new List<Nikita.Assist.WcfConfiguration.Model.WcfConfigInfo>();
            MSSQLHelper h = new MSSQLHelper(GlobalHelp.WcfConfigDbConnstr);
            h.CreateCommand(strSql.ToString());
            using (IDataReader dataReader = h.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    list.Add(ReaderBind(dataReader));
                }
                h.CloseConn();
            }
            return list;
        }

        /// <summary>分页获取数据列表
        /// 
        /// </summary>
        public List<Nikita.Assist.WcfConfiguration.Model.WcfConfigInfo> GetListArray(string fileds, string order, string ordertype, int PageSize, int PageIndex, string strWhere)
        {
            MSSQLHelper h = new MSSQLHelper(GlobalHelp.WcfConfigDbConnstr);
            h.CreateStoredCommand("[proc_SplitPage]");
            h.AddParameter("@tblName", "WcfConfigInfo");
            h.AddParameter("@strFields", fileds);
            h.AddParameter("@strOrder", order);
            h.AddParameter("@strOrderType", ordertype);
            h.AddParameter("@PageSize", PageSize);
            h.AddParameter("@PageIndex", PageIndex);
            h.AddParameter("@strWhere", strWhere);
            List<Nikita.Assist.WcfConfiguration.Model.WcfConfigInfo> list = new List<Nikita.Assist.WcfConfiguration.Model.WcfConfigInfo>();
            using (IDataReader dataReader = h.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    list.Add(ReaderBind(dataReader));
                }
                h.CloseConn();
            }
            return list;
        }

        /// <summary>对象实体绑定数据
        /// 
        /// </summary>
        public Nikita.Assist.WcfConfiguration.Model.WcfConfigInfo ReaderBind(IDataReader dataReader)
        {
            Nikita.Assist.WcfConfiguration.Model.WcfConfigInfo model = new Nikita.Assist.WcfConfiguration.Model.WcfConfigInfo();
            object ojb;
            ojb = dataReader["id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.id = int.Parse(ojb.ToString());
            }
            model.WcfServiceName = dataReader["WcfServiceName"].ToString();
            model.WcfServiceClassName = dataReader["WcfServiceClassName"].ToString();
            model.WcfServiceInterfaceName = dataReader["WcfServiceInterfaceName"].ToString();
            model.WcfServiceNameSpace = dataReader["WcfServiceNameSpace"].ToString();
            model.BseUrl = dataReader["BseUrl"].ToString();
            model.EnpointBindUrl = dataReader["EnpointBindUrl"].ToString();
            model.WcfType = dataReader["WcfType"].ToString();
            ojb = dataReader["Percentage"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Percentage = int.Parse(ojb.ToString());
            }
            ojb = dataReader["WcfGroup"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.WcfGroup = int.Parse(ojb.ToString());
            }
            model.Remark = dataReader["Remark"].ToString();
            ojb = dataReader["State"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.State = int.Parse(ojb.ToString());
            }

            return model;
        }

        /// <summary>计算记录数
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public int CalcCount(string cond)
        {
            string sql = "select count(1) from WcfConfigInfo";
            if (!string.IsNullOrEmpty(cond))
            {
                sql += " where " + cond;
            }
            MSSQLHelper h = new MSSQLHelper(GlobalHelp.WcfConfigDbConnstr);
            h.CreateCommand(sql);
            return int.Parse(h.ExecuteScalar());
        }
    }
}

