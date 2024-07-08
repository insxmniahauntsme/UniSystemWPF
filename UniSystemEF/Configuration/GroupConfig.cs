using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniSystemEF.MVVM.Model;

namespace UniSystemEF.Configuration
{
    internal class GroupConfig : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.ToTable("Groups", "UniversitySchema");

            builder.HasKey(g => g.GroupId);
            builder.Property(g => g.GroupName).IsRequired();
            builder.Property(g => g.Faculty).IsRequired();
      


        }
    }

}
