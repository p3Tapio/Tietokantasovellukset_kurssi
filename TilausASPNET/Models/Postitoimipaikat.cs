//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TilausASPNET.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Postitoimipaikat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Postitoimipaikat()
        {
            this.Asiakkaat = new HashSet<Asiakkaat>();
            this.Tilaukset = new HashSet<Tilaukset>();
            this.Henkilot = new HashSet<Henkilot>();
        }
    
        public string Postinumero { get; set; }
        public string Postitoimipaikka { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Asiakkaat> Asiakkaat { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tilaukset> Tilaukset { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Henkilot> Henkilot { get; set; }
    }
}
