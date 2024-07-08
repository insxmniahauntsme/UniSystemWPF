using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using UniSystemEF.MVVM.Model;

namespace UniSystemEF.Configuration
{
    internal class FacultyConfig : IEntityTypeConfiguration<Faculty>
    {
        public void Configure(EntityTypeBuilder<Faculty> builder)
        {
            builder.ToTable("Faculties", "UniversitySchema");

            builder.HasKey(f => f.FacultyId);
            builder.Property(f => f.FacultyName).IsRequired();
        }
    }

}
