using System.Collections.Generic;
using Nettbutikk.Model;
using System;

namespace Nettbutikk.DataAccess
{
    public interface IAccountRepository
    {
        bool AttemptLogin(string email, string password);
        bool AddPerson(Person person, Role role, string password);
        bool ChangePassword(string email, string newPassword);
        Admin GetAdmin(int adminId);
        Admin GetAdmin(string email);
        List<Person> GetAllPeople();
        Person GetPerson(string email);
        bool UpdatePerson(Person personUpdate, string email);
        Customer GetCustomer(int customerId);
        Customer GetCustomer(string email);
        bool DeletePerson(string email);
        bool CreateCredentials(string email, string password);
        bool SetRole(string email, Role role, bool isRole);
    }
}