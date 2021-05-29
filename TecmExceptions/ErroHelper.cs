using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;
using TecmExceptions.Models;

namespace VeripagExceptions
{
    /// <summary>
    /// Class para normalização de respostas de erros.
    /// </summary>
    public static class ErrorHelper
    {
        /// <summary>
        /// Retorna a resposta de erro padrão.
        /// </summary>
        /// <param name="validate">Validation result.</param>
        /// <returns>Error response.</returns>
        public static ErrorResponse ValidationError(this ValidationResult validate)
        {
            var response = new ErrorResponse();
            var errorList = new List<ErrorModel>();

            var errorSelect = validate.Errors.Select(s => new ErrorModel
            {
                ErrorCode = Convert.ToInt32(s.ErrorCode),
                ParameterName = s.FormattedMessagePlaceholderValues != null ? 
                s.FormattedMessagePlaceholderValues["PropertyName"].ToString() : s.PropertyName,
                Message = s.ErrorMessage
            })
            .ToList();

            errorList.AddRange(errorSelect);
            response.Errors = errorList;

            return response;
        }
    }
}
