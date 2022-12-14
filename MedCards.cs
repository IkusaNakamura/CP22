//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CP22
{
    using System;
    using System.Collections.Generic;
    
    public partial class MedCards
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MedCards()
        {
            this.FeatureSheet = new HashSet<FeatureSheet>();
            this.MedicalHistory = new HashSet<MedicalHistory>();
        }
    
        public int ID { get; set; }
        public int TypeCard { get; set; }
        public int Patient { get; set; }
        public int Institution { get; set; }
    
        public virtual CardTyps CardTyps { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FeatureSheet> FeatureSheet { get; set; }
        public virtual Institution Institution1 { get; set; }
        public virtual Patients Patients { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MedicalHistory> MedicalHistory { get; set; }
    }
}
