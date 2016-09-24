using System;

namespace Nikita.Permission.Model
{
    /// <summary>Bse_Organize表实体类
    ///
    /// </summary>
    [Serializable]
    public class Bse_Organize
    {
        private string _Address;

        private string _Bank;

        private string _BankAccount;

        private int? _Bloc_Id;

        private string _BlocName;

        private string _Category;

        private int? _Company_Id;

        private string _CompanyName;

        private DateTime _CreateDate = DateTime.Now;

        private string _CreateName;

        private int? _CreateUserId;

        private int? _DeletionStateCode = 0;

        private int? _Dept_Id;

        private string _DeptName;

        private string _EditDate;

        private int? _EditUserId;

        private string _EditUserName;

        private string _Fax;

        private string _InnerPhone;

        private int _IsInnerOrganize = 1;

        private int? _Layer;

        private string _Name;

        private string _Number;

        private int _Organize_Id;

        private string _OuterPhone;

        private int? _ParentId;

        private string _Postalcode;

        private string _PY;

        private string _Remark;

        private string _ShortName;

        private int? _Sort;

        private int? _State;

        private int? _SystemId;

        private string _Web;

        public Bse_Organize()
        { }

        /// <summary>地址
        ///
        /// </summary>
        public string Address
        {
            set { _Address = value; }
            get { return _Address; }
        }

        /// <summary>开户行
        ///
        /// </summary>
        public string Bank
        {
            set { _Bank = value; }
            get { return _Bank; }
        }

        /// <summary>银行账号
        ///
        /// </summary>
        public string BankAccount
        {
            set { _BankAccount = value; }
            get { return _BankAccount; }
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

        /// <summary>分类
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
        public int? DeletionStateCode
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

        /// <summary>传真
        ///
        /// </summary>
        public string Fax
        {
            set { _Fax = value; }
            get { return _Fax; }
        }

        /// <summary>内线电话
        ///
        /// </summary>
        public string InnerPhone
        {
            set { _InnerPhone = value; }
            get { return _InnerPhone; }
        }

        /// <summary>内部组织机构
        ///
        /// </summary>
        public int IsInnerOrganize
        {
            set { _IsInnerOrganize = value; }
            get { return _IsInnerOrganize; }
        }

        /// <summary>层
        ///
        /// </summary>
        public int? Layer
        {
            set { _Layer = value; }
            get { return _Layer; }
        }

        /// <summary>全称
        ///
        /// </summary>
        public string Name
        {
            set { _Name = value; }
            get { return _Name; }
        }

        /// <summary>编号
        ///
        /// </summary>
        public string Number
        {
            set { _Number = value; }
            get { return _Number; }
        }

        /// <summary>主键
        ///
        /// </summary>
        public int Organize_Id
        {
            set { _Organize_Id = value; }
            get { return _Organize_Id; }
        }

        /// <summary>外线电话
        ///
        /// </summary>
        public string OuterPhone
        {
            set { _OuterPhone = value; }
            get { return _OuterPhone; }
        }

        /// <summary>父级主键
        ///
        /// </summary>
        public int? ParentId
        {
            set { _ParentId = value; }
            get { return _ParentId; }
        }

        /// <summary>邮编
        ///
        /// </summary>
        public string Postalcode
        {
            set { _Postalcode = value; }
            get { return _Postalcode; }
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

        /// <summary>简称
        ///
        /// </summary>
        public string ShortName
        {
            set { _ShortName = value; }
            get { return _ShortName; }
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

        /// <summary>网址
        ///
        /// </summary>
        public string Web
        {
            set { _Web = value; }
            get { return _Web; }
        }
    }
}