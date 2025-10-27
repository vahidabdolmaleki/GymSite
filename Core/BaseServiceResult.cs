using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public abstract class BaseServiceResult
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
    }

}
