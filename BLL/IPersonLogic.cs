using Oblig1_Nettbutikk.Model;
using System.Collections.Generic;

namespace Oblig1_Nettbutikk.BLL
{
    public interface IPersonLogic
    {

        bool AddPerson(PersonModel person);
        bool DeletePerson(int personId);
        AdminModel GetAdmin(int adminId);
        List<PersonModel> GetAllPeople();
        CustomerModel GetCustomer(int customerId);
        PersonModel GetPerson(int personId);
        bool UpdatePerson(PersonModel personUpdate, int personId);
    }
}