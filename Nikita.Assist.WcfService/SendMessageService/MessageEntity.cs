using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace Nikita.Assist.WcfService
{
    [DataContract]
    public class MessageEntity
    {
        [DataMember]
        public string CacheKey { get; set; }

        [DataMember]
        public string Operation { get; set; }


        [DataMember]
        public DataTable DataTableCache { get; set; }

    }
}
