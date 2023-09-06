﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using backend_API.Data;

#nullable disable

namespace backend_API.Migrations
{
    [DbContext(typeof(CCGToolsDbContext))]
    [Migration("20230718090659_final")]
    partial class final
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("backend_API.Data.Activity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ActivityCategoryId")
                        .HasColumnType("int");

                    b.Property<int>("ActivityCategoryStateId")
                        .HasColumnType("int");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("NextId")
                        .HasColumnType("int");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<int?>("PreviousId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("TotalHours")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ActivityCategoryId");

                    b.HasIndex("ActivityCategoryStateId");

                    b.HasIndex("ParentId");

                    b.ToTable("Activity");
                });

            modelBuilder.Entity("backend_API.Data.ActivityCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("UpdateBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("ActivityCategory");
                });

            modelBuilder.Entity("backend_API.Data.ActivityCategoryState", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("ActivityCategoryId")
                        .HasColumnType("int");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsLocked")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("UpdateBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("ActivityCategoryId");

                    b.ToTable("ActivityCategoryState");
                });

            modelBuilder.Entity("backend_API.Data.ActivityWorkerProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ActivityId")
                        .HasColumnType("int");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("UpdateBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("WorkerProfileId")
                        .HasColumnType("int");

                    b.Property<bool>("isAssociated")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("totalHours")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ActivityId");

                    b.HasIndex("WorkerProfileId");

                    b.ToTable("ActivityWorkerProfile");
                });

            modelBuilder.Entity("backend_API.Data.WorkerProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("UpdateBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("WorkerProfile");
                });

            modelBuilder.Entity("backend_API.Data.Activity", b =>
                {
                    b.HasOne("backend_API.Data.ActivityCategory", null)
                        .WithMany("Activities")
                        .HasForeignKey("ActivityCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend_API.Data.ActivityCategoryState", null)
                        .WithMany("Activities")
                        .HasForeignKey("ActivityCategoryStateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend_API.Data.Activity", "Parent")
                        .WithMany("Child")
                        .HasForeignKey("ParentId");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("backend_API.Data.ActivityCategoryState", b =>
                {
                    b.HasOne("backend_API.Data.ActivityCategory", null)
                        .WithMany("ActivityCategoryStates")
                        .HasForeignKey("ActivityCategoryId");
                });

            modelBuilder.Entity("backend_API.Data.ActivityWorkerProfile", b =>
                {
                    b.HasOne("backend_API.Data.Activity", null)
                        .WithMany("TimesheetId")
                        .HasForeignKey("ActivityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend_API.Data.WorkerProfile", null)
                        .WithMany("ActivityWorkers")
                        .HasForeignKey("WorkerProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("backend_API.Data.Activity", b =>
                {
                    b.Navigation("Child");

                    b.Navigation("TimesheetId");
                });

            modelBuilder.Entity("backend_API.Data.ActivityCategory", b =>
                {
                    b.Navigation("Activities");

                    b.Navigation("ActivityCategoryStates");
                });

            modelBuilder.Entity("backend_API.Data.ActivityCategoryState", b =>
                {
                    b.Navigation("Activities");
                });

            modelBuilder.Entity("backend_API.Data.WorkerProfile", b =>
                {
                    b.Navigation("ActivityWorkers");
                });
#pragma warning restore 612, 618
        }
    }
}
