namespace Assignment3_Connection.Models
{
    public class Response
    {
        public int statusCode { get; set; }
        public String message { get; set; }
        public Response() { }

        public Response(int statusCode, String message) 
        {
            this.statusCode = statusCode;
            this.message = message;
        }
    }
}
