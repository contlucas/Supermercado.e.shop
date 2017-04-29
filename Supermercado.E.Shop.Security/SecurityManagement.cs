using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Security.Cryptography;
using Supermercado.E.Shop.Context;
namespace Supermercado.E.Shop.Security
{
    public static class SecurityManagement
    {
        public static bool Authenticate(string username, string password)
        {
            using (SupermercadoEShopDB db = new SupermercadoEShopDB())
            {
                string encryptedPass = EncryptPassword(password, Algorithm.SHA1);
                User user = db.User.Where(u => u.Username == username
                    && u.Password == encryptedPass).FirstOrDefault();

                return (user != null);
            }
        }
        public static string EncryptPassword(string password, Algorithm algorithm)
        {
            switch (algorithm)
            {
                case Algorithm.SHA1:
                    {
                        SHA1 sha1 = SHA1CryptoServiceProvider.Create();
                        byte[] arrayPass = sha1.ComputeHash(Encoding.UTF8.GetBytes(password));
                        IEnumerable<string> a3 = arrayPass.Select(x => x.ToString("X2"));
                        string result = string.Join("", a3);
                        return result;
                    }
                default:
                    {
                        throw new Exception("this option wasn't implemented");
                    }
            }
        }
    }

    public enum Algorithm
    {
        SHA1,
        MD5
    }
}
