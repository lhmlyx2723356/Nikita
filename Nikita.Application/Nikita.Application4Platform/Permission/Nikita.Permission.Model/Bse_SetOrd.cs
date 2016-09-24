using System;

namespace Nikita.Permission.Model
{
    /// <summary>Bse_SetOrd表实体类
    ///
    /// </summary>
    [Serializable]
    public class Bse_SetOrd
    {
        private int? _Bloc_Id;

        private int? _Company_Id;

        private DateTime _CreateDate = DateTime.Now;

        private string _CreateName;

        private int? _CreateUserId;

        private int? _Dept_Id;

        private string _Name;

        private string _PY;

        private string _Remark;

        private int _SetOrd_Id;

        private string _SetOrd_Key;

        private int? _Sort;

        private int? _State;

        private int _SystemId;

        public Bse_SetOrd()
        { }

        /// <summary>所属集团
        ///
        /// </summary>
        public int? Bloc_Id
        {
            set { _Bloc_Id = value; }
            get { return _Bloc_Id; }
        }

        /// <summary>所属公司
        ///
        /// </summary>
        public int? Company_Id
        {
            set { _Company_Id = value; }
            get { return _Company_Id; }
        }

        /// <summary>
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

        /// <summary>
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

        /// <summary>名称
        ///
        /// </summary>
        public string Name
        {
            set { _Name = value; }
            get { return _Name; }
        }

        /// <summary>简拼
        ///
        /// </summary>
        public string PY
        {
            set { _PY = value; }
            get { return _PY; }
        }

        /// <summary>
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
        public int SetOrd_Id
        {
            set { _SetOrd_Id = value; }
            get { return _SetOrd_Id; }
        }

        /// <summary>键值
        ///
        /// </summary>
        public string SetOrd_Key
        {
            set { _SetOrd_Key = value; }
            get { return _SetOrd_Key; }
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
        public int SystemId
        {
            set { _SystemId = value; }
            get { return _SystemId; }
        }
    }
}