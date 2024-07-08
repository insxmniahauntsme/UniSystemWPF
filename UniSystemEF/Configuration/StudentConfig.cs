using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using UniSystemEF.MVVM.Model;

namespace UniSystemEF.Configuration
{
    internal class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students", "UniversitySchema");

            builder.HasKey(s => s.RegistrationDate);
            builder.Property(s => s.Name).IsRequired().HasMaxLength(100);
            builder.Property(s => s.Surname).IsRequired().HasMaxLength(100);


        }
    }

}
