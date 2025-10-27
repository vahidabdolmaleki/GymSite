using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Interfaces
{
    public interface IJwtService
    {
        string GenerateTokenForPerson(Person person);
    }
}
