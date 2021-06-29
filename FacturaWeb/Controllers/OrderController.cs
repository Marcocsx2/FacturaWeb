using FacturaWeb.Models;
using FacturaWeb.Requests;
using MVCAjax.Proxy;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FacturaWeb.Controllers
{
    public class OrderController : Controller
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
    }
}