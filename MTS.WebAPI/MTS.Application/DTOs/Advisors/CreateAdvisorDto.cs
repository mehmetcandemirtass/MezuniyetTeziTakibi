using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTS.Application.DTOs.Advisors
{
    public class CreateAdvisorDto
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Department { get; set; }
    }
}
