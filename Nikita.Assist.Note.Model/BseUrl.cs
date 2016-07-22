using System;
namespace Nikita.Assist.Note.Model
{
	/// <summary>BseUrl表实体类
	/// 作者:卢华明
	/// 创建时间:2016-06-19 11:46:04
	/// </summary>
	[Serializable]
	public class BseUrl
	{
		public BseUrl()
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
		private string _Type ;
		/// <summary>
		/// 
		/// </summary>
		public string Type
		{
			set{ _Type=value;}
			get{return _Type;}
		}
		private string _UrlTitle ;
		/// <summary>
		/// 
		/// </summary>
		public string UrlTitle
		{
			set{ _UrlTitle=value;}
			get{return _UrlTitle;}
		}
		private string _Url ;
		/// <summary>
		/// 
		/// </summary>
		public string Url
		{
			set{ _Url=value;}
			get{return _Url;}
		}
		private string _UrlContent ;
		/// <summary>
		/// 
		/// </summary>
		public string UrlContent
		{
			set{ _UrlContent=value;}
			get{return _UrlContent;}
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
		private DateTime _CreateDate = DateTime.Now;
		/// <summary>
		/// 
		/// </summary>
		public DateTime CreateDate
		{
			set{ _CreateDate=value;}
			get{return _CreateDate;}
		}
	}
}
