using BlazorCRUD.lib;
using Microsoft.EntityFrameworkCore;

namespace BlazorCRUD.api.Data
{
    public class Datadbcontext : DbContext
    {
        public Datadbcontext(DbContextOptions<Datadbcontext> options) : base(options)
        {
        }
        public DbSet<Student> tbl_students { get; set; }
    }
}
