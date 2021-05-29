
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
            this.ErrorCode = errorCode;
            this.ParameterName = parameter;
            this.Message = message; 
        }
        public ErrorModel(string message, string parameter, HttpStatusCode errorCode)
        {
            this.ErrorCode = (int)errorCode;
            this.ParameterName = parameter;
            this.Message = message;
        }
        public string Message { get; set; }
        public string ParameterName { get; set; }
        public int ErrorCode { get; set; }
    }
}
