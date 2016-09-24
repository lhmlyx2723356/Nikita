using Nikita.Assist.WcfService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Nikita.Permission.DAL
{
    /// <summary>Bse_SetInfo表数据访问类
    ///
    /// </summary>
    public partial class Bse_SetInfoDAL
    {
        public Bse_SetInfoDAL()
        { }

        /// <summary>增加一条数据
        ///
        /// </summary>
        public int Add(Nikita.Permission.Model.Bse_SetInfo model)
        {
            IMsSqlDataAccessService h = ServiceHelper.GetMsSqlDataAccessService();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Bse_SetInfo(");
            strSql.Append("SetOrd_Id, SetInfo_Key, SetInfo_Value, Number, Name, PY, Sort, Dept_Id, Company_Id, Bloc_Id, CreateUserId, CreateName, CreateDate, Remark, State, SystemId  )");
            strSql.Append(" values (");
            strSql.Append("@SetOrd_Id, @SetInfo_Key, @SetInfo_Value, @Number, @Name, @PY, @Sort, @Dept_Id, @Company_Id, @Bloc_Id, @CreateUserId, @CreateName, @CreateDate, @Remark, @State, @SystemId  )");
            strSql.Append(";select @@IDENTITY");

            h.CreateCommand(strSql.ToString());
            if (model.SetOrd_Id == null)
            {
                h.AddParameter("@SetOrd_Id", DBNull.Value);
            }
            else
            {
                h.AddParameter("@SetOrd_Id", model.SetOrd_Id);
            }
            if (model.SetInfo_Key == null)
            {
                h.AddParameter("@SetInfo_Key", DBNull.Value);
            }
            else
            {
                h.AddParameter("@SetInfo_Key", model.SetInfo_Key);
            }
            if (model.SetInfo_Value == null)
            {
                h.AddParameter("@SetInfo_Value", DBNull.Value);
            }
            else
            {
                h.AddParameter("@SetInfo_Value", model.SetInfo_Value);
            }
            if (model.Number == null)
            {
                h.AddParameter("@Number", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Number", model.Number);
            }
            if (model.Name == null)
            {
                h.AddParameter("@Name", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Name", model.Name);
            }
            if (model.PY == null)
            {
                h.AddParameter("@PY", DBNull.Value);
            }
            else
            {
                h.AddParameter("@PY", model.PY);
            }
            if (model.Sort == null)
            {
                h.AddParameter("@Sort", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Sort", model.Sort);
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
            if (model.Bloc_Id == null)
            {
                h.AddParameter("@Bloc_Id", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Bloc_Id", model.Bloc_Id);
            }
            if (model.CreateUserId == null)
            {
                h.AddParameter("@CreateUserId", DBNull.Value);
            }
            else
            {
                h.AddParameter("@CreateUserId", model.CreateUserId);
            }
            if (model.CreateName == null)
            {
                h.AddParameter("@CreateName", DBNull.Value);
            }
            else
            {
                h.AddParameter("@CreateName", model.CreateName);
            }
            if (model.CreateDate == null)
            {
                h.AddParameter("@CreateDate", DBNull.Value);
            }
            else
            {
                h.AddParameter("@CreateDate", model.CreateDate);
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
            if (model.SystemId == null)
            {
                h.AddParameter("@SystemId", DBNull.Value);
            }
            else
            {
                h.AddParameter("@SystemId", model.SystemId);
            }

            int result;
            string obj = h.ExecuteScalar();
            if (!int.TryParse(obj, out result))
            {
                return 0;
            }
            return result;
        }

        /// <summary>计算记录数
        ///
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public int CalcCount(string cond)
        {
            IMsSqlDataAccessService h = ServiceHelper.GetMsSqlDataAccessService();
            string sql = "select count(1) from Bse_SetInfo";
            if (!string.IsNullOrEmpty(cond))
            {
                sql += " where " + cond;
            }

            h.CreateCommand(sql);
            return int.Parse(h.ExecuteScalar());
        }

        /// <summary>删除一条数据
        ///
        /// </summary>
        public bool Delete(int SetInfo_Id)
        {
            IMsSqlDataAccessService h = ServiceHelper.GetMsSqlDataAccessService();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Bse_SetInfo ");
            strSql.Append(" where SetInfo_Id=@SetInfo_Id ");

            h.CreateCommand(strSql.ToString());
            h.AddParameter("@SetInfo_Id", SetInfo_Id);
            return h.ExecuteNonQuery();
        }

        /// <summary>根据条件删除数据
        ///
        /// </summary>
        public bool DeleteByCond(string cond)
        {
            IMsSqlDataAccessService h = ServiceHelper.GetMsSqlDataAccessService();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Bse_SetInfo ");
            if (!string.IsNullOrEmpty(cond))
            {
                strSql.Append(" where " + cond);
            }

            h.CreateCommand(strSql.ToString());
            return h.ExecuteNonQuery();
        }

        /// <summary>获得数据列表
        ///
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            IMsSqlDataAccessService h = ServiceHelper.GetMsSqlDataAccessService();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM Bse_SetInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }

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
            IMsSqlDataAccessService h = ServiceHelper.GetMsSqlDataAccessService();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select " + Filds + " ");
            strSql.Append(" FROM Bse_SetInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }

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
            IMsSqlDataAccessService h = ServiceHelper.GetMsSqlDataAccessService();
            h.CreateStoredCommand("[proc_SplitPage]");
            h.AddParameter("@tblName", "Bse_SetInfo");
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

        /// <summary>更新一条数据
        ///
        /// </summary>
        public bool Update(Nikita.Permission.Model.Bse_SetInfo model)
        {
            IMsSqlDataAccessService h = ServiceHelper.GetMsSqlDataAccessService();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Bse_SetInfo set ");
            strSql.Append("SetOrd_Id=@SetOrd_Id, SetInfo_Key=@SetInfo_Key, SetInfo_Value=@SetInfo_Value, Number=@Number, Name=@Name, PY=@PY, Sort=@Sort, Dept_Id=@Dept_Id, Company_Id=@Company_Id, Bloc_Id=@Bloc_Id, CreateUserId=@CreateUserId, CreateName=@CreateName, CreateDate=@CreateDate, Remark=@Remark, State=@State, SystemId=@SystemId  ");
            strSql.Append(" where SetInfo_Id=@SetInfo_Id ");

            h.CreateCommand(strSql.ToString());
            if (model.SetInfo_Id == null)
            {
                h.AddParameter("@SetInfo_Id", DBNull.Value);
            }
            else
            {
                h.AddParameter("@SetInfo_Id", model.SetInfo_Id);
            }
            if (model.SetOrd_Id == null)
            {
                h.AddParameter("@SetOrd_Id", DBNull.Value);
            }
            else
            {
                h.AddParameter("@SetOrd_Id", model.SetOrd_Id);
            }
            if (model.SetInfo_Key == null)
            {
                h.AddParameter("@SetInfo_Key", DBNull.Value);
            }
            else
            {
                h.AddParameter("@SetInfo_Key", model.SetInfo_Key);
            }
            if (model.SetInfo_Value == null)
            {
                h.AddParameter("@SetInfo_Value", DBNull.Value);
            }
            else
            {
                h.AddParameter("@SetInfo_Value", model.SetInfo_Value);
            }
            if (model.Number == null)
            {
                h.AddParameter("@Number", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Number", model.Number);
            }
            if (model.Name == null)
            {
                h.AddParameter("@Name", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Name", model.Name);
            }
            if (model.PY == null)
            {
                h.AddParameter("@PY", DBNull.Value);
            }
            else
            {
                h.AddParameter("@PY", model.PY);
            }
            if (model.Sort == null)
            {
                h.AddParameter("@Sort", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Sort", model.Sort);
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
            if (model.Bloc_Id == null)
            {
                h.AddParameter("@Bloc_Id", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Bloc_Id", model.Bloc_Id);
            }
            if (model.CreateUserId == null)
            {
                h.AddParameter("@CreateUserId", DBNull.Value);
            }
            else
            {
                h.AddParameter("@CreateUserId", model.CreateUserId);
            }
            if (model.CreateName == null)
            {
                h.AddParameter("@CreateName", DBNull.Value);
            }
            else
            {
                h.AddParameter("@CreateName", model.CreateName);
            }
            if (model.CreateDate == null)
            {
                h.AddParameter("@CreateDate", DBNull.Value);
            }
            else
            {
                h.AddParameter("@CreateDate", model.CreateDate);
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
            if (model.SystemId == null)
            {
                h.AddParameter("@SystemId", DBNull.Value);
            }
            else
            {
                h.AddParameter("@SystemId", model.SystemId);
            }

            return h.ExecuteNonQuery();
        }
    }
}