using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Infraestructure.Categoria.DTOs;

namespace Infraestructure.Categoria
{
    public interface ICategoryAppServices
    {
        public Category AddCategory(CategoriaDto category);
        public List<Category> GetAllCategory();
        public Category GetById(int id);
        public Category UpdateCategory(int id, CategoriaDto category);
        public void DeleteCategory(int id);
        public bool SoftDelete(int id);
        public List<Category> GetAllCategoryWihtCondition();
    }
}
