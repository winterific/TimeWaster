using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace TimeWastedByEktron.Web.Models
{
    public class Application
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        /// <summary>
        /// Unique field for this entity.
        /// </summary>
        public Guid? Uid { get; set; }

        public int Status { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public Application()
        {
            Uid = Guid.NewGuid();
        }
    }

    public class ApplicationMap : EntityTypeConfiguration<Application>
    {
        public ApplicationMap()
        {
            ToTable("Application");

            HasKey(t => t.Id);

            Property(t => t.Uid).HasColumnName("uid").IsOptional();
            Property(t => t.Status).HasColumnName("status");
            Property(t => t.Name).HasColumnName("name").HasMaxLength(300);
            Property(t => t.Description).HasColumnName("description");

        }
    }

}