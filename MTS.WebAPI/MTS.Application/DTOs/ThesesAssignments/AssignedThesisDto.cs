using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTS.Application.DTOs.ThesesAssignments
{
    public class AssignedThesisDto
    {
        public int StudentId { get; set; }
        public int ThesisId { get; set; }
        public string ThesisTitle { get; set; }
    }
}
