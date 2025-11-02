using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class VerificationCode : BaseEntity
    {
        public int PersonId { get; set; }
        public string Code { get; set; } = null!;
        public DateTime ExpireAt { get; set; }
        public bool IsUsed { get; set; } = false;

        // Navigation Property
        public Person Person { get; set; } = null!;
    }

}
