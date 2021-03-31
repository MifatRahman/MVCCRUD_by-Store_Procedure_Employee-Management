using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCCRUD_by_Store_Procedure_Employee_Management.Models
{
    public class Employee
    {
        public int Eno { get; set; }
        public string Ename { get; set; }
        public double Salary { get; set; }
    }
}