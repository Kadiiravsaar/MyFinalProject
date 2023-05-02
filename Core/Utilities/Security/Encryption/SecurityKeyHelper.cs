using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Encryption
{
    public class SecurityKeyHelper // appsettings de verdiğim keyi byte haline getirmeye yarar. Simetrik anahtar haline getirir
    {
        public static SecurityKey CreateSecurityKey(string securityKey) // SecurityKey bunu biz yazmadık systemden geliyor
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey)); // SymmetricSecurityKey araştır
        }
    }
}
