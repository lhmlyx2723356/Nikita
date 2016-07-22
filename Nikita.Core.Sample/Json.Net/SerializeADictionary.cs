using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Nikita.Core.Sample.Json.Net
{
    public class SerializeADictionary
    {
     static    Dictionary<string, int> points = new Dictionary<string, int>
 {
     { "James", 9001 },
    { "Jo", 3474 },
    { "Jess", 11926 }
 };

        public static  string DoSerializeADictionary()
        {

            string json = JsonConvert.SerializeObject(points, Formatting.Indented);
            return json;
        }
    }
}
