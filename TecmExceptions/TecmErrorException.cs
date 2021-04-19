using System;
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
        }

        public ErrorModel ErrorModel { get; }
        public ErrorResponse ErrorResponse { get; }
    }
}
