using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetup.Login.Application.Interfaces
{
    public interface IEncryptionService
    {
        string HashPassword(string password);
    }
}
