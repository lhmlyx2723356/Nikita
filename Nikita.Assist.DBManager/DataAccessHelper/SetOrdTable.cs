using System;

namespace Nikita.Assist.DBManager.Model
{
    /// <summary>Tb_SetOrdTable表实体类
    ///
    /// </summary>
    [Serializable]
    public class SetOrdTable
    {
        private string _AllowWorkType;

        private int _id = 0;

        private string _Remark;

        private string _SetOrdKey;

        private string _SetOrdText;

        private int _State = 0;

        public SetOrdTable()
        { }

        /// <summary>AllowWorkType
        ///
        /// </summary>
        public string AllowWorkType
        {
            set { _AllowWorkType = value; }
            get { return _AllowWorkType; }
        }

        /// <summary>id
        ///
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }

        /// <summary>Remark
        ///
        /// </summary>
        public string Remark
        {
            set { _Remark = value; }
            get { return _Remark; }
        }

        /// <summary>SetOrdKey
        ///
        /// </summary>
        public string SetOrdKey
        {
            set { _SetOrdKey = value; }
            get { return _SetOrdKey; }
        }

        /// <summary>SetOrdText
        ///
        /// </summary>
        public string SetOrdText
        {
            set { _SetOrdText = value; }
            get { return _SetOrdText; }
        }

        /// <summary>State
        ///
        /// </summary>
        public int State
        {
            set { _State = value; }
            get { return _State; }
        }
    }
}