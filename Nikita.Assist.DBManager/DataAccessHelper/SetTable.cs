using System;

namespace Nikita.Assist.DBManager.Model
{
    /// <summary>Tb_SetTable表实体类
    ///
    /// </summary>
    [Serializable]
    public class SetTable
    {
        private string _ChangLiang;

        private int _id = 0;

        private string _Remark;

        private string _SetKey;

        private string _SetText;

        private string _SetValue;

        private int _State = 0;

        public SetTable()
        { }

        /// <summary>Remark
        ///
        /// </summary>
        public string ChangLiang
        {
            set { _ChangLiang = value; }
            get { return _ChangLiang; }
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

        /// <summary>SetKey
        ///
        /// </summary>
        public string SetKey
        {
            set { _SetKey = value; }
            get { return _SetKey; }
        }

        /// <summary>SetText
        ///
        /// </summary>
        public string SetText
        {
            set { _SetText = value; }
            get { return _SetText; }
        }

        /// <summary>SetValue
        ///
        /// </summary>
        public string SetValue
        {
            set { _SetValue = value; }
            get { return _SetValue; }
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