using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Nikita.Base.DbSchemaReader.DataSchema;
using Nikita.Assist.CodeMaker.CodeMakerDemoForm;
using Nikita.DataAccess4DBHelper;

namespace Nikita.Assist.CodeMaker.DAL
{
    /// <summary>Bse_User表数据访问类
    /// 作者:Luhm
    /// 创建时间:2016-01-31 19:08:26
    /// </summary>
    public partial class Bse_UserDAL
    {
        public Bse_UserDAL()
        { }
        /// <summary>增加一条数据
        /// 
        /// </summary>
        /// <param name="model">实体对象</param> 
        /// <returns>返回新增实体ID</returns>
        public int Add(Nikita.Assist.CodeMaker.Model.Bse_User model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Bse_User(");
            strSql.Append("UserName, Password, TrueName, Company, CreateDate, State  )");
            strSql.Append(" values (");
            strSql.Append("@UserName, @Password, @TrueName, @Company, @CreateDate, @State  )");
            strSql.Append(";select @@IDENTITY");
            DataAccess4DBHelper.IDbHelper h = GlobalHelpDemoForm.GetDataAccessHelper();
            h.CreateCommand(strSql.ToString());
            if (model.UserName == null)
            {
                h.AddParameter("@UserName", DBNull.Value);
            }
            else
            {
                h.AddParameter("@UserName", model.UserName);
            }
            if (model.Password == null)
            {
                h.AddParameter("@Password", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Password", model.Password);
            }
            if (model.TrueName == null)
            {
                h.AddParameter("@TrueName", DBNull.Value);
            }
            else
            {
                h.AddParameter("@TrueName", model.TrueName);
            }
            if (model.Company == null)
            {
                h.AddParameter("@Company", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Company", model.Company);
            }
            if (model.CreateDate == null)
            {
                h.AddParameter("@CreateDate", DBNull.Value);
            }
            else
            {
                h.AddParameter("@CreateDate", model.CreateDate);
            }
            if (model.State == null)
            {
                h.AddParameter("@State", DBNull.Value);
            }
            else
            {
                h.AddParameter("@State", model.State);
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
        public bool Update(Nikita.Assist.CodeMaker.Model.Bse_User model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Bse_User set ");
            strSql.Append("UserName=@UserName, Password=@Password, TrueName=@TrueName, Company=@Company, CreateDate=@CreateDate, State=@State  ");
            strSql.Append(" where User_Id=@User_Id ");
            DataAccess4DBHelper.IDbHelper h = GlobalHelpDemoForm.GetDataAccessHelper();
            h.CreateCommand(strSql.ToString());
            if (model.User_Id == null)
            {
                h.AddParameter("@User_Id", DBNull.Value);
            }
            else
            {
                h.AddParameter("@User_Id", model.User_Id);
            }
            if (model.UserName == null)
            {
                h.AddParameter("@UserName", DBNull.Value);
            }
            else
            {
                h.AddParameter("@UserName", model.UserName);
            }
            if (model.Password == null)
            {
                h.AddParameter("@Password", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Password", model.Password);
            }
            if (model.TrueName == null)
            {
                h.AddParameter("@TrueName", DBNull.Value);
            }
            else
            {
                h.AddParameter("@TrueName", model.TrueName);
            }
            if (model.Company == null)
            {
                h.AddParameter("@Company", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Company", model.Company);
            }
            if (model.CreateDate == null)
            {
                h.AddParameter("@CreateDate", DBNull.Value);
            }
            else
            {
                h.AddParameter("@CreateDate", model.CreateDate);
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
        /// <param name="User_Id">主键ID</param> 
        /// <returns>返回受影响的行数</returns>
        public bool Delete(int User_Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Bse_User ");
            strSql.Append(" where User_Id=@User_Id ");
            DataAccess4DBHelper.IDbHelper h = GlobalHelpDemoForm.GetDataAccessHelper();
            h.CreateCommand(strSql.ToString());
            h.AddParameter("@User_Id", User_Id);
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
            strSql.Append("delete from Bse_User ");
            if (!string.IsNullOrEmpty(strCond))
            {
                strSql.Append(" where " + strCond);
            }
            DataAccess4DBHelper.IDbHelper h = GlobalHelpDemoForm.GetDataAccessHelper();
            h.CreateCommand(strSql.ToString());
            return h.ExecuteNonQuery();
        }

        /// <summary>得到一个对象实体
        /// 
        /// </summary>
        /// <param name="User_Id">主键</param> 
        /// <returns>返回对象实体</returns>
        public Nikita.Assist.CodeMaker.Model.Bse_User GetModel(int User_Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Bse_User ");
            strSql.Append(" where User_Id=@User_Id ");
            DataAccess4DBHelper.IDbHelper h = GlobalHelpDemoForm.GetDataAccessHelper();
            h.CreateCommand(strSql.ToString());
            h.AddParameter("@User_Id", User_Id);
            Nikita.Assist.CodeMaker.Model.Bse_User model = null;
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
        public Nikita.Assist.CodeMaker.Model.Bse_User GetModelByCond(string strCond)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from Bse_User ");
            if (!string.IsNullOrEmpty(strCond))
            {
                strSql.Append(" where " + strCond);
            }
            DataAccess4DBHelper.IDbHelper h = GlobalHelpDemoForm.GetDataAccessHelper();
            h.CreateCommand(strSql.ToString());
            Nikita.Assist.CodeMaker.Model.Bse_User model = null;
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
            strSql.Append(" FROM Bse_User ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataAccess4DBHelper.IDbHelper h = GlobalHelpDemoForm.GetDataAccessHelper();
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
            strSql.Append(" FROM Bse_User ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataAccess4DBHelper.IDbHelper h = GlobalHelpDemoForm.GetDataAccessHelper();
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
            DataAccess4DBHelper.IDbHelper h = GlobalHelpDemoForm.GetDataAccessHelper();
            h.CreateStoredCommand("proc_SplitPage");
            h.AddParameter("@tblName", "Bse_User");
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
        public List<Nikita.Assist.CodeMaker.Model.Bse_User> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM Bse_User ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<Nikita.Assist.CodeMaker.Model.Bse_User> list = new List<Nikita.Assist.CodeMaker.Model.Bse_User>();
            DataAccess4DBHelper.IDbHelper h = GlobalHelpDemoForm.GetDataAccessHelper();
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
        public List<Nikita.Assist.CodeMaker.Model.Bse_User> GetListArray(string strFields, string strOrder, string strOrderType, int intPageSize, int intPageIndex, string strWhere)
        {
            DataAccess4DBHelper.IDbHelper h = GlobalHelpDemoForm.GetDataAccessHelper();
            h.CreateStoredCommand("[proc_SplitPage]");
            h.AddParameter("@tblName", "Bse_User");
            h.AddParameter("@strFields", strFields);
            h.AddParameter("@strOrder", strOrder);
            h.AddParameter("@strOrderType", strOrderType);
            h.AddParameter("@PageSize", intPageSize);
            h.AddParameter("@PageIndex", intPageIndex);
            h.AddParameter("@strWhere", strWhere);
            List<Nikita.Assist.CodeMaker.Model.Bse_User> list = new List<Nikita.Assist.CodeMaker.Model.Bse_User>();
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
        public Nikita.Assist.CodeMaker.Model.Bse_User ReaderBind(IDataReader dataReader)
        {
            Nikita.Assist.CodeMaker.Model.Bse_User model = new Nikita.Assist.CodeMaker.Model.Bse_User();
            object ojb;
            ojb = dataReader["User_Id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.User_Id = int.Parse(ojb.ToString());
            }
            model.UserName = dataReader["UserName"].ToString();
            model.Password = dataReader["Password"].ToString();
            model.TrueName = dataReader["TrueName"].ToString();
            model.Company = dataReader["Company"].ToString();
            ojb = dataReader["CreateDate"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.CreateDate = DateTime.Parse(ojb.ToString());
            }
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
        /// <param name="strCond">条件</param>
        /// <returns>总数量</returns>
        public int CalcCount(string strCond)
        {
            string strSql = "select count(1) from Bse_User";
            if (!string.IsNullOrEmpty(strCond))
            {
                strSql += " where " + strCond;
            }
            DataAccess4DBHelper.IDbHelper h = GlobalHelpDemoForm.GetDataAccessHelper();
            h.CreateCommand(strSql);
            return int.Parse(h.ExecuteScalar());
        }
    }
}

