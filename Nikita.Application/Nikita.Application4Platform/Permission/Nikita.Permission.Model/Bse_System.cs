using System;

namespace Nikita.Permission.Model
{
    /// <summary>Bse_System表实体类
    ///
    /// </summary>
    [Serializable]
    public class Bse_System
    {
        private int? _Bloc_Id;

        private string _BlocName;

        private int? _Company_Id;

        private string _CompanyName;

        private DateTime? _CreateDate = DateTime.Now;

        private string _CreateName;

        private int? _CreateUserId;

        private string _CustNumber;

        private int? _Dept_Id;

        private string _DeptName;

        private string _EditDate;

        private int? _EditUserId;

        private string _EditUserName;

        private string _LimitNumber;

        private string _PY;

        private string _Remark;

        private int? _Sort;

        private int? _State = 1;

        private int _System_Id;

        private string _System_Language;

        private string _System_Name;

        private string _System_Type;

        private string _System_Version;

        public Bse_System()
        { }

        /// <summary>所属集团
        ///
        /// </summary>
        public int? Bloc_Id
        {
            set { _Bloc_Id = value; }
            get { return _Bloc_Id; }
        }

        /// <summary>集团名称
        ///
        /// </summary>
        public string BlocName
        {
            set { _BlocName = value; }
            get { return _BlocName; }
        }

        /// <summary>所属公司
        ///
        /// </summary>
        public int? Company_Id
        {
            set { _Company_Id = value; }
            get { return _Company_Id; }
        }

        /// <summary>公司名称
        ///
        /// </summary>
        public string CompanyName
        {
            set { _CompanyName = value; }
            get { return _CompanyName; }
        }

        /// <summary>创建时间
        ///
        /// </summary>
        public DateTime? CreateDate
        {
            set { _CreateDate = value; }
            get { return _CreateDate; }
        }

        /// <summary>创建人中文名
        ///
        /// </summary>
        public string CreateName
        {
            set { _CreateName = value; }
            get { return _CreateName; }
        }

        /// <summary>创建人
        ///
        /// </summary>
        public int? CreateUserId
        {
            set { _CreateUserId = value; }
            get { return _CreateUserId; }
        }

        /// <summary>客户编码
        ///
        /// </summary>
        public string CustNumber
        {
            set { _CustNumber = value; }
            get { return _CustNumber; }
        }

        /// <summary>所属部门
        ///
        /// </summary>
        public int? Dept_Id
        {
            set { _Dept_Id = value; }
            get { return _Dept_Id; }
        }

        /// <summary>部门名称
        ///
        /// </summary>
        public string DeptName
        {
            set { _DeptName = value; }
            get { return _DeptName; }
        }

        /// <summary>修改日期
        ///
        /// </summary>
        public string EditDate
        {
            set { _EditDate = value; }
            get { return _EditDate; }
        }

        /// <summary>修改人ID
        ///
        /// </summary>
        public int? EditUserId
        {
            set { _EditUserId = value; }
            get { return _EditUserId; }
        }

        /// <summary>修改人
        ///
        /// </summary>
        public string EditUserName
        {
            set { _EditUserName = value; }
            get { return _EditUserName; }
        }

        /// <summary>授权编码
        ///
        /// </summary>
        public string LimitNumber
        {
            set { _LimitNumber = value; }
            get { return _LimitNumber; }
        }

        /// <summary>简拼
        ///
        /// </summary>
        public string PY
        {
            set { _PY = value; }
            get { return _PY; }
        }

        /// <summary>备注
        ///
        /// </summary>
        public string Remark
        {
            set { _Remark = value; }
            get { return _Remark; }
        }

        /// <summary>排序
        ///
        /// </summary>
        public int? Sort
        {
            set { _Sort = value; }
            get { return _Sort; }
        }

        /// <summary>状态
        ///
        /// </summary>
        public int? State
        {
            set { _State = value; }
            get { return _State; }
        }

        /// <summary>主键
        ///
        /// </summary>
        public int System_Id
        {
            set { _System_Id = value; }
            get { return _System_Id; }
        }

        /// <summary>系统语言
        ///
        /// </summary>
        public string System_Language
        {
            set { _System_Language = value; }
            get { return _System_Language; }
        }

        /// <summary>名称
        ///
        /// </summary>
        public string System_Name
        {
            set { _System_Name = value; }
            get { return _System_Name; }
        }

        /// <summary>类型
        ///
        /// </summary>
        public string System_Type
        {
            set { _System_Type = value; }
            get { return _System_Type; }
        }

        /// <summary>系统版本
        ///
        /// </summary>
        public string System_Version
        {
            set { _System_Version = value; }
            get { return _System_Version; }
        }
    }
}