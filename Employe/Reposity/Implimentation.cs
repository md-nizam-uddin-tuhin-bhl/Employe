using Employe.Models;
using Microsoft.EntityFrameworkCore;

namespace Employe.Reposity
{

    public class Implimentation : IReposity
    {
        private readonly EmployeeDbContext _db;

        public Implimentation(EmployeeDbContext db)
        {
            _db = db;
        }

        public Task<List<Employee>> bubbleSort(Employee emp)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Employee>> GetEmployee()
        {
            return await  _db.Employee.ToListAsync();
        }

        public async Task<Employee> UpdateId(Employee model)
        {
            var code = await _db.Employee.Where(x => x.EmployeeCode == model.EmployeeCode).ToListAsync();
            if (!code.Any())
            {
                _db.Employee.Update(model);
                await _db.SaveChangesAsync();
                return model;
            }

            return model;
        }
    }
}
