using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Data.Configurations;

public class CourseTrainingAreaConfiguration : IEntityTypeConfiguration<CourseTrainingArea>
{
    public void Configure(EntityTypeBuilder<CourseTrainingArea> builder)
    {
        //Table
        builder.ToTable("curso_areaformativa");

        //Primary Key
        builder.HasKey(x => x.Id)
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);;

        //Properties
        builder.Property(x => x.Id)
            .HasColumnName("curare_iCodigo");

        builder.Property(x => x.Name)
            .HasColumnName("curare_vcNombre")
            .HasColumnType("VARCHAR(32)");;
    }
}