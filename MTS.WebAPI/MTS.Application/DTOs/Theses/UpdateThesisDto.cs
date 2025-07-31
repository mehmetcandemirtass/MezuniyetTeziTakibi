using System.ComponentModel.DataAnnotations;

namespace MTS.Application.DTOs.Theses
{
    public class UpdateThesisStatusDto
    {
        [Required(ErrorMessage = "Tez ID zorunludur")]
        public int ThesisId { get; set; }

        [Required(ErrorMessage = "Durum zorunludur")]
        public string Status { get; set; } // "Onaylandı", "Reddedildi", "Revize"

        public string Feedback { get; set; } // Geri bildirim (opsiyonel)
    }
}