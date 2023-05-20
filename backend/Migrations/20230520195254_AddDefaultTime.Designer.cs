﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using backend.Entity;

#nullable disable

namespace backend.Migrations
{
    [DbContext(typeof(WordDbContext))]
    [Migration("20230520195254_AddDefaultTime")]
    partial class AddDefaultTime
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("backend.Models.Word.WordRecord", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValue(new DateTime(2023, 5, 20, 15, 52, 53, 976, DateTimeKind.Local).AddTicks(6148));

                    b.Property<string>("EnglishWord")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Frequency")
                        .HasColumnType("int");

                    b.Property<bool>("IsMemorized")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("T_WordRecord", (string)null);
                });

            modelBuilder.Entity("backend.Models.Word.WordRecord", b =>
                {
                    b.OwnsOne("backend.Models.Word.Translation", "Translation", b1 =>
                        {
                            b1.Property<long>("WordRecordId")
                                .HasColumnType("bigint");

                            b1.Property<string>("Definition")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<int>("Language")
                                .HasColumnType("int");

                            b1.HasKey("WordRecordId");

                            b1.ToTable("T_WordRecord");

                            b1.WithOwner()
                                .HasForeignKey("WordRecordId");
                        });

                    b.Navigation("Translation")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
