using ManageUser.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManageUser.Infra.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .HasColumnName("Name")
                .IsRequired()
                .HasColumnType("string")
                .HasMaxLength(80);

            builder.Property(x => x.Password)
                .IsRequired()
                .HasColumnType("string")
                .HasMaxLength(1000);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasColumnType("string")
                .HasMaxLength(180);
        }
    }
}
