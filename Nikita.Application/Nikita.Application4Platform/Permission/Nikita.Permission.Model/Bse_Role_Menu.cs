using System;

namespace Nikita.Permission.Model
{
    /// <summary>Bse_Role_Menu表实体类
    ///
    /// </summary>
    [Serializable]
    public class Bse_Role_Menu
    {
        private int _Account_Id;

        private string _Allowed_Operator;

        private int? _Bloc_Id;

        private string _BlocName;

        private int? _Company_Id;

        private string _CompanyName;

        private DateTime _CreateDate = DateTime.Now;

        private string _CreateName;

        private int? _CreateUserId;

        private int? _Dept_Id;

        private string _DeptName;

        private string _EditDate;

        private int? _EditUserId;

        private string _EditUserName;

        private int _Module_Id;

        private int _Role_Id;

        private int? _State = 1;

        private int? _SystemId;

        public Bse_Role_Menu()
        { }

        /// <summary>主键
        ///
        /// </summary>
        public int Account_Id
        {
            set { _Account_Id = value; }
            get { return _Account_Id; }
        }

        /// <summary>允许特殊权限
        ///
        /// </summary>
        public string Allowed_Operator
        {
            set { _Allowed_Operator = value; }
            get { return _Allowed_Operator; }
        }

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
        public DateTime CreateDate
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

        /// <summary>菜单ID
        ///
        /// </summary>
        public int Module_Id
        {
            set { _Module_Id = value; }
            get { return _Module_Id; }
        }

        /// <summary>角色ID
        ///
        /// </summary>
        public int Role_Id
        {
            set { _Role_Id = value; }
            get { return _Role_Id; }
        }

        /// <summary>状态
        ///
        /// </summary>
        public int? State
        {
            set { _State = value; }
            get { return _State; }
        }

        /// <summary>
        ///
        /// </summary>
        public int? SystemId
        {
            set { _SystemId = value; }
            get { return _SystemId; }
        }
    }
}