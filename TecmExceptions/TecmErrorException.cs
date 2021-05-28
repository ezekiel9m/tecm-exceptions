using System;
using System.Net;
using TecmExceptions.Models;

namespace TecmExceptions
{
   
    public class TecmErrorException : Exception
    {
        public TecmErrorException(ErrorModel error)
        {
            ErrorModel = error;
        }

        public TecmErrorException(int errorCode, string message, string parameterName)
        {
            ErrorModel = new ErrorModel
            {
                ErrorCode = errorCode,
                Message = message,
                ParameterName = parameterName
            };
        }

        public ErrorModel ErrorModel { get; private set; }

        public ErrorResponse ErrorResponse { get; private set; }
    }

    public class InvalidApiKeyException : Exception
    {
        public InvalidApiKeyException(ErrorModel error)
        {
            ErrorModel = error;
        }

        public ErrorModel ErrorModel { get; private set; }

        public ErrorResponse ErrorResponse { get; private set; }
    }
}
