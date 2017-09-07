using ConsoleRequester.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleRequester
{
    public static class HttpClient
    {
        private static readonly Regex tagRegex = new Regex(@"<\s*([^ >]+)[^>]*>.*?<\s*/\s*\1\s*>");

        private static readonly System.Net.Http.HttpClient m_HttpClient = new System.Net.Http.HttpClient();

        public static async Task<HttpResponse> GetAsync(string baseUri, string resource, Dictionary<string, string> customHeaders = null, TimeSpan timeOut = default(TimeSpan), bool returnResponseHeaders = false) =>
            await SendAsync(baseUri, resource, customHeaders: customHeaders, timeOut: timeOut, returnResponseHeaders: returnResponseHeaders).ConfigureAwait(false);

        public static async Task<HttpResponse> DeleteAsync(string baseUri, string resource, Dictionary<string, string> customHeaders = null, TimeSpan timeOut = default(TimeSpan), bool returnResponseHeaders = false) =>
            await SendAsync(baseUri, resource, customHeaders: customHeaders, timeOut: timeOut, returnResponseHeaders: returnResponseHeaders).ConfigureAwait(false);

        public static async Task<HttpResponse> PostAsync<T>(string baseUri, string resource, T content, Dictionary<string, string> customHeaders = null, TimeSpan timeOut = default(TimeSpan), bool returnResponseHeaders = false) =>
            await SendAsync(baseUri, resource, content, customHeaders, timeOut, returnResponseHeaders).ConfigureAwait(false);

        public static async Task<HttpResponse> PutAsync<T>(string baseUri, string resource, T content, Dictionary<string, string> customHeaders = null, TimeSpan timeOut = default(TimeSpan), bool returnResponseHeaders = false) =>
            await SendAsync(baseUri, resource, content, customHeaders, timeOut, returnResponseHeaders).ConfigureAwait(false);

        private static async Task<HttpResponse> SendAsync(string baseUri, string resource, object content = null, Dictionary<string, string> customHeaders = null, TimeSpan timeOut = default(TimeSpan), bool returnResponseHeaders = false, [CallerMemberName]string caller = "")
        {
            if (timeOut == default(TimeSpan))
            {
                timeOut = TimeSpan.FromSeconds(30);
            }

            HttpRequestMessage requestMessage = null;

            switch (caller)
            {
                case nameof(GetAsync):
                    {
                        requestMessage = BuildRequestMessage(baseUri, resource, HttpMethod.Get, customHeaders); break;
                    }
                case nameof(DeleteAsync):
                    {
                        requestMessage = BuildRequestMessage(baseUri, resource, HttpMethod.Delete, customHeaders); break;
                    }
                case nameof(PostAsync):
                    {
                        requestMessage = BuildRequestMessage(baseUri, resource, HttpMethod.Post, customHeaders, content); break;
                    }
                case nameof(PutAsync):
                    {
                        requestMessage = BuildRequestMessage(baseUri, resource, HttpMethod.Put, customHeaders, content); break;
                    }
                default:
                    throw new InvalidOperationException();
            }

            try
            {
                using (var cancellationToken = new CancellationTokenSource(timeOut))
                {
                    using (var httpResponse = await m_HttpClient.SendAsync(requestMessage, HttpCompletionOption.ResponseContentRead, cancellationToken.Token).ConfigureAwait(false))
                    {
                        var responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

                        if (!httpResponse.IsSuccessStatusCode && tagRegex.IsMatch(responseContent))
                        {
                            responseContent = $"The remote server returned an error ({Convert.ToInt32(httpResponse.StatusCode)}) {httpResponse.StatusCode}. The original content was removed for containing HTML data.";
                        }

                        return new HttpResponse
                        {
                            Headers = returnResponseHeaders ? httpResponse.Headers : null,
                            IsSuccessStatusCode = httpResponse.IsSuccessStatusCode,
                            StatusCode = httpResponse.StatusCode,
                            Content = responseContent
                        };
                    }
                }
            }
            catch (TaskCanceledException)
            {
                return new HttpResponse { Content = "TimeOut" };
            }
        }

        private static HttpRequestMessage BuildRequestMessage(string baseUri, string resource, HttpMethod method, Dictionary<string, string> customHeaders, object content = null)
        {
            var uri = new Uri(baseUri);

            var requestMessage = new HttpRequestMessage
            {
                Method = method,
                RequestUri = new Uri($"{uri.AbsoluteUri}{resource}")
            };

            if (content != null)
            {
                requestMessage.Content = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
            }

            if (customHeaders != null && customHeaders.Count > default(int))
            {
                foreach (var item in customHeaders)
                {
                    if (requestMessage.Headers.Contains(item.Key))
                    {
                        continue;
                    }

                    requestMessage.Headers.Add(item.Key, item.Value);
                }
            }

            requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return requestMessage;
        }
    }
}
