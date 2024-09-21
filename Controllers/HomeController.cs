using asp_mvc_hello_bookrental.Models;
using asp_mvc_hello_bookrental.Data;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace asp_mvc_hello_bookrental.Controllers
{
    // Default HomeController 
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        
        // adding context feild
        private readonly LibraryContext _context;

        // adding context
        public HomeController(ILogger<HomeController> logger, LibraryContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            // adding all available books to pass to view
            var allBooks = _context.Books.ToList();

            return View(allBooks);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // adding method for renting a book
        [HttpPost]
        public IActionResult RentBook(int id)
        {
            var book = _context.Books.Find(id);
            if (book != null && !book.IsRented)
            {
                book.IsRented = true;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // adding method for retunring a book
        [HttpPost]
        public IActionResult ReturnBook(int id)
        {
            var book = _context.Books.Find(id);
            if (book != null && book.IsRented)
            {
                book.IsRented = false;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
