using FacturaWeb.Proxy;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FacturaWeb.Controllers
{
    public class CustomerController : Controller
    {
        readonly CustomerProxy proxy = new CustomerProxy();

        [HttpGet]
        //public async Task<JsonResult> GetProducts()
        public JsonResult GetCustomers()
        {
            var response = Task.Run(() => proxy.GetCustomersAsync());
            return Json(response.Result.Listado, JsonRequestBehavior.AllowGet);
        }
    }
}