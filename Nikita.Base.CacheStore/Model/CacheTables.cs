using System;
namespace Nikita.Base.CacheStore.Model
{
	/// <summary>CacheTables表实体类
	/// 作者:卢华明
	/// 创建时间:2016-06-26 09:32:22
	/// </summary>
	[Serializable]
	public class CacheTables
	{
		public CacheTables()
		{}
		private int _Id ;
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			set{ _Id=value;}
			get{return _Id;}
		}
		private string _TableName ;
		/// <summary>
		/// 
		/// </summary>
		public string TableName
		{
			set{ _TableName=value;}
			get{return _TableName;}
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
		private int _Status  = 1;
		/// <summary>
		/// 
		/// </summary>
		public int Status
		{
			set{ _Status=value;}
			get{return _Status;}
		}
	}
}
