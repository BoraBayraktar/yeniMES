using MES.DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MES.API.ViewModels;
namespace MES.API.JwtToken
{
    public interface IJwtAuthenticationManager
    {
        string Authenticate(UserViewModel userViewModel);
    }
}
