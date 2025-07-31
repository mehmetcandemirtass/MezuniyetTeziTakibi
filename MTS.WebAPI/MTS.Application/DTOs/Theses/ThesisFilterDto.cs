using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTS.Application.DTOs.Theses
{
    public class ThesisFilterDto
    {
        public int? AdvisorId { get; set; }
        public string Status { get; set; } // "Draft", "Submitted", vb.
        public string TitleSearch { get; set; } // Başlıkta arama
    }
}