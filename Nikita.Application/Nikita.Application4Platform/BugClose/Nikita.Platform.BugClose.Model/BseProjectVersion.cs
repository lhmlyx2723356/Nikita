using System;
namespace Nikita.Platform.BugClose.Model
{
	/// <summary>BseProjectVersion表实体类
	/// 作者:卢华明
	/// 创建时间:2016-06-04 17:21:23
	/// </summary>
	[Serializable]
	public class BseProjectVersion
	{
		public BseProjectVersion()
		{}
		private int _VersionID ;
		/// <summary>主键
		/// 
		/// </summary>
		public int VersionID
		{
			set{ _VersionID=value;}
			get{return _VersionID;}
		}
		private int _ProjectID ;
		/// <summary>所属项目
		/// 
		/// </summary>
		public int ProjectID
		{
			set{ _ProjectID=value;}
			get{return _ProjectID;}
		}
		private string _Name ;
		/// <summary>版本名称
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
