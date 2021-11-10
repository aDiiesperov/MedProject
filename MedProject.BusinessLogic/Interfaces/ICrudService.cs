using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedProject.BusinessLogic.Interfaces
{
    public interface ICrudService<TDto>
           where TDto : class
    {
        Task<IList<TDto>> GetListAsync();
    }
}
