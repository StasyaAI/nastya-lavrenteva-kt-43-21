﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using _1_лабораторная.Database;

#nullable disable

namespace _1_лабораторная.Migrations
{
    [DbContext(typeof(TeacherDbContext))]
    partial class TeacherDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.35")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("_1_лабораторная.Models.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("department_id")
                        .HasComment("Идентификатор записи кафедры");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DepartmentId"));

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar")
                        .HasColumnName("c_department_name")
                        .HasComment("Название кафедры");

                    b.Property<int?>("TeacherHeaderId")
                        .HasColumnType("integer");

                    b.HasKey("DepartmentId")
                        .HasName("pk_cd_departament_department_id");

                    b.HasIndex("TeacherHeaderId")
                        .IsUnique();

                    b.ToTable("cd_departament", (string)null);
                });

            modelBuilder.Entity("_1_лабораторная.Models.Position", b =>
                {
                    b.Property<int>("PositionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("position_id")
                        .HasComment("Идентификатор записи должности");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PositionId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar")
                        .HasColumnName("c_position_name")
                        .HasComment("Название должности");

                    b.HasKey("PositionId")
                        .HasName("pk_cd_position_position_id");

                    b.ToTable("cd_position", (string)null);
                });

            modelBuilder.Entity("_1_лабораторная.Models.Teacher", b =>
                {
                    b.Property<int>("TeacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("teacher_id")
                        .HasComment("Идентификатор записи студента");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TeacherId"));

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int4")
                        .HasColumnName("f_department_id");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("c_teacher_firstname");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("c_teacher_lastname");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("c_teacher_middlename");

                    b.Property<int>("PositionId")
                        .HasColumnType("int4")
                        .HasColumnName("f_position_id");

                    b.HasKey("TeacherId")
                        .HasName("pk_cd_teacher_teacher_id");

                    b.HasIndex(new[] { "PositionId" }, "idx_cd_teacher_fk_c_position_id");

                    b.HasIndex(new[] { "DepartmentId" }, "idx_cd_teacher_fk_f_department_id");

                    b.ToTable("cd_teacher", (string)null);
                });

            modelBuilder.Entity("_1_лабораторная.Models.Department", b =>
                {
                    b.HasOne("_1_лабораторная.Models.Teacher", "Teacher")
                        .WithOne()
                        .HasForeignKey("_1_лабораторная.Models.Department", "TeacherHeaderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("_1_лабораторная.Models.Teacher", b =>
                {
                    b.HasOne("_1_лабораторная.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_f_department_id");

                    b.HasOne("_1_лабораторная.Models.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_f_position_id");

                    b.Navigation("Department");

                    b.Navigation("Position");
                });
#pragma warning restore 612, 618
        }
    }
}
