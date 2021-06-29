using System.Threading.Tasks;
using System.Web.Mvc;
using FacturaWeb.Proxy;
using Newtonsoft.Json;

namespace FacturaWeb.Controllers
{
    public class ProductController : Controller
    {
        readonly ProductProxy proxy = new ProductProxy();

        [HttpGet]
        //public async Task<JsonResult> GetProducts()
        public JsonResult GetProducts()
        {
            var response = Task.Run(() => proxy.GetProductsAsync());
            return Json(response.Result.Listado, JsonRequestBehavior.AllowGet);
        }
    }
}
