using SchoolManagementSystem.Data.Infrastructure.Interfaces;

namespace SchoolManagementSystem.Data.Infrastructure.Implementations
{
    public class DatabaseFactory:Disposable, IDatabaseFactory
    {
        private SchoolEntities _dataContext;

        public SchoolEntities Get()
        {
            return _dataContext ?? (_dataContext = new SchoolEntities());
        }
        protected override void DisposeCore()
        {
            if (_dataContext!=null)
            {
                _dataContext.Dispose();
            }
        }
    }
}
