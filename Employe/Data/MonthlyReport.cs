namespace Employe.Data
{
    public class MonthlyReport
    {
        public long EmployeeId { get; set; }
        public string Name { get; set; }
        public string Month { get; set; }
        public int TotalPresent { get; set; }
        public int TotalAbsent { get; set; }
        public int TotalOffDay { get; set; }
    }
}
