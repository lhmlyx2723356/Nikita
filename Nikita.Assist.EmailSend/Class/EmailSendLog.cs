using System;

namespace FrmEmailSend.Model
{
    /// <summary>EmailSendLog表实体类
    /// </summary>
    [Serializable]
    public class EmailSendLog
    {
        private string _createDate;
        private string _emailFromAddress;
        private string _emailSubject;
        private string _emailToAddress;
        private int _id;
        private string _isSuccess;

        private string _remark;

        /// <summary>CreateDate
        ///
        /// </summary>
        public string CreateDate
        {
            set { _createDate = value; }
            get { return _createDate; }
        }

        /// <summary>EmailFromAddress
        ///
        /// </summary>
        public string EmailFromAddress
        {
            set { _emailFromAddress = value; }
            get { return _emailFromAddress; }
        }

        /// <summary>EmailSubject
        ///
        /// </summary>
        public string EmailSubject
        {
            set { _emailSubject = value; }
            get { return _emailSubject; }
        }

        /// <summary>EmailToAddress
        ///
        /// </summary>
        public string EmailToAddress
        {
            set { _emailToAddress = value; }
            get { return _emailToAddress; }
        }

        /// <summary>id
        ///
        /// </summary>
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }

        /// <summary>IsSuccess
        ///
        /// </summary>
        public string IsSuccess
        {
            set { _isSuccess = value; }
            get { return _isSuccess; }
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