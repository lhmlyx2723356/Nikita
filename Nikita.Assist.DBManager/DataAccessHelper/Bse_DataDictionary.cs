using System;

namespace Nikita.Assist.DBManager.Model
{
    /// <summary>Bse_DataDictionary表实体类
    ///
    /// </summary>
    [Serializable]
    public class Bse_DataDictionary
    {
        private string _ColumnAllowNull;

        private string _ColumnDefaultValue;

        private string _ColumnHistory;

        private string _ColumnIdentity;

        private string _ColumnLength;

        private string _ColumnName;

        private string _ColumnPK;

        private string _ColumnRemark;

        private string _ColumnScale;

        private string _ColumnSpace;

        private string _ColumnType;

        private DateTime? _CreateTime = DateTime.Now;

        private string _CreateUser;

        private string _DatabaseName;

        private string _DbType;

        private int _id;

        private DateTime? _LastEditTime;

        private string _LastEditUser;

        private string _OperationType;

        private string _ServerName;

        private int? _Status = 1;

        private string _TableHistoryName;

        private string _TableName;

        private string _TableRemark;

        /// <summary>
        ///
        /// </summary>
        public string ColumnAllowNull
        {
            set { _ColumnAllowNull = value; }
            get { return _ColumnAllowNull; }
        }

        /// <summary>
        ///
        /// </summary>
        public string ColumnDefaultValue
        {
            set { _ColumnDefaultValue = value; }
            get { return _ColumnDefaultValue; }
        }

        /// <summary>
        ///
        /// </summary>
        public string ColumnHistory
        {
            set { _ColumnHistory = value; }
            get { return _ColumnHistory; }
        }

        /// <summary>
        ///
        /// </summary>
        public string ColumnIdentity
        {
            set { _ColumnIdentity = value; }
            get { return _ColumnIdentity; }
        }

        /// <summary>
        ///
        /// </summary>
        public string ColumnLength
        {
            set { _ColumnLength = value; }
            get { return _ColumnLength; }
        }

        /// <summary>
        ///
        /// </summary>
        public string ColumnName
        {
            set { _ColumnName = value; }
            get { return _ColumnName; }
        }

        /// <summary>
        ///
        /// </summary>
        public string ColumnPK
        {
            set { _ColumnPK = value; }
            get { return _ColumnPK; }
        }

        /// <summary>
        ///
        /// </summary>
        public string ColumnRemark
        {
            set { _ColumnRemark = value; }
            get { return _ColumnRemark; }
        }

        /// <summary>
        ///
        /// </summary>
        public string ColumnScale
        {
            set { _ColumnScale = value; }
            get { return _ColumnScale; }
        }

        /// <summary>
        ///
        /// </summary>
        public string ColumnSpace
        {
            set { _ColumnSpace = value; }
            get { return _ColumnSpace; }
        }

        /// <summary>
        ///
        /// </summary>
        public string ColumnType
        {
            set { _ColumnType = value; }
            get { return _ColumnType; }
        }

        /// <summary>
        ///
        /// </summary>
        public DateTime? CreateTime
        {
            set { _CreateTime = value; }
            get { return _CreateTime; }
        }

        /// <summary>
        ///
        /// </summary>
        public string CreateUser
        {
            set { _CreateUser = value; }
            get { return _CreateUser; }
        }

        /// <summary>
        ///
        /// </summary>
        public string DatabaseName
        {
            set { _DatabaseName = value; }
            get { return _DatabaseName; }
        }

        /// <summary>
        ///
        /// </summary>
        public string DbType
        {
            set { _DbType = value; }
            get { return _DbType; }
        }

        /// <summary>
        ///
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }

        /// <summary>
        ///
        /// </summary>
        public DateTime? LastEditTime
        {
            set { _LastEditTime = value; }
            get { return _LastEditTime; }
        }

        /// <summary>
        ///
        /// </summary>
        public string LastEditUser
        {
            set { _LastEditUser = value; }
            get { return _LastEditUser; }
        }

        /// <summary>
        ///
        /// </summary>
        public string OperationType
        {
            set { _OperationType = value; }
            get { return _OperationType; }
        }

        /// <summary>
        ///
        /// </summary>
        public string ServerName
        {
            set { _ServerName = value; }
            get { return _ServerName; }
        }

        /// <summary>
        ///
        /// </summary>
        public int? Status
        {
            set { _Status = value; }
            get { return _Status; }
        }

        /// <summary>
        ///
        /// </summary>
        public string TableHistoryName
        {
            set { _TableHistoryName = value; }
            get { return _TableHistoryName; }
        }

        /// <summary>
        ///
        /// </summary>
        public string TableName
        {
            set { _TableName = value; }
            get { return _TableName; }
        }

        /// <summary>
        ///
        /// </summary>
        public string TableRemark
        {
            set { _TableRemark = value; }
            get { return _TableRemark; }
        }
    }
}