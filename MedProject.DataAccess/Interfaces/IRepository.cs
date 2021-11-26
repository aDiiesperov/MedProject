using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedProject.DataAccess.Interfaces
{
    public interface IRepository<TModel> where TModel : class
    {
        Task<IList<TModel>> GetAllAsync();
    }
}
