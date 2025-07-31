using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MTS.Application.DTOs.Theses
{
    public class AssignJuryDto
    {
        [Required(ErrorMessage = "Jüri üyeleri zorunludur")]
        [MinLength(2, ErrorMessage = "En az 2 jüri üyesi girin")]
        public List<int> JuryMemberIds { get; set; }

        [Required(ErrorMessage = "Savunma tarihi zorunludur")]
        public DateTime DefenseDate { get; set; }

        public string Location { get; set; } // Savunma yeri (opsiyonel)
    }
}