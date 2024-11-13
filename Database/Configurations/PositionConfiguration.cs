using _1_лабораторная.Helpers;
using _1_лабораторная.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace _1_лабораторная.Database.Configurations
{
    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        private const string TableName = "cd_position";

        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.HasKey(p => p.PositionId)
                   .HasName($"pk_{TableName}_position_id");

            builder.Property(p => p.PositionId)
                    .ValueGeneratedOnAdd();

            builder.Property(p => p.PositionId)
                .HasColumnName("position_id")
                .HasComment("Идентификатор записи должности");

            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnName("c_position_name")
                .HasColumnType(ColumnType.String).HasMaxLength(150)
                .HasComment("Название должности");

            builder.ToTable(TableName);
        }
    }
}
