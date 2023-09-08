using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Employe.Models
{
    public partial class Employee
    {

        [Key]
        public long EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public string? EmployeeCode { get; set; }
        public string? EmployeeSalary { get; set; }

        public virtual ICollection<Attendance> Attendances { get; set; }
    }
}
