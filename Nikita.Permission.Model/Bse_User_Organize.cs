using System;

namespace Nikita.Permission.Model
{
    /// <summary>Bse_User_Organize表实体类
    ///
    /// </summary>
    [Serializable]
    public class Bse_User_Organize
    {
        private int? _Bloc_Id;

        private string _BlocName;

        private int? _Company_Id;

        private string _CompanyName;

        private DateTime _CreateDate = DateTime.Now;

        private string _CreateName;

        private int? _CreateUserId;

        private int? _DeletionStateCode;

        private int? _Dept_Id;

        private string _DeptName;

        private string _EditDate;

        private int? _EditUserId;

        private string _EditUserName;

        private int? _Organize_Id;

        private string _Remark;

        private int? _Sort;

        private int? _State;

        private string _SystemId;

        private int? _User_Id;

        private int _User_Organize_Id;

        public Bse_User_Organize()
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

        /// <summary>组织机构ID
        ///
        /// </summary>
        public int? Organize_Id
        {
            set { _Organize_Id = value; }
            get { return _Organize_Id; }
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

        /// <summary>
        ///
        /// </summary>
        public string SystemId
        {
            set { _SystemId = value; }
            get { return _SystemId; }
        }

        /// <summary>用户ID
        ///
        /// </summary>
        public int? User_Id
        {
            set { _User_Id = value; }
            get { return _User_Id; }
        }

        /// <summary>主键
        ///
        /// </summary>
        public int User_Organize_Id
        {
            set { _User_Organize_Id = value; }
            get { return _User_Organize_Id; }
        }
    }
}