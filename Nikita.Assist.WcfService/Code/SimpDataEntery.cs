using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Nikita.Assist.WcfService
{
    public class SimpDataEntery
    {
        private SimpDataColInf[] _clos;
        private List<object[]> _rows;

        public SimpDataEntery()
        {
            SimpDataArry = new object[4];
        }

        [System.Web.Script.Serialization.ScriptIgnore]
        public SimpDataColInf[] Cols
        {
            set
            {
                var cols = new object[value.Length];
                SimpDataArry[2] = cols;
                _clos = null;
                _clos = value;
                for (int i = 0, iCnt = value.Length; i < iCnt; i++)
                {
                    cols[i] = (new object[] { value[i].Name, (int)value[i].Type });
                }
            }
            get
            {
                if (_clos != null)
                    return _clos;
                if (SimpDataArry[2] == null)
                    return null;
                object[] cols = (object[])SimpDataArry[2];
                int i = 0, iCnt = cols.Length;
                _clos = new SimpDataColInf[iCnt];
                for (; i < iCnt; i++)
                {
                    object[] colinf = (object[])cols[i];
                    _clos[i] = new SimpDataColInf() { Name = colinf[0].ToString(), Type = (DotNetType)colinf[1] };
                }
                return _clos;
            }
        }

        [System.Web.Script.Serialization.ScriptIgnore]
        public string Key
        {
            set
            {
                SimpDataArry[1] = value;
            }
            get
            {
                if (SimpDataArry[1] != null)
                {
                    return SimpDataArry[1].ToString();
                }
                return string.Empty;
            }
        }

        [System.Web.Script.Serialization.ScriptIgnore]
        public List<object[]> Rows
        {
            set
            {
                _rows = value;
                SimpDataArry[3] = _rows.ToArray();
            }
            get
            {
                if (_rows != null)
                    return _rows;
                if (SimpDataArry[3] == null)
                    return null;
                _rows = new List<object[]>();
                object[] rows = (object[])SimpDataArry[3];
                int i = 0, iCnt = rows.Length;
                for (; i < iCnt; i++)
                {
                    _rows.Add((object[])rows[i]);
                }
                return _rows;
            }
        }

        public object[] SimpDataArry { get; set; }

        [System.Web.Script.Serialization.ScriptIgnore]
        public long Val
        {
            set
            {
                SimpDataArry[0] = value;
            }
            get
            {
                long tval = 0;
                if (SimpDataArry[0] != null)
                {
                    long.TryParse(SimpDataArry[0].ToString(), out tval);
                }
                return tval;
            }
        }
    }
}