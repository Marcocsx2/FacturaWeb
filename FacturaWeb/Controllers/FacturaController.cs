using FacturaWeb.Models;
using FacturaWeb.Requests;
using MVCAjax.Proxy;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FacturaWeb.Controllers
{
    public class FacturaController : Controller
    {

        readonly OrderProxy proxy = new OrderProxy();

        // GET: List Factura
        public ActionResult List()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetOrders()
        {
            var response = Task.Run(() => proxy.GetOrderAsync());
            return Json(response.Result.Listado, JsonRequestBehavior.AllowGet);
        }

        // GET: List Factura By ID
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpPost]
        public JsonResult CreateOrder(CreateOrderRequest request)
        {
            var order = JsonConvert.DeserializeObject<Order>(request.ToString());
            var response = Task.Run(() => proxy.InsertAsync(order));
            return Json(response.Result.Mensaje, JsonRequestBehavior.AllowGet);
        }

        [HttpDelete]
        public JsonResult DeleteOrder(int id)
        {
            var response = Task.Run(() => proxy.DeleteOrderAsync(id));
            return Json(response.Result.Mensaje, JsonRequestBehavior.AllowGet);
        }

        //[HttpPost]
        //public async Task<JsonResult> CreateOrder(Order order)
        //{
        //    try
        //    {
        //        var request = JsonConvert.SerializeObject(order);
        //        var content = new StringContent(request, Encoding.UTF8, "application/json");

        //        var url = "https://localhost:44327/api/Orders/PostOrder";

        //        var httpClient = new HttpClient();
        //        var response = httpClient.PostAsync(url, content).Result;

        //        if (response.StatusCode == HttpStatusCode.Created)
        //        {
        //            var result = await response.Content.ReadAsStringAsync();
        //            var exito = JsonConvert.DeserializeObject<bool>(result);
        //            return Json(new { Message = "Orden creada correctamente" });
        //        }
        //        else
        //        {
        //            return Json("Error al crear la orden");
        //        }
        //    }
        //    catch (Exception error)
        //    {
        //        return Json(error, JsonRequestBehavior.AllowGet);
        //    }
        //}

        //[HttpGet]
        //public async Task<JsonResult> GetOrderDetailsById(int id)
        //{
        //    try
        //    {
        //        var url = "https://localhost:44327/api/OrderDetails/GetSpecificOrder/" + id;
        //        var httpClient = new HttpClient();
        //        var json = await httpClient.GetStringAsync(url);
        //        var orderDetailsList = JsonConvert.DeserializeObject<List<OrderDetail>>(json);

        //        return Json(orderDetailsList, JsonRequestBehavior.AllowGet);
        //    } catch (Exception error)
        //    {
        //        return Json(error, JsonRequestBehavior.AllowGet);
        //    }
        //}

        //[HttpGet]
        //public async Task<JsonResult> GetProducts()
        //{
        //    try
        //    {
        //        var url = "https://localhost:44327/api/Products/GetProducts";
        //        var httpClient = new HttpClient();
        //        var json = await httpClient.GetStringAsync(url);
        //        var productsList = JsonConvert.DeserializeObject<List<Product>>(json);

        //        return Json(productsList, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception error)
        //    {
        //        return Json(error, JsonRequestBehavior.AllowGet);
        //    }
        //}

        //[HttpGet]
        //public async Task<JsonResult> GetClients()
        //{
        //    try
        //    {
        //        var url = "https://localhost:44327/api/Customers/GetCustomers";
        //        var httpClient = new HttpClient();
        //        var json = await httpClient.GetStringAsync(url);
        //        var productsList = JsonConvert.DeserializeObject<List<Customer>>(json);

        //        return Json(productsList, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception error)
        //    {
        //        return Json(error, JsonRequestBehavior.AllowGet);
        //    }
        //}

        //[HttpPost]
        //public async Task<JsonResult> CreateOrderDetail(OrderDetail orderDetail)
        //{
        //    try
        //    {
        //        var request = JsonConvert.SerializeObject(orderDetail);
        //        var content = new StringContent(request, Encoding.UTF8, "application/json");

        //        var url = "https://localhost:44327/api/OrderDetails/PostOrderDetail";

        //        var httpClient = new HttpClient();
        //        var response = httpClient.PostAsync(url, content).Result;

        //        if (response.StatusCode == HttpStatusCode.Created)
        //        {
        //            var result = await response.Content.ReadAsStringAsync();
        //            var exito = JsonConvert.DeserializeObject<bool>(result);
        //            return Json(new { Message = "Detalle creado correctamente" });
        //        } else
        //        {
        //            return Json("Error al crear detalle de la orden");
        //        }
        //    }
        //    catch (Exception error)
        //    {
        //        return Json(error, JsonRequestBehavior.AllowGet);
        //    }
        //}
    }
}