﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nikita.Core.Sample.Json.Net
{
    public class SerializeAnObject
    {
        public class Account
        {
            public string Email { get; set; }
            public bool Active { get; set; }
            public DateTime CreatedDate { get; set; }
            public IList<string> Roles { get; set; }
        }

        public static string DoSerializeAnObject()
        {
             Account account = new Account
             {
                 Email = "james@example.com",
                 Active = true,
                 CreatedDate = new DateTime(2013, 1, 20, 0, 0, 0, DateTimeKind.Utc),
                 Roles = new List<string>
                 {
                    "User",
                    "Admin"
                }
             };

            string json = JsonConvert.SerializeObject(account, Formatting.Indented);
            return json;
        }
    }
}
