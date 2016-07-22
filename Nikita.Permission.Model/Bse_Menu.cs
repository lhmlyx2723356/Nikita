using System;

namespace Nikita.Permission.Model
{
    /// <summary>Bse_Menu表实体类
    ///
    /// </summary>
    [Serializable]
    public class Bse_Menu
    {
        private int _AllowDelete = 1;

        private int _AllowEdit = 1;

        private int? _Bloc_Id;

        private string _BlocName;

        private string _Category = "Application";

        private int? _Company_Id;

        private string _CompanyName;

        private string _ControlPower;
        private DateTime _CreateDate = DateTime.Now;

        private string _CreateName;

        private int? _CreateUserId;

        private int _DeletionStateCode = 0;

        private int? _Dept_Id;

        private string _DeptName;

        private string _EditDate;

        private int? _EditUserId;

        private string _EditUserName;

        private int _Expand = 1;

        private string _FormName;
        private string _GroupTxt;

        private string _ImageIndex;

        private string _ImagUrl;

        private bool _IsPublic = true;

        private int _Module_Id;

        private string _Name;

        private string _NavigateUrl;

        private string _Number;

        private int? _ParentId;

        private string _PY;

        private string _Remark;

        private string _SelectedImageIndex;

        private int? _Sort;

        private int? _State = 1;

        private int? _SystemId;

        private string _Target = "fraContent";

        private string _TileItemSize;

        public Bse_Menu()
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

        /// <summary>类别
        ///
        /// </summary>
        public string Category
        {
            set { _Category = value; }
            get { return _Category; }
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

        /// <summary>目标窗体中打开
        ///
        /// </summary>
        public string ControlPower
        {
            set { _ControlPower = value; }
            get { return _ControlPower; }
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

        /// <summary>删除标志
        ///
        /// </summary>
        public int DeletionStateCode
        {
            set { _DeletionStateCode = value; }
            get { return _DeletionStateCode; }
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

        /// <summary>展开状态
        ///
        /// </summary>
        public int Expand
        {
            set { _Expand = value; }
            get { return _Expand; }
        }

        /// <summary>窗体名称
        ///
        /// </summary>
        public string FormName
        {
            set { _FormName = value; }
            get { return _FormName; }
        }

        /// <summary>分组名称
        ///
        /// </summary>
        public string GroupTxt
        {
            set { _GroupTxt = value; }
            get { return _GroupTxt; }
        }

        /// <summary>图表编号
        ///
        /// </summary>
        public string ImageIndex
        {
            set { _ImageIndex = value; }
            get { return _ImageIndex; }
        }

        /// <summary>图片地址
        ///
        /// </summary>
        public string ImagUrl
        {
            set { _ImagUrl = value; }
            get { return _ImagUrl; }
        }

        /// <summary>是否公开
        ///
        /// </summary>
        public bool IsPublic
        {
            set { _IsPublic = value; }
            get { return _IsPublic; }
        }

        /// <summary>主键
        ///
        /// </summary>
        public int Module_Id
        {
            set { _Module_Id = value; }
            get { return _Module_Id; }
        }

        /// <summary>名称
        ///
        /// </summary>
        public string Name
        {
            set { _Name = value; }
            get { return _Name; }
        }

        /// <summary>导航地址
        ///
        /// </summary>
        public string NavigateUrl
        {
            set { _NavigateUrl = value; }
            get { return _NavigateUrl; }
        }

        /// <summary>编号
        ///
        /// </summary>
        public string Number
        {
            set { _Number = value; }
            get { return _Number; }
        }

        /// <summary>父节点主键
        ///
        /// </summary>
        public int? ParentId
        {
            set { _ParentId = value; }
            get { return _ParentId; }
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

        /// <summary>选中状态图标编号
        ///
        /// </summary>
        public string SelectedImageIndex
        {
            set { _SelectedImageIndex = value; }
            get { return _SelectedImageIndex; }
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

        /// <summary>
        ///
        /// </summary>
        public int? SystemId
        {
            set { _SystemId = value; }
            get { return _SystemId; }
        }

        /// <summary>目标窗体中打开
        ///
        /// </summary>
        public string Target
        {
            set { _Target = value; }
            get { return _Target; }
        }

        /// <summary>
        ///
        /// </summary>
        public string TileItemSize
        {
            set { _TileItemSize = value; }
            get { return _TileItemSize; }
        }
    }
}