using System.Collections.Generic;

namespace API.Infrastructure.Services
{
    public class Message
    {
        public List<string> To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}