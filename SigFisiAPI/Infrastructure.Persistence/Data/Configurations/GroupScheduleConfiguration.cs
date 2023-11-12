using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Data.Configurations;

public class GroupScheduleConfiguration : IEntityTypeConfiguration<GroupSchedule>
{
    public void Configure(EntityTypeBuilder<GroupSchedule> builder)
    {
        builder.ToTable("grupo_horario");

        //Primary Key
        builder.HasKey(x => x.Id)
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);;

        //Properties
        builder.Property(x => x.Id)
            .HasColumnName("gruhor_iCodigo");

        builder.Property(x => x.StartTime)
            .HasColumnName("gruhor_tHoraInicio")
            .HasConversion(
                x => new TimeSpan(0, 0, (int)x.TotalSeconds),
                x => TimeSpan.FromSeconds(x.TotalSeconds)
            ).HasColumnType("TIME");

        builder.Property(x => x.EndTime)
            .HasColumnName("gruhor_tHoraFin")
            .HasConversion(
                x => new TimeSpan(0, 0, (int)x.TotalSeconds),
                x => TimeSpan.FromSeconds(x.TotalSeconds)
            ).HasColumnType("TIME");

        builder.Property(x => x.Limit)
            .HasColumnName("gruhor_iTope");

        builder.Property(x => x.GroupId)
            .HasColumnName("gru_iCodigo");

        builder.Property(x => x.DayId)
            .HasColumnName("dia_iCodigo");

        builder.Property(x => x.ClassroomId)
            .HasColumnName("aul_iCodigo");

        builder.Property(x => x.CourseDictationTypeId)
            .HasColumnName("curtip_iCodigo");

        //Relationships
        builder.HasOne(x => x.Group)
            .WithMany(x => x.GroupSchedules)
            .IsRequired();

        builder.HasOne(x => x.Day)
            .WithMany(x => x.GroupSchedules)
            .IsRequired();

        builder.HasOne(x => x.Classroom)
            .WithMany(x => x.GroupSchedules)
            .IsRequired();

        builder.HasOne(x => x.CourseDictationType)
            .WithMany(x => x.GroupSchedules)
            .IsRequired();
    }
}