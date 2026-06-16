using Domain.Entities;
using Infraestructure.Categoria.DTOs;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Categoria
{
    public class CategoryAppService : ICategoryAppServices
    {
        private readonly GeneralRepository<Category> _categoryRepository;
        public CategoryAppService(GeneralRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public Category AddCategory(CategoriaDto category)
        {
            var exists = _categoryRepository.Exists(c => c.CategoryName.ToLower() == category.CategoryName.ToLower());

            if (exists)
            {
                throw new Exception("La categoría ya existe.");
            }

            var newCategory = new Category
            {
                CategoryName = category.CategoryName,
                Description = category.Description
            };

            return _categoryRepository.Add(newCategory);
        }  
        
        public void DeleteCategory(int id)
        {
            var category = _categoryRepository.GetById(id);
            if (category != null)
            {
                _categoryRepository.Delete(category);
            }
        }

        public List<Category> GetAllCategory()
        {
            return _categoryRepository.GetAll();
        }

        public Category GetById(int id)
        {
            return _categoryRepository.GetById(id);
        }

        public bool SoftDelete(int id)
        {
            var SDCategory = _categoryRepository.GetById(id);
            if (SDCategory == null)
            {
                return false;
            }
            SDCategory.Isdelete = '1';
            _categoryRepository.SoftDelete(SDCategory);
            return true;
        }

        public Category UpdateCategory(int id, CategoriaDto category)
        {
            var UpCategory = _categoryRepository.GetById(id);
            if (UpCategory != null)
            {
                UpCategory.CategoryName = category.CategoryName;
                UpCategory.Description = category.Description;
            }
            return _categoryRepository.Update(UpCategory);
        }
        public List<Category> GetAllCategoryWihtCondition()
        {
            return _categoryRepository.GetAll().Where(c=> c.Isdelete =='0').ToList();
        }
        
    }
}
