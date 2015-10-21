using System.Collections.Generic;
using Oblig1_Nettbutikk.Model;

namespace Oblig1_Nettbutikk.DAL
{
    public interface IPersonRepo
    {
        int AddPerson(PersonModel person);
        PersonModel DeletePerson(int personId);
        PersonModel GetAdmin(int adminId);
        List<PersonModel> GetAllPeople();
        PersonModel GetCustomer(int customerId);
        PersonModel GetPerson(int personId);
        bool UpdatePerson(PersonModel personUpdate, int personId);
    }
}