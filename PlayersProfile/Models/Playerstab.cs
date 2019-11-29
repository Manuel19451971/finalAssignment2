using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayersProfile.Models
{
    [Table("playerstab")]
    public partial class Playerstab
    {
        public Playerstab()
        {
            Carstab = new HashSet<Carstab>();
        }

        [Key]
        [Column("PlayerID")]
        public int PlayerId { get; set; }
        [StringLength(20)]
        public string PlayerName { get; set; }
        [StringLength(15)]
        public string Country { get; set; }
        [StringLength(10)]
        public string Team { get; set; }

        [InverseProperty("Player")]
        public ICollection<Carstab> Carstab { get; set; }
    }
}
