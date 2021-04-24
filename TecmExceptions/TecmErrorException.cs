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

        public TecmErrorException(int errorCode, string parameterName, string message)
        {
        }

        public TecmErrorException(HttpStatusCode errorCode, string parameterName, string message)
        {
        }

        public ErrorModel ErrorModel { get; }
        public ErrorResponse ErrorResponse { get; }
    }
}
