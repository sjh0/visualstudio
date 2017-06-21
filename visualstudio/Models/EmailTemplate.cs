using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace visualstudio.Models
{
    public class PastDueTemplate
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Intro { get; set; }

        public string Body { get; set; }

        public string Closing { get; set; }
    }
}
