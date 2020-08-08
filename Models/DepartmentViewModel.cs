using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeDetails.Models
{
    public class DepartmentViewModel
    {
        
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeeDetail> EmployeeDetails { get; set; }

    }
}