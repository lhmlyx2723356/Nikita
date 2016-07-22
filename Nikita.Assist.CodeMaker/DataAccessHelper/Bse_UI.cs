using System;
namespace Nikita.Assist.CodeMaker.Model
{
	/// <summary>Bse_UI表实体类
	/// 作者:
	/// 创建时间:2016-02-04 12:04:21
	/// </summary>
	[Serializable]
	public class Bse_UI
	{
		public Bse_UI()
		{}
		private int _Ui_Id  = 0;
		/// <summary>Ui_Id
		/// 
		/// </summary>
		public int Ui_Id
		{
			set{ _Ui_Id=value;}
			get{return _Ui_Id;}
		}
		private string _TableName ;
		/// <summary>TableName
		/// 
		/// </summary>
		public string TableName
		{
			set{ _TableName=value;}
			get{return _TableName;}
		}
		private string _PanelName ;
		/// <summary>PanelName
		/// 
		/// </summary>
		public string PanelName
		{
			set{ _PanelName=value;}
			get{return _PanelName;}
		}
		private string _ColumnName ;
		/// <summary>ColumnName
		/// 
		/// </summary>
		public string ColumnName
		{
			set{ _ColumnName=value;}
			get{return _ColumnName;}
		}
		private string _ColumnType ;
		/// <summary>ColumnType
		/// 
		/// </summary>
		public string ColumnType
		{
			set{ _ColumnType=value;}
			get{return _ColumnType;}
		}
		private string _FrmNameSpace ;
		/// <summary>FrmNameSpace
		/// 
		/// </summary>
		public string FrmNameSpace
		{
			set{ _FrmNameSpace=value;}
			get{return _FrmNameSpace;}
		}
		private string _ControlNameSpace ;
		/// <summary>ControlNameSpace
		/// 
		/// </summary>
		public string ControlNameSpace
		{
			set{ _ControlNameSpace=value;}
			get{return _ControlNameSpace;}
		}
		private string _ControlType ;
		/// <summary>ControlType
		/// 
		/// </summary>
		public string ControlType
		{
			set{ _ControlType=value;}
			get{return _ControlType;}
		}
		private string _Ctl_Simple ;
		/// <summary>Ctl_Simple
		/// 
		/// </summary>
		public string Ctl_Simple
		{
			set{ _Ctl_Simple=value;}
			get{return _Ctl_Simple;}
		}
		private string _ControlName ;
		/// <summary>ControlName
		/// 
		/// </summary>
		public string ControlName
		{
			set{ _ControlName=value;}
			get{return _ControlName;}
		}
		private string _GridSpeicalCtlName ;
		/// <summary>GridSpeicalCtlName
		/// 
		/// </summary>
		public string GridSpeicalCtlName
		{
			set{ _GridSpeicalCtlName=value;}
			get{return _GridSpeicalCtlName;}
		}
		private string _ControlSort ;
		/// <summary>ControlSort
		/// 
		/// </summary>
		public string ControlSort
		{
			set{ _ControlSort=value;}
			get{return _ControlSort;}
		}
		private string _DefaultValue ;
		/// <summary>DefaultValue
		/// 
		/// </summary>
		public string DefaultValue
		{
			set{ _DefaultValue=value;}
			get{return _DefaultValue;}
		}
		private string _IsAddLable ;
		/// <summary>IsAddLable
		/// 
		/// </summary>
		public string IsAddLable
		{
			set{ _IsAddLable=value;}
			get{return _IsAddLable;}
		}
		private string _LabelName ;
		/// <summary>LabelName
		/// 
		/// </summary>
		public string LabelName
		{
			set{ _LabelName=value;}
			get{return _LabelName;}
		}
		private string _LabelText ;
		/// <summary>LabelText
		/// 
		/// </summary>
		public string LabelText
		{
			set{ _LabelText=value;}
			get{return _LabelText;}
		}
		private string _IsNeed ;
		/// <summary>IsNeed
		/// 
		/// </summary>
		public string IsNeed
		{
			set{ _IsNeed=value;}
			get{return _IsNeed;}
		}
		private string _IsReadonly ;
		/// <summary>IsReadonly
		/// 
		/// </summary>
		public string IsReadonly
		{
			set{ _IsReadonly=value;}
			get{return _IsReadonly;}
		}
		private string _FiledText ;
		/// <summary>FiledText
		/// 
		/// </summary>
		public string FiledText
		{
			set{ _FiledText=value;}
			get{return _FiledText;}
		}
		private string _FiledValue ;
		/// <summary>FiledValue
		/// 
		/// </summary>
		public string FiledValue
		{
			set{ _FiledValue=value;}
			get{return _FiledValue;}
		}
		private string _DataSourse ;
		/// <summary>DataSourse
		/// 
		/// </summary>
		public string DataSourse
		{
			set{ _DataSourse=value;}
			get{return _DataSourse;}
		}
		private string _DefaultFiledText ;
		/// <summary>DefaultFiledText
		/// 
		/// </summary>
		public string DefaultFiledText
		{
			set{ _DefaultFiledText=value;}
			get{return _DefaultFiledText;}
		}
		private string _DefaultFiledValue ;
		/// <summary>DefaultFiledValue
		/// 
		/// </summary>
		public string DefaultFiledValue
		{
			set{ _DefaultFiledValue=value;}
			get{return _DefaultFiledValue;}
		}
		private string _DefaultDataSourse ;
		/// <summary>DefaultDataSourse
		/// 
		/// </summary>
		public string DefaultDataSourse
		{
			set{ _DefaultDataSourse=value;}
			get{return _DefaultDataSourse;}
		}
		private string _Remark ;
		/// <summary>Remark
		/// 
		/// </summary>
		public string Remark
		{
			set{ _Remark=value;}
			get{return _Remark;}
		}
		private int _State  = 0;
		/// <summary>State
		/// 
		/// </summary>
		public int State
		{
			set{ _State=value;}
			get{return _State;}
		}
		private DateTime _CreateDate  = DateTime.Now;
		/// <summary>CreateDate
		/// 
		/// </summary>
		public DateTime CreateDate
		{
			set{ _CreateDate=value;}
			get{return _CreateDate;}
		}
		private int _CreateUserId  = 0;
		/// <summary>CreateUserId
		/// 
		/// </summary>
		public int CreateUserId
		{
			set{ _CreateUserId=value;}
			get{return _CreateUserId;}
		}
	}
}
