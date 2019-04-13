using SchoolManagementSystem.Data.Infrastructure.Abstractions;
using SchoolManagementSystem.Data.Infrastructure.Interfaces;
using SchoolManagementSystem.Data.Repository.Interfaces;
using SchoolManagementSystem.Model.Models;

namespace SchoolManagementSystem.Data.Repository.Implementations
{
    public class RoomRepository : RepositoryBase<Room>, IRoomRepository
    {
        public RoomRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }
    }
}
