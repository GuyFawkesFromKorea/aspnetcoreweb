using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace JWLibraryNetCore
{
    public class RequestHelper
    {
        private readonly string _host = "";
        public RequestHelper() {

        }

        public async Task<TEntity> Get<TEntity>(string cpa, string param) {
            using(var clinet = new HttpClient()) {
                var send = cpa + param;
                clinet.BaseAddress = new Uri(_host);
                var response = await clinet.GetAsync(send);

                response.EnsureSuccessStatusCode();

                var value = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<TEntity>(value);
            }
        }

        public async Task<TEntity> Post<TEntity>(string cpa, string postData)
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_host);

                var response = await client.PostAsync(cpa, new StringContent(postData));

                response.EnsureSuccessStatusCode();

                var value = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<TEntity>(value);
            }
        }
    }
}
