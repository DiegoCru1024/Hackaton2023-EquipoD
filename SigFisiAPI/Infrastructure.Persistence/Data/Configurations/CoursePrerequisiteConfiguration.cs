using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Data.Configurations;

public class CoursePrerequisiteConfiguration : IEntityTypeConfiguration<CoursePrerequisite>
{
    public void Configure(EntityTypeBuilder<CoursePrerequisite> builder)
    {
        //Table
        builder.ToTable("curso_prerequisito");

        //Primary Key
        builder.HasKey(x => x.Id)
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);;

        //Properties
        builder.Property(x => x.Id)
            .HasColumnName("curpre_iCodigo");

        builder.Property(x => x.CourseId)
            .HasColumnName("cur_iCodigo");

        builder.Property(x => x.Prerequisite)
            .HasColumnName("req_iCodigo");

        builder.Ignore(x => x.Prerequisite);
    }
}