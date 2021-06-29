using FacturaWeb.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MVCAjax.Proxy
{
    public class OrderProxy
    {
        public async Task<ResponseProxy<Order>> GetOrderAsync()
        {
            var client = new HttpClient();
            var urlBase = "https://localhost:44327";
            client.BaseAddress = new Uri(urlBase);

            var url = string.Concat(urlBase, "/api", "/Orders", "/GetOrders");
            var response = client.GetAsync(url).Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                var orders = JsonConvert.DeserializeObject<List<Order>>(result);

                return new ResponseProxy<Order>
                {
                    Exitoso = true,
                    Codigo = (int) HttpStatusCode.OK,
                    Mensaje = "Todas las facturas",
                    Listado = orders
                };
            }
            else
            {
                return new ResponseProxy<Order>
                {
                    Exitoso = false,
                    Codigo = (int) response.StatusCode,
                    Mensaje = "Error al obtener facturas"
                };
            }
        }

        public async Task<ResponseProxy<Order>> InsertAsync(Order student)
        {
            student.Active = true;
            var request = JsonConvert.SerializeObject(student);
            var content = new StringContent(request, Encoding.UTF8, "application/json");

            var client = new HttpClient();
            var urlBase = "https://localhost:44327";
            client.BaseAddress = new Uri(urlBase);

            var url = string.Concat(urlBase, "/api", "/Orders", "/PostOrder");
            var response = client.PostAsync(url, content).Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                var exito = JsonConvert.DeserializeObject<bool>(result);

                return new ResponseProxy<Order>
                {
                    Exitoso = exito,
                    Codigo = (int) HttpStatusCode.Created,
                    Mensaje = "Factura creada exitosamente"
                };
            }
            else
            {
                return new ResponseProxy<Order>
                {
                    Exitoso = false,
                    Codigo = (int) response.StatusCode,
                    Mensaje = "Error al crear factura"
                };
            }
        }

        public async Task<ResponseProxy<Order>> DeleteOrderAsync(int id)
        {
            try
            {
                var client = new HttpClient();
                var urlBase = "https://localhost:44327";
                client.BaseAddress = new Uri(urlBase);

                var url = string.Concat(urlBase, "/api", "/Orders", "/DeleteOrder", "/", id);

                var httpClient = new HttpClient();
                var response = httpClient.DeleteAsync(url).Result;

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var exito = JsonConvert.DeserializeObject<bool>(result);

                    return new ResponseProxy<Order>
                    {
                        Exitoso = exito,
                        Codigo = (int) HttpStatusCode.OK,
                        Mensaje = "Factura eliminada exitosamente"
                    };
                }
                else
                {
                    return new ResponseProxy<Order>
                    {
                        Exitoso = false,
                        Codigo = (int) response.StatusCode,
                        Mensaje = "Error al eliminar la orden"
                    };
                }
            }
            catch (Exception error)
            {
                return new ResponseProxy<Order>
                {
                    Exitoso = false,
                    Codigo = (int) HttpStatusCode.InternalServerError,
                    Mensaje = error.Message
                };
            }
        }
    }
}