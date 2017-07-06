using Orders.Models;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;

namespace Orders.Services
{
    public class ApiService
    {

        public async Task<List<Order>> GetAllOrders()
        {
            var handler = new HttpClientHandler { Credentials= new NetworkCredential("jconnor","Jjcf0078")};
            using (var client = new HttpClient(handler))
            {
            
                string url = "http://myordersdb.azurewebsites.net/tables/Orders";
                client.DefaultRequestHeaders.Add("ZUMO-API-VERSION", "2.0.0");
 
                var result = await client.GetAsync(url);

                string data = await result.Content.ReadAsStringAsync();

                if (result.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<List<Order>>(data);
                }
                else
                {
                    return new List<Order>();
                }
            }
        }

    }
}
