using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WebApplication6.Models.Model;

namespace WebApplication6.Models
{
    [Table("Countries", Schema ="dbo")]
    public class Country
    {
        public Country()
        {
            this.States = new HashSet<State>();    //enforces the policy that in collection no two objects
            //inside state can be same, it shld have different stateID and stateName
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  //to show this is identity column
        public byte CountryId { get; set; }

        [Required]
        [StringLength(50)]          //[MaxLength(50)] can also be used
        [Column(name:"CountryName", TypeName ="varchar")]     //to define that this column is projected into db as column with conditions
        [Index("IX_CountryName", IsClustered= false, IsUnique=true)] //name IX_CountryName is to show similar to FK_Name or PK_name
        public string CountryName{get; set;}


        public virtual ICollection<State> States { get; set; }   //to tell that there is a collection of type state inside the table
        //this gives relation between state and country
    }
}