﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestApi3K.DataBaseContext;

#nullable disable

namespace TestApi3K.Migrations
{
    [DbContext(typeof(ContextDb))]
    partial class ContextDbModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TestApi3K.Model.Skins", b =>
                {
                    b.Property<int>("id_Skin")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_Skin"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("id_Skin");

                    b.ToTable("Skins");
                });

            modelBuilder.Entity("TestApi3K.Model.Users", b =>
                {
                    b.Property<int>("id_User")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_User"));

                    b.Property<int>("Currency")
                        .HasColumnType("int");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_User");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TestApi3K.Model.UsersSkins", b =>
                {
                    b.Property<int>("id_User_Skin")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_User_Skin"));

                    b.Property<int>("id_Skin")
                        .HasColumnType("int");

                    b.Property<int>("id_User")
                        .HasColumnType("int");

                    b.HasKey("id_User_Skin");

                    b.ToTable("UsersSkins");
                });
#pragma warning restore 612, 618
        }
    }
}
