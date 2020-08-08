using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeDetails.Models
{
    public class DesignationViewModel
    {
        public DesignationViewModel()
        {
            this.EmployeeDetails = new HashSet<EmployeeDetail>();
        }

        public int DesignationID { get; set; }
        public string DesignationName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeeDetail> EmployeeDetails { get; set; }

    }
}