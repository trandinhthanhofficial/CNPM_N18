using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cafe_manager.Common
{
    [Serializable]
    public class Userlogin
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
    }
}