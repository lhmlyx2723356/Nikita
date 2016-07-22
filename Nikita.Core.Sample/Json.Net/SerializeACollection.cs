using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Nikita.Core.Sample.Json.Net
{
    public class SerializeACollection
    {
      static   List<string> videogames = new List<string>
            {
            "Starcraft",
            "Halo",
            "Legend of Zelda"
            };

        public static string DoSerializeACollection()
        {
            string json = JsonConvert.SerializeObject(videogames);
            return json;
        }
    }
}
