using Employe.Models;
using Microsoft.AspNetCore.Mvc;

namespace Employe.Reposity
{

    public interface IReposity
    {
        Task<IEnumerable<Employee>> GetEmployee();
        Task<Employee> UpdateId(Employee model);
     


    }
}
