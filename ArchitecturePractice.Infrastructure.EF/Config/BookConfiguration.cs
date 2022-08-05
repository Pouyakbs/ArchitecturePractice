using ArchitecturePractice.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArchitecturePractice.Infrastructure.EF.Config
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(a => a.BookID);
            builder.Property(a => a.BookTitle).HasColumnType("nvarchar(60)").IsRequired();
            builder.Property(a => a.Price).HasColumnType("int").IsRequired();
            builder.Property(a => a.Quantity).HasColumnType("int").IsRequired();
            builder.Property(a => a.PubDate).HasColumnType("datetime").IsRequired();
            builder.HasOne(a => a.Writer).WithMany().HasForeignKey(a => a.WriterID);

        }
    }
}
