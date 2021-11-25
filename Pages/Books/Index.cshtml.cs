using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
<<<<<<< Updated upstream
using Gramada_Cosmin_Lab8.Data;
using Gramada_Cosmin_Lab8.Models;
using System.Linq;
=======
using Sas_Bogdan_Lab8.Data;
using Sas_Bogdan_Lab8.Models;
>>>>>>> Stashed changes

namespace Sas_Bogdan_Lab8.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly Sas_Bogdan_Lab8Context _context;

        public IndexModel(Sas_Bogdan_Lab8Context context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; }
        public BookData BookD { get; set; }
        public int BookID { get; set; }
        public int CategoryID { get; set; }
        public async Task OnGetAsync(int? id, int? categoryID)
        {
            BookD = new BookData();

            BookD.Books = await _context.Book
                .Include(b => b.Publisher)
                .Include(b => b.BookCategories)
                .ThenInclude(b => b.Category)
                .AsNoTracking()
                .OrderBy(b => b.Title)
                .ToListAsync();

            if (id != null)
            {
                BookID = id.Value;
                Book book = BookD.Books
                .Where(i => i.ID == id.Value).Single();
                BookD.Categories = book.BookCategories.Select(s => s.Category);
            }
        }
    }
}
