using Microsoft.EntityFrameworkCore;

namespace CRUDelicious.Models
{
    public class MyContext : DbContext
    {
        public MyContext (DbContextOptions options) : base(options) { }

        // Code ↓ is setting the Model "Dish" into our database.
        public DbSet<Dish> Dishs {get;set;}
    }
}