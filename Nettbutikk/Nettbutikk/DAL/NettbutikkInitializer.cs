using Nettbutikk.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace Nettbutikk.DAL
{
    public class NettbutikkInitializer : CreateDatabaseIfNotExists<NettbutikkContext>
    {
        protected override void Seed(NettbutikkContext context)
        {
            var users = new List<User>
            {
                //... list of users
            };
            users.ForEach(user => context.Users.Add(user));

            var addresses = new List<Address>
            {
                //... list of addresses
            };
            addresses.ForEach(address => context.Addresses.Add(address));

            var customers = new List<User>();
            // transform users to customers...
            customers.ForEach(customer => context.Users.Add(customer));

            var categories = new List<Category>
            {
                // ...list of categories
            };
            // ... transform some categories to children
            categories.ForEach(category => context.Categories.Add(category));

            var products = new List<Product>();
            //...
            products.ForEach(product => context.Products.Add(product));
        }
    }
}