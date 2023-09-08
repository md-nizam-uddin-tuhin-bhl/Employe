using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employe.Models
{
    public partial class Attendance
    {
        [Key]
        public long AttendanceId { get; set; }
        public long? EmployeeId { get; set; }
        public DateTime? AttendanceDate { get; set; }
        public bool? IsPresent { get; set; }
        public bool? IsAbsent { get; set; }
        public bool? IsOffDay { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Employee? Employee { get; set; }
    }
}
