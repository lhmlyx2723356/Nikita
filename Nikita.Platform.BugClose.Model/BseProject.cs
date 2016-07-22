using System;
namespace Nikita.Platform.BugClose.Model
{
	/// <summary>BseProject表实体类
	/// 作者:卢华明
	/// 创建时间:2016-05-28 11:55:13
	/// </summary>
	[Serializable]
	public class BseProject
	{
		public BseProject()
		{}
		private int _ProjectID ;
		/// <summary>主键
		/// 
		/// </summary>
		public int ProjectID
		{
			set{ _ProjectID=value;}
			get{return _ProjectID;}
		}
		private string _Category ;
		/// <summary>项目分类
		/// 
		/// </summary>
		public string Category
		{
			set{ _Category=value;}
			get{return _Category;}
		}
		private string _Name ;
		/// <summary>项目名称
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
		private string _OnLevel ;
		/// <summary>项目级别
		/// 
		/// </summary>
		public string OnLevel
		{
			set{ _OnLevel=value;}
			get{return _OnLevel;}
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
