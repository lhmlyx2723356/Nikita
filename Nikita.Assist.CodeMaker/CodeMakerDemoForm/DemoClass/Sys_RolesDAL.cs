using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Nikita.Assist.CodeMaker.CodeMakerDemoForm;

namespace Nikita.Assist.CodeMaker.DAL
{
    /// <summary>Sys_Roles表数据访问类
    /// 作者:Luhm
    /// 创建时间:2016-04-24 20:16:31
    /// </summary>
    public partial class Sys_RolesDAL
    {
        public Sys_RolesDAL()
        { }
        /// <summary>增加一条数据
        /// 
        /// </summary>
        /// <param name="model">实体对象</param> 
        /// <returns>返回新增实体ID</returns>
        public int Add(Nikita.Assist.CodeMaker.Model.Sys_Roles model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_Roles(");
            strSql.Append("RoleName, Sortnum, Remark, isDefault  )");
            strSql.Append(" values (");
            strSql.Append("@RoleName, @Sortnum, @Remark, @isDefault  )");
            strSql.Append(";select @@IDENTITY");
            DataAccess4DBHelper.IDbHelper h = GlobalHelpDemoForm.GetDataAccessHelperDemo();
            h.CreateCommand(strSql.ToString());
            if (model.RoleName == null)
            {
                 h.AddParameter("@RoleName", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@RoleName", model.RoleName);
            }
            if (model.Sortnum == null)
            {
                 h.AddParameter("@Sortnum", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@Sortnum", model.Sortnum);
            }
            if (model.Remark == null)
            {
                 h.AddParameter("@Remark", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@Remark", model.Remark);
            }
            if (model.isDefault == null)
            {
                 h.AddParameter("@isDefault", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@isDefault", model.isDefault);
            }

            int intResult;
            string strObj = h.ExecuteScalar();
            if (!int.TryParse(strObj, out intResult))
            {
                return 0;
            }
            return intResult;
        }

        /// <summary>更新一条数据
        /// 
        /// </summary>
        /// <param name="model">实体对象</param> 
        /// <returns>返回受影响的行数</returns>
        public bool Update(Nikita.Assist.CodeMaker.Model.Sys_Roles model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_Roles set ");
            strSql.Append("RoleName=@RoleName, Sortnum=@Sortnum, Remark=@Remark, isDefault=@isDefault  ");
            strSql.Append(" where KeyId=@KeyId ");
            DataAccess4DBHelper.IDbHelper h = GlobalHelpDemoForm.GetDataAccessHelperDemo();
            h.CreateCommand(strSql.ToString());
            if (model.KeyId == null)
            {
                 h.AddParameter("@KeyId", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@KeyId", model.KeyId);
            }
            if (model.RoleName == null)
            {
                 h.AddParameter("@RoleName", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@RoleName", model.RoleName);
            }
            if (model.Sortnum == null)
            {
                 h.AddParameter("@Sortnum", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@Sortnum", model.Sortnum);
            }
            if (model.Remark == null)
            {
                 h.AddParameter("@Remark", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@Remark", model.Remark);
            }
            if (model.isDefault == null)
            {
                 h.AddParameter("@isDefault", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@isDefault", model.isDefault);
            }

            return h.ExecuteNonQuery();
        }

             /// <summary>更新一一个字段
        /// 
        /// </summary>
        public bool Update(string strFieldWithValue,string strCond)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update  Sys_Roles  set ");
            strSql.Append(strFieldWithValue);
            if (!string.IsNullOrEmpty(strCond))
            {
                strSql.Append(" where " + strCond );
            }
            DataAccess4DBHelper.IDbHelper h = GlobalHelpDemoForm.GetDataAccessHelperDemo();
            h.CreateCommand(strSql.ToString()); 
            return h.ExecuteNonQuery();
        }

        /// <summary>删除一条数据
        /// 
        /// </summary> 
        /// <param name="KeyId">主键ID</param> 
        /// <returns>返回受影响的行数</returns>
        public bool Delete(int KeyId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_Roles ");
            strSql.Append(" where KeyId=@KeyId ");
            DataAccess4DBHelper.IDbHelper h = GlobalHelpDemoForm.GetDataAccessHelperDemo();
            h.CreateCommand(strSql.ToString());
            h.AddParameter("@KeyId", KeyId);
            return h.ExecuteNonQuery();
        }

        /// <summary>根据条件删除数据
        /// 
        /// </summary>
        /// <param name="strCond">条件</param> 
        /// <returns>返回受影响的行数</returns>
        public bool DeleteByCond(string strCond)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_Roles ");
            if (!string.IsNullOrEmpty(strCond))
            {
                strSql.Append(" where " + strCond);
            }
            DataAccess4DBHelper.IDbHelper h = GlobalHelpDemoForm.GetDataAccessHelperDemo();
            h.CreateCommand(strSql.ToString());
            return h.ExecuteNonQuery();
        }

        /// <summary>得到一个对象实体
        /// 
        /// </summary>
        /// <param name="KeyId">主键</param> 
        /// <returns>返回对象实体</returns>
        public Nikita.Assist.CodeMaker.Model.Sys_Roles GetModel(int KeyId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Sys_Roles ");
            strSql.Append(" where KeyId=@KeyId ");
            DataAccess4DBHelper.IDbHelper h = GlobalHelpDemoForm.GetDataAccessHelperDemo();
            h.CreateCommand(strSql.ToString());
            h.AddParameter("@KeyId", KeyId);
            Nikita.Assist.CodeMaker.Model.Sys_Roles model = null;
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
        /// <param name="strCond">条件</param> 
        /// <returns>返回对象实体</returns>
        public Nikita.Assist.CodeMaker.Model.Sys_Roles GetModelByCond(string strCond)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from Sys_Roles ");
            if (!string.IsNullOrEmpty(strCond))
            {
                strSql.Append(" where " + strCond);
            }
            DataAccess4DBHelper.IDbHelper h = GlobalHelpDemoForm.GetDataAccessHelperDemo();
            h.CreateCommand(strSql.ToString());
            Nikita.Assist.CodeMaker.Model.Sys_Roles model = null;
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
        /// <param name="strWhere">条件</param> 
        /// <returns>返回符合条件的DataSet数据集</returns>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM Sys_Roles ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataAccess4DBHelper.IDbHelper h = GlobalHelpDemoForm.GetDataAccessHelperDemo();
            h.CreateCommand(strSql.ToString());
            DataTable dt = h.ExecuteQuery();
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            return ds;
        }

		
        /// <summary>获得指定字段的数据列表(字段间用逗号隔开)
        /// 
        /// </summary>
        /// <param name="strWhere">条件</param> 
        /// <param name="strFields">字段</param> 
        /// <returns>返回符合条件的DataSet数据集</returns>
        public DataSet GetList(string strWhere, string strFields)
        {
            StringBuilder strSql = new StringBuilder(); 
			  strSql.Append("select " + strFields + " ");
            strSql.Append(" FROM Sys_Roles ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataAccess4DBHelper.IDbHelper h = GlobalHelpDemoForm.GetDataAccessHelperDemo();
            h.CreateCommand(strSql.ToString());
            DataTable dt = h.ExecuteQuery();
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            return ds;
        }


        /// <summary>分页获取数据列表
        /// 
        /// </summary>
        /// <param name="strFields">字段</param> 
        /// <param name="strOrder">排序</param> 
        /// <param name="strOrderType">排序类型</param> 
        /// <param name="intPageSize">每页大小</param> 
        /// <param name="intPageIndex">当前第N页</param> 
        /// <param name="strWhere">条件</param> 
        /// <returns>返回符合条件的DataSet数据集</returns>
        public DataSet GetList(string strFields, string strOrder, string strOrderType, int intPageSize, int intPageIndex, string strWhere)
        {
            DataAccess4DBHelper.IDbHelper h = GlobalHelpDemoForm.GetDataAccessHelperDemo();
            h.CreateStoredCommand("[proc_SplitPage]");
            h.AddParameter("@tblName", "Sys_Roles");
            h.AddParameter("@strFields", strFields);
            h.AddParameter("@strOrder", strOrder);
            h.AddParameter("@strOrderType", strOrderType);
            h.AddParameter("@PageSize", intPageSize);
            h.AddParameter("@PageIndex", intPageIndex);
            h.AddParameter("@strWhere", strWhere);
            DataTable dt = h.ExecuteQuery();
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            return ds;
        }

        /// <summary>获得数据列表（比DataSet效率高，推荐使用）
        /// 
        /// </summary>
        /// <param name="strWhere">条件</param> 
        /// <returns>返回符合条件的对象集合</returns>
        public List<Nikita.Assist.CodeMaker.Model.Sys_Roles> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM Sys_Roles ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<Nikita.Assist.CodeMaker.Model.Sys_Roles> list = new List<Nikita.Assist.CodeMaker.Model.Sys_Roles>();
            DataAccess4DBHelper.IDbHelper h = GlobalHelpDemoForm.GetDataAccessHelperDemo();
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
        /// <param name="strFields">字段</param> 
        /// <param name="strOrder">排序</param> 
        /// <param name="strOrderType">排序类型</param> 
        /// <param name="intPageSize">每页大小</param> 
        /// <param name="intPageIndex">当前第N页</param> 
        /// <param name="strWhere">条件</param> 
        /// <returns>返回符合条件的对象集合</returns>
        public List<Nikita.Assist.CodeMaker.Model.Sys_Roles> GetListArray(string strFields, string strOrder, string strOrderType, int intPageSize, int intPageIndex, string strWhere)
        {
            DataAccess4DBHelper.IDbHelper h = GlobalHelpDemoForm.GetDataAccessHelperDemo();
            h.CreateStoredCommand("[proc_SplitPage]");
            h.AddParameter("@tblName", "Sys_Roles");
            h.AddParameter("@strFields", strFields);
            h.AddParameter("@strOrder", strOrder);
            h.AddParameter("@strOrderType", strOrderType);
            h.AddParameter("@PageSize", intPageSize);
            h.AddParameter("@PageIndex", intPageIndex);
            h.AddParameter("@strWhere", strWhere);
            List<Nikita.Assist.CodeMaker.Model.Sys_Roles> list = new List<Nikita.Assist.CodeMaker.Model.Sys_Roles>();
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
        /// <param name="dataReader">IDataReader对象</param> 
        /// <returns>返回实体对象</returns>
        public Nikita.Assist.CodeMaker.Model.Sys_Roles ReaderBind(IDataReader dataReader)
        {
            Nikita.Assist.CodeMaker.Model.Sys_Roles model = new Nikita.Assist.CodeMaker.Model.Sys_Roles();
            object ojb;
            ojb = dataReader["KeyId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.KeyId = int.Parse(ojb.ToString());
            }
            model.RoleName = dataReader["RoleName"].ToString();
            ojb = dataReader["Sortnum"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Sortnum = int.Parse(ojb.ToString());
            }
            model.Remark = dataReader["Remark"].ToString();
            ojb = dataReader["isDefault"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.isDefault = int.Parse(ojb.ToString());
            }

            return model;
        }

        /// <summary>计算记录数
        /// 
        /// </summary>
        /// <param name="strCond">条件</param>
        /// <returns>总数量</returns>
        public int CalcCount(string strCond)
        {
            string strSql = "select count(1) from Sys_Roles";
            if (!string.IsNullOrEmpty(strCond))
            {
                strSql += " where " + strCond;
            }
            DataAccess4DBHelper.IDbHelper h = GlobalHelpDemoForm.GetDataAccessHelperDemo();
            h.CreateCommand(strSql);
            return int.Parse(h.ExecuteScalar());
        }
    }
}

