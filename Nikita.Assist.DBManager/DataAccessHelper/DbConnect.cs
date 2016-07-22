using System;

namespace Nikita.Assist.DBManager.Model
{
    /// <summary>DbConnect表实体类
    ///
    /// </summary>
    [Serializable]
    public class DbConnect
    {
        private string _Column1;

        private string _CreateDate;

        private int _id = 0;

        private string _IP;

        private string _Pwd;

        private string _Remark;

        private string _User;

        public DbConnect()
        { }

        /// <summary>Column1
        ///
        /// </summary>
        public string Column1
        {
            set { _Column1 = value; }
            get { return _Column1; }
        }

        /// <summary>CreateDate
        ///
        /// </summary>
        public string CreateDate
        {
            set { _CreateDate = value; }
            get { return _CreateDate; }
        }

        /// <summary>id
        ///
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }

        /// <summary>IP
        ///
        /// </summary>
        public string IP
        {
            set { _IP = value; }
            get { return _IP; }
        }

        /// <summary>Pwd
        ///
        /// </summary>
        public string Pwd
        {
            set { _Pwd = value; }
            get { return _Pwd; }
        }

        /// <summary>Remark
        ///
        /// </summary>
        public string Remark
        {
            set { _Remark = value; }
            get { return _Remark; }
        }

        /// <summary>User
        ///
        /// </summary>
        public string User
        {
            set { _User = value; }
            get { return _User; }
        }
    }
}