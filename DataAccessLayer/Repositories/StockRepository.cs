using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class StockRepository : IStockRepository
    {
        private readonly MatrixIncDbContext _context;

        public StockRepository(MatrixIncDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Stock> GetAllStock()
        {
            return _context.Products
                .Select(p => new Stock
                {
                    Id = p.Id,
                    Name = p.Name,
                    StockAmount = p.Stock
                })
                .ToList();
        }

        public Stock GetStockByProductId(int productId)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == productId);
            if (product == null) return null;

            return new Stock
            {
                Id = product.Id,
                Name = product.Name,
                StockAmount = product.Stock
            };
        }
    }
}
