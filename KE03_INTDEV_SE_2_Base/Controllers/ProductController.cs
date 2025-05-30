using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;

namespace KE03_INTDEV_SE_2_Base.Controllers
{
    public class ProductController : Controller
    {
        private readonly MatrixIncDbContext _context;

        public ProductController(MatrixIncDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }
    }
}
