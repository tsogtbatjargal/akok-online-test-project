﻿// <auto-generated />
using AKOK_BlazorServer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AKOK_BlazorServer.Data.FortuneMigration
{
    [DbContext(typeof(FortuneDbContext))]
    partial class FortuneDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.4");

            modelBuilder.Entity("AKOK_BlazorServer.Models.ResultText", b =>
                {
                    b.Property<int>("Number")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LongText")
                        .HasColumnType("TEXT");

                    b.HasKey("Number");

                    b.ToTable("ResultTexts");
                });
#pragma warning restore 612, 618
        }
    }
}
