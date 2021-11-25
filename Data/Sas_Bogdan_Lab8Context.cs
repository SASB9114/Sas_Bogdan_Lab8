using Microsoft.EntityFrameworkCore;
using Sas_Bogdan_Lab8.Models;

namespace Sas_Bogdan_Lab8.Data
{
    public class Sas_Bogdan_Lab8Context : DbContext
    {
        public Sas_Bogdan_Lab8Context (DbContextOptions<Sas_Bogdan_Lab8Context> options)
            : base(options)
        {
        }

        public DbSet<Book> Book { get; set; }

        public DbSet<Publisher> Publisher { get; set; }

        public DbSet<Sas_Bogdan_Lab8.Models.Category> Category { get; set; }
    }
}
