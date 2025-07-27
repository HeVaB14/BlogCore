using BlogCore.AccessData.Data.Repository;
using BlogCore.AccessData.Data.Repository.IRepository;
using BlogCore.Data;
using BlogCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCore.AccessData.Data
{
    public class CategoryRepository : Repository<CategoryModel>, ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(CategoryModel category)
        {
            var objFromDb = _context.Category.FirstOrDefault(s => s.IdCategory == category.IdCategory);
            if (objFromDb != null)
            {
                objFromDb.NameCategory = category.NameCategory;
                objFromDb.Order = category.Order;
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("La categoria no existe");
            }
        }
        }


      
    
}
