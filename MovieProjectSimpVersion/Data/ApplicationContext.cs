using Microsoft.EntityFrameworkCore;
using MovieProjectSimpVersion.Models;

namespace MovieProjectSimpVersion.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options)
        {

        }


        public DbSet<Movie> Movies { get; set; }
    }
}
