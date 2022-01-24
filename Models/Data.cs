using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XapiensTest.Models
{

    public class ResponseObject : Support
    {
        public Data data { get; set; }
        public Support support { get; set; }
    }

    public class Data
    {
        public int id { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string avatar { get; set; }
    }
}