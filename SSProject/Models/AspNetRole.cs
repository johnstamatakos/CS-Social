//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SSProject.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class AspNetRole
    {
        public AspNetRole()
        {
            this.AspNetUsers = new HashSet<AspNetUser>();
            this.AspNetUsers1 = new HashSet<AspNetUser>();
            this.AspNetUsers2 = new HashSet<AspNetUser>();
            this.AspNetUsers3 = new HashSet<AspNetUser>();
        }
    
        public string Id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<AspNetUser> AspNetUsers { get; set; }
        public virtual ICollection<AspNetUser> AspNetUsers1 { get; set; }
        public virtual ICollection<AspNetUser> AspNetUsers2 { get; set; }
        public virtual ICollection<AspNetUser> AspNetUsers3 { get; set; }
    }
}
