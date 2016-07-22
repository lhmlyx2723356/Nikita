using System;
namespace Nikita.Assist.CodeMaker.Model
{
	/// <summary>OrderMaster表实体类
	/// 作者:卢华明
	/// 创建时间:2016-05-10 20:46:36
	/// </summary>
	[Serializable]
	public class OrderMaster
	{
		public OrderMaster()
		{}
		private int _OrderId ;
		/// <summary>
		/// 
		/// </summary>
		public int OrderId
		{
			set{ _OrderId=value;}
			get{return _OrderId;}
		}
		private string _OrderNumber ;
		/// <summary>
		/// 
		/// </summary>
		public string OrderNumber
		{
			set{ _OrderNumber=value;}
			get{return _OrderNumber;}
		}
		private bool _Status  = true;
		/// <summary>
		/// 
		/// </summary>
		public bool Status
		{
			set{ _Status=value;}
			get{return _Status;}
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
	}
}
