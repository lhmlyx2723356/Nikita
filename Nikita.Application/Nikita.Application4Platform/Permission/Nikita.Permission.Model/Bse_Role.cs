using System;

namespace Nikita.Permission.Model
{
    /// <summary>Bse_Role表实体类
    ///
    /// </summary>
    [Serializable]
    public class Bse_Role
    {
        private int _AllowDelete = 1;

        private int _AllowEdit = 1;

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

        private int _IsVisible = 1;

        private string _Name;

        private int? _OwnerCompany;

        private string _PY;

        private string _Remark;

        private int _Role_Id;

        private string _RoleNumber;

        private int? _Sort;

        private int? _State;

        private int? _SystemId;

        private string _Type;

        public Bse_Role()
        { }

        /// <summary>允许删除
        ///
        /// </summary>
        public int AllowDelete
        {
            set { _AllowDelete = value; }
            get { return _AllowDelete; }
        }

        /// <summary>允许编辑
        ///
        /// </summary>
        public int AllowEdit
        {
            set { _AllowEdit = value; }
            get { return _AllowEdit; }
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

        /// <summary>是否可见
        ///
        /// </summary>
        public int IsVisible
        {
            set { _IsVisible = value; }
            get { return _IsVisible; }
        }

        /// <summary>角色名称
        ///
        /// </summary>
        public string Name
        {
            set { _Name = value; }
            get { return _Name; }
        }

        /// <summary>所属公司
        ///
        /// </summary>
        public int? OwnerCompany
        {
            set { _OwnerCompany = value; }
            get { return _OwnerCompany; }
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

        /// <summary>主键
        ///
        /// </summary>
        public int Role_Id
        {
            set { _Role_Id = value; }
            get { return _Role_Id; }
        }

        /// <summary>角色编号
        ///
        /// </summary>
        public string RoleNumber
        {
            set { _RoleNumber = value; }
            get { return _RoleNumber; }
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

        /// <summary>系统主键
        ///
        /// </summary>
        public int? SystemId
        {
            set { _SystemId = value; }
            get { return _SystemId; }
        }

        /// <summary>角色分类
        ///
        /// </summary>
        public string Type
        {
            set { _Type = value; }
            get { return _Type; }
        }
    }
}