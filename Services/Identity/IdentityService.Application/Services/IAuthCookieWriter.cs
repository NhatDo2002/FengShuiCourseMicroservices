using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.Services
{
    public interface IAuthCookieWriter
    {
        void WriteAuthToken(string cookieName, string token, DateTime? expiredAtUtc);
    }
}
