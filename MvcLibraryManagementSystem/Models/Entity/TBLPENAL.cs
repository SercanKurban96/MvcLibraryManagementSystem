//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcLibraryManagementSystem.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBLPENAL
    {
        public int PenalID { get; set; }
        public Nullable<int> Member { get; set; }
        public Nullable<int> Acting { get; set; }
        public Nullable<System.DateTime> Beginning { get; set; }
        public Nullable<System.DateTime> Ending { get; set; }
        public Nullable<decimal> Cash { get; set; }
    
        public virtual TBLACTING TBLACTING { get; set; }
        public virtual TBLMEMBER TBLMEMBER { get; set; }
    }
}
