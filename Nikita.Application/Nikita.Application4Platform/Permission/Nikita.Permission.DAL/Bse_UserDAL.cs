using Nikita.Assist.WcfService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Nikita.Permission.DAL
{
    /// <summary>Bse_User表数据访问类
    ///
    /// </summary>
    public partial class Bse_UserDAL
    {
        public Bse_UserDAL()
        { }

        /// <summary>增加一条数据
        ///
        /// </summary>
        public int Add(Nikita.Permission.Model.Bse_User model)
        {
            IMsSqlDataAccessService h = ServiceHelper.GetMsSqlDataAccessService();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Bse_User(");
            strSql.Append("Number, UserName, Realname, NiName, UserFrom, Password, ChangePasswordDate, Duty, Title, Email, Lang, Sex, Birthday, Mobile, Telephone, QQ, SFZNumber, HomeAddress, HomeTel, WorkAddress, WorkTel, Theme, AllowStartTime, AllowEndTime, LockStartDate, LockEndDate, FirstVisit, PreviousVisit, LastVisit, LogOnCount, IsStaff, IsVisible, IPAddress, MACAddress, Question, AnswerQuestion, UserAddressId, AuditStatus, PY, Sort, Dept_Id, DeptName, Company_Id, CompanyName, Bloc_Id, BlocName, CreateUserId, CreateName, CreateDate, EditUserId, EditUserName, EditDate, Remark, State, SystemId  )");
            strSql.Append(" values (");
            strSql.Append("@Number, @UserName, @Realname, @NiName, @UserFrom, @Password, @ChangePasswordDate, @Duty, @Title, @Email, @Lang, @Sex, @Birthday, @Mobile, @Telephone, @QQ, @SFZNumber, @HomeAddress, @HomeTel, @WorkAddress, @WorkTel, @Theme, @AllowStartTime, @AllowEndTime, @LockStartDate, @LockEndDate, @FirstVisit, @PreviousVisit, @LastVisit, @LogOnCount, @IsStaff, @IsVisible, @IPAddress, @MACAddress, @Question, @AnswerQuestion, @UserAddressId, @AuditStatus, @PY, @Sort, @Dept_Id, @DeptName, @Company_Id, @CompanyName, @Bloc_Id, @BlocName, @CreateUserId, @CreateName, @CreateDate, @EditUserId, @EditUserName, @EditDate, @Remark, @State, @SystemId  )");
            strSql.Append(";select @@IDENTITY");

            h.CreateCommand(strSql.ToString());
            if (model.Number == null)
            {
                h.AddParameter("@Number", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Number", model.Number);
            }
            if (model.UserName == null)
            {
                h.AddParameter("@UserName", DBNull.Value);
            }
            else
            {
                h.AddParameter("@UserName", model.UserName);
            }
            if (model.Realname == null)
            {
                h.AddParameter("@Realname", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Realname", model.Realname);
            }
            if (model.NiName == null)
            {
                h.AddParameter("@NiName", DBNull.Value);
            }
            else
            {
                h.AddParameter("@NiName", model.NiName);
            }
            if (model.UserFrom == null)
            {
                h.AddParameter("@UserFrom", DBNull.Value);
            }
            else
            {
                h.AddParameter("@UserFrom", model.UserFrom);
            }
            if (model.Password == null)
            {
                h.AddParameter("@Password", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Password", model.Password);
            }
            if (model.ChangePasswordDate == null)
            {
                h.AddParameter("@ChangePasswordDate", DBNull.Value);
            }
            else
            {
                h.AddParameter("@ChangePasswordDate", model.ChangePasswordDate);
            }
            if (model.Duty == null)
            {
                h.AddParameter("@Duty", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Duty", model.Duty);
            }
            if (model.Title == null)
            {
                h.AddParameter("@Title", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Title", model.Title);
            }
            if (model.Email == null)
            {
                h.AddParameter("@Email", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Email", model.Email);
            }
            if (model.Lang == null)
            {
                h.AddParameter("@Lang", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Lang", model.Lang);
            }
            if (model.Sex == null)
            {
                h.AddParameter("@Sex", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Sex", model.Sex);
            }
            if (model.Birthday == null)
            {
                h.AddParameter("@Birthday", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Birthday", model.Birthday);
            }
            if (model.Mobile == null)
            {
                h.AddParameter("@Mobile", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Mobile", model.Mobile);
            }
            if (model.Telephone == null)
            {
                h.AddParameter("@Telephone", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Telephone", model.Telephone);
            }
            if (model.QQ == null)
            {
                h.AddParameter("@QQ", DBNull.Value);
            }
            else
            {
                h.AddParameter("@QQ", model.QQ);
            }
            if (model.SFZNumber == null)
            {
                h.AddParameter("@SFZNumber", DBNull.Value);
            }
            else
            {
                h.AddParameter("@SFZNumber", model.SFZNumber);
            }
            if (model.HomeAddress == null)
            {
                h.AddParameter("@HomeAddress", DBNull.Value);
            }
            else
            {
                h.AddParameter("@HomeAddress", model.HomeAddress);
            }
            if (model.HomeTel == null)
            {
                h.AddParameter("@HomeTel", DBNull.Value);
            }
            else
            {
                h.AddParameter("@HomeTel", model.HomeTel);
            }
            if (model.WorkAddress == null)
            {
                h.AddParameter("@WorkAddress", DBNull.Value);
            }
            else
            {
                h.AddParameter("@WorkAddress", model.WorkAddress);
            }
            if (model.WorkTel == null)
            {
                h.AddParameter("@WorkTel", DBNull.Value);
            }
            else
            {
                h.AddParameter("@WorkTel", model.WorkTel);
            }
            if (model.Theme == null)
            {
                h.AddParameter("@Theme", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Theme", model.Theme);
            }
            if (model.AllowStartTime == null)
            {
                h.AddParameter("@AllowStartTime", DBNull.Value);
            }
            else
            {
                h.AddParameter("@AllowStartTime", model.AllowStartTime);
            }
            if (model.AllowEndTime == null)
            {
                h.AddParameter("@AllowEndTime", DBNull.Value);
            }
            else
            {
                h.AddParameter("@AllowEndTime", model.AllowEndTime);
            }
            if (model.LockStartDate == null)
            {
                h.AddParameter("@LockStartDate", DBNull.Value);
            }
            else
            {
                h.AddParameter("@LockStartDate", model.LockStartDate);
            }
            if (model.LockEndDate == null)
            {
                h.AddParameter("@LockEndDate", DBNull.Value);
            }
            else
            {
                h.AddParameter("@LockEndDate", model.LockEndDate);
            }
            if (model.FirstVisit == null)
            {
                h.AddParameter("@FirstVisit", DBNull.Value);
            }
            else
            {
                h.AddParameter("@FirstVisit", model.FirstVisit);
            }
            if (model.PreviousVisit == null)
            {
                h.AddParameter("@PreviousVisit", DBNull.Value);
            }
            else
            {
                h.AddParameter("@PreviousVisit", model.PreviousVisit);
            }
            if (model.LastVisit == null)
            {
                h.AddParameter("@LastVisit", DBNull.Value);
            }
            else
            {
                h.AddParameter("@LastVisit", model.LastVisit);
            }
            if (model.LogOnCount == null)
            {
                h.AddParameter("@LogOnCount", DBNull.Value);
            }
            else
            {
                h.AddParameter("@LogOnCount", model.LogOnCount);
            }
            if (model.IsStaff == null)
            {
                h.AddParameter("@IsStaff", DBNull.Value);
            }
            else
            {
                h.AddParameter("@IsStaff", model.IsStaff);
            }
            if (model.IsVisible == null)
            {
                h.AddParameter("@IsVisible", DBNull.Value);
            }
            else
            {
                h.AddParameter("@IsVisible", model.IsVisible);
            }
            if (model.IPAddress == null)
            {
                h.AddParameter("@IPAddress", DBNull.Value);
            }
            else
            {
                h.AddParameter("@IPAddress", model.IPAddress);
            }
            if (model.MACAddress == null)
            {
                h.AddParameter("@MACAddress", DBNull.Value);
            }
            else
            {
                h.AddParameter("@MACAddress", model.MACAddress);
            }
            if (model.Question == null)
            {
                h.AddParameter("@Question", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Question", model.Question);
            }
            if (model.AnswerQuestion == null)
            {
                h.AddParameter("@AnswerQuestion", DBNull.Value);
            }
            else
            {
                h.AddParameter("@AnswerQuestion", model.AnswerQuestion);
            }
            if (model.UserAddressId == null)
            {
                h.AddParameter("@UserAddressId", DBNull.Value);
            }
            else
            {
                h.AddParameter("@UserAddressId", model.UserAddressId);
            }
            if (model.AuditStatus == null)
            {
                h.AddParameter("@AuditStatus", DBNull.Value);
            }
            else
            {
                h.AddParameter("@AuditStatus", model.AuditStatus);
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
            if (model.DeptName == null)
            {
                h.AddParameter("@DeptName", DBNull.Value);
            }
            else
            {
                h.AddParameter("@DeptName", model.DeptName);
            }
            if (model.Company_Id == null)
            {
                h.AddParameter("@Company_Id", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Company_Id", model.Company_Id);
            }
            if (model.CompanyName == null)
            {
                h.AddParameter("@CompanyName", DBNull.Value);
            }
            else
            {
                h.AddParameter("@CompanyName", model.CompanyName);
            }
            if (model.Bloc_Id == null)
            {
                h.AddParameter("@Bloc_Id", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Bloc_Id", model.Bloc_Id);
            }
            if (model.BlocName == null)
            {
                h.AddParameter("@BlocName", DBNull.Value);
            }
            else
            {
                h.AddParameter("@BlocName", model.BlocName);
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
            if (model.EditUserId == null)
            {
                h.AddParameter("@EditUserId", DBNull.Value);
            }
            else
            {
                h.AddParameter("@EditUserId", model.EditUserId);
            }
            if (model.EditUserName == null)
            {
                h.AddParameter("@EditUserName", DBNull.Value);
            }
            else
            {
                h.AddParameter("@EditUserName", model.EditUserName);
            }
            if (model.EditDate == null)
            {
                h.AddParameter("@EditDate", DBNull.Value);
            }
            else
            {
                h.AddParameter("@EditDate", model.EditDate);
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
            string sql = "select count(1) from Bse_User";
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
        public bool Delete(int User_Id)
        {
            IMsSqlDataAccessService h = ServiceHelper.GetMsSqlDataAccessService();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Bse_User ");
            strSql.Append(" where User_Id=@User_Id ");

            h.CreateCommand(strSql.ToString());
            h.AddParameter("@User_Id", User_Id);
            return h.ExecuteNonQuery();
        }

        /// <summary>根据条件删除数据
        ///
        /// </summary>
        public bool DeleteByCond(string cond)
        {
            IMsSqlDataAccessService h = ServiceHelper.GetMsSqlDataAccessService();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Bse_User ");
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
            strSql.Append(" FROM Bse_User ");
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
            strSql.Append(" FROM Bse_User ");
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
            h.AddParameter("@tblName", "Bse_User");
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
        public bool Update(Nikita.Permission.Model.Bse_User model)
        {
            IMsSqlDataAccessService h = ServiceHelper.GetMsSqlDataAccessService();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Bse_User set ");
            strSql.Append("Number=@Number, UserName=@UserName, Realname=@Realname, NiName=@NiName, UserFrom=@UserFrom, Password=@Password, ChangePasswordDate=@ChangePasswordDate, Duty=@Duty, Title=@Title, Email=@Email, Lang=@Lang, Sex=@Sex, Birthday=@Birthday, Mobile=@Mobile, Telephone=@Telephone, QQ=@QQ, SFZNumber=@SFZNumber, HomeAddress=@HomeAddress, HomeTel=@HomeTel, WorkAddress=@WorkAddress, WorkTel=@WorkTel, Theme=@Theme, AllowStartTime=@AllowStartTime, AllowEndTime=@AllowEndTime, LockStartDate=@LockStartDate, LockEndDate=@LockEndDate, FirstVisit=@FirstVisit, PreviousVisit=@PreviousVisit, LastVisit=@LastVisit, LogOnCount=@LogOnCount, IsStaff=@IsStaff, IsVisible=@IsVisible, IPAddress=@IPAddress, MACAddress=@MACAddress, Question=@Question, AnswerQuestion=@AnswerQuestion, UserAddressId=@UserAddressId, AuditStatus=@AuditStatus, PY=@PY, Sort=@Sort, Dept_Id=@Dept_Id, DeptName=@DeptName, Company_Id=@Company_Id, CompanyName=@CompanyName, Bloc_Id=@Bloc_Id, BlocName=@BlocName, CreateUserId=@CreateUserId, CreateName=@CreateName, CreateDate=@CreateDate, EditUserId=@EditUserId, EditUserName=@EditUserName, EditDate=@EditDate, Remark=@Remark, State=@State, SystemId=@SystemId  ");
            strSql.Append(" where User_Id=@User_Id ");

            h.CreateCommand(strSql.ToString());
            if (model.User_Id == null)
            {
                h.AddParameter("@User_Id", DBNull.Value);
            }
            else
            {
                h.AddParameter("@User_Id", model.User_Id);
            }
            if (model.Number == null)
            {
                h.AddParameter("@Number", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Number", model.Number);
            }
            if (model.UserName == null)
            {
                h.AddParameter("@UserName", DBNull.Value);
            }
            else
            {
                h.AddParameter("@UserName", model.UserName);
            }
            if (model.Realname == null)
            {
                h.AddParameter("@Realname", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Realname", model.Realname);
            }
            if (model.NiName == null)
            {
                h.AddParameter("@NiName", DBNull.Value);
            }
            else
            {
                h.AddParameter("@NiName", model.NiName);
            }
            if (model.UserFrom == null)
            {
                h.AddParameter("@UserFrom", DBNull.Value);
            }
            else
            {
                h.AddParameter("@UserFrom", model.UserFrom);
            }
            if (model.Password == null)
            {
                h.AddParameter("@Password", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Password", model.Password);
            }
            if (model.ChangePasswordDate == null)
            {
                h.AddParameter("@ChangePasswordDate", DBNull.Value);
            }
            else
            {
                h.AddParameter("@ChangePasswordDate", model.ChangePasswordDate);
            }
            if (model.Duty == null)
            {
                h.AddParameter("@Duty", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Duty", model.Duty);
            }
            if (model.Title == null)
            {
                h.AddParameter("@Title", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Title", model.Title);
            }
            if (model.Email == null)
            {
                h.AddParameter("@Email", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Email", model.Email);
            }
            if (model.Lang == null)
            {
                h.AddParameter("@Lang", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Lang", model.Lang);
            }
            if (model.Sex == null)
            {
                h.AddParameter("@Sex", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Sex", model.Sex);
            }
            if (model.Birthday == null)
            {
                h.AddParameter("@Birthday", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Birthday", model.Birthday);
            }
            if (model.Mobile == null)
            {
                h.AddParameter("@Mobile", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Mobile", model.Mobile);
            }
            if (model.Telephone == null)
            {
                h.AddParameter("@Telephone", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Telephone", model.Telephone);
            }
            if (model.QQ == null)
            {
                h.AddParameter("@QQ", DBNull.Value);
            }
            else
            {
                h.AddParameter("@QQ", model.QQ);
            }
            if (model.SFZNumber == null)
            {
                h.AddParameter("@SFZNumber", DBNull.Value);
            }
            else
            {
                h.AddParameter("@SFZNumber", model.SFZNumber);
            }
            if (model.HomeAddress == null)
            {
                h.AddParameter("@HomeAddress", DBNull.Value);
            }
            else
            {
                h.AddParameter("@HomeAddress", model.HomeAddress);
            }
            if (model.HomeTel == null)
            {
                h.AddParameter("@HomeTel", DBNull.Value);
            }
            else
            {
                h.AddParameter("@HomeTel", model.HomeTel);
            }
            if (model.WorkAddress == null)
            {
                h.AddParameter("@WorkAddress", DBNull.Value);
            }
            else
            {
                h.AddParameter("@WorkAddress", model.WorkAddress);
            }
            if (model.WorkTel == null)
            {
                h.AddParameter("@WorkTel", DBNull.Value);
            }
            else
            {
                h.AddParameter("@WorkTel", model.WorkTel);
            }
            if (model.Theme == null)
            {
                h.AddParameter("@Theme", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Theme", model.Theme);
            }
            if (model.AllowStartTime == null)
            {
                h.AddParameter("@AllowStartTime", DBNull.Value);
            }
            else
            {
                h.AddParameter("@AllowStartTime", model.AllowStartTime);
            }
            if (model.AllowEndTime == null)
            {
                h.AddParameter("@AllowEndTime", DBNull.Value);
            }
            else
            {
                h.AddParameter("@AllowEndTime", model.AllowEndTime);
            }
            if (model.LockStartDate == null)
            {
                h.AddParameter("@LockStartDate", DBNull.Value);
            }
            else
            {
                h.AddParameter("@LockStartDate", model.LockStartDate);
            }
            if (model.LockEndDate == null)
            {
                h.AddParameter("@LockEndDate", DBNull.Value);
            }
            else
            {
                h.AddParameter("@LockEndDate", model.LockEndDate);
            }
            if (model.FirstVisit == null)
            {
                h.AddParameter("@FirstVisit", DBNull.Value);
            }
            else
            {
                h.AddParameter("@FirstVisit", model.FirstVisit);
            }
            if (model.PreviousVisit == null)
            {
                h.AddParameter("@PreviousVisit", DBNull.Value);
            }
            else
            {
                h.AddParameter("@PreviousVisit", model.PreviousVisit);
            }
            if (model.LastVisit == null)
            {
                h.AddParameter("@LastVisit", DBNull.Value);
            }
            else
            {
                h.AddParameter("@LastVisit", model.LastVisit);
            }
            if (model.LogOnCount == null)
            {
                h.AddParameter("@LogOnCount", DBNull.Value);
            }
            else
            {
                h.AddParameter("@LogOnCount", model.LogOnCount);
            }
            if (model.IsStaff == null)
            {
                h.AddParameter("@IsStaff", DBNull.Value);
            }
            else
            {
                h.AddParameter("@IsStaff", model.IsStaff);
            }
            if (model.IsVisible == null)
            {
                h.AddParameter("@IsVisible", DBNull.Value);
            }
            else
            {
                h.AddParameter("@IsVisible", model.IsVisible);
            }
            if (model.IPAddress == null)
            {
                h.AddParameter("@IPAddress", DBNull.Value);
            }
            else
            {
                h.AddParameter("@IPAddress", model.IPAddress);
            }
            if (model.MACAddress == null)
            {
                h.AddParameter("@MACAddress", DBNull.Value);
            }
            else
            {
                h.AddParameter("@MACAddress", model.MACAddress);
            }
            if (model.Question == null)
            {
                h.AddParameter("@Question", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Question", model.Question);
            }
            if (model.AnswerQuestion == null)
            {
                h.AddParameter("@AnswerQuestion", DBNull.Value);
            }
            else
            {
                h.AddParameter("@AnswerQuestion", model.AnswerQuestion);
            }
            if (model.UserAddressId == null)
            {
                h.AddParameter("@UserAddressId", DBNull.Value);
            }
            else
            {
                h.AddParameter("@UserAddressId", model.UserAddressId);
            }
            if (model.AuditStatus == null)
            {
                h.AddParameter("@AuditStatus", DBNull.Value);
            }
            else
            {
                h.AddParameter("@AuditStatus", model.AuditStatus);
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
            if (model.DeptName == null)
            {
                h.AddParameter("@DeptName", DBNull.Value);
            }
            else
            {
                h.AddParameter("@DeptName", model.DeptName);
            }
            if (model.Company_Id == null)
            {
                h.AddParameter("@Company_Id", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Company_Id", model.Company_Id);
            }
            if (model.CompanyName == null)
            {
                h.AddParameter("@CompanyName", DBNull.Value);
            }
            else
            {
                h.AddParameter("@CompanyName", model.CompanyName);
            }
            if (model.Bloc_Id == null)
            {
                h.AddParameter("@Bloc_Id", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Bloc_Id", model.Bloc_Id);
            }
            if (model.BlocName == null)
            {
                h.AddParameter("@BlocName", DBNull.Value);
            }
            else
            {
                h.AddParameter("@BlocName", model.BlocName);
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
            if (model.EditUserId == null)
            {
                h.AddParameter("@EditUserId", DBNull.Value);
            }
            else
            {
                h.AddParameter("@EditUserId", model.EditUserId);
            }
            if (model.EditUserName == null)
            {
                h.AddParameter("@EditUserName", DBNull.Value);
            }
            else
            {
                h.AddParameter("@EditUserName", model.EditUserName);
            }
            if (model.EditDate == null)
            {
                h.AddParameter("@EditDate", DBNull.Value);
            }
            else
            {
                h.AddParameter("@EditDate", model.EditDate);
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