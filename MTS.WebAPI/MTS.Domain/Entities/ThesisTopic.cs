using System.Collections.Generic;

namespace MTS.Domain.Entities
{
    public class ThesisTopic
    {
        public int Id { get; set; }
        public string TopicName { get; set; }
        public string Status { get; set; } = "Draft"; // Varsayılan değer

        // İlişkisel özellikler
        public int? AdvisorId { get; set; } // Nullable yapıldı
        public Advisor Advisor { get; set; }

        public int? StudentId { get; set; } // Nullable yapıldı
        public Student Student { get; set; }

        public ICollection<ThesisJuryMember> JuryMembers { get; set; } = new List<ThesisJuryMember>();

        // Opsiyonel: Ek bilgiler
        public DateTime? SubmissionDate { get; set; }
        public DateTime? DefenseDate { get; set; }
        public string Feedback { get; set; }
    }
}