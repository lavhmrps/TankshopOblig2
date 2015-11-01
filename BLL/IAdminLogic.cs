﻿using Nettbutikk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nettbutikk.BusinessLogic
{
    public interface IAdminLogic
    {
        List<CustomerModel> GetAllCustomers();
        bool UpdatePerson(PersonModel personUpdate, string email);
        bool DeleteCustomer(string email);
    }
}
