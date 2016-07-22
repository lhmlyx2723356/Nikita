using System;

namespace Nikita.Assist.CodeMaker.Model
{
    /// <summary>Tb_SetOrd表实体类
    /// </summary>
    [Serializable]
    public class SetOrd
    {
        private int _id;

        private string _remark;

        private string _setOrdKey;

        private string _setOrdText;

        private int _state;

        /// <summary>id
        ///
        /// </summary>
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }

        /// <summary>Remark
        ///
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }

        /// <summary>SetOrdKey
        ///
        /// </summary>
        public string SetOrdKey
        {
            set { _setOrdKey = value; }
            get { return _setOrdKey; }
        }

        /// <summary>SetOrdText
        ///
        /// </summary>
        public string SetOrdText
        {
            set { _setOrdText = value; }
            get { return _setOrdText; }
        }

        /// <summary>State
        ///
        /// </summary>
        public int State
        {
            set { _state = value; }
            get { return _state; }
        }
    }
}