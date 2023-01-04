using University.DAL.Entities;
using University.DAL.Repositories.Contracts;

namespace University.BLL.Services.Contracts
{
    public interface IStudentService : IRepository<Student>
    {
        Task<string> Test();
    }
}
