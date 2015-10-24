using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oblig1_Nettbutikk.Model;
using Oblig1_Nettbutikk.DAL;

namespace Oblig1_Nettbutikk.BLL
{
    public class ProductBLL : IProductLogic
    {
        private IProductRepo _repo;

        public ProductBLL()
        {
            _repo = new ProductRepo();
        }

        public List<ProductModel> GetProducts(List<int> productIdList)
        {
            return _repo.GetProducts(productIdList);
        }
    }
}
