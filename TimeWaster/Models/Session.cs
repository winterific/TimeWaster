using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace TimeWastedByEktron.Web.Models
{
    public class Session
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        /// <summary>
        /// Unique field for this entity.
        /// </summary>
        public Guid? Uid { get; set; }

        /// <summary>
        /// A reference to the application that this session is associated with.
        /// </summary>
        [Required]
        public long? ApplicationId { get; set; }

        /// <summary>
        /// The date that this time wasted session started.
        /// </summary>
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime SessionDate { get; set; }

        /// <summary>
        /// How long this time wasted session lasted for.
        /// </summary>
        [Required]
        public TimeSpan Duration { get; set; }

        /// <summary>
        /// The Id of the user who this session belongs to.
        /// </summary>
        [Required]
        public long? UserId { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        public Session()
        {
            Uid = Guid.NewGuid();
        }
    }

    public class SessionMap : EntityTypeConfiguration<Session>
    {
        public SessionMap()
        {
            ToTable("WastedSession");

            HasKey(t => t.Id);

            Property(t => t.Uid).HasColumnName("uid").IsOptional();
            Property(t => t.UserId).HasColumnName("userid");
            Property(t => t.SessionDate).HasColumnName("wastedDate");
            Property(t => t.Duration).HasColumnName("duration");

        }
    }
}