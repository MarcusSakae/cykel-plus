﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RunningApp.Data;

#nullable disable

namespace RunningApp.Migrations
{
    [DbContext(typeof(EfContex))]
    [Migration("20230512061059_Init23")]
    partial class Init23
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("RunningApp.ApplicationCore.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NickName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ProfilePicture")
                        .HasColumnType("TEXT");

                    b.Property<int?>("RunningInfoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RunningInfoId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RunningApp.RunningInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Distance")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("Tempo")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("X")
                        .HasColumnType("REAL");

                    b.Property<double>("Y")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("RunningInfos");
                });

            modelBuilder.Entity("RunningApp.ApplicationCore.User", b =>
                {
                    b.HasOne("RunningApp.RunningInfo", null)
                        .WithMany("Users")
                        .HasForeignKey("RunningInfoId");
                });

            modelBuilder.Entity("RunningApp.RunningInfo", b =>
                {
                    b.HasOne("RunningApp.ApplicationCore.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("RunningApp.RunningInfo", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}