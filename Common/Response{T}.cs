using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Response<T> : Response, IResponse<T>
    {
        public T Data { get; set; }
        public List<CustomValidationError> ValidationErrors { get; set; }
        public Response(string message, ResponseType responseType) : base(message, responseType)
        {
        }

        public Response(ResponseType responseType, T data) : base(responseType)
        {
            Data = data;
        }

        public Response(T data, List<CustomValidationError> errors) : base(ResponseType.ValidationError)
        {
            ValidationErrors = errors;
            Data = data;
        }
    }
}
