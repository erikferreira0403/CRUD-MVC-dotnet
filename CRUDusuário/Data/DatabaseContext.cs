using CRUDusuário.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDusuário.Data
{
    public class DatabaseContext : DbContext {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) 
        {
        
        }
        public DbSet<User> users { get; set; }
    }
}
