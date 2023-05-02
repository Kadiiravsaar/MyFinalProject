using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt) // out araştır kodlama io da var
        {
            // Bu metot verdiğimiz password değerinin salt ve hash değerini oluşturmaya yarar

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key; // algoritmanın değişmeyen anahtarı olacak.
                                         // İlgili algoritmanın o an oluşturduğu(System.Security.Cryptography.HMACSHA512()) key değeridir. her kullanıcı için bir key oluşturur. )

                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)); // bir stringin byte karşılığını almak istiyorsak bunu yapabiliriz.
            }
        }

        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt) // passwordhash'i doğrula
        {
            // this byte[] passwordHash dbdeki hash olacak. Kullanıcının gönderdiği hash ile dbdeki hash karşılaştırılıyor
            // burada ki password kullanıcının sisteme girmeye çalıştığı paroladır
           
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt)) // doğrulama için key girmek gerekir yani salt
            {
                var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computeHash.Length; i++)
                {
                    if (computeHash[i] == passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }

        }
    }
}
