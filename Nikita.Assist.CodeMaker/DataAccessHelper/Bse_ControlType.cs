using System;
namespace Nikita.Assist.CodeMaker.Model
{
	/// <summary>Bse_ControlType表实体类
	/// 作者:
	/// 创建时间:2016-02-04 12:04:21
	/// </summary>
	[Serializable]
	public class Bse_ControlType
	{
		public Bse_ControlType()
		{}
		private int _Ctl_Id  = 0;
		/// <summary>Ctl_Id
		/// 
		/// </summary>
		public int Ctl_Id
		{
			set{ _Ctl_Id=value;}
			get{return _Ctl_Id;}
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
		private string _Ctl_Name ;
		/// <summary>Ctl_Name
		/// 
		/// </summary>
		public string Ctl_Name
		{
			set{ _Ctl_Name=value;}
			get{return _Ctl_Name;}
		}
		private string _Ctl_NameSpace ;
		/// <summary>Ctl_NameSpace
		/// 
		/// </summary>
		public string Ctl_NameSpace
		{
			set{ _Ctl_NameSpace=value;}
			get{return _Ctl_NameSpace;}
		}
		private int _Ctl_Width  = 0;
		/// <summary>Ctl_Width
		/// 
		/// </summary>
		public int Ctl_Width
		{
			set{ _Ctl_Width=value;}
			get{return _Ctl_Width;}
		}
		private int _Ctl_Height  = 0;
		/// <summary>Ctl_Height
		/// 
		/// </summary>
		public int Ctl_Height
		{
			set{ _Ctl_Height=value;}
			get{return _Ctl_Height;}
		}
		private string _Ctl_Type ;
		/// <summary>Ctl_Type
		/// 
		/// </summary>
		public string Ctl_Type
		{
			set{ _Ctl_Type=value;}
			get{return _Ctl_Type;}
		}
		private string _State ;
		/// <summary>State
		/// 
		/// </summary>
		public string State
		{
			set{ _State=value;}
			get{return _State;}
		}
		private int _Sort  = 0;
		/// <summary>Sort
		/// 
		/// </summary>
		public int Sort
		{
			set{ _Sort=value;}
			get{return _Sort;}
		}
		private string _Type ;
		/// <summary>Type
		/// 
		/// </summary>
		public string Type
		{
			set{ _Type=value;}
			get{return _Type;}
		}
		private string _IsSelf ;
		/// <summary>IsSelf
		/// 
		/// </summary>
		public string IsSelf
		{
			set{ _IsSelf=value;}
			get{return _IsSelf;}
		}
	}
}
