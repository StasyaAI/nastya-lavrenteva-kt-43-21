﻿using _1_лабораторная.Helpers;
using _1_лабораторная.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _1_лабораторная.Database.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        private const string TableName = "cd_departament";

        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(p => p.DepartmentId)
                   .HasName($"pk_{TableName}_department_id");

            builder.Property(p => p.DepartmentId)
                    .ValueGeneratedOnAdd();

            builder.Property(p => p.DepartmentId)
                .HasColumnName("department_id")
                .HasComment("Идентификатор записи кафедры");

            builder.HasOne(d => d.Teacher)
              .WithOne()
              .HasForeignKey<Department>(t => t.TeacherHeaderId)
              .OnDelete(DeleteBehavior.Cascade);

            builder.Property(p => p.DepartmentName)
                .IsRequired()
                .HasColumnName("c_department_name")
                .HasColumnType(ColumnType.String).HasMaxLength(150)
                .HasComment("Название кафедры");

            builder.ToTable(TableName);
        }
    }
}
