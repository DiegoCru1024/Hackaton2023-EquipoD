using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Data.Configurations;

public class CourseTypeConfiguration : IEntityTypeConfiguration<CourseType>
{
    public void Configure(EntityTypeBuilder<CourseType> builder)
    {
        builder.ToTable("curso_tipo");

        //Primary Key
        builder.HasKey(x => x.Id)
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);;

        //Properties
        builder.Property(x => x.Id)
            .HasColumnName("curtip_iCodigo");

        builder.Property(x => x.Name)
            .HasColumnName("curtip_vcNombre")
            .HasColumnType("VARCHAR(32)");

        builder.Property(x => x.IsActive)
            .HasColumnName("curtip_bActivo");
    }
}