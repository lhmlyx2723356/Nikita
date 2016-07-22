using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Nikita.Assist.CodeMaker.CodeMakerDemoForm;

namespace Nikita.Assist.CodeMaker.DAL
{
    /// <summary>TreeListDemo表数据访问类
    /// 作者:Luhm
    /// 创建时间:2016-05-07 19:27:54
    /// </summary>
    public partial class TreeListDemoDAL
    {
        public TreeListDemoDAL()
        { }
        /// <summary>增加一条数据
        /// 
        /// </summary>
        public int Add(Nikita.Assist.CodeMaker.Model.TreeListDemo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TreeListDemo(");
            strSql.Append("ParentId, Name, Value, OnLevel, OwerCompanyId, Status, Remark, Dept_Id, Company_Id, CreateUser, CreateDate, EditUser, EditDate  )");
            strSql.Append(" values (");
            strSql.Append("@ParentId, @Name, @Value, @OnLevel, @OwerCompanyId, @Status, @Remark, @Dept_Id, @Company_Id, @CreateUser, @CreateDate, @EditUser, @EditDate  )");
            strSql.Append(";select @@IDENTITY");
            DataAccess4DBHelper.IDbHelper h = GlobalHelpDemoForm.GetDataAccessHelperDemo();
            h.CreateCommand(strSql.ToString());
            if (model.ParentId == null)
            {
                 h.AddParameter("@ParentId", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@ParentId", model.ParentId);
            }
            if (model.Name == null)
            {
                 h.AddParameter("@Name", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@Name", model.Name);
            }
            if (model.Value == null)
            {
                 h.AddParameter("@Value", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@Value", model.Value);
            }
            if (model.OnLevel == null)
            {
                 h.AddParameter("@OnLevel", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@OnLevel", model.OnLevel);
            }
            if (model.OwerCompanyId == null)
            {
                 h.AddParameter("@OwerCompanyId", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@OwerCompanyId", model.OwerCompanyId);
            }
            if (model.Status == null)
            {
                 h.AddParameter("@Status", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@Status", model.Status);
            }
            if (model.Remark == null)
            {
                 h.AddParameter("@Remark", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@Remark", model.Remark);
            }
            if (model.Dept_Id == null)
            {
                 h.AddParameter("@Dept_Id", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@Dept_Id", model.Dept_Id);
            }
            if (model.Company_Id == null)
            {
                 h.AddParameter("@Company_Id", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@Company_Id", model.Company_Id);
            }
            if (model.CreateUser == null)
            {
                 h.AddParameter("@CreateUser", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@CreateUser", model.CreateUser);
            }
            if (model.CreateDate == null)
            {
                 h.AddParameter("@CreateDate", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@CreateDate", model.CreateDate);
            }
            if (model.EditUser == null)
            {
                 h.AddParameter("@EditUser", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@EditUser", model.EditUser);
            }
            if (model.EditDate == null)
            {
                 h.AddParameter("@EditDate", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@EditDate", model.EditDate);
            }

            int intResult;
            string obj = h.ExecuteScalar();
            if (!int.TryParse(obj, out intResult))
            {
                return 0;
            }
            return   intResult;
        }

        /// <summary>更新一条数据
        /// 
        /// </summary>
        public bool Update(Nikita.Assist.CodeMaker.Model.TreeListDemo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TreeListDemo set ");
            strSql.Append("ParentId=@ParentId, Name=@Name, Value=@Value, OnLevel=@OnLevel, OwerCompanyId=@OwerCompanyId, Status=@Status, Remark=@Remark, Dept_Id=@Dept_Id, Company_Id=@Company_Id, CreateUser=@CreateUser, CreateDate=@CreateDate, EditUser=@EditUser, EditDate=@EditDate  ");
            strSql.Append(" where Id=@Id ");
            DataAccess4DBHelper.IDbHelper h = GlobalHelpDemoForm.GetDataAccessHelperDemo();
            h.CreateCommand(strSql.ToString());
            if (model.Id == null)
            {
                 h.AddParameter("@Id", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@Id", model.Id);
            }
            if (model.ParentId == null)
            {
                 h.AddParameter("@ParentId", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@ParentId", model.ParentId);
            }
            if (model.Name == null)
            {
                 h.AddParameter("@Name", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@Name", model.Name);
            }
            if (model.Value == null)
            {
                 h.AddParameter("@Value", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@Value", model.Value);
            }
            if (model.OnLevel == null)
            {
                 h.AddParameter("@OnLevel", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@OnLevel", model.OnLevel);
            }
            if (model.OwerCompanyId == null)
            {
                 h.AddParameter("@OwerCompanyId", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@OwerCompanyId", model.OwerCompanyId);
            }
            if (model.Status == null)
            {
                 h.AddParameter("@Status", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@Status", model.Status);
            }
            if (model.Remark == null)
            {
                 h.AddParameter("@Remark", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@Remark", model.Remark);
            }
            if (model.Dept_Id == null)
            {
                 h.AddParameter("@Dept_Id", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@Dept_Id", model.Dept_Id);
            }
            if (model.Company_Id == null)
            {
                 h.AddParameter("@Company_Id", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@Company_Id", model.Company_Id);
            }
            if (model.CreateUser == null)
            {
                 h.AddParameter("@CreateUser", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@CreateUser", model.CreateUser);
            }
            if (model.CreateDate == null)
            {
                 h.AddParameter("@CreateDate", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@CreateDate", model.CreateDate);
            }
            if (model.EditUser == null)
            {
                 h.AddParameter("@EditUser", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@EditUser", model.EditUser);
            }
            if (model.EditDate == null)
            {
                 h.AddParameter("@EditDate", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@EditDate", model.EditDate);
            }

            return h.ExecuteNonQuery();
        }

        /// <summary>根据条件更新字段
        /// 
        /// </summary>
        public bool Update(string strFieldWithValue,string strCond)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TreeListDemo set ");
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
        public bool Delete(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TreeListDemo ");
            strSql.Append(" where Id=@Id ");
            DataAccess4DBHelper.IDbHelper h = GlobalHelpDemoForm.GetDataAccessHelperDemo();
            h.CreateCommand(strSql.ToString());
            h.AddParameter("@Id", Id);
            return h.ExecuteNonQuery();
        }

        /// <summary>根据条件删除数据
        /// 
        /// </summary>
        public bool DeleteByCond(string cond)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TreeListDemo ");
            if (!string.IsNullOrEmpty(cond))
            {
                strSql.Append(" where " + cond);
            }
            DataAccess4DBHelper.IDbHelper h = GlobalHelpDemoForm.GetDataAccessHelperDemo();
            h.CreateCommand(strSql.ToString());
            return h.ExecuteNonQuery();
        }

        /// <summary>得到一个对象实体
        /// 
        /// </summary>
        public Nikita.Assist.CodeMaker.Model.TreeListDemo GetModel(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from TreeListDemo ");
            strSql.Append(" where Id=@Id ");
            DataAccess4DBHelper.IDbHelper h = GlobalHelpDemoForm.GetDataAccessHelperDemo();
            h.CreateCommand(strSql.ToString());
            h.AddParameter("@Id", Id);
            Nikita.Assist.CodeMaker.Model.TreeListDemo model = null;
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
        public Nikita.Assist.CodeMaker.Model.TreeListDemo GetModelByCond(string strCond)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from TreeListDemo ");
            if (!string.IsNullOrEmpty(strCond))
            {
                strSql.Append(" where " + strCond);
            }
            DataAccess4DBHelper.IDbHelper h = GlobalHelpDemoForm.GetDataAccessHelperDemo();
            h.CreateCommand(strSql.ToString());
            Nikita.Assist.CodeMaker.Model.TreeListDemo model = null;
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
            strSql.Append(" FROM TreeListDemo ");
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

		
        /// <summary>获得数据列表
        /// 
        /// </summary>
        public DataSet GetList(string strWhere, string strFields)
        {
            StringBuilder strSql = new StringBuilder(); 
			  strSql.Append("select " +strFields + " ");
            strSql.Append(" FROM TreeListDemo ");
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
        public DataSet GetList(string strFileds, string strOrder, string strOrderType, int intPageSize, int intPageIndex, string strWhere)
        {
            DataAccess4DBHelper.IDbHelper h = GlobalHelpDemoForm.GetDataAccessHelperDemo();
            h.CreateStoredCommand("[proc_SplitPage]");
            h.AddParameter("@tblName", "TreeListDemo");
            h.AddParameter("@strFields",strFileds);
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
        public List<Nikita.Assist.CodeMaker.Model.TreeListDemo> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM TreeListDemo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<Nikita.Assist.CodeMaker.Model.TreeListDemo> list = new List<Nikita.Assist.CodeMaker.Model.TreeListDemo>();
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
        public List<Nikita.Assist.CodeMaker.Model.TreeListDemo> GetListArray(string strFileds, string strOrder, string strOrderType, int intPageSize, int intPageIndex, string strWhere)
        {
            DataAccess4DBHelper.IDbHelper h = GlobalHelpDemoForm.GetDataAccessHelperDemo();
            h.CreateStoredCommand("[proc_SplitPage]");
            h.AddParameter("@tblName", "TreeListDemo");
            h.AddParameter("@strFields", strFileds);
            h.AddParameter("@strOrder", strOrder);
            h.AddParameter("@strOrderType", strOrderType);
            h.AddParameter("@PageSize", intPageSize);
            h.AddParameter("@PageIndex", intPageIndex);
            h.AddParameter("@strWhere", strWhere);
            List<Nikita.Assist.CodeMaker.Model.TreeListDemo> list = new List<Nikita.Assist.CodeMaker.Model.TreeListDemo>();
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
        public Nikita.Assist.CodeMaker.Model.TreeListDemo ReaderBind(IDataReader dataReader)
        {
            Nikita.Assist.CodeMaker.Model.TreeListDemo model = new Nikita.Assist.CodeMaker.Model.TreeListDemo();
            object ojb;
            ojb = dataReader["Id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Id = int.Parse(ojb.ToString());
            }
            ojb = dataReader["ParentId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ParentId = int.Parse(ojb.ToString());
            }
            model.Name = dataReader["Name"].ToString();
            model.Value = dataReader["Value"].ToString();
            ojb = dataReader["OnLevel"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.OnLevel = int.Parse(ojb.ToString());
            }
            ojb = dataReader["OwerCompanyId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.OwerCompanyId = int.Parse(ojb.ToString());
            }
            ojb = dataReader["Status"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Status = bool.Parse(ojb.ToString());
            }
            model.Remark = dataReader["Remark"].ToString();
            ojb = dataReader["Dept_Id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Dept_Id = int.Parse(ojb.ToString());
            }
            ojb = dataReader["Company_Id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Company_Id = int.Parse(ojb.ToString());
            }
            model.CreateUser = dataReader["CreateUser"].ToString();
            ojb = dataReader["CreateDate"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.CreateDate = DateTime.Parse(ojb.ToString());
            }
            model.EditUser = dataReader["EditUser"].ToString();
            ojb = dataReader["EditDate"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.EditDate = DateTime.Parse(ojb.ToString());
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
            string sql = "select count(1) from TreeListDemo";
            if (!string.IsNullOrEmpty(cond))
            {
                sql += " where " + cond;
            }
            DataAccess4DBHelper.IDbHelper h = GlobalHelpDemoForm.GetDataAccessHelperDemo();
            h.CreateCommand(sql);
            return int.Parse(h.ExecuteScalar());
        }
    }
}

