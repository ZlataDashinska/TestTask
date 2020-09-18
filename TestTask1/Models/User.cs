using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestTask1.Models
{
    public class User
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string middle_name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string password_hash { get; set; }

    }
}
