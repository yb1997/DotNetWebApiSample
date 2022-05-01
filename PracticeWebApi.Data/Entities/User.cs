using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeWebApi.Data.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime CreatedOn { get; set; }
    }

    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User", "Auth");
            builder.HasKey(x => x.UserId);
            builder.Property(x => x.UserId).UseIdentityColumn();
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(256);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(256);
            builder.Property(x => x.BirthDate).IsRequired().HasColumnType("datetime2(3)");
            builder.Property(x => x.CreatedOn).IsRequired().HasColumnType("datetime2(3)");
        }
    }
}
