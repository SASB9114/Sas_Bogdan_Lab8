using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Sas_Bogdan_Lab8.Data;
using Sas_Bogdan_Lab8.Models;

namespace Sas_Bogdan_Lab8.Pages.Publishers
{
    public class DeleteModel : PageModel
    {
<<<<<<< Updated upstream
        private readonly Gramada_Cosmin_Lab8Context _context;

        public DeleteModel(Gramada_Cosmin_Lab8Context context)
=======
        private readonly Sas_Bogdan_Lab8.Data.Sas_Bogdan_Lab8Context _context;

        public DeleteModel(Sas_Bogdan_Lab8.Data.Sas_Bogdan_Lab8Context context)
>>>>>>> Stashed changes
        {
            _context = context;
        }

        [BindProperty]
        public Publisher Publisher { get; set; }
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Publisher = await _context.Publisher.FirstOrDefaultAsync(m => m.ID == id);

            if (Publisher == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var books = await _context
                .Book
                .Where(b => b.PublisherID == id)
                .ToListAsync();

            if (books.Count != 0)
            {
                ErrorMessage = "Unable to delete Publisher as it is used in one or more books";
                return Page();
            }

            Publisher = await _context.Publisher.FindAsync(id);

            if (Publisher != null)
            {
                _context.Publisher.Remove(Publisher);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
