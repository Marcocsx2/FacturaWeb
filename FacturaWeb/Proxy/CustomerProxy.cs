using FacturaWeb.Models;
using MVCAjax.Proxy;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace FacturaWeb.Proxy
{
    public class CustomerProxy
    {
        public async Task<ResponseProxy<Customer>> GetCustomersAsync()
        {
            var client = new HttpClient();
            var urlBase = "https://localhost:44327";
            client.BaseAddress = new Uri(urlBase);

            var url = string.Concat(urlBase, "/api", "/Customers", "/GetCustomers");
            var response = client.GetAsync(url).Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                var customers = JsonConvert.DeserializeObject<List<Customer>>(result);

                return new ResponseProxy<Customer>
                {
                    Exitoso = true,
                    Codigo = (int) HttpStatusCode.OK,
                    Mensaje = "Todas los clientes",
                    Listado = customers
                };
            }
            else
            {
                return new ResponseProxy<Customer>
                {
                    Exitoso = false,
                    Codigo = (int) response.StatusCode,
                    Mensaje = "Error al obtener clientes"
                };
            }
        }
    }
}