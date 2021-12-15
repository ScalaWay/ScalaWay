using Microsoft.EntityFrameworkCore;

namespace ScalaWay.EntityFrameworkCore
{
    /// <summary>
    /// A base class which can be herited from any DbContext.
    /// </summary>
    public abstract class ScalaWayDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ConfigureFilters(modelBuilder);
        }

        protected virtual void ConfigureFilters(ModelBuilder modelBuilder)
        {

        }

    }
}