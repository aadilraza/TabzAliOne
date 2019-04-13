using SchoolManagementSystem.Data.Infrastructure.Interfaces;

namespace SchoolManagementSystem.Data.Infrastructure.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDatabaseFactory _databaseFactory;
        private SchoolEntities _dataContext;

        public UnitOfWork(IDatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
        }
        
        protected SchoolEntities DataContext
        {
            get { return _dataContext ?? (_dataContext = _databaseFactory.Get()); }
        }
        public void Commit()
        {
            DataContext.SaveChanges();
        }
    }
}
