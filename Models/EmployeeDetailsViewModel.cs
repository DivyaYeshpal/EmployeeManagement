using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeDetails.Models
{
    public class EmployeeDetailsViewModel
    {
        [Key]
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public Nullable<System.DateTime> DOJ { get; set; }
        public Nullable<int> DesignationID { get; set; }
        public Nullable<int> DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public string DesignationName { get; set; }
        public virtual Department Department { get; set; }
        public virtual Designation Designation { get; set; }

    }
}