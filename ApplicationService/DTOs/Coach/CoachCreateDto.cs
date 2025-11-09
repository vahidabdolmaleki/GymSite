using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.DTOs
{
    public class CoachCreateDto
    {
        public int PersonId { get; set; }
        public string Specialition { get; set; } = null;
        public int ExperienceYears { get; set; }
        public string? CertificateNumber { get; set; }
    }
}
