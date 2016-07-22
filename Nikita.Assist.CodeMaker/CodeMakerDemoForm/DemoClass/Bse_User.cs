using System;
namespace Nikita.Assist.CodeMaker.Model
{
	/// <summary>Bse_User表实体类
	/// 作者:
	/// 创建时间:2016-01-31 19:08:26
	/// </summary>
	[Serializable]
	public class Bse_User
	{
		public Bse_User()
		{}
		private int _User_Id ;
		/// <summary>主键
		/// 
		/// </summary>
		public int User_Id
		{
			set{ _User_Id=value;}
			get{return _User_Id;}
		}
		private string _UserName ;
		/// <summary>用户名
		/// 
		/// </summary>
		public string UserName
		{
			set{ _UserName=value;}
			get{return _UserName;}
		}
		private string _Password ;
		/// <summary>密码
		/// 
		/// </summary>
		public string Password
		{
			set{ _Password=value;}
			get{return _Password;}
		}
		private string _TrueName ;
		/// <summary>真实名称
		/// 
		/// </summary>
		public string TrueName
		{
			set{ _TrueName=value;}
			get{return _TrueName;}
		}
		private string _Company ;
		/// <summary>公司名称
		/// 
		/// </summary>
		public string Company
		{
			set{ _Company=value;}
			get{return _Company;}
		}
		private DateTime? _CreateDate = DateTime.Now;
		/// <summary>创建时间
		/// 
		/// </summary>
		public DateTime? CreateDate
		{
			set{ _CreateDate=value;}
			get{return _CreateDate;}
		}
		private int? _State  = 1;
		/// <summary>状态
		/// 
		/// </summary>
		public int? State
		{
			set{ _State=value;}
			get{return _State;}
		}
	}
}
