using Microsoft.AspNetCore.Mvc;
using ShoppingProject.Data;
using ShoppingProject.Models;
using System.Diagnostics;
using Microsoft.Data.SqlClient;

namespace ShoppingProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult ProductsList()
        {
            try
            {
                var products = _context.Product.ToList();
                return View(products);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        public JsonResult CalculatePrice(int ipd, int atv, int mbp, int vga)
        {
            try
            {
                var products = _context.Product.ToList();
                if (ipd > 4)
                {
                    products[0].Price = 499.99M;
                }
                var TotalPrice = ipd * products[0].Price + atv * products[2].Price + mbp * products[1].Price + vga * products[3].Price;
                return Json(TotalPrice);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}