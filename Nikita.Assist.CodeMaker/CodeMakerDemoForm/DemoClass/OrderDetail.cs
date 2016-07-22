using System;
namespace Nikita.Assist.CodeMaker.Model
{
	/// <summary>OrderDetail表实体类
	/// 作者:卢华明
	/// 创建时间:2016-05-10 20:46:23
	/// </summary>
	[Serializable]
	public class OrderDetail
	{
		public OrderDetail()
		{}
		private int _DetailId ;
		/// <summary>
		/// 
		/// </summary>
		public int DetailId
		{
			set{ _DetailId=value;}
			get{return _DetailId;}
		}
		private int _OrderId ;
		/// <summary>
		/// 
		/// </summary>
		public int OrderId
		{
			set{ _OrderId=value;}
			get{return _OrderId;}
		}
		private string _Customer ;
		/// <summary>
		/// 
		/// </summary>
		public string Customer
		{
			set{ _Customer=value;}
			get{return _Customer;}
		}
		private string _ProductName ;
		/// <summary>
		/// 
		/// </summary>
		public string ProductName
		{
			set{ _ProductName=value;}
			get{return _ProductName;}
		}
		private int? _Amount ;
		/// <summary>
		/// 
		/// </summary>
		public int? Amount
		{
			set{ _Amount=value;}
			get{return _Amount;}
		}
		private double? _SumMoney ;
		/// <summary>
		/// 
		/// </summary>
		public double? SumMoney
		{
			set{ _SumMoney=value;}
			get{return _SumMoney;}
		}
		private bool? _Status  = true;
		/// <summary>
		/// 
		/// </summary>
		public bool? Status
		{
			set{ _Status=value;}
			get{return _Status;}
		}
	}
}
