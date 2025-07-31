using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTS.Domain.Entities
{
    public class Report
    {
        public int Id { get; set; }
        public string Content { get; set; }

        // Foreign Key
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int AdvisorId { get; set; }
        public Advisor Advisor { get; set; }
    }

}
