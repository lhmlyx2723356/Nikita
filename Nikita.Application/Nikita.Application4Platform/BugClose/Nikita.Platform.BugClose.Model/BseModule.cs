using System;
namespace Nikita.Platform.BugClose.Model
{
	/// <summary>BseModule表实体类
	/// 作者:卢华明
	/// 创建时间:2016-06-05 18:22:34
	/// </summary>
	[Serializable]
	public class BseModule
	{
		public BseModule()
		{}
		private int _ModuleID ;
		/// <summary>
		/// 
		/// </summary>
		public int ModuleID
		{
			set{ _ModuleID=value;}
			get{return _ModuleID;}
		}
		private int? _ProjectID ;
		/// <summary>
		/// 
		/// </summary>
		public int? ProjectID
		{
			set{ _ProjectID=value;}
			get{return _ProjectID;}
		}
		private string _Name ;
		/// <summary>
		/// 
		/// </summary>
		public string Name
		{
			set{ _Name=value;}
			get{return _Name;}
		}
		private int? _Status  = 1;
		/// <summary>
		/// 
		/// </summary>
		public int? Status
		{
			set{ _Status=value;}
			get{return _Status;}
		}
		private string _Remark ;
		/// <summary>
		/// 
		/// </summary>
		public string Remark
		{
			set{ _Remark=value;}
			get{return _Remark;}
		}
		private int? _Sort  = 0;
		/// <summary>
		/// 
		/// </summary>
		public int? Sort
		{
			set{ _Sort=value;}
			get{return _Sort;}
		}
		private int? _DeptId ;
		/// <summary>
		/// 
		/// </summary>
		public int? DeptId
		{
			set{ _DeptId=value;}
			get{return _DeptId;}
		}
		private int? _CompanyID ;
		/// <summary>
		/// 
		/// </summary>
		public int? CompanyID
		{
			set{ _CompanyID=value;}
			get{return _CompanyID;}
		}
		private DateTime? _CreateDate = DateTime.Now;
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreateDate
		{
			set{ _CreateDate=value;}
			get{return _CreateDate;}
		}
		private string _CreateUser ;
		/// <summary>
		/// 
		/// </summary>
		public string CreateUser
		{
			set{ _CreateUser=value;}
			get{return _CreateUser;}
		}
		private DateTime? _EditDate ;
		/// <summary>
		/// 
		/// </summary>
		public DateTime? EditDate
		{
			set{ _EditDate=value;}
			get{return _EditDate;}
		}
		private string _EditUser ;
		/// <summary>
		/// 
		/// </summary>
		public string EditUser
		{
			set{ _EditUser=value;}
			get{return _EditUser;}
		}
	}
}
