using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Security.Cryptography;
using Supermercado.E.Shop.Repository;
using Supermercado.E.Shop.Entities;

namespace Supermercado.E.Shop.Security
{
    public static class SecurityManagement
    {
        public static bool Authenticate(string username, string password)
        {
            try
            {
                using (EntityContext<User> db = new EntityContext<User>())
                {
                    User user = db.SearchFor(u => u.Username == username).FirstOrDefault();
                    string encryptedPass = EncryptPassword(password, Algorithm.SHA1);

                    if (user != null)
                    {
                        if (user.State != "A")
                        {
                            throw new Exception("The user " + username + " does not exist");
                        }

                        if (user.Password == encryptedPass)
                        {
                            user.LastLoginDateTime = DateTime.Now;
                            user.AttemptsQuantity = 3;
                            db.ConfirmChanges();
                            return true;
                        }
                        else
                        {
                            //user.AttemptsQuantity -= 1;

                            //if (user.AttemptsQuantity <= 0)
                            //{
                            //    throw new Exception("Account bloqued, the user has passed max attempts.");
                            //}
                            //else
                            //{
                            //    db.SaveChanges();
                            return false;
                            //}
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string EncryptPassword(string password, Algorithm algorithm = Algorithm.SHA1)
        {
            switch (algorithm)
            {
                case Algorithm.SHA1:
                    {
                        SHA1 sha1 = SHA1CryptoServiceProvider.Create();
                        byte[] arrayPass = sha1.ComputeHash(Encoding.UTF8.GetBytes(password));
                        IEnumerable<string> arrayResult = arrayPass.Select(x => x.ToString("X2"));
                        string result = string.Join("", arrayResult);
                        return result;
                    }
                default:
                    {
                        throw new Exception("this option isn't implemented");
                    }
            }
        }
    }

    public enum Algorithm
    {
        SHA1,
        MD5
    }

    public enum Roles
    {
        Administrator = 1,
        Guest = 2
    }
}
