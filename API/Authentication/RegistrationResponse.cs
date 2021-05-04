using System.Collections.Generic;

namespace API.Authentication
{
    public class RegistrationResponse : Response
    {
        public string RefreshToken { get; set; }
        public string Token { get; set; }
        public List<string> Errors { get; set; }
        public string UserName { get; set; }
    }
}