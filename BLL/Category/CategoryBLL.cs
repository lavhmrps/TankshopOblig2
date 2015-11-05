﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oblig1_Nettbutikk.Model;

namespace BLL.Category
{
    public class CategoryBLL : ICategoryLogic
    {

        private DAL.Category.ICategoryRepo repo;

        public CategoryBLL() {
            repo = new DAL.Category.CategoryRepo();
        }

        public CategoryBLL(DAL.Category.ICategoryRepo repo) {
            this.repo = repo;
        }

        public List<CategoryModel> GetAllCategoryModels() {
            return repo.GetAllCategoryModels();
        }

        public bool AddCategory(string Name)
        {
            return repo.AddCategory(Name);
        }

        public bool DeleteCategory(int CategoryId)
        {
            Oblig1_Nettbutikk.Model.Category category = repo.GetCategory(CategoryId);

            if (category== null)
                return false;

            if (!repo.AddOldCategory(category.Name, 1))//Get admin id from session
                return false;

            return repo.DeleteCategory(CategoryId);
        }

        public List<Oblig1_Nettbutikk.Model.Category> GetAllCategories()
        {
            return repo.GetAllCategories();
        }

        public Oblig1_Nettbutikk.Model.Category GetCategory(int CategoryId)
        {
            return repo.GetCategory(CategoryId);
        }

        public bool UpdateCategory(int CategoryId, string Name)
        {

            Oblig1_Nettbutikk.Model.Category category = repo.GetCategory(CategoryId);

            if (category == null)
                return false;

            if (!repo.AddOldCategory(category.Name, 1))//Get admin id from session
                return false;

            return repo.UpdateCategory(CategoryId, Name);
        }

        public string GetCategoryName(int CategoryId)
        {
            return repo.GetCategoryName(CategoryId);
        }
    }
}
