using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oblig1_Nettbutikk.Model;

namespace Oblig1_Nettbutikk.DAL
{
    class PersonRepoStub : IPersonRepo
    {
        public int AddPerson(PersonModel person)
        {
            throw new NotImplementedException();
        }

        public PersonModel DeletePerson(int personId)
        {
            throw new NotImplementedException();
        }

        public PersonModel GetAdmin(int adminId)
        {
            throw new NotImplementedException();
        }

        public List<PersonModel> GetAllPeople()
        {
            throw new NotImplementedException();
        }

        public PersonModel GetCustomer(int customerId)
        {
            throw new NotImplementedException();
        }

        public PersonModel GetPerson(int personId)
        {
            throw new NotImplementedException();
        }

        public bool UpdatePerson(PersonModel personUpdate, int personId)
        {
            throw new NotImplementedException();
        }
    }
}
