using Microsoft.EntityFrameworkCore;
using uwebapi.Models;

namespace uwebapi.Data
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
          
        }
          public DbSet<Character> Characters { get; set; }
          public DbSet<User> Users { get; set; }

    }
}