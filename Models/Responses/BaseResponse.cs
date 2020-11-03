using System.Net;
namespace stock_app.Models
{
    public class BaseResponse
    {
        public int Status { get; set; }
        public string Message { get; set; }
    }
}