using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using University.BLL.Services.Contracts;
using University.DAL.DataContext;
using University.DAL.Entities;
using University.DAL.Repositories;

namespace University.BLL.Services
{
    public class StudentManager : EfCoreRepository<Student>, IStudentService
    {
        private readonly AppDbContext _dbContext;
        public StudentManager(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> Test()
        {
            return "test";
        }

        public override async Task DeleteAsync(Student entity)
        {
            var deletedEntity = await _dbContext.Students
                .Where(x=>x.Firstname==entity.Firstname.Trim() && x.Lastname==entity.Lastname.Trim() && x.Age==entity.Age)
                .FirstOrDefaultAsync();

            if (deletedEntity == null) throw new Exception();

            _dbContext.Remove(deletedEntity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
