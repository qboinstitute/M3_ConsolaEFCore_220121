using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace M3_ConsolaEFCore.CodeFirst.Models
{
    [Table("Player")]
    public class Player
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName ="nvarchar(100)")]
        public string FullName { get; set; }
        [Column(TypeName = "int")]
        public int Dorsal { get; set; }
        [Column(TypeName = "date")]
        public DateTime DoB { get; set; }

        public virtual ICollection<Team> Teams { get; set; }

        public Player(string fullName, int dorsal)
        {
            FullName = fullName;
            Dorsal = dorsal;
        }

    }
}
