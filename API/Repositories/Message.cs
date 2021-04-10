using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories
{
    public class Message
    {
        public List<string > To { get; set; }
        public string  Subject { get; set; }
        public string  Body { get; set; }
    }
}
