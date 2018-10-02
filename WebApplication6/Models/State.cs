using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication6.Models.Model
{
    [Table("States", Schema = "dbo")]
    public class State
    {
        public State()
        {
            this.Cities = new HashSet<City>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short StateId { get; set; }

        public byte CountryId { get; set; }

        [Required]
        [StringLength(50)]
        [Column(name: "StateName", TypeName = "varchar")]
        public string StateName { get; set; }

        public virtual ICollection<City> Cities { get; set; }

        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }
    }
}