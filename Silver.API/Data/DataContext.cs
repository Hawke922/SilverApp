using Microsoft.EntityFrameworkCore;

namespace Silver.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}
        
    }
}