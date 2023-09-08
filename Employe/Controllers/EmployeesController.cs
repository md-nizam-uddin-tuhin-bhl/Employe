
using Employe.Data;
using Employe.Models;
using Employe.Reposity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NPOI.SS.Formula.Functions;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Intrinsics.Arm;
using System.Text.Json.Serialization;

namespace Employe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly  EmployeeDbContext db;
        private readonly IReposity _reposity;

        public EmployeesController(EmployeeDbContext db, IReposity reposity)
        {
            this.db = db;
            _reposity = reposity;
        }

        [HttpGet]
        [Route("/GetAllEmployee")]
        public async Task<IEnumerable<Employee>> GetEmployee()
        {
            return await _reposity.GetEmployee();
        }

        [HttpPut]
        public IActionResult UpdateId([FromBody] Employee model)
        {
           
            _reposity.UpdateId(model);  
            return Ok(model);
        }

        public static List<Employee> bubbleSort(List<Employee>emp)
        {
            int i, j;
            Employee temp;
            bool swapped;
            for (i = 0; i < emp.Count - 1; i++)
            {
                swapped = false;
                for (j = 0; j < emp.Count - i - 1; j++)
                {
                    long s1 = Convert.ToInt64(emp[j].EmployeeSalary);
                    long s2 = Convert.ToInt64(emp[j + 1].EmployeeSalary);
                    if ( s1 < s2)
                    {
                        temp = emp[j];
                        emp[j] = emp[j + 1];
                        emp[j + 1] = temp;
                        swapped = true;
                    }
                }

                if (swapped == false) break;
            }
            return emp;
        }

        [HttpGet]
        [Route("/GetAllEmployeeBaseOnSalary")]
        public async Task<IEnumerable<Employee>> GetAllEmployeeBaseOnSalary()
        {
            var e = db.Employee.ToList();
            List<Employee> emp = bubbleSort(e);
            return emp;
        
        }

        [HttpGet]
        [Route("/GetAbsentEmployee")]
        public async Task<IEnumerable<Employee>> GetAbsentEmployee()
        {
            var emp = new List<Employee>();
            var att = db.Attendance.ToList();

            var v = att.Where(x => x.IsAbsent == true && x.IsOffDay == false).Select(x => x.EmployeeId).ToList();

            bool duplicate = false;

            foreach(var x in v)
            {
                var e = db.Employee.Find(x);
                e.Attendances = null;
                if (e != null)
                {
                    foreach(var l in emp)
                    {
                        if(l.EmployeeId==e.EmployeeId)
                        {
                            duplicate = true;
                            break;
                        }
                    }
                    if(!duplicate) emp.Add(e);
                    else duplicate  = false;
                }
            }

            return emp;
        }

        [HttpGet]
        [Route("/EmployeeList")]
        public async Task<IEnumerable<MonthlyReport>> EmployeeList()
        {
            List<MonthlyReport>mr = new List<MonthlyReport>();
            var e = db.Employee.ToList();
            var att = db.Attendance.ToList();
            var month = new List<string>();
         
            foreach(var x in att)
            {
                var ToMonth = (DateTime) x.AttendanceDate;
                string monthName = ToMonth.ToString("MMMM");
                bool duplicateFoune = Dup.Duplicate(month, monthName);
                if(!duplicateFoune)
                    month.Add(monthName);
            }

            foreach(var m in month)
            {
                foreach(var employee in e)
                {
                    MonthlyReport r = new MonthlyReport();
                    r.EmployeeId = employee.EmployeeId;
                    r.Name = employee.EmployeeName;
                    r.Month = m;
                    mr.Add(r);
                }
            }

            for(int i=0; i<mr.Count; i++)
            {
                foreach(var attendance in att)
                {
                    if (((DateTime)attendance.AttendanceDate).ToString("MMMM") == mr[i].Month && attendance.EmployeeId == mr[i].EmployeeId)
                    {
                        mr[i].TotalPresent = ((bool)attendance.IsPresent) ? mr[i].TotalPresent + 1 : mr[i].TotalPresent += 0;
                        mr[i].TotalOffDay = ((bool)attendance.IsOffDay) ? mr[i].TotalOffDay + 1 : mr[i].TotalOffDay += 0;
                        mr[i].TotalAbsent = ((bool)attendance.IsAbsent && !((bool)attendance.IsOffDay)) ? mr[i].TotalAbsent + 1 : mr[i].TotalAbsent += 0; 
                    }
                }
            }

            return mr;
        }

    }
}
