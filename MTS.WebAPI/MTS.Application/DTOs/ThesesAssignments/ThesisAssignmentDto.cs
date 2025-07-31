using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTS.Application.DTOs.ThesesAssignments
{
    public class ThesisAssignmentDto
    {
        public int StudentId { get; set; }
        public List<int> ThesisPreferences { get; set; } // Öğrencinin seçtiği tezlerin ID listesi
    }
}
