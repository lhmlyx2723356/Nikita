using System;

namespace Nikita.Assist.CodeMaker.Model
{
    /// <summary>Tb_Set表实体类
    /// </summary>
    [Serializable]
    public class Set
    {
        private int _id;

        private string _remark;

        private string _setKey;

        private string _setText;

        private string _setValue;

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

        /// <summary>SetKey
        ///
        /// </summary>
        public string SetKey
        {
            set { _setKey = value; }
            get { return _setKey; }
        }

        /// <summary>SetText
        ///
        /// </summary>
        public string SetText
        {
            set { _setText = value; }
            get { return _setText; }
        }

        /// <summary>SetValue
        ///
        /// </summary>
        public string SetValue
        {
            set { _setValue = value; }
            get { return _setValue; }
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