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

        public ErrorModel ErrorModel { get; }
        public ErrorResponse ErrorResponse { get; }
    }
}
