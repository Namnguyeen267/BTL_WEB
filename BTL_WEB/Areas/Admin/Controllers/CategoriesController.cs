using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BTL_WEB.Data;
using BTL_WEB.Models;

namespace BTL_WEB.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly DtbContext _dbContext;
        public CategoriesController(DtbContext dbContext) 
        {
          _dbContext = dbContext;
        }

        public async Task<IActionResult>Index()
        {
            return View( await _dbContext.Categories.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        public async Task<IActionResult> Edit(int? Id)     
        {
            if(Id == null)
            {
                return NotFound();
            }

            var category = await _dbContext.Categories.FindAsync(Id);
            if(category ==null )
            {
                return NotFound (string.Empty);
            }
             return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int Id, [Bind("CategoryId,CategoryName,CategoryDescription")] Categories categories )
        {
            if(Id != categories.CategoryId)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                try
                {
                    _dbContext.Update(categories);
                    await _dbContext.SaveChangesAsync();
                    RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException) 
                {
                    if(!CategoriesExists(categories.CategoryId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            else
            {
                RedirectToAction(nameof(Index));
            }
            return View(categories);
        }
        private  bool CategoriesExists(int categoryId) 
        {
            return _dbContext.Categories.Any(p=>p.CategoryId==categoryId); 
        }
    }
}
