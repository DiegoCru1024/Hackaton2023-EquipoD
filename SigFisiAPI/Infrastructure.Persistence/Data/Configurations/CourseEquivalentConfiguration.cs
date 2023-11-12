using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Data.Configurations;

public class CourseEquivalentConfiguration : IEntityTypeConfiguration<CourseEquivalent>
{
    public void Configure(EntityTypeBuilder<CourseEquivalent> builder)
    {
        //Table
        builder.ToTable("curso_equivalente");

        //Primary Key
        builder.HasKey(x => x.Id)
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);;

        //Properties
        builder.Property(x => x.Id)
            .HasColumnName("cureqi_iCodigo");

        builder.Property(x => x.CourseId)
            .HasColumnName("cur_iCodigo");

        builder.Property(x => x.EquivalentId)
            .HasColumnName("equ_iCodigo");

        builder.Ignore(x => x.Equivalent);
    }
}