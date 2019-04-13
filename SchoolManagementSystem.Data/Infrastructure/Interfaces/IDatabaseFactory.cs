using System;

namespace SchoolManagementSystem.Data.Infrastructure.Interfaces
{
    public interface IDatabaseFactory:IDisposable
    {
        SchoolEntities Get();
    }
}
