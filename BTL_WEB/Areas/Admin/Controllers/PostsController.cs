using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BTL_WEB.Data;
using BTL_WEB.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;
using BTL_WEB.Models.ViewModel;

namespace BTL_WEB.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PostsController : Controller
    {
        private readonly DtbContext _context;

        public PostsController(DtbContext context)
        {
            _context = context;
        }

        // GET: Admin/Posts
        public async Task<IActionResult> Index()
        {
            var dtbContext = _context.Posts.Include(p => p.Account).Include(p => p.Category);
            return View(await dtbContext.ToListAsync());
        }

        // GET: Admin/Posts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var posts = await _context.Posts
                .Include(p => p.Account)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.PostID == id);
            if (posts == null)
            {
                return NotFound();
            }

            return View(posts);
        }
        //public IActionResult GetImage(int ItemId)
        //{
        //    var item = _context.Ge
        //    return File()
        //}
        // GET: Admin/Posts/Create
        public IActionResult Create()
        {
            ViewData["AccountID"] = new SelectList(_context.Accounts, "AccountID", "ConfirmPassword");
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryId", "CategoryDescription");
            return View();
        }

        // POST: Admin/Posts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PostID,AccountID,CategoryID,ImageUrl,Keyword,isHot,isNewfeed,isAccept,CreatedTime,Published")] Posts posts)
        {
            if (ModelState.IsValid)
            {   
                _context.Add(posts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AccountID"] = new SelectList(_context.Accounts, "AccountID", "ConfirmPassword", posts.AccountID);
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryId", "CategoryDescription", posts.CategoryID);
            return View(posts);
        }

        // GET: Admin/Posts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }
            var post =await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            var postviewmodel = new PostViewModel
            {
                PostID = post.PostID,
                FullName = post.Account.FullName,
                CategoryName=post.Category.CategoryName,
                ImageUrl= post.ImageUrl,
                Keyword= post.Keyword,
                isHot=post.isHot,
                isAccept=post.isAccept,
                isNewfeed=post.isNewfeed,
                CreatedTime=post.CreatedTime,
                Published=post.Published,

            };
         
            ViewData["AccountID"] = new SelectList(_context.Accounts, "AccountID", "AccountID", postviewmodel.AccountID);
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", postviewmodel.CategoryID);
            return View(postviewmodel);
        }

        // POST: Admin/Posts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PostID,AccountID,CategoryID,ImageUrl,Keyword,isHot,isNewfeed,isAccept,CreatedTime,Published")] Posts posts)
        {
            if (id != posts.PostID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(posts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostsExists(posts.PostID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AccountID"] = new SelectList(_context.Accounts, "AccountID", "AccountID", posts.AccountID);
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", posts.CategoryID);
            return View(posts);
        }

        // GET: Admin/Posts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var posts = await _context.Posts
                .Include(p => p.Account)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.PostID == id);
            if (posts == null)
            {
                return NotFound();
            }

            return View(posts);
        }

        // POST: Admin/Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var posts = await _context.Posts.FindAsync(id);
            if (posts != null)
            {
                _context.Posts.Remove(posts);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostsExists(int id)
        {
            return _context.Posts.Any(e => e.PostID == id);
        }
    }
}
