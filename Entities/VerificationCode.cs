using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class VerificationCode : BaseEntity
    {
        public string Target { get; set; } = null!; // شماره موبایل یا ایمیل
        public string Code { get; set; } = null!;
        public DateTime Expiration { get; set; }
        public bool IsUsed { get; set; } = false;

    }
}
