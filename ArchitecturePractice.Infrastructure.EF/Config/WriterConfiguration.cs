using ArchitecturePractice.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArchitecturePractice.Infrastructure.EF.Config
{
    public class WriterConfiguration : IEntityTypeConfiguration<Writer>
    {
        public void Configure(EntityTypeBuilder<Writer> builder)
        {
            builder.HasKey(a => a.WriterID);
            builder.Property(a => a.WriterName).HasColumnType("nvarchar(30)").IsRequired();
            builder.Property(a => a.WriterSurname).HasColumnType("nvarchar(30)").IsRequired();
            builder.HasMany(a => a.Books);
        }
    }
}
