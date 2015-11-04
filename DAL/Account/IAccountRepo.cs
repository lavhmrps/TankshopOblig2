using System.Collections.Generic;
using Oblig1_Nettbutikk.Model;

namespace Oblig1_Nettbutikk.DAL
{
    public interface IAccountRepo
    {
        // bool AttemptLogin(int personId, string password);
        bool AttemptLogin(string email, string password);
        bool AddPerson(PersonModel person, Role role, string password);
        // bool ChangePassword(int personId, string newPassword);
        bool ChangePassword(string email, string newPassword);
        // bool DeletePerson(int personId);
        AdminModel GetAdmin(int adminId);
        AdminModel GetAdmin(string email);
        List<PersonModel> GetAllPeople();
        CustomerModel GetCustomer(int customerId);
        CustomerModel GetCustomer(string email);
        // PersonModel GetPerson(int personId);
        PersonModel GetPerson(string email);
        //int GetPersonId(string email);
        //bool UpdatePerson(PersonModel personUpdate, int personId);
        bool UpdatePerson(PersonModel personUpdate, string email);
        bool DeletePerson(string email);
        bool CreateCredentials(string email, string password);
        bool SetRole(string email, Role role, bool isRole);
    }
}