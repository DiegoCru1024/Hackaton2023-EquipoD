using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Data.Configurations;

public class SchoolConfiguration : IEntityTypeConfiguration<School>
{
    public void Configure(EntityTypeBuilder<School> builder)
    {
        builder.ToTable("escuela");

        //Primary Key
        builder.HasKey(x => x.Id)
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);;

        //Properties
        builder.Property(x => x.Id)
            .HasColumnName("esc_iCodigo");

        builder.Property(x => x.Code)
            .HasColumnName("esc_vcCodigo")
            .HasColumnType("VARCHAR(16)");

        builder.Property(x => x.Name)
            .HasColumnName("esc_vcNombre")
            .HasColumnType("VARCHAR(64)");

        builder.Property(x => x.IsActive)
            .HasColumnName("esc_bActive");

        builder.Property(x => x.FacultyId)
            .HasColumnName("fac_iCodigo");

        builder.Property(x => x.AcademicAreaId)
            .HasColumnName("areaca_iCodigo");

        //Relationships
        builder.HasOne(x => x.Faculty)
            .WithMany(y => y.Schools)
            .IsRequired();

        builder.HasOne(x => x.AcademicArea)
            .WithMany(y => y.Schools)
            .IsRequired();

        builder.HasMany(x => x.StudyPlans)
            .WithOne(y => y.School)
            .IsRequired();
    }
}