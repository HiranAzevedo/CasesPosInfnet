using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace ConsoleRequester
{
    class Program
    {
        public static void Main(string[] args)
        {
            const string omsOrderId = "NumeroPedido";

            var httpResponse = HttpClient.GetAsync("http://{nomedaloja}.vtexcommercestable.com.br", $"api/oms/pvt/orders/{omsOrderId}", BuildAuthenticationHeaders(null)).Result;

            if (!httpResponse.IsSuccessStatusCode)
            {
                if (httpResponse.StatusCode == HttpStatusCode.NotFound)
                {
                    //Não encontrado
                    return;
                }
                if (httpResponse.StatusCode == HttpStatusCode.Forbidden)
                {
                    throw new Exception("Acesso negado, as permissões da chave foram retiradas");
                }

                throw new Exception(httpResponse.Content);
            }

            Console.WriteLine(httpResponse.Content);
            Console.ReadLine();
            //Ja desconverte na classe de pedido com os campos que vc quiser :D
            //return httpResponse.ReadContent<OmsOrderResponse>();
        }

        public static Dictionary<string, string> BuildAuthenticationHeaders(Dictionary<string, string> headers)
        {
            if (headers == null)
            {
                return new Dictionary<string, string>
                {
                    ["X-VTEX-API-AppKey"] = "Entrar email",
                    ["X-VTEX-API-AppToken"] = "Entrar Token",
                };
            }

            if (!headers.ContainsKey("X-VTEX-API-AppKey"))
            {
                headers.Add("X-VTEX-API-AppKey", "email");
            }

            if (!headers.ContainsKey("X-VTEX-API-AppToken"))
            {
                headers.Add("X-VTEX-API-AppToken", "token");
            }

            return headers;
        }
    }
}
