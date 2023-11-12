using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Data.Configurations;

public class ClassroomConfiguration : IEntityTypeConfiguration<Classroom>
{
    public void Configure(EntityTypeBuilder<Classroom> builder)
    {
        //Table
        builder.ToTable("aula");

        //Primary Key
        builder.HasKey(x => x.Id)
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);;

        //Properties
        builder.Property(x => x.Id)
            .HasColumnName("aul_iCodigo");

        builder.Property(x => x.Code)
            .HasColumnName("aul_vcCodigo")
            .HasColumnType("VARCHAR(16)");

        builder.Property(x => x.Capacity)
            .HasColumnName("aul_iCapacidad");

        builder.Property(x => x.LocationId)
            .HasColumnName("loc_iCodigo");

        builder.HasOne(x => x.Location)
            .WithMany(y => y.Classrooms)
            .IsRequired();
    }
}