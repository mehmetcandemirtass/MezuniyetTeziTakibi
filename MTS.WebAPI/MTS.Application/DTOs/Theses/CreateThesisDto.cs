using System.ComponentModel.DataAnnotations;

namespace MTS.Application.DTOs.Theses
{
    public class CreateThesisDto
    {
        [Required(ErrorMessage = "Tez başlığı zorunludur")]
        [StringLength(200, ErrorMessage = "Başlık en fazla 200 karakter olabilir")]
        public string TopicName { get; set; }

        [Required(ErrorMessage = "Tez açıklaması zorunludur")]
        public string Description { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Geçerli bir danışman ID girin")]
        public int AdvisorId { get; set; }
    }
}