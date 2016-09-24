using System;
namespace Nikita.Core.Sample.Model
{
	/// <summary>T_Sample_Menu表实体类
	/// 作者:UsTeam(QQ:871939149、944527357、363458293)
	/// 创建时间:2015-06-06 14:48:22
	/// </summary>
	[Serializable]
	public class T_Sample_Menu 
	{
		public T_Sample_Menu()
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
		private int _ParentId  = 0;
		/// <summary>ParentId
		/// 
		/// </summary>
		public int ParentId
		{
			set{ _ParentId=value;}
			get{return _ParentId;}
		}
		private string _MenuClass ;
		/// <summary>MenuClass
		/// 
		/// </summary>
		public string MenuClass
		{
			set{ _MenuClass=value;}
			get{return _MenuClass;}
		}
		private string _MenuName ;
		/// <summary>MenuName
		/// 
		/// </summary>
		public string MenuName
		{
			set{ _MenuName=value;}
			get{return _MenuName;}
		}
		private string _MenuIcon ;
		/// <summary>MenuIcon
		/// 
		/// </summary>
		public string MenuIcon
		{
			set{ _MenuIcon=value;}
			get{return _MenuIcon;}
		}
		private int _State  = 0;
		/// <summary>State
		/// 
		/// </summary>
		public int State
		{
			set{ _State=value;}
			get{return _State;}
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
		private string _Fileld1 ;
		/// <summary>Fileld1
		/// 
		/// </summary>
		public string Fileld1
		{
			set{ _Fileld1=value;}
			get{return _Fileld1;}
		}
		private string _Field2 ;
		/// <summary>Field2
		/// 
		/// </summary>
		public string Field2
		{
			set{ _Field2=value;}
			get{return _Field2;}
		}
		private string _Field3 ;
		/// <summary>Field3
		/// 
		/// </summary>
		public string Field3
		{
			set{ _Field3=value;}
			get{return _Field3;}
		}
		private string _Field4 ;
		/// <summary>Field4
		/// 
		/// </summary>
		public string Field4
		{
			set{ _Field4=value;}
			get{return _Field4;}
		}
		private string _Field5 ;
		/// <summary>Field5
		/// 
		/// </summary>
		public string Field5
		{
			set{ _Field5=value;}
			get{return _Field5;}
		}
	}
}
