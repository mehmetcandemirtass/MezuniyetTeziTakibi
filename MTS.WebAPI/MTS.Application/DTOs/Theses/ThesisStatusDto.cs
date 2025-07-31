using System.ComponentModel.DataAnnotations;

namespace MTS.Application.DTOs.Theses
{
    public class ThesisStatusDto
    {
        [Required(ErrorMessage = "Tez ID zorunludur")]
        public int ThesisId { get; set; }

        [Required(ErrorMessage = "Durum bilgisi zorunludur")]
        public string Status { get; set; } // "Approved", "Rejected", "Revision"

        public string Feedback { get; set; } // Danışman geri bildirimi (opsiyonel)
    }
}