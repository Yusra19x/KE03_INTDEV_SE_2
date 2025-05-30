using DataAccessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KE03_INTDEV_SE_2_Base.Controllers
{
    public class StockController : Controller
    {
        private readonly IStockRepository _stockRepository;

        public StockController(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public IActionResult Index()
        {
            var stockList = _stockRepository.GetAllStock();
            return View(stockList);
        }
    }
}
