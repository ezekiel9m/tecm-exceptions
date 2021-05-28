
using System.Collections.Generic;


namespace TecmExceptions.Models
{
    public class ErrorResponse
    {
        public ErrorResponse()
        {
        }
        public List<ErrorModel> Errors { get; set; }
    }
}
