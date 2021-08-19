

namespace Pokemon.Core.Pokemon.Response
{
    public class Response<T>
    {
        public Response() {}
        public Response(T Response)
        {
            Data = Response;
        }

        public T Data {get; set;}
    }
}
