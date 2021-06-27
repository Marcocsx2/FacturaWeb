using FacturaWeb.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FacturaWeb.Controllers
{
    public class FacturaController : Controller
    {
        // GET: Create Factura
        public ActionResult Index()
        {
            return View();
        }

        // GET: List Factura
        public async Task<ActionResult> List()
        {
            var url = "https://localhost:44327/api/OrderDetails/GetOrderDetails";
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(url);
            var orderList = JsonConvert.DeserializeObject<List<Order>>(json);

            return View(orderList);
        }

        // GET: List Factura By ID
        public async Task<ActionResult> Details()
        {
            //var url = "";
            //var httpClient = new HttpClient();
            //var json = await httpClient.GetStringAsync(url);
            //var orderList = JsonConvert.DeserializeObject<List<Order>>(json);

            return View();
        }

    }
}