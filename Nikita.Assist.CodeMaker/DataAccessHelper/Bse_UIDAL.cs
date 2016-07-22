using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Nikita.DataAccess4DBHelper;

namespace Nikita.Assist.CodeMaker.DAL
{
    /// <summary>Bse_UI表数据访问类
    /// 作者:Luhm
    /// 创建时间:2016-02-04 12:04:21
    /// </summary>
    public partial class Bse_UIDAL
    {
        public Bse_UIDAL()
        { }
        /// <summary>增加一条数据
        /// 
        /// </summary>
        /// <param name="model">实体对象</param> 
        /// <returns>返回新增实体ID</returns>
        public int Add(Nikita.Assist.CodeMaker.Model.Bse_UI model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Bse_UI(");
            strSql.Append("TableName, PanelName, ColumnName, ColumnType, FrmNameSpace, ControlNameSpace, ControlType, Ctl_Simple, ControlName, GridSpeicalCtlName, ControlSort, DefaultValue, IsAddLable, LabelName, LabelText, IsNeed, IsReadonly, FiledText, FiledValue, DataSourse, DefaultFiledText, DefaultFiledValue, DefaultDataSourse, Remark, State, CreateDate, CreateUserId )");
            strSql.Append(" values (");
            strSql.Append("@TableName, @PanelName, @ColumnName, @ColumnType, @FrmNameSpace, @ControlNameSpace, @ControlType, @Ctl_Simple, @ControlName, @GridSpeicalCtlName, @ControlSort, @DefaultValue, @IsAddLable, @LabelName, @LabelText, @IsNeed, @IsReadonly, @FiledText, @FiledValue, @DataSourse, @DefaultFiledText, @DefaultFiledValue, @DefaultDataSourse, @Remark, @State, @CreateDate, @CreateUserId )");
           SQLiteHelper h = GlobalHelp.GetSQLiteHelper();

            h.CreateCommand(strSql.ToString()); 
if (model.TableName == null)
            {
                 h.AddParameter("@TableName", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@TableName", model.TableName);
            }
if (model.PanelName == null)
            {
                 h.AddParameter("@PanelName", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@PanelName", model.PanelName);
            }
if (model.ColumnName == null)
            {
                 h.AddParameter("@ColumnName", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@ColumnName", model.ColumnName);
            }
if (model.ColumnType == null)
            {
                 h.AddParameter("@ColumnType", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@ColumnType", model.ColumnType);
            }
if (model.FrmNameSpace == null)
            {
                 h.AddParameter("@FrmNameSpace", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@FrmNameSpace", model.FrmNameSpace);
            }
if (model.ControlNameSpace == null)
            {
                 h.AddParameter("@ControlNameSpace", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@ControlNameSpace", model.ControlNameSpace);
            }
if (model.ControlType == null)
            {
                 h.AddParameter("@ControlType", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@ControlType", model.ControlType);
            }
if (model.Ctl_Simple == null)
            {
                 h.AddParameter("@Ctl_Simple", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@Ctl_Simple", model.Ctl_Simple);
            }
if (model.ControlName == null)
            {
                 h.AddParameter("@ControlName", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@ControlName", model.ControlName);
            }
if (model.GridSpeicalCtlName == null)
            {
                 h.AddParameter("@GridSpeicalCtlName", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@GridSpeicalCtlName", model.GridSpeicalCtlName);
            }
if (model.ControlSort == null)
            {
                 h.AddParameter("@ControlSort", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@ControlSort", model.ControlSort);
            }
if (model.DefaultValue == null)
            {
                 h.AddParameter("@DefaultValue", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@DefaultValue", model.DefaultValue);
            }
if (model.IsAddLable == null)
            {
                 h.AddParameter("@IsAddLable", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@IsAddLable", model.IsAddLable);
            }
if (model.LabelName == null)
            {
                 h.AddParameter("@LabelName", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@LabelName", model.LabelName);
            }
if (model.LabelText == null)
            {
                 h.AddParameter("@LabelText", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@LabelText", model.LabelText);
            }
if (model.IsNeed == null)
            {
                 h.AddParameter("@IsNeed", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@IsNeed", model.IsNeed);
            }
if (model.IsReadonly == null)
            {
                 h.AddParameter("@IsReadonly", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@IsReadonly", model.IsReadonly);
            }
if (model.FiledText == null)
            {
                 h.AddParameter("@FiledText", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@FiledText", model.FiledText);
            }
if (model.FiledValue == null)
            {
                 h.AddParameter("@FiledValue", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@FiledValue", model.FiledValue);
            }
if (model.DataSourse == null)
            {
                 h.AddParameter("@DataSourse", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@DataSourse", model.DataSourse);
            }
if (model.DefaultFiledText == null)
            {
                 h.AddParameter("@DefaultFiledText", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@DefaultFiledText", model.DefaultFiledText);
            }
if (model.DefaultFiledValue == null)
            {
                 h.AddParameter("@DefaultFiledValue", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@DefaultFiledValue", model.DefaultFiledValue);
            }
if (model.DefaultDataSourse == null)
            {
                 h.AddParameter("@DefaultDataSourse", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@DefaultDataSourse", model.DefaultDataSourse);
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
if (model.CreateDate == null)
            {
                 h.AddParameter("@CreateDate", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@CreateDate", model.CreateDate.ToString("s"));
            }
if (model.CreateUserId == null)
            {
                 h.AddParameter("@CreateUserId", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@CreateUserId", model.CreateUserId);
            }


            h.ExecuteNonQuery();
            string strSql2 = "select max(Ui_Id) from Bse_UI";
            h.CreateCommand(strSql2);
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
        public bool Update(Nikita.Assist.CodeMaker.Model.Bse_UI model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Bse_UI set ");
            strSql.Append(" TableName=@TableName, PanelName=@PanelName, ColumnName=@ColumnName, ColumnType=@ColumnType, FrmNameSpace=@FrmNameSpace, ControlNameSpace=@ControlNameSpace, ControlType=@ControlType, Ctl_Simple=@Ctl_Simple, ControlName=@ControlName, GridSpeicalCtlName=@GridSpeicalCtlName, ControlSort=@ControlSort, DefaultValue=@DefaultValue, IsAddLable=@IsAddLable, LabelName=@LabelName, LabelText=@LabelText, IsNeed=@IsNeed, IsReadonly=@IsReadonly, FiledText=@FiledText, FiledValue=@FiledValue, DataSourse=@DataSourse, DefaultFiledText=@DefaultFiledText, DefaultFiledValue=@DefaultFiledValue, DefaultDataSourse=@DefaultDataSourse, Remark=@Remark, State=@State, CreateDate=@CreateDate, CreateUserId=@CreateUserId  ");
            strSql.Append(" where id=@id ");
           SQLiteHelper h = GlobalHelp.GetSQLiteHelper();
            h.CreateCommand(strSql.ToString()); 
            if (model.TableName == null)
            {
                 h.AddParameter("@TableName", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@TableName", model.TableName);
            }
            if (model.PanelName == null)
            {
                 h.AddParameter("@PanelName", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@PanelName", model.PanelName);
            }
            if (model.ColumnName == null)
            {
                 h.AddParameter("@ColumnName", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@ColumnName", model.ColumnName);
            }
            if (model.ColumnType == null)
            {
                 h.AddParameter("@ColumnType", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@ColumnType", model.ColumnType);
            }
            if (model.FrmNameSpace == null)
            {
                 h.AddParameter("@FrmNameSpace", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@FrmNameSpace", model.FrmNameSpace);
            }
            if (model.ControlNameSpace == null)
            {
                 h.AddParameter("@ControlNameSpace", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@ControlNameSpace", model.ControlNameSpace);
            }
            if (model.ControlType == null)
            {
                 h.AddParameter("@ControlType", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@ControlType", model.ControlType);
            }
            if (model.Ctl_Simple == null)
            {
                 h.AddParameter("@Ctl_Simple", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@Ctl_Simple", model.Ctl_Simple);
            }
            if (model.ControlName == null)
            {
                 h.AddParameter("@ControlName", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@ControlName", model.ControlName);
            }
            if (model.GridSpeicalCtlName == null)
            {
                 h.AddParameter("@GridSpeicalCtlName", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@GridSpeicalCtlName", model.GridSpeicalCtlName);
            }
            if (model.ControlSort == null)
            {
                 h.AddParameter("@ControlSort", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@ControlSort", model.ControlSort);
            }
            if (model.DefaultValue == null)
            {
                 h.AddParameter("@DefaultValue", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@DefaultValue", model.DefaultValue);
            }
            if (model.IsAddLable == null)
            {
                 h.AddParameter("@IsAddLable", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@IsAddLable", model.IsAddLable);
            }
            if (model.LabelName == null)
            {
                 h.AddParameter("@LabelName", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@LabelName", model.LabelName);
            }
            if (model.LabelText == null)
            {
                 h.AddParameter("@LabelText", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@LabelText", model.LabelText);
            }
            if (model.IsNeed == null)
            {
                 h.AddParameter("@IsNeed", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@IsNeed", model.IsNeed);
            }
            if (model.IsReadonly == null)
            {
                 h.AddParameter("@IsReadonly", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@IsReadonly", model.IsReadonly);
            }
            if (model.FiledText == null)
            {
                 h.AddParameter("@FiledText", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@FiledText", model.FiledText);
            }
            if (model.FiledValue == null)
            {
                 h.AddParameter("@FiledValue", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@FiledValue", model.FiledValue);
            }
            if (model.DataSourse == null)
            {
                 h.AddParameter("@DataSourse", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@DataSourse", model.DataSourse);
            }
            if (model.DefaultFiledText == null)
            {
                 h.AddParameter("@DefaultFiledText", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@DefaultFiledText", model.DefaultFiledText);
            }
            if (model.DefaultFiledValue == null)
            {
                 h.AddParameter("@DefaultFiledValue", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@DefaultFiledValue", model.DefaultFiledValue);
            }
            if (model.DefaultDataSourse == null)
            {
                 h.AddParameter("@DefaultDataSourse", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@DefaultDataSourse", model.DefaultDataSourse);
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
            if (model.CreateDate == null)
            {
                 h.AddParameter("@CreateDate", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@CreateDate", model.CreateDate.ToString("s"));
            }
            if (model.CreateUserId == null)
            {
                 h.AddParameter("@CreateUserId", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@CreateUserId", model.CreateUserId);
            }
            h.AddParameter("@id", model.Ui_Id);

            return h.ExecuteNonQuery();
        }

        /// <summary>删除一条数据
        /// 
        /// </summary>
        /// <param name="intId">主键ID</param> 
        /// <returns>返回受影响的行数</returns>
        public bool Delete(int intId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Bse_UI ");
            strSql.Append(" where Ui_Id=@id ");
           SQLiteHelper h = GlobalHelp.GetSQLiteHelper();
            h.CreateCommand(strSql.ToString());
            h.AddParameter("@id", intId);
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
            strSql.Append("delete from Bse_UI ");
            if (!string.IsNullOrEmpty(strCond))
            {
                strSql.Append(" where " + strCond);
            }
           SQLiteHelper h = GlobalHelp.GetSQLiteHelper();
            h.CreateCommand(strSql.ToString());
            return h.ExecuteNonQuery();
        }

        /// <summary>得到一个对象实体
        /// 
        /// </summary>
        /// <param name="intId">主键</param> 
        /// <returns>返回对象实体</returns>
        public Nikita.Assist.CodeMaker.Model.Bse_UI GetModel(int intId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Bse_UI ");
            strSql.Append(" where Ui_Id=@id ");
           SQLiteHelper h = GlobalHelp.GetSQLiteHelper();
            h.CreateCommand(strSql.ToString());
            h.AddParameter("@id", intId);
            Nikita.Assist.CodeMaker.Model.Bse_UI model = null;
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
        public Nikita.Assist.CodeMaker.Model.Bse_UI GetModelByCond(string strCond)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Bse_UI ");
            if (!string.IsNullOrEmpty(strCond))
            {
                strSql.Append(" where " + strCond);
            }
            strSql.Append(" limit 1");
           SQLiteHelper h = GlobalHelp.GetSQLiteHelper();
            h.CreateCommand(strSql.ToString());
            Nikita.Assist.CodeMaker.Model.Bse_UI model = null;
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
            strSql.Append(" FROM Bse_UI  ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
           SQLiteHelper h = GlobalHelp.GetSQLiteHelper();
            h.CreateCommand(strSql.ToString());
            DataTable dt = h.ExecuteQuery();
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            return ds;
        }
	     /// <summary>获得数据列表
        /// 
        /// </summary>
        /// <param name="strWhere">条件</param> 
        /// <param name="strFields">字段</param> 
        /// <returns>返回符合条件的DataSet数据集</returns>
        public DataSet GetList(string strWhere,string strFields)
        {
            StringBuilder strSql = new StringBuilder();
			  strSql.Append("select " + strFields + " ");
            strSql.Append(" FROM Bse_UI  ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
           SQLiteHelper h = GlobalHelp.GetSQLiteHelper();
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
           SQLiteHelper h = GlobalHelp.GetSQLiteHelper();
            DataTable dt = h.FengYe("Bse_UI", strFields, strOrder, strOrderType, strWhere, intPageSize, intPageIndex);
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            return ds;
        }
		
        /// <summary>获得数据列表（比DataSet效率高，推荐使用）
        /// 
        /// </summary>
        /// <param name="strWhere">条件</param> 
        /// <returns>返回符合条件的对象集合</returns>
        public List<Nikita.Assist.CodeMaker.Model.Bse_UI> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM Bse_UI ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<Nikita.Assist.CodeMaker.Model.Bse_UI> list = new List<Nikita.Assist.CodeMaker.Model.Bse_UI>();
           SQLiteHelper h = GlobalHelp.GetSQLiteHelper();
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
        public List<Nikita.Assist.CodeMaker.Model.Bse_UI> GetListArray(string strFields, string strOrder, string strOrderType, int intPageSize, int intPageIndex, string strWhere)
        {
           SQLiteHelper h = GlobalHelp.GetSQLiteHelper();
            DataTable dt = h.FengYe("Bse_UI", strFields, strOrder, strOrderType, strWhere, intPageSize, intPageIndex);
            List<Nikita.Assist.CodeMaker.Model.Bse_UI> list = new List<Nikita.Assist.CodeMaker.Model.Bse_UI>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Model.Bse_UI()
                {
                    Ui_Id = int.Parse(row["Ui_Id"].ToString()),TableName = row["TableName"].ToString(),PanelName = row["PanelName"].ToString(),ColumnName = row["ColumnName"].ToString(),ColumnType = row["ColumnType"].ToString(),FrmNameSpace = row["FrmNameSpace"].ToString(),ControlNameSpace = row["ControlNameSpace"].ToString(),ControlType = row["ControlType"].ToString(),Ctl_Simple = row["Ctl_Simple"].ToString(),ControlName = row["ControlName"].ToString(),GridSpeicalCtlName = row["GridSpeicalCtlName"].ToString(),ControlSort = row["ControlSort"].ToString(),DefaultValue = row["DefaultValue"].ToString(),IsAddLable = row["IsAddLable"].ToString(),LabelName = row["LabelName"].ToString(),LabelText = row["LabelText"].ToString(),IsNeed = row["IsNeed"].ToString(),IsReadonly = row["IsReadonly"].ToString(),FiledText = row["FiledText"].ToString(),FiledValue = row["FiledValue"].ToString(),DataSourse = row["DataSourse"].ToString(),DefaultFiledText = row["DefaultFiledText"].ToString(),DefaultFiledValue = row["DefaultFiledValue"].ToString(),DefaultDataSourse = row["DefaultDataSourse"].ToString(),Remark = row["Remark"].ToString(),State = int.Parse(row["State"].ToString()),CreateDate = DateTime.Parse(row["CreateDate"].ToString()),CreateUserId = int.Parse(row["CreateUserId"].ToString()),
                });
            }
            return list;
        }

        /// <summary>对象实体绑定数据
        /// 
        /// </summary>
        /// <param name="dataReader">IDataReader对象</param> 
        /// <returns>返回实体对象</returns>
        public Nikita.Assist.CodeMaker.Model.Bse_UI ReaderBind(IDataReader dataReader)
        {
            Nikita.Assist.CodeMaker.Model.Bse_UI model = new Nikita.Assist.CodeMaker.Model.Bse_UI();
            object ojb;
                        ojb = dataReader["Ui_Id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Ui_Id = int.Parse(ojb.ToString());
            }
            model.TableName = dataReader["TableName"].ToString();
            model.PanelName = dataReader["PanelName"].ToString();
            model.ColumnName = dataReader["ColumnName"].ToString();
            model.ColumnType = dataReader["ColumnType"].ToString();
            model.FrmNameSpace = dataReader["FrmNameSpace"].ToString();
            model.ControlNameSpace = dataReader["ControlNameSpace"].ToString();
            model.ControlType = dataReader["ControlType"].ToString();
            model.Ctl_Simple = dataReader["Ctl_Simple"].ToString();
            model.ControlName = dataReader["ControlName"].ToString();
            model.GridSpeicalCtlName = dataReader["GridSpeicalCtlName"].ToString();
            model.ControlSort = dataReader["ControlSort"].ToString();
            model.DefaultValue = dataReader["DefaultValue"].ToString();
            model.IsAddLable = dataReader["IsAddLable"].ToString();
            model.LabelName = dataReader["LabelName"].ToString();
            model.LabelText = dataReader["LabelText"].ToString();
            model.IsNeed = dataReader["IsNeed"].ToString();
            model.IsReadonly = dataReader["IsReadonly"].ToString();
            model.FiledText = dataReader["FiledText"].ToString();
            model.FiledValue = dataReader["FiledValue"].ToString();
            model.DataSourse = dataReader["DataSourse"].ToString();
            model.DefaultFiledText = dataReader["DefaultFiledText"].ToString();
            model.DefaultFiledValue = dataReader["DefaultFiledValue"].ToString();
            model.DefaultDataSourse = dataReader["DefaultDataSourse"].ToString();
            model.Remark = dataReader["Remark"].ToString();
            ojb = dataReader["State"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.State = int.Parse(ojb.ToString());
            }
            ojb = dataReader["CreateDate"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.CreateDate = DateTime.Parse(ojb.ToString());
            }
            ojb = dataReader["CreateUserId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.CreateUserId = int.Parse(ojb.ToString());
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
            string sql = "select count(1) from Bse_UI";
            if (!string.IsNullOrEmpty(strCond))
            {
                sql += " where " + strCond;
            }
           SQLiteHelper h = GlobalHelp.GetSQLiteHelper();
            h.CreateCommand(sql);
            return int.Parse(h.ExecuteScalar());
        }
    }
}

