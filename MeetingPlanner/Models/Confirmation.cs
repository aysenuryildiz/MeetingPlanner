//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MeetingPlanner.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Confirmation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Confirmation()
        {
            this.Meeting = new HashSet<Meeting>();
        }
    
        public int ID { get; set; }
        public string Type { get; set; }
    
        public virtual Confirmation Confirmation1 { get; set; }
        public virtual Confirmation Confirmation2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Meeting> Meeting { get; set; }
    }
}