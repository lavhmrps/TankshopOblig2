using System.Collections.Generic;
using Nettbutikk.Model;

namespace Nettbutikk.DataAccess
{
    public interface IAccountRepo
    {
        // bool AttemptLogin(int personId, string password);
        bool AttemptLogin(string email, string password);
        bool AddPerson(Person person, Role role, string password);
        // bool ChangePassword(int personId, string newPassword);
        bool ChangePassword(string email, string newPassword);
        // bool DeletePerson(int personId);
        Admin GetAdmin(int adminId);
        Admin GetAdmin(string email);
        List<Person> GetAllPeople();
        Customer GetCustomer(int customerId);
        Customer GetCustomer(string email);
        // PersonModel GetPerson(int personId);
        Person GetPerson(string email);
        //int GetPersonId(string email);
        //bool UpdatePerson(PersonModel personUpdate, int personId);
        bool UpdatePerson(Person personUpdate, string email);
        bool DeletePerson(string email);
        bool CreateCredentials(string email, string password);
        bool SetRole(string email, Role role, bool isRole);
    }
}