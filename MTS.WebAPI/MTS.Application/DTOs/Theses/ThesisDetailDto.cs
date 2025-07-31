namespace MTS.Application.DTOs.Theses
{
    public class ThesisDetailDto : ThesisDto
    {
        public string StudentName { get; set; }
        public string AdvisorName { get; set; }
        public string Department { get; set; }
        public List<JuryMemberDto> JuryMembers { get; set; }
        public List<ThesisMilestoneDto> Milestones { get; set; }
    }

    public class JuryMemberDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; } // Prof. Dr., Doç. Dr. vb.
    }

    public class ThesisMilestoneDto
    {
        public string Name { get; set; } // "Ön Teslim", "Final Teslim"
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }
    }
}