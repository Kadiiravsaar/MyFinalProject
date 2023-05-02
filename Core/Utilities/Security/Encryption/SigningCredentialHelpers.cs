using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Encryption
{
    public class SigningCredentialHelpers // credential => kimlik bilgileri olarak çevirir. Signing de imza
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey) // json token servislerinin oluşturulabilmesi için gerekli
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature); // bir tane hash işlemi yapacaksın.
                                                                                                // Anahtar olarak bu securityKey kullan.
                                                                                                // Şifreleme olarak da Güvenlik algoritmalarından SecurityAlgorithms.HmacSha512Signature bunu kullan
        }
    }
}
