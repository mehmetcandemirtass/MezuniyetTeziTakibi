using System.ComponentModel.DataAnnotations;

namespace MTS.Application.DTOs.Theses
{
    public class ThesisProposalDto
    {
        [Required(ErrorMessage = "Tez başlığı zorunludur")]
        [StringLength(200, ErrorMessage = "Başlık en fazla 200 karakter olabilir")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Özet metni zorunludur")]
        [StringLength(1000, ErrorMessage = "Özet en fazla 1000 karakter olabilir")]
        public string Abstract { get; set; }

        [Required(ErrorMessage = "Danışman ID zorunludur")]
        public int AdvisorId { get; set; }

        [Required(ErrorMessage = "Öğrenci ID zorunludur")]
        public int StudentId { get; set; }
    }
}