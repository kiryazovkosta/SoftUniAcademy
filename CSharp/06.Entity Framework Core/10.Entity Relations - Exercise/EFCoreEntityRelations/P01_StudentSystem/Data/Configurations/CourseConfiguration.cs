using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data.Configurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.Property(p => p.Name).IsUnicode(true);
            builder.Property(p => p.Description).IsUnicode(true);

            builder.HasMany(p => p.Resources).WithOne(r => r.Course).HasForeignKey(c => c.CourseId);
        }
    }
}
    