using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Data.Configurations;

public class AcademicAreaConfiguration : IEntityTypeConfiguration<AcademicArea>
{
    public void Configure(EntityTypeBuilder<AcademicArea> builder)
    {
        //Table
        builder.ToTable("area_academica");

        //Primary Key
        builder.HasKey(x => x.Id)
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);;

        //Properties
        builder.Property(x => x.Id)
            .HasColumnName("areaca_iCodigo");

        builder.Property(x => x.Code)
            .HasColumnName("areaca_vcCodigo")
            .HasColumnType("VARCHAR(4)");

        builder.Property(x => x.Name)
            .HasColumnName("areaca_vcNombre")
            .HasColumnType("VARCHAR(64)");

        builder.Property(x => x.IsActive)
            .HasColumnName("areaca_bActivo");
    }
}