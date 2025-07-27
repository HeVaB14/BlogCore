using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCore.AccessData.Data.Repository.IRepository
{
    public interface IJobsContainer: IDisposable
    {
        //aqui debemos agregar las interfaces de los repositorios que vamos a utilizar
        ICategoryRepository Category { get; }

        void Save();


    }
}
