using System;
namespace Nikita.Assist.WcfConfiguration.Model
{
	/// <summary>WcfConfigInfo表实体类
	/// 作者:
	/// 创建时间:2016-01-02 21:51:08
	/// </summary>
	[Serializable]
	public class WcfConfigInfo
	{
		public WcfConfigInfo()
		{}
		private int _id ;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		private string _WcfServiceName ;
		/// <summary>
		/// 
		/// </summary>
		public string WcfServiceName
		{
			set{ _WcfServiceName=value;}
			get{return _WcfServiceName;}
		}
		private string _WcfServiceClassName ;
		/// <summary>
		/// 
		/// </summary>
		public string WcfServiceClassName
		{
			set{ _WcfServiceClassName=value;}
			get{return _WcfServiceClassName;}
		}
		private string _WcfServiceInterfaceName ;
		/// <summary>
		/// 
		/// </summary>
		public string WcfServiceInterfaceName
		{
			set{ _WcfServiceInterfaceName=value;}
			get{return _WcfServiceInterfaceName;}
		}
		private string _WcfServiceNameSpace ;
		/// <summary>
		/// 
		/// </summary>
		public string WcfServiceNameSpace
		{
			set{ _WcfServiceNameSpace=value;}
			get{return _WcfServiceNameSpace;}
		}
		private string _BseUrl ;
		/// <summary>
		/// 
		/// </summary>
		public string BseUrl
		{
			set{ _BseUrl=value;}
			get{return _BseUrl;}
		}
		private string _EnpointBindUrl ;
		/// <summary>
		/// 
		/// </summary>
		public string EnpointBindUrl
		{
			set{ _EnpointBindUrl=value;}
			get{return _EnpointBindUrl;}
		}
		private string _WcfType ;
		/// <summary>
		/// 
		/// </summary>
		public string WcfType
		{
			set{ _WcfType=value;}
			get{return _WcfType;}
		}
		private int? _Percentage ;
		/// <summary>
		/// 
		/// </summary>
		public int? Percentage
		{
			set{ _Percentage=value;}
			get{return _Percentage;}
		}
		private int? _WcfGroup ;
		/// <summary>
		/// 
		/// </summary>
		public int? WcfGroup
		{
			set{ _WcfGroup=value;}
			get{return _WcfGroup;}
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
		private int? _State ;
		/// <summary>
		/// 
		/// </summary>
		public int? State
		{
			set{ _State=value;}
			get{return _State;}
		}
	}
}
