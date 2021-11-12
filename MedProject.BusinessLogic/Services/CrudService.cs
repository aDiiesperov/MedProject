using MedProject.BusinessLogic.Interfaces;
using MedProject.DataAccess.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedProject.BusinessLogic.Services
{
    internal abstract class CrudService<TDto, TDb, TRepository> : ICrudService<TDto>
        where TDto : class
        where TDb : class
        where TRepository : IRepository<TDb>
    {
        protected TRepository repository { get; set; }

        public CrudService(TRepository repository)
        {
            this.repository = repository;
        }

        // TODO: Temporary solition
        protected abstract TDto MapToDto(TDb model);

        public async Task<IList<TDto>> GetListAsync()
        {
            var list = await this.repository.GetAllAsync();
            return list.Select(item => this.MapToDto(item)).ToList();
        }
    }
}
