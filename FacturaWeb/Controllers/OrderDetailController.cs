using System.Threading.Tasks;
using System.Web.Mvc;
using FacturaWeb.Models;
using FacturaWeb.Proxy;
using FacturaWeb.Requests;
using Newtonsoft.Json;

namespace FacturaWeb.Controllers
{
    public class OrderDetailController: Controller
    {
        readonly OrderDetailProxy proxy = new OrderDetailProxy();

        [HttpGet]
        //public async Task<JsonResult> GetOrderDetails()
        public JsonResult GetOrderDetails(int id)
        {
            var response = Task.Run(() => proxy.GetOrderDetailsById(id));
            return Json(response.Result.Listado, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CreateOrderDetail(CreateOrderDetailRequest request)
        {
            var orderDetail = JsonConvert.DeserializeObject<OrderDetail>(request.ToString());
            var response = Task.Run(() => proxy.InsertAsync(orderDetail));
            return Json(response.Result.Listado, JsonRequestBehavior.AllowGet);
        }
    }
}