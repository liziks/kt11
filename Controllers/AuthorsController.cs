using asp.netKT11.Data;
using asp.netKT11.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace asp.netKT11.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly AppDbContext _db;

        public AuthorsController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.Authors.Include(a => a.Books).ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Author author)
        {
            _db.Authors.Add(author);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var author = _db.Authors.Find(id);
            _db.Authors.Remove(author);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
