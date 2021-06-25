
using System.Net;

namespace VeripagExceptions.Model
{
    public class ErrorModel
    {
        public ErrorModel(string message, string parameter, int errorCode)
        {
            this.Message = message;
            this.ParameterName = parameter;
            this.ErrorCode = errorCode;
        }

        public ErrorModel(string message, string parameter, HttpStatusCode errorCode)
        {
            this.Message = message;
            this.ParameterName = parameter;
            this.ErrorCode = (int)errorCode;
        }

        public ErrorModel()
        {

        }

        public string Message { get; set; }

        public string ParameterName { get; set; }

        public int ErrorCode { get; set; }
    }
}
