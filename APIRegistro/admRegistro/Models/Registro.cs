using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace admRegistro.Models
{
    public enum Place
    {
        LPZ = 10,
        SCZ = 20,
        CBBA = 30,
        TJA = 40,
        SRE = 50
    }
    public class Registro
    {
        [Key]
        public int RamirezID { get; set; }

        [Required]
        [Display(Name = "Nombre Completo")]
        [StringLength(24, MinimumLength = 2)]
        public string FriendofRamirez { get; set; }

        [Required]
        public Place Place { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Cumpleaños")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyy}", ApplyFormatInEditMode = true)]
        public DateTime Birthdate { get; set; }

    }
}