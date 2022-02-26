using ManageUser.Domain.Entities;
using ManageUser.Infra.Mapping;
using Microsoft.EntityFrameworkCore;

namespace ManageUser.Infra.Context
{
    public class ManagerUserContext : DbContext
    {
        public virtual DbSet<User> Users => Set<User>();

        public ManagerUserContext()
        { }

        public ManagerUserContext(DbContextOptions<ManagerUserContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
        }
    }
}
