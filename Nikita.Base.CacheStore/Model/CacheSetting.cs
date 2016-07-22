using System;
namespace Nikita.Base.CacheStore.Model
{
	/// <summary>CacheSetting表实体类
	/// 作者:卢华明
	/// 创建时间:2016-06-30 21:56:03
	/// </summary>
	[Serializable]
	public class CacheSetting
	{
		public CacheSetting()
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
		private string _SetKey ;
		/// <summary>
		/// 
		/// </summary>
		public string SetKey
		{
			set{ _SetKey=value;}
			get{return _SetKey;}
		}
		private string _SetText ;
		/// <summary>
		/// 
		/// </summary>
		public string SetText
		{
			set{ _SetText=value;}
			get{return _SetText;}
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
	}
}
