using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace TimeWaster.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public Guid? Uid { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime LastLoginDate { get; set; }

        public User()
        {
            Uid = Guid.NewGuid();
        }
    }

    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("User");

            HasKey(t => t.Id);

            Property(t => t.Uid).HasColumnName("uid").IsOptional();
            Property(t => t.UserName).HasColumnName("username").HasMaxLength(50);
            Property(t => t.Password).HasColumnName("password").HasMaxLength(50);
            Property(t => t.Email).HasColumnName("email").HasMaxLength(200).IsOptional();
            Property(t => t.DateCreated).HasColumnName("dateCreated");
            Property(t => t.LastLoginDate).HasColumnName("lastLoginDate");

        }
    }
}