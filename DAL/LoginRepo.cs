using Oblig1_Nettbutikk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblig1_Nettbutikk.DAL
{
    public class LoginRepo
    {
        public bool AttemptLogin(int personId, string password)
        {
            using (var db = new TankshopDbContext())
            {
                try
                {
                    var passwordHash = CreateHash(password);
                    var existingUser = db.Credentials.FirstOrDefault(c => c.PersonId == personId && c.Password == passwordHash);

                    if (existingUser == null)
                        return false;

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public byte[] CreateHash(string password)
        {
            byte[] inData, outData;
            var alg = System.Security.Cryptography.SHA256.Create();
            inData = System.Text.Encoding.Default.GetBytes(password);
            outData = alg.ComputeHash(inData);
            return outData;
        }
    }
}
