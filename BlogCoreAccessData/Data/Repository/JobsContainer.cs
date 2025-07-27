using BlogCore.AccessData.Data.Repository.IRepository;
using BlogCore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCore.AccessData.Data.Repository
{
    public class JobsContainer:IJobsContainer
    {
        private readonly ApplicationDbContext _context;
        public JobsContainer(ApplicationDbContext context)
        {
            _context= context;
            Category = new CategoryRepository(_context);
        }

        public ICategoryRepository Category { get; private set; }


        public void Dispose()
        {
           _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
