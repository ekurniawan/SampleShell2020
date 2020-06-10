using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleShellNav.Models
{
    public class Employee
    {
        [PrimaryKey,AutoIncrement]
        public int EmpId { get; set; }
        [NotNull]
        public string EmpName { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public string Qualification { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
