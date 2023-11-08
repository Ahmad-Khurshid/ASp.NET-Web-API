﻿using System;
using System.Collections.Generic;

namespace WebApI2.Models
{
    public partial class Department
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }

        public int DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
        public int? DepartmentHeadId { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
