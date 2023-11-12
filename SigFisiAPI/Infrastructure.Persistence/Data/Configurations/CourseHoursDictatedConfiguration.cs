using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Data.Configurations;

public class CourseHoursDictatedConfiguration : IEntityTypeConfiguration<CourseHoursDictated>
{
    public void Configure(EntityTypeBuilder<CourseHoursDictated> builder)
    {
        //Table
        builder.ToTable("curso_horasdictadas");

        //Primary Key
        builder.HasKey(x => x.Id)
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);;

        //Properties
        builder.Property(x => x.Id)
            .HasColumnName("curhor_iCodigo");

        builder.Property(x => x.Hours)
            .HasColumnName("curhor_iHoras");

        builder.Property(x => x.CourseId)
            .HasColumnName("cur_iCodigo");

        builder.Property(x => x.CourseDictationTypeId)
            .HasColumnName("curtip_iCogigo");

        //Relationships
        builder.HasOne(x => x.CourseDictationType)
            .WithMany(x => x.CourseHoursDictateds);

    }
}