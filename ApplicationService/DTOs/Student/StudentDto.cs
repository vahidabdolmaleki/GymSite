using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.DTOs.Student
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string? Level { get; set; }
        public string? Goal { get; set; }
        public string? CoachName { get; set; }
        public bool IsActive { get; set; }
    }

}
