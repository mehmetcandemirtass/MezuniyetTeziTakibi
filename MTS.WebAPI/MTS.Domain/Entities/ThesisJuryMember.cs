using System.ComponentModel.DataAnnotations;

namespace MTS.Domain.Entities
{
    public class ThesisJuryMember
    {
        [Key] // DataAnnotations kullanarak
        public int Id { get; set; }

        // Diğer property'ler
        public int ThesisId { get; set; }
        public int AdvisorId { get; set; }
        // ...
    }
}