using System;
namespace Nikita.Assist.CodeMaker.Model
{
	/// <summary>Sys_Roles表实体类
	/// 作者:
	/// 创建时间:2016-04-24 20:16:31
	/// </summary>
	[Serializable]
	public class Sys_Roles
	{
		public Sys_Roles()
		{}
		private int _KeyId ;
		/// <summary>
		/// 
		/// </summary>
		public int KeyId
		{
			set{ _KeyId=value;}
			get{return _KeyId;}
		}
		private string _RoleName ;
		/// <summary>
		/// 
		/// </summary>
		public string RoleName
		{
			set{ _RoleName=value;}
			get{return _RoleName;}
		}
		private int? _Sortnum ;
		/// <summary>
		/// 
		/// </summary>
		public int? Sortnum
		{
			set{ _Sortnum=value;}
			get{return _Sortnum;}
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
		private int? _isDefault ;
		/// <summary>
		/// 
		/// </summary>
		public int? isDefault
		{
			set{ _isDefault=value;}
			get{return _isDefault;}
		}
	}
}
