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
    public class ProductProxy
    {
        public async Task<ResponseProxy<Product>> GetProductsAsync()
        {
            var client = new HttpClient();
            var urlBase = "https://localhost:44327";
            client.BaseAddress = new Uri(urlBase);

            var url = string.Concat(urlBase, "/api", "/Products", "/GetProducts");
            var response = client.GetAsync(url).Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                var products = JsonConvert.DeserializeObject<List<Product>>(result);

                return new ResponseProxy<Product>
                {
                    Exitoso = true,
                    Codigo = (int) HttpStatusCode.OK,
                    Mensaje = "Todas los productos",
                    Listado = products
                };
            }
            else
            {
                return new ResponseProxy<Product>
                {
                    Exitoso = false,
                    Codigo = (int) response.StatusCode,
                    Mensaje = "Error al obtener productos"
                };
            }
        }
    }
}