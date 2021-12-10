namespace MedProject.BusinessLogic.Services
{
    internal abstract class BaseService<TDataStore>
    {
        protected readonly TDataStore store;

        public BaseService(TDataStore store)
        {
            this.store = store;
        }
    }
}
