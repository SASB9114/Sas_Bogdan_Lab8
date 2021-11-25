using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sas_Bogdan_Lab8.Data;
using Sas_Bogdan_Lab8.Models;

namespace Sas_Bogdan_Lab8.Pages.Books
{
    public class EditModel : BookCategoriesPageModel
    {
<<<<<<< Updated upstream
        private readonly Gramada_Cosmin_Lab8Context _context;

        public EditModel(Gramada_Cosmin_Lab8Context context)
=======
        private readonly Sas_Bogdan_Lab8.Data.Sas_Bogdan_Lab8Context _context;

        public EditModel(Sas_Bogdan_Lab8.Data.Sas_Bogdan_Lab8Context context)
>>>>>>> Stashed changes
        {
            _context = context;
        }

        [BindProperty]
        public Book Book { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book = await _context.Book
             .Include(b => b.Publisher)
             .Include(b => b.BookCategories).ThenInclude(b => b.Category)
             .AsNoTracking()
             .FirstOrDefaultAsync(m => m.ID == id);

            if (Book == null)
            {
                return NotFound();
            }
            PopulateAssignedCategoryData(_context, Book);

            ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID", "PublisherName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var bookToUpdate = await _context.Book
            .Include(i => i.Publisher)
            .Include(i => i.BookCategories)
            .ThenInclude(i => i.Category)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (bookToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync(
                bookToUpdate, 
                "Book",
                i => i.Title, i => i.Author,
                i => i.Price, i => i.PublishingDate, i => i.Publisher))
            {
                UpdateBookCategories(_context, selectedCategories, bookToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            
            UpdateBookCategories(_context, selectedCategories, bookToUpdate);
            PopulateAssignedCategoryData(_context, bookToUpdate);
            return Page();
        }
    }
}
