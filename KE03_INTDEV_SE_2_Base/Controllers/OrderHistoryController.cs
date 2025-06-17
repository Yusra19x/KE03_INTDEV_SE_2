using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace KE03_INTDEV_SE_2_Base.Controllers
{
    public class OrderHistoryController : Controller

    {

        public IActionResult Index()
            {
                return View();
            }
        
    }

}
