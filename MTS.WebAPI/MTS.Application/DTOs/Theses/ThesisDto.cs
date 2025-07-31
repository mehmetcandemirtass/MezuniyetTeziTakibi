namespace MTS.Application.DTOs.Theses
{
    public class ThesisDto
    {
        public int Id { get; set; }
        public string TopicName { get; set; }
        public int AdvisorId { get; set; }
        public string AdvisorName { get; set; } // Danışman adı (opsiyonel)
        public string Status { get; set; } = "Draft"; // Varsayılan değer
    }
}