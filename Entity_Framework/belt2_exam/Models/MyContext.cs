using Microsoft.EntityFrameworkCore;

// the project is lowecase "b" as im belt2_exam
namespace belt2_exam.Models
{
    public class MyContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public MyContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users {get;set;}
        public DbSet<Association> Associations {get;set;}
        public DbSet<Hobby> Hobbies {get;set;}
        public DbSet<Proficiency> Proficiencies {get;set;}
    }
}