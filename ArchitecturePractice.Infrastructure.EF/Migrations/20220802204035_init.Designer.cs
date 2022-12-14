// <auto-generated />
using System;
using ArchitecturePractice.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ArchitecturePractice.Infrastructure.EF.Migrations
{
    [DbContext(typeof(DemoContext))]
    [Migration("20220802204035_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ArchitecturePractice.Core.Domain.Entities.Book", b =>
                {
                    b.Property<int>("BookID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BookTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<DateTime>("PubDate")
                        .HasColumnType("datetime");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("WriterID")
                        .HasColumnType("int");

                    b.Property<int?>("WriterID1")
                        .HasColumnType("int");

                    b.HasKey("BookID");

                    b.HasIndex("WriterID");

                    b.HasIndex("WriterID1");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("ArchitecturePractice.Core.Domain.Entities.Writer", b =>
                {
                    b.Property<int>("WriterID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("WriterName")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("WriterSurname")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("WriterID");

                    b.ToTable("Writers");
                });

            modelBuilder.Entity("ArchitecturePractice.Core.Domain.Entities.Book", b =>
                {
                    b.HasOne("ArchitecturePractice.Core.Domain.Entities.Writer", "Writer")
                        .WithMany()
                        .HasForeignKey("WriterID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ArchitecturePractice.Core.Domain.Entities.Writer", null)
                        .WithMany("Books")
                        .HasForeignKey("WriterID1");
                });
#pragma warning restore 612, 618
        }
    }
}
