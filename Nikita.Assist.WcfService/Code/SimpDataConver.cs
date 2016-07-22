using System.Collections.Generic;
using System.Data;

namespace Nikita.Assist.WcfService
{
    public abstract class SimpDataConver
    {
        public static object[] GetNewItemArray(object[] ojbs)
        {
            for (int i = 0, iCnt = ojbs.Length; i < iCnt; i++)
            {
                if (ojbs[i].Equals(System.DBNull.Value))
                {
                    ojbs[i] = string.Empty;
                }
            }
            return ojbs;
        }

        //public static SimpDataCollections DataTableToSimpData(DataTable dt, string dtName)
        //{
        //  List<object[]> _objs = new List<object[]>();
        //  SimpDataColInf[] _colinfs = new SimpDataColInf[dt.Columns.Count];
        //  for (int _i = 0, _cCnt = dt.Columns.Count; _i < _cCnt; _i++)
        //  {
        //    _colinfs[_i] = new SimpDataColInf() { name = dt.Columns[_i].ColumnName, type = dt.Columns[_i].DataType.ToString() };
        //  }
        //  for (int _i = 0, _rCnt = dt.Rows.Count; _i < _rCnt; _i++)
        //  {
        //    _objs.Add(GetNewItemArray(dt.Rows[_i].ItemArray));
        //  }
        //  SimpDataEntery _simp = new SimpDataEntery()
        //  {
        //    TVal = System.DateTime.Now.Ticks,
        //    Key = string.Empty,
        //    Cols = _colinfs,
        //    Rows = _objs
        //  };
        //  return new SimpDataCollections()  {{ dtName,new List<SimpDataEntery>(){_simp}} } ;//存在DBNull会出错
        //}
    }
}