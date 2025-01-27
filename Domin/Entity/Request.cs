using Domin.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domin.Entity
{
    public  class Request
    {
       
        [Key]
        public int RequestId { get; set; }
        public int CustomerId { get; set; }
        public int ProviderId { get; set; }
        public int EmployeeId { get; set; }
        public int ServiceId { get; set; }
        public DateTime OrderDate { get; set; }
        public bool Status { get; set; }
        public string Comment { get; set; }
        [ForeignKey("CustomerId")]

        public virtual Customer Customer { get; set; }
        [ForeignKey("EmployeeId")]

        public virtual Employees Employees { get; set; }
        [ForeignKey("ServiceId")]

        public virtual Service Service { get; set; }
        [ForeignKey("ProviderId")]

        public virtual Provider Provider { get; set; }

        public virtual ICollection<EmployeeRequest> EmployeeRequests { get; set; }
    }
}
