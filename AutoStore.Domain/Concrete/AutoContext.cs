using AutoStore.Domain.Entities;
using System.Data.Entity;
namespace AutoStore.Domain.Concrete
{
    public class AutoContext: DbContext
    {
        public DbSet<Auto> Autos { get; set; }
        
        
    }
}
