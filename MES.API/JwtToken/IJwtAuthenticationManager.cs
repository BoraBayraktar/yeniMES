using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MES.API.JwtToken
{
    public interface IJwtAuthenticationManager
    {
        string Authenticate(USER users, COMPANY companies);
    }
}
