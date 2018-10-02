using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication6.Models.Model
{
    [Table("Cities", Schema = "dbo")]
    public class City
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CityId { get; set; }

        public short StateId { get; set; }

        [Required]
        [StringLength(50)]
        [Column(name: "CityName", TypeName = "varchar")]
        public string CityName { get; set; }

        [ForeignKey("StateId")]
        public virtual State State { get; set; }
    }
}