using Microsoft.AspNetCore.Mvc;
using ShoppingProject.Data;
using ShoppingProject.Models;
using System.Diagnostics;
using Microsoft.Data.SqlClient;

namespace ShoppingProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ProductsList()
        {
            var products = _context.Product.ToList();
            return View(products);
        }
        [HttpPost]
        public JsonResult CalculatePrice(int ipd,int atv,int mbp,int vga)
        {
            var products = _context.Product.ToList();
            if(ipd>4)
            {
                products[0].Price = 499.99M;
            }
            var TotalPrice= ipd * products[0].Price + atv * products[2].Price + mbp * products[1].Price + vga * products[3].Price;
            return Json(TotalPrice);
        }
    }
}