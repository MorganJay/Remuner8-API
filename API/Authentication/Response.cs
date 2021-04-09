namespace API.Authentication
{
    public abstract class Response
    {
        public string Status { get; set; }
        public string Message { get; set; }
    }
}