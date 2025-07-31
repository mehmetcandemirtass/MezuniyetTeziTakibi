using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTS.Domain.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public string Content { get; set; }

        // Foreign Key
        public int StudentId { get; set; }

        // Navigation Property
        public Student Student { get; set; }

        public int AdvisorId { get; set; }
        public Advisor Advisor { get; set; }
    }

}
