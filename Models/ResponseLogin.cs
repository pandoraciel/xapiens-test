using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XapiensTest.Models
{
    public class ResponseLoginSuccessOrFail
    {
        public string token { get; set; }
        public string error { get; set; }
    }

}