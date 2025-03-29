using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure_Layer.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBulider = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBulider.UseSqlServer("Data Source=DESKTOP-VHRQRS1\\SQLEXPRESS;Database=MahalShop;Integrated Security=True;Trust Server Certificate=True");
            return new ApplicationDbContext(optionsBulider.Options);
        }
    }
}
