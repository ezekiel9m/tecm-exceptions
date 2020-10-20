
using System.Net;

namespace TecmExceptions.Models
{
    public class ErrorModel
    {
        public ErrorModel()
        {

        }
        public ErrorModel(string message, string parameter, int errorCode)
        {

        }
        public ErrorModel(string message, string parameter, HttpStatusCode errorCode)
        {

        }
        public string Message { get; set; }
        public string ParameterName { get; set; }
        public int ErrorCode { get; set; }
    }
}
