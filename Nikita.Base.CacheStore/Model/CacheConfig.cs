using System;
namespace Nikita.Base.CacheStore.Model
{
	/// <summary>CacheConfig表实体类
	/// 作者:卢华明
	/// 创建时间:2016-06-26 10:00:28
	/// </summary>
	[Serializable]
	public class CacheConfig
	{
		public CacheConfig()
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
		private string _ConnectionString ;
		/// <summary>
		/// 
		/// </summary>
		public string ConnectionString
		{
			set{ _ConnectionString=value;}
			get{return _ConnectionString;}
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
		private string _Filter ;
		/// <summary>
		/// 
		/// </summary>
		public string Filter
		{
			set{ _Filter=value;}
			get{return _Filter;}
		}
		private string _CacheTableName ;
		/// <summary>
		/// 
		/// </summary>
		public string CacheTableName
		{
			set{ _CacheTableName=value;}
			get{return _CacheTableName;}
		}
		private string _CacheChekGuid ;
		/// <summary>
		/// 
		/// </summary>
		public string CacheChekGuid
		{
			set{ _CacheChekGuid=value;}
			get{return _CacheChekGuid;}
		}
		private string _CacheVersion ;
		/// <summary>
		/// 
		/// </summary>
		public string CacheVersion
		{
			set{ _CacheVersion=value;}
			get{return _CacheVersion;}
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
		private DateTime _CreateDate = DateTime.Now;
		/// <summary>
		/// 
		/// </summary>
		public DateTime CreateDate
		{
			set{ _CreateDate=value;}
			get{return _CreateDate;}
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
