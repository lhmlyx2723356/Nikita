using System;
namespace Nikita.Core.Sample.Model
{
	/// <summary>T_Sample_Log表实体类
	/// 作者:UsTeam(QQ:871939149、944527357、363458293)
	/// 创建时间:2015-06-09 19:30:55
	/// </summary>
	[Serializable]
	public class T_Sample_Log
	{
		public T_Sample_Log()
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
		private DateTime _Date  = DateTime.Now;
		/// <summary>Date
		/// 
		/// </summary>
		public DateTime Date
		{
			set{ _Date=value;}
			get{return _Date;}
		}
		private string _Level ;
		/// <summary>Level
		/// 
		/// </summary>
		public string Level
		{
			set{ _Level=value;}
			get{return _Level;}
		}
		private string _Logger ;
		/// <summary>Logger
		/// 
		/// </summary>
		public string Logger
		{
			set{ _Logger=value;}
			get{return _Logger;}
		}
		private string _Message ;
		/// <summary>Message
		/// 
		/// </summary>
		public string Message
		{
			set{ _Message=value;}
			get{return _Message;}
		}
	}
}
