using System.Collections.Generic;

namespace API.Authentication
{
    public class Response
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }
        public bool Success { get; set; }
        public List<string> Errors { get; set; }
    }
}