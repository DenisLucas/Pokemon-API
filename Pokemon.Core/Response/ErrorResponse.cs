using System;
using System.Collections.Generic;
using Pokemon.Domain.ViewModel.Error;

namespace Pokemon.Core.Response
{
    public class ErrorResponse
    {
        public List<ErrorModel> ErrorMessage { get; set; } = new List<ErrorModel>();
    }
}
