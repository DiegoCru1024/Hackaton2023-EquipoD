using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Data.Configurations;

public class GroupConfiguration : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.ToTable("grupo");

        //Primary Key
        builder.HasKey(x => x.Id)
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);;

        //Properties
        builder.Property(x => x.Id)
            .HasColumnName("gru_iCodigo");

        builder.Property(x => x.Number)
            .HasColumnName("gru_iNumero");

        builder.Property(x => x.SemesterId)
            .HasColumnName("sem_iCodigo");

        builder.Property(x => x.CourseId)
            .HasColumnName("cur_iCodigo");

        //Relationships
        builder.HasOne(x => x.Semester)
            .WithMany(y => y.Groups)
            .IsRequired();

        builder.HasOne(x => x.Course)
            .WithMany(y => y.Groups)
            .IsRequired();
    }
}