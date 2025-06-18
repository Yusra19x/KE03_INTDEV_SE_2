using DataAccessLayer;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KE03_INTDEV_SE_2_Base.Controllers
{
    public class OrderHistoryController : Controller
    {
        private readonly MatrixIncDbContext _context;

        public OrderHistoryController(MatrixIncDbContext context)
        {
            _context = context;
        }



        public IActionResult Index()
        {
            var orders = _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.Products) 
                .ToList();

            return View(orders);
        }
    }
}

