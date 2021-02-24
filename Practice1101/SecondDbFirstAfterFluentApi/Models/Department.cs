using System;
using System.Collections.Generic;

#nullable disable

namespace SecondDbFirstAfterFluentApi.Models
{
    public partial class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string GroupName { get; set; }
    }
}
