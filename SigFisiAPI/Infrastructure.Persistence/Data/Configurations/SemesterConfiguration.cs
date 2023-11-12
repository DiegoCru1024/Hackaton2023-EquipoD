using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Data.Configurations;

public class SemesterConfiguration : IEntityTypeConfiguration<Semester>
{
    public void Configure(EntityTypeBuilder<Semester> builder)
    {
        //Table
        builder.ToTable("semestre");

        //Primary Key
        builder.HasKey(x => x.Id)
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);;

        //Properties
        builder.Property(x => x.Id)
            .HasColumnName("sem_iCodigo");

        builder.Property(x => x.Code)
            .HasColumnName("sem_vcCodigo")
            .HasColumnType("VARCHAR(8)");

        builder.Property(x => x.StartDate)
            .HasColumnName("sem_dFechaInicio")
            .HasColumnType("DATE");

        builder.Property(x => x.EndDate)
            .HasColumnName("sem_dFechaFin")
            .HasColumnType("DATE");

        builder.Property(x => x.IsActive)
            .HasColumnName("sem_bActive");
    }
}