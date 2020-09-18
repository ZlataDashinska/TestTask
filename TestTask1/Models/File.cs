using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestTask1.Models
{
    public class File
    {
        public Guid id { get; set; }
        public string path { get; set; }
        public Guid user_id { get; set; }

    }
}
