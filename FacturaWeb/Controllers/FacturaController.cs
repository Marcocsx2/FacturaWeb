using FacturaWeb.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FacturaWeb.Controllers
{
    public class FacturaController : Controller
    {
        // GET: List Factura
        public ActionResult List()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> GetOrders()
        {
            var url = "https://localhost:44327/api/Orders/GetOrders";
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(url);
            var orderList = JsonConvert.DeserializeObject<List<Order>>(json);

            return Json(orderList, JsonRequestBehavior.AllowGet);
        }

        // GET: List Factura By ID
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> GetOrderDetailsById(int id)
        {
            try
            {
                var url = "https://localhost:44327/api/OrderDetails/GetSpecificOrder/" + id;
                var httpClient = new HttpClient();
                var json = await httpClient.GetStringAsync(url);
                var orderDetailsList = JsonConvert.DeserializeObject<List<OrderDetail>>(json);

                return Json(orderDetailsList, JsonRequestBehavior.AllowGet);
            } catch (Exception error)
            {
                return Json(error, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public async Task<JsonResult> GetProducts()
        {
            try
            {
                var url = "https://localhost:44327/api/Products/GetProducts";
                var httpClient = new HttpClient();
                var json = await httpClient.GetStringAsync(url);
                var productsList = JsonConvert.DeserializeObject<List<Product>>(json);

                return Json(productsList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception error)
            {
                return Json(error, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public async Task<JsonResult> GetClients()
        {
            try
            {
                var url = "https://localhost:44327/api/Customers/GetCustomers";
                var httpClient = new HttpClient();
                var json = await httpClient.GetStringAsync(url);
                var productsList = JsonConvert.DeserializeObject<List<Customer>>(json);

                return Json(productsList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception error)
            {
                return Json(error, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Create(int id)
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> CreateOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                var request = JsonConvert.SerializeObject(orderDetail);
                var content = new StringContent(request, Encoding.UTF8, "application/json");

                var url = "https://localhost:44327/api/OrderDetails/PostOrderDetail";

                var httpClient = new HttpClient();
                var response = httpClient.PostAsync(url, content).Result;

                if (response.StatusCode == HttpStatusCode.Created)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var exito = JsonConvert.DeserializeObject<bool>(result);
                    return Json(new { Message = "Detalle creado correctamente" });
                } else
                {
                    return Json("Error al crear detalle de la orden");
                }
            }
            catch (Exception error)
            {
                return Json(error, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public async Task<JsonResult> CreateOrder(Order order)
        {
            try
            {
                var request = JsonConvert.SerializeObject(order);
                var content = new StringContent(request, Encoding.UTF8, "application/json");

                var url = "https://localhost:44327/api/Orders/PostOrder";

                var httpClient = new HttpClient();
                var response = httpClient.PostAsync(url, content).Result;

                if (response.StatusCode == HttpStatusCode.Created)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var exito = JsonConvert.DeserializeObject<bool>(result);
                    return Json(new { Message = "Orden creada correctamente" });
                }
                else
                {
                    return Json("Error al crear la orden");
                }
            }
            catch (Exception error)
            {
                return Json(error, JsonRequestBehavior.AllowGet);
            }
        }
    }
}