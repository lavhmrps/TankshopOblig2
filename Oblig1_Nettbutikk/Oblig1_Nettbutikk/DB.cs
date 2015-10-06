using Oblig1_Nettbutikk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Oblig1_Nettbutikk
{
	public class DB
	{
        public static bool AttemptLogin(CustomerLoginPartial user)
        {
            using (var db = new WebShopModel())
            {
                try
                {
                    //var existingUser = db.CustomerCredentials.Find(user.Email);
                    var passwordHash = CreateHash(user.Password);
                    var existingUser = db.CustomerCredentials.FirstOrDefault(u => u.Email == user.Email && u.Password == passwordHash);

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

        internal static List<Category> AllCategories()
        {
            using (var db = new WebShopModel())
            {
                try
                {
                    return db.Categories.ToList();
    }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        private static byte[] CreateHash(string password)
        {
            byte[] inData, outData;
            var alg = System.Security.Cryptography.SHA256.Create();
            inData = System.Text.Encoding.Default.GetBytes(password);
            outData = alg.ComputeHash(inData);
            return outData;
        }

        public static bool RegisterCustomer(CustomerRegisterPartial customer)
        {
            using (var db = new WebShopModel())
            {
                try
                {
                    var existingCustomer = db.Customers.Find(customer.Email);
                    if (existingCustomer != null)
                        return false;
                    var newCustomer = new Customer
                    {
                        Email = customer.Email,
                        Firstname = customer.Firstname,
                        Lastname = customer.Lastname,
                        Address = customer.Address,
                        CreditCards = new List<CCard>()
                    };

                    var customerPostal = db.Postals.Find(customer.Zipcode);
                    if (customerPostal == null)
                    {
                        customerPostal = new Postal
                        {
                            Zipcode = customer.Zipcode,
                            City = customer.City
                        };
                    }

                    newCustomer.Postal = customerPostal;

                    var newCustomerCredential = new CustomerCredential
                    {
                        Email = customer.Email,
                        Password = CreateHash(customer.Password)
                    };

                    db.Customers.Add(newCustomer);
                    db.CustomerCredentials.Add(newCustomerCredential);


                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}