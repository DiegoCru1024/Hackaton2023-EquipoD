using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Data.Configurations;

public class StudyPlanConfiguration : IEntityTypeConfiguration<StudyPlan>
{
    public void Configure(EntityTypeBuilder<StudyPlan> builder)
    {
        //Table
        builder.ToTable("plan_estudios");

        //Primary Key
        builder.HasKey(x => x.Id)
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);;

        //Properties
        builder.Property(x => x.Id)
            .HasColumnName("plaest_iCodigo");

        builder.Property(x => x.Code)
            .HasColumnName("plaest_vcCodigo")
            .HasColumnType("VARCHAR(8)");

        builder.Property(x => x.RR)
            .HasColumnName("plaest_vcRR")
            .HasColumnType("VARCHAR(16)");

        builder.Property(x => x.Vigency)
            .HasColumnName("plaest_dVigencia")
            .HasColumnType("DATE");;

        builder.Property(x => x.Credits)
            .HasColumnName("plaest_iCreditos");

        builder.Property(x => x.IsActive)
            .HasColumnName("plaest_bActivo");
    }
}