using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nikita.Assist.IDBuilder
{
    public interface IIDBuilder
    {
        long GetNewID(Nikita.Assist.IDBuilder.IDBuilderHelper.SqlType dbType, string strTableName, string strConn);

        string GetSeriesNumber(Nikita.Assist.IDBuilder.IDBuilderHelper.SqlType dbType, string strType, string strTableName, string strTableField, string strPreficLength, bool blnDt, int intFyId, string strConn);
    }
}