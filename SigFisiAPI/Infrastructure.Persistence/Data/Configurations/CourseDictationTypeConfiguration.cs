using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Data.Configurations;

public class CourseDictationTypeConfiguration : IEntityTypeConfiguration<CourseDictationType>
{
    public void Configure(EntityTypeBuilder<CourseDictationType> builder)
    {
        //Table
        builder.ToTable("curso_tipodictado");

        //Primary Key
        builder.HasKey(x => x.Id)
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);;

        //Properties
        builder.Property(x => x.Id)
            .HasColumnName("curtip_iCodigo");

        builder.Property(x => x.Name)
            .HasColumnName("curtip_vcName")
            .HasColumnType("VARCHAR(32)");
    }
}