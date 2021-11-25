using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
<<<<<<< Updated upstream
using Gramada_Cosmin_Lab8.Data;
using Gramada_Cosmin_Lab8.Models;
using System.Collections.Generic;
=======
using Sas_Bogdan_Lab8.Data;
using Sas_Bogdan_Lab8.Models;
>>>>>>> Stashed changes

namespace Sas_Bogdan_Lab8.Pages.Books
{
    public class CreateModel : BookCategoriesPageModel
    {
<<<<<<< Updated upstream
        private readonly Gramada_Cosmin_Lab8Context _context;

        public CreateModel(Gramada_Cosmin_Lab8Context context)
=======
        private readonly Sas_Bogdan_Lab8.Data.Sas_Bogdan_Lab8Context _context;

        public CreateModel(Sas_Bogdan_Lab8.Data.Sas_Bogdan_Lab8Context context)
>>>>>>> Stashed changes
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID", "PublisherName");

            var book = new Book();
            book.BookCategories = new List<BookCategory>();
            PopulateAssignedCategoryData(_context, book);

            return Page();
        }

        [BindProperty]
        public Book Book { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newBook = new Book();
            if (selectedCategories != null)
            {
                newBook.BookCategories = new List<BookCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new BookCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newBook.BookCategories.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync(
                newBook,
                "Book",
                i => i.Title, i => i.Author,
                i => i.Price, i => i.PublishingDate, i => i.PublisherID))
            {
                _context.Book.Add(newBook);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newBook);
            return Page();
        }
    }
}
