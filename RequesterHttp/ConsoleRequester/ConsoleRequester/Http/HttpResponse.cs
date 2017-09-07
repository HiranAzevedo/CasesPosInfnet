using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;

namespace ConsoleRequester.Http
{
    public class HttpResponse
    {
        public HttpStatusCode StatusCode { get; set; }

        public string Content { get; set; }

        public bool IsSuccessStatusCode { get; set; }

        public HttpResponseHeaders Headers { get; set; }

        public T ReadContent<T>() where T : class
        {
            return string.IsNullOrWhiteSpace(Content) ? null : JsonConvert.DeserializeObject<T>(Content, new JsonSerializerSettings { DateFormatHandling = DateFormatHandling.IsoDateFormat, DateTimeZoneHandling = DateTimeZoneHandling.Utc });
        }
    }
}
