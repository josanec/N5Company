using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace N5Company.Models
{
    public class Permissions
    {
        public int ID { get; set; }
        public string EmployeeForename { get; set; }
        public string EmployeeSurname { get; set; }
        public int PermissionType { get; set; }
        public DateTime PermissionDate { get; set; }
    }
}
