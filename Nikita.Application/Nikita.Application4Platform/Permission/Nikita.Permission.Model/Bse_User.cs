using System;

namespace Nikita.Permission.Model
{
    /// <summary>Bse_User表实体类
    ///
    /// </summary>
    [Serializable]
    public class Bse_User
    {
        private DateTime? _AllowEndTime;

        private DateTime? _AllowStartTime;

        private string _AnswerQuestion;

        private string _AuditStatus;

        private string _Birthday;

        private int? _Bloc_Id;

        private string _BlocName;

        private DateTime? _ChangePasswordDate;

        private int? _Company_Id;

        private string _CompanyName;

        private DateTime? _CreateDate = DateTime.Now;

        private string _CreateName;

        private int? _CreateUserId;

        private int? _Dept_Id;

        private string _DeptName;

        private string _Duty;

        private string _EditDate;

        private int? _EditUserId;

        private string _EditUserName;

        private string _Email;

        private DateTime? _FirstVisit;

        private string _HomeAddress;

        private string _HomeTel;

        private string _IPAddress;

        private int? _IsStaff = 1;

        private int? _IsVisible = 1;

        private string _Lang;

        private DateTime? _LastVisit;

        private DateTime? _LockEndDate;

        private DateTime? _LockStartDate;

        private int? _LogOnCount = 0;

        private string _MACAddress;

        private string _Mobile;

        private string _NiName;

        private string _Number;

        private string _Password;

        private DateTime? _PreviousVisit;

        private string _PY;

        private string _QQ;

        private string _Question;

        private string _Realname;

        private string _Remark;

        private string _Sex;

        private string _SFZNumber;

        private int? _Sort;

        private int? _State;

        private int? _SystemId;

        private string _Telephone;

        private string _Theme;

        private string _Title;

        private int _User_Id;

        private int? _UserAddressId;

        private string _UserFrom;

        private string _UserName;

        private string _WorkAddress;

        private string _WorkTel;

        public Bse_User()
        { }

        /// <summary>允许登录时间结束
        ///
        /// </summary>
        public DateTime? AllowEndTime
        {
            set { _AllowEndTime = value; }
            get { return _AllowEndTime; }
        }

        /// <summary>允许开始登录时间
        ///
        /// </summary>
        public DateTime? AllowStartTime
        {
            set { _AllowStartTime = value; }
            get { return _AllowStartTime; }
        }

        /// <summary>密码提示答案
        ///
        /// </summary>
        public string AnswerQuestion
        {
            set { _AnswerQuestion = value; }
            get { return _AnswerQuestion; }
        }

        /// <summary>审核状态（备用：可能有些需要审核才能让State等于可用状态）
        ///
        /// </summary>
        public string AuditStatus
        {
            set { _AuditStatus = value; }
            get { return _AuditStatus; }
        }

        /// <summary>生日
        ///
        /// </summary>
        public string Birthday
        {
            set { _Birthday = value; }
            get { return _Birthday; }
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

        /// <summary>最后一次修改日期
        ///
        /// </summary>
        public DateTime? ChangePasswordDate
        {
            set { _ChangePasswordDate = value; }
            get { return _ChangePasswordDate; }
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

        /// <summary>岗位
        ///
        /// </summary>
        public string Duty
        {
            set { _Duty = value; }
            get { return _Duty; }
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

        /// <summary>邮件
        ///
        /// </summary>
        public string Email
        {
            set { _Email = value; }
            get { return _Email; }
        }

        /// <summary>第一次访问时间
        ///
        /// </summary>
        public DateTime? FirstVisit
        {
            set { _FirstVisit = value; }
            get { return _FirstVisit; }
        }

        /// <summary>家庭住址
        ///
        /// </summary>
        public string HomeAddress
        {
            set { _HomeAddress = value; }
            get { return _HomeAddress; }
        }

        /// <summary>家庭电话
        ///
        /// </summary>
        public string HomeTel
        {
            set { _HomeTel = value; }
            get { return _HomeTel; }
        }

        /// <summary>IP地址
        ///
        /// </summary>
        public string IPAddress
        {
            set { _IPAddress = value; }
            get { return _IPAddress; }
        }

        /// <summary>是否职员
        ///
        /// </summary>
        public int? IsStaff
        {
            set { _IsStaff = value; }
            get { return _IsStaff; }
        }

        /// <summary>是否显示
        ///
        /// </summary>
        public int? IsVisible
        {
            set { _IsVisible = value; }
            get { return _IsVisible; }
        }

        /// <summary>系统语言选择
        ///
        /// </summary>
        public string Lang
        {
            set { _Lang = value; }
            get { return _Lang; }
        }

        /// <summary>最后一次登录时间
        ///
        /// </summary>
        public DateTime? LastVisit
        {
            set { _LastVisit = value; }
            get { return _LastVisit; }
        }

        /// <summary>暂停用户结束日期
        ///
        /// </summary>
        public DateTime? LockEndDate
        {
            set { _LockEndDate = value; }
            get { return _LockEndDate; }
        }

        /// <summary>暂停用户开始日期
        ///
        /// </summary>
        public DateTime? LockStartDate
        {
            set { _LockStartDate = value; }
            get { return _LockStartDate; }
        }

        /// <summary>登录次数
        ///
        /// </summary>
        public int? LogOnCount
        {
            set { _LogOnCount = value; }
            get { return _LogOnCount; }
        }

        /// <summary>MAC地址
        ///
        /// </summary>
        public string MACAddress
        {
            set { _MACAddress = value; }
            get { return _MACAddress; }
        }

        /// <summary>手机
        ///
        /// </summary>
        public string Mobile
        {
            set { _Mobile = value; }
            get { return _Mobile; }
        }

        /// <summary>用户昵称
        ///
        /// </summary>
        public string NiName
        {
            set { _NiName = value; }
            get { return _NiName; }
        }

        /// <summary>编号
        ///
        /// </summary>
        public string Number
        {
            set { _Number = value; }
            get { return _Number; }
        }

        /// <summary>密码
        ///
        /// </summary>
        public string Password
        {
            set { _Password = value; }
            get { return _Password; }
        }

        /// <summary>上一次访问时间
        ///
        /// </summary>
        public DateTime? PreviousVisit
        {
            set { _PreviousVisit = value; }
            get { return _PreviousVisit; }
        }

        /// <summary>简拼
        ///
        /// </summary>
        public string PY
        {
            set { _PY = value; }
            get { return _PY; }
        }

        /// <summary>QQ号码
        ///
        /// </summary>
        public string QQ
        {
            set { _QQ = value; }
            get { return _QQ; }
        }

        /// <summary>密码提示问题代码
        ///
        /// </summary>
        public string Question
        {
            set { _Question = value; }
            get { return _Question; }
        }

        /// <summary>真实名
        ///
        /// </summary>
        public string Realname
        {
            set { _Realname = value; }
            get { return _Realname; }
        }

        /// <summary>备注
        ///
        /// </summary>
        public string Remark
        {
            set { _Remark = value; }
            get { return _Remark; }
        }

        /// <summary>性别
        ///
        /// </summary>
        public string Sex
        {
            set { _Sex = value; }
            get { return _Sex; }
        }

        /// <summary>身份证
        ///
        /// </summary>
        public string SFZNumber
        {
            set { _SFZNumber = value; }
            get { return _SFZNumber; }
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

        /// <summary>电话
        ///
        /// </summary>
        public string Telephone
        {
            set { _Telephone = value; }
            get { return _Telephone; }
        }

        /// <summary>系统样式选择
        ///
        /// </summary>
        public string Theme
        {
            set { _Theme = value; }
            get { return _Theme; }
        }

        /// <summary>职称
        ///
        /// </summary>
        public string Title
        {
            set { _Title = value; }
            get { return _Title; }
        }

        /// <summary>主键
        ///
        /// </summary>
        public int User_Id
        {
            set { _User_Id = value; }
            get { return _User_Id; }
        }

        /// <summary>用户默认地址
        ///
        /// </summary>
        public int? UserAddressId
        {
            set { _UserAddressId = value; }
            get { return _UserAddressId; }
        }

        /// <summary>用户来源
        ///
        /// </summary>
        public string UserFrom
        {
            set { _UserFrom = value; }
            get { return _UserFrom; }
        }

        /// <summary>用户名
        ///
        /// </summary>
        public string UserName
        {
            set { _UserName = value; }
            get { return _UserName; }
        }

        /// <summary>
        ///
        /// </summary>
        public string WorkAddress
        {
            set { _WorkAddress = value; }
            get { return _WorkAddress; }
        }

        /// <summary>
        ///
        /// </summary>
        public string WorkTel
        {
            set { _WorkTel = value; }
            get { return _WorkTel; }
        }
    }
}