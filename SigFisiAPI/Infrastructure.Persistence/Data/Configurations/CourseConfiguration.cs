using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Data.Configurations;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        //Table
        builder.ToTable("curso");

        //Primary Key
        builder.HasKey(x => x.Id)
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);
        ;

        //Properties
        builder.Property(x => x.Id)
            .HasColumnName("cur_iCodigo");

        builder.Property(x => x.Code)
            .HasColumnName("cur_vcCodigo")
            .HasColumnType("VARCHAR(16)");

        builder.Property(x => x.Name)
            .HasColumnName("cur_vcName")
            .HasColumnType("VARCHAR(64)");

        builder.Property(x => x.Credits)
            .HasColumnName("cur_fCreditos")
            .HasColumnType("DECIMAL(6,1)");

        builder.Property(x => x.RequiredCredits)
            .HasColumnName("cur_fCreditosRequisito")
            .HasColumnType("DECIMAL(6,1)");

        builder.Property(x => x.Semester)
            .HasColumnName("cur_iSemestre");

        builder.Property(x => x.StudyPlanId)
            .HasColumnName("plaest_iCodigo");

        builder.Property(x => x.CourseTypeId)
            .HasColumnName("curtip_iCodigo");

        builder.Property(x => x.CourseTrainingAreaId)
            .HasColumnName("curare_iCodigo");

        builder.HasOne(x => x.CourseType)
            .WithMany(y => y.Courses)
            .IsRequired();

        builder.HasOne(x => x.StudyPlan)
            .WithMany(y => y.Courses)
            .IsRequired();

        builder.HasOne(x => x.CourseTrainingArea)
            .WithMany(y => y.Courses)
            .IsRequired();

        builder.HasOne(x => x.CourseType)
            .WithMany(y => y.Courses)
            .IsRequired();

        builder.HasMany(x => x.Groups)
            .WithOne(y => y.Course)
            .IsRequired();

        builder.HasMany(x => x.CoursePrerequisites)
            .WithOne(y => y.Course)
            .HasForeignKey(x => x.CourseId)
            .IsRequired();

        /*builder.HasMany(x => x.CoursePrerequisites)
            .WithOne(y => y.Prerequisite)
            .HasForeignKey(x => x.PrerequisiteId)
            .IsRequired();*/

        builder.HasMany(x => x.CourseEquivalents)
            .WithOne(y => y.Course)
            .IsRequired();

        /*builder.HasMany(x => x.CourseEquivalents)
            .WithOne(y => y.Equivalent)
            .HasForeignKey(y => y.EquivalentId)
            .IsRequired();*/

        builder.HasMany(x => x.CourseHoursDictateds)
            .WithOne(y => y.Course)
            .IsRequired();
    }
}