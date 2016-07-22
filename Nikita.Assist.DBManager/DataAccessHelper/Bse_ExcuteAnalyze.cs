using System;

namespace Nikita.Assist.DBManager.Model
{
    /// <summary>Bse_ExcuteAnalyze表实体类
    ///
    /// </summary>
    [Serializable]
    public class Bse_ExcuteAnalyze
    {
        private DateTime _CreateDate = DateTime.Now;

        private string _DbType;

        private string _ExcuteName;

        private string _ExcuteSql;

        private string _ExcuteType;

        private int _id;

        private string _Remark;

        public Bse_ExcuteAnalyze()
        { }

        /// <summary>
        ///
        /// </summary>
        public DateTime CreateDate
        {
            set { _CreateDate = value; }
            get { return _CreateDate; }
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
        public string ExcuteName
        {
            set { _ExcuteName = value; }
            get { return _ExcuteName; }
        }

        /// <summary>
        ///
        /// </summary>
        public string ExcuteSql
        {
            set { _ExcuteSql = value; }
            get { return _ExcuteSql; }
        }

        /// <summary>
        ///
        /// </summary>
        public string ExcuteType
        {
            set { _ExcuteType = value; }
            get { return _ExcuteType; }
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
        public string Remark
        {
            set { _Remark = value; }
            get { return _Remark; }
        }
    }
}