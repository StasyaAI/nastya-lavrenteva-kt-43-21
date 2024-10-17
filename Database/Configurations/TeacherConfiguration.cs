using _1_лабораторная.Helpers;
using _1_лабораторная.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.RegularExpressions;

namespace _1_лабораторная.Database.Configurations
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        private const string TableName = "cd_teacher";
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder
                .HasKey(p => p.TeacherId)
                .HasName($"pk_{TableName}_teacher_id");

            builder.Property(p => p.TeacherId)
                  .ValueGeneratedOnAdd();

            builder.Property(p => p.TeacherId)
                .HasColumnName("teacher_id")
                .HasComment("Идентификатор записи преподавателя");

            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasColumnName("c_teacher_firstname")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Имя преподавателя");

            builder.Property(p => p.LastName)
                .IsRequired()
                .HasColumnName("c_teacher_lastname")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Фамилия преподавателя");

            builder.Property(p => p.MiddleName)
                .HasColumnName("c_teacher_middlename")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Отчество преподавателя");

        // Конфигурирование "Кафедра"
            builder.Property(p => p.DepartmentId)
                  .IsRequired()
                  .HasColumnName("f_department_id")
                  .HasColumnType(ColumnType.Int)
                  .HasComment("Идентификатор кафедры");

            builder.ToTable(TableName)
                .HasOne(p => p.Department)
                .WithMany()
                .HasForeignKey(p => p.DepartmentId)
                .HasConstraintName("fk_f_deparment_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(TableName)
               .HasIndex(p => p.DepartmentId, $"idx_{TableName}_fk_f_department_id");

            builder.Navigation(p => p.Department).AutoInclude();

        // Конфигурирование "Должность"
            builder.Property(p => p.PositionId)
                  .IsRequired()
                  .HasColumnName("f_position_id")
                  .HasColumnType(ColumnType.Int)
                  .HasComment("Идентификатор должности");

            builder.ToTable(TableName)
                .HasOne(p => p.Position)
                .WithMany()
                .HasForeignKey(p => p.PositionId)
                .HasConstraintName("fk_f_position_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(TableName)
               .HasIndex(p => p.PositionId, $"idx_{TableName}_fk_f_position_id");

            builder.Navigation(p => p.Position);
        }
    }
}
