using System;
namespace Nikita.Platform.BugClose.Model
{
	/// <summary>BseDictionary表实体类
	/// 作者:卢华明
	/// 创建时间:2016-05-22 21:36:16
	/// </summary>
	[Serializable]
	public class BseDictionary
	{
		public BseDictionary()
		{}
		private int _Id ;
		/// <summary>主键
		/// 
		/// </summary>
		public int Id
		{
			set{ _Id=value;}
			get{return _Id;}
		}
		private int _ParentID  = 0;
		/// <summary>父级主键
		/// 
		/// </summary>
		public int ParentID
		{
			set{ _ParentID=value;}
			get{return _ParentID;}
		}
		private int? _OwerCompanyId ;
		/// <summary>所属公司
		/// 
		/// </summary>
		public int? OwerCompanyId
		{
			set{ _OwerCompanyId=value;}
			get{return _OwerCompanyId;}
		}
		private string _Name ;
		/// <summary>名称
		/// 
		/// </summary>
		public string Name
		{
			set{ _Name=value;}
			get{return _Name;}
		}
		private string _Value ;
		/// <summary>值
		/// 
		/// </summary>
		public string Value
		{
			set{ _Value=value;}
			get{return _Value;}
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
		private int? _OnLevel ;
		/// <summary>
		/// 
		/// </summary>
		public int? OnLevel
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
