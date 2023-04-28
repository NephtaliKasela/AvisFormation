﻿// <auto-generated />
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(MonDBContext))]
    partial class MonDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Data.Avis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Commentaire")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("FormationId")
                        .HasColumnType("int");

                    b.Property<string>("NomUtilisateur")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Note")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("FormationId");

                    b.ToTable("Avis");
                });

            modelBuilder.Entity("Data.ContactMessage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Data.Formation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descriotion")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nameSeo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Formations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descriotion = "C# (C-Sharp) is a programming language developed by Microsoft that runs on the .NET Framework. C# is used to develop web apps, desktop apps, mobile apps, games and much more. Start learning C# now »",
                            name = "C#",
                            nameSeo = "----"
                        },
                        new
                        {
                            Id = 2,
                            Descriotion = "Le C++ est un langage compilé : pour écrire un tel programme, il faut commencer par écrire un ou plusieurs fichiers source. Ensuite, il faut compiler ces fichiers source grâce à un programme appelé compilateur afin d'obtenir un programme exécutable. Cette phase s'appelle la compilation.",
                            name = "C++",
                            nameSeo = "----"
                        },
                        new
                        {
                            Id = 3,
                            Descriotion = "Python is a computer programming language often used to build websites and software, automate tasks, and conduct data analysis. Python is a general-purpose language, meaning it can be used to create a variety of different programs and isn't specialized for any specific problems.",
                            name = "Python",
                            nameSeo = "----"
                        },
                        new
                        {
                            Id = 4,
                            Descriotion = "JavaScript (JS) is a lightweight, interpreted, or just-in-time compiled programming language with first-class functions. While it is most well-known as the scripting language for Web pages, many non-browser environments also use it, such as Node.js, Apache CouchDB and Adobe Acrobat.",
                            name = "JavaScript",
                            nameSeo = "----"
                        },
                        new
                        {
                            Id = 5,
                            Descriotion = "What is Java? Java is a widely used object-oriented programming language and software platform that runs on billions of devices, including notebook computers, mobile devices, gaming consoles, medical devices and many others. The rules and syntax of Java are based on the C and C++ languages.",
                            name = "Java",
                            nameSeo = "----"
                        });
                });

            modelBuilder.Entity("Data.ReRouting", b =>
                {
                    b.Property<string>("OldUrl")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("NewUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OldUrl");

                    b.ToTable("ReRouting");
                });

            modelBuilder.Entity("Data.Avis", b =>
                {
                    b.HasOne("Data.Formation", "Formation")
                        .WithMany("Avis")
                        .HasForeignKey("FormationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Formation");
                });

            modelBuilder.Entity("Data.Formation", b =>
                {
                    b.Navigation("Avis");
                });
#pragma warning restore 612, 618
        }
    }
}
