using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace M3_ConsolaEFCore.CodeFirst.Models
{
    [Table("Team")]
    public class Team
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Description { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Country { get; set; }

        public virtual ICollection<Player> Players { get; set; }

        public Team(string description, string country)
        {
            Description = description;
            Country = country;
        }

    }
}
