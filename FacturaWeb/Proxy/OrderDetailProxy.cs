using FacturaWeb.Models;
using MVCAjax.Proxy;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FacturaWeb.Proxy
{
    public class OrderDetailProxy
    {
        public async Task<ResponseProxy<OrderDetail>> GetOrderDetailsById(int id)
        {
            try {
                var client = new HttpClient();
                var urlBase = "https://localhost:44327";
                client.BaseAddress = new Uri(urlBase);

                var url = string.Concat(urlBase, "/api", "/OrderDetails", "/GetSpecificOrder", "/", id);

                var httpClient = new HttpClient();
                var response = httpClient.DeleteAsync(url).Result;

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var orderDetails = JsonConvert.DeserializeObject<List<OrderDetail>>(result);

                    return new ResponseProxy<OrderDetail>
                    {
                        Exitoso = true,
                        Listado = orderDetails,
                        Codigo = (int)HttpStatusCode.OK,
                        Mensaje = "Factura eliminada exitosamente"
                    };
                }
                else
                {
                    return new ResponseProxy<OrderDetail>
                    {
                        Exitoso = false,
                        Codigo = (int)response.StatusCode,
                        Mensaje = "Error al eliminar la orden"
                    };
                }
            }
            catch (Exception error)
            {
                return new ResponseProxy<OrderDetail>
                {
                    Exitoso = false,
                    Codigo = (int)HttpStatusCode.InternalServerError,
                    Mensaje = error.Message
                };
            }
        }


        public async Task<ResponseProxy<OrderDetail>> InsertAsync(OrderDetail orderDetail)
        {
            try
            {
                var request = JsonConvert.SerializeObject(orderDetail);
                var content = new StringContent(request, Encoding.UTF8, "application/json");

                var client = new HttpClient();
                var urlBase = "https://localhost:44327";
                client.BaseAddress = new Uri(urlBase);

                var url = string.Concat(urlBase, "/api", "/OrderDetails", "/PostOrderDetail");
                var response = client.PostAsync(url, content).Result;

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var exito = JsonConvert.DeserializeObject<bool>(result);

                    return new ResponseProxy<OrderDetail>
                    {
                        Exitoso = exito,
                        Codigo = (int) HttpStatusCode.Created,
                        Mensaje = "Detalle de Factura creada exitosamente"
                    };
                }
                else
                {
                    return new ResponseProxy<OrderDetail>
                    {
                        Exitoso = false,
                        Codigo = (int) response.StatusCode,
                        Mensaje = "Error al crear Detalle de factura"
                    };
                }
            }
            catch (Exception error)
            {
                return new ResponseProxy<OrderDetail>
                {
                    Exitoso = false,
                    Codigo = (int) HttpStatusCode.InternalServerError,
                    Mensaje = error.Message
                };
            }
        }
    }
}
