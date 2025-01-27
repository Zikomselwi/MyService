using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domin.Entity
{
    public  class EmployeeRequest
    {
        public int EmployeeRequestId { get; set; }
        public int EmployeeId { get; set; }
        public int? RequestId { get; set; }
        public DateTime? CreatedAt { get; set; }
        [ForeignKey("EmployeeId")]
        public  Employees? Employee { get; set; }
        [ForeignKey("RequestId")]
        public  Request? Request { get; set; }
    }
}
