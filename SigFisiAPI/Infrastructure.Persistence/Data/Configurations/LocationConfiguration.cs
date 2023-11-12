using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Data.Configurations;

public class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.ToTable("locales");

        //Primary Key
        builder.HasKey(x => x.Id)
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);;

        //Properties
        builder.Property(x => x.Id)
            .HasColumnName("loc_iCodigo");

        builder.Property(x => x.Code)
            .HasColumnName("loc_vcCodigo")
            .HasColumnType("VARCHAR(16)");

        builder.Property(x => x.Name)
            .HasColumnName("loc_vcNombre")
            .HasColumnType("VARCHAR(64)");
    }
}