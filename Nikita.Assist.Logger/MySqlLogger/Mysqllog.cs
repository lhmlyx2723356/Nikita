using System;
namespace Nikita.Assist.Logger.Model
{
	/// <summary>mysqllog表实体类
	/// 作者:UsTeam(QQ:871939149、944527357、363458293)
	/// 创建时间:2015-08-16 18:52:15
	/// </summary>
	[Serializable]
	public class Mysqllog
	{
		public Mysqllog()
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
		private DateTime _Date ;
		/// <summary>
		/// 
		/// </summary>
		public DateTime Date
		{
			set{ _Date=value;}
			get{return _Date;}
		}
		private string _Level ;
		/// <summary>
		/// 
		/// </summary>
		public string Level
		{
			set{ _Level=value;}
			get{return _Level;}
		}
		private string _Logger ;
		/// <summary>
		/// 
		/// </summary>
		public string Logger
		{
			set{ _Logger=value;}
			get{return _Logger;}
		}
		private string _Message ;
		/// <summary>
		/// 
		/// </summary>
		public string Message
		{
			set{ _Message=value;}
			get{return _Message;}
		}
	}
}
