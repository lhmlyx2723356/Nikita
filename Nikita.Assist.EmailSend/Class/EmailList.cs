using System;

namespace FrmEmailSend.Model
{
    /// <summary>EmailList表实体类
    /// </summary>
    [Serializable]
    public class EmailList
    {
        private string _createDate;
        private string _emailAddress;
        private int _id;
        private string _remark;

        /// <summary>CreateDate
        ///
        /// </summary>
        public string CreateDate
        {
            set { _createDate = value; }
            get { return _createDate; }
        }

        /// <summary>EmailAddress
        ///
        /// </summary>
        public string EmailAddress
        {
            set { _emailAddress = value; }
            get { return _emailAddress; }
        }

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
    }
}