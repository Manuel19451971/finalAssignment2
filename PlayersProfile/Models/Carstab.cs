using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayersProfile.Models
{
    [Table("carstab")]
    public partial class Carstab
    {
        [Key]
        [Column("CarID")]
        public int CarId { get; set; }
        [Column(TypeName = "decimal(7, 2)")]
        public decimal? Cost { get; set; }
        [StringLength(15)]
        public string Brand { get; set; }
        public int? Year { get; set; }
        [Column("PlayerID")]
        public int? PlayerId { get; set; }

        [ForeignKey("PlayerId")]
        [InverseProperty("Carstab")]
        public Playerstab Player { get; set; }
    }
}
