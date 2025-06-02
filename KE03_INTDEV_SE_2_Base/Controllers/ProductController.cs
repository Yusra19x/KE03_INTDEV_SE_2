using DataAccessLayer;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KE03_INTDEV_SE_2_Base.Controllers
{
    public class ProductController : Controller
    {
        private readonly MatrixIncDbContext _context;

        
            public ProductController(MatrixIncDbContext context)
            {
                _context = context;
            }

            // GET: Product
            public async Task<IActionResult> Index()
            {
                return View(await _context.Products.ToListAsync());
            }

            // GET: Product/Details/5
            public async Task<IActionResult> Details(int? id)
            {
                if (id == null) return NotFound();

                var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
                if (product == null) return NotFound();

                return View(product);
            }

            // GET: Product/Create
            public IActionResult Create()
            {
                return View();
            }

            // POST: Product/Create
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create([Bind("Id,Name,Description,Image,Category,Brand,Color,Material,Weight,Stock,PurchasePrice,SellingPrice,VAT,Active")] Product product)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(product);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(product);
            }

        // GET: Product/Edit/5
        public async Task<IActionResult> Edit(int? id)
            {
                if (id == null) return NotFound();

                var product = await _context.Products.FindAsync(id);
                if (product == null) return NotFound();

                return View(product);
            }

            // POST: Product/Edit/5
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Image,Category,Brand,Color,Material,Weight,Stock,PurchasePrice,SellingPrice,VAT,Active")] Product product)
            {
                if (id != product.Id) return NotFound();

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(product);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ProductExists(product.Id)) return NotFound();
                        else throw;
                    }
                    return RedirectToAction(nameof(Index));
                }
                return View(product);
            }

            // GET: Product/Delete/5
            public async Task<IActionResult> Delete(int? id)
            {
                if (id == null) return NotFound();

                var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
                if (product == null) return NotFound();

                return View(product);
            }

            // POST: Product/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                var product = await _context.Products.FindAsync(id);
                if (product != null)
                {
                    _context.Products.Remove(product);
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Index));
            }

            private bool ProductExists(int id)
            {
                return _context.Products.Any(p => p.Id == id);
            }
        }
    }

