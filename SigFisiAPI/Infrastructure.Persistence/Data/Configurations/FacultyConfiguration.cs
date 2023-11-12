using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Data.Configurations;

public class FacultyConfiguration : IEntityTypeConfiguration<Faculty>
{
    public void Configure(EntityTypeBuilder<Faculty> builder)
    {
        //Table
        builder.ToTable("facultad");

        //Primary Key
        builder.HasKey(x => x.Id)
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);;

        //Properties
        builder.Property(x => x.Id)
            .HasColumnName("fac_iCodigo");

        builder.Property(x => x.Code)
            .HasColumnName("fac_vcCodigo")
            .HasColumnType("VARCHAR(64)");

        builder.Property(x => x.Name)
            .HasColumnName("fac_vcNombre")
            .HasColumnType("VARCHAR(64)");
    }
}