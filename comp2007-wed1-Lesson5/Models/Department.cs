//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace comp2007_wed1_Lesson5.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Department
    {
        public Department()
        {
            this.Courses = new HashSet<Cours>();
        }

        public int DepartmentID { get; set; }
        public string Name { get; set; }
        public Nullable<decimal> Budget { get; set; }

        public virtual ICollection<Cours> Courses { get; set; }
    }
}
