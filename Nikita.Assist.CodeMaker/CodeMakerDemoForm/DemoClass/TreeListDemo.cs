using System;
namespace Nikita.Assist.CodeMaker.Model
{
	/// <summary>TreeListDemo表实体类
	/// 作者:卢华明
	/// 创建时间:2016-05-07 19:27:44
	/// </summary>
	[Serializable]
	public class TreeListDemo
	{
		public TreeListDemo()
		{}
		private int _Id ;
		/// <summary>扣型ID
		/// 
		/// </summary>
		public int Id
		{
			set{ _Id=value;}
			get{return _Id;}
		}
		private int _ParentId ;
		/// <summary>父级ID
		/// 
		/// </summary>
		public int ParentId
		{
			set{ _ParentId=value;}
			get{return _ParentId;}
		}
		private string _Name ;
		/// <summary>扣型名称
		/// 
		/// </summary>
		public string Name
		{
			set{ _Name=value;}
			get{return _Name;}
		}
		private string _Value ;
		/// <summary>扣型值
		/// 
		/// </summary>
		public string Value
		{
			set{ _Value=value;}
			get{return _Value;}
		}
		private int _OnLevel ;
		/// <summary>扣型级别
		/// 
		/// </summary>
		public int OnLevel
		{
			set{ _OnLevel=value;}
			get{return _OnLevel;}
		}
		private int _OwerCompanyId  = 1;
		/// <summary>所属工厂ID 
		/// 
		/// </summary>
		public int OwerCompanyId
		{
			set{ _OwerCompanyId=value;}
			get{return _OwerCompanyId;}
		}
		private bool _Status  = true;
		/// <summary>状态
		/// 
		/// </summary>
		public bool Status
		{
			set{ _Status=value;}
			get{return _Status;}
		}
		private string _Remark ;
		/// <summary>备注
		/// 
		/// </summary>
		public string Remark
		{
			set{ _Remark=value;}
			get{return _Remark;}
		}
		private int? _Dept_Id ;
		/// <summary>所属部门
		/// 
		/// </summary>
		public int? Dept_Id
		{
			set{ _Dept_Id=value;}
			get{return _Dept_Id;}
		}
		private int? _Company_Id ;
		/// <summary>所属公司
		/// 
		/// </summary>
		public int? Company_Id
		{
			set{ _Company_Id=value;}
			get{return _Company_Id;}
		}
		private string _CreateUser ;
		/// <summary>创建人中文名
		/// 
		/// </summary>
		public string CreateUser
		{
			set{ _CreateUser=value;}
			get{return _CreateUser;}
		}
		private DateTime _CreateDate = DateTime.Now;
		/// <summary>创建时间
		/// 
		/// </summary>
		public DateTime CreateDate
		{
			set{ _CreateDate=value;}
			get{return _CreateDate;}
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
		private DateTime? _EditDate ;
		/// <summary>
		/// 
		/// </summary>
		public DateTime? EditDate
		{
			set{ _EditDate=value;}
			get{return _EditDate;}
		}
	}
}
