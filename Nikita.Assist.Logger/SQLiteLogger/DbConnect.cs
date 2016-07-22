using System;
namespace Nikita.Assist.Logger.Model
{
	/// <summary>DbConnect表实体类
	/// 作者:UsTeam(QQ:871939149、944527357、363458293)
	/// 创建时间:2015-08-18 20:46:04
	/// </summary>
	[Serializable]
	public class DbConnect
	{
		public DbConnect()
		{}
		private int _id  = 0;
		/// <summary>id
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		private string _IP ;
		/// <summary>IP
		/// 
		/// </summary>
		public string IP
		{
			set{ _IP=value;}
			get{return _IP;}
		}
		private string _User ;
		/// <summary>User
		/// 
		/// </summary>
		public string User
		{
			set{ _User=value;}
			get{return _User;}
		}
		private string _Pwd ;
		/// <summary>Pwd
		/// 
		/// </summary>
		public string Pwd
		{
			set{ _Pwd=value;}
			get{return _Pwd;}
		}
		private string _CreateDate ;
		/// <summary>CreateDate
		/// 
		/// </summary>
		public string CreateDate
		{
			set{ _CreateDate=value;}
			get{return _CreateDate;}
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
		private string _Column1 ;
		/// <summary>Column1
		/// 
		/// </summary>
		public string Column1
		{
			set{ _Column1=value;}
			get{return _Column1;}
		}
	}
}
