//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace eSARDAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Student
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Student()
        {
            this.Payments = new HashSet<Payment>();
            this.Siblings = new HashSet<Sibling>();
            this.Siblings1 = new HashSet<Sibling>();
            this.StudentEnrollments = new HashSet<StudentEnrollment>();
        }
    
        public string StudentId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public string POBAddress { get; set; }
        public string POBBarangay { get; set; }
        public string POBTownCity { get; set; }
        public string POBProvince { get; set; }
        public string HomeAddress { get; set; }
        public string HomeBarangay { get; set; }
        public string HomeTownCity { get; set; }
        public string HomeProvince { get; set; }
        public string SchoolLastAttended { get; set; }
        public string FathersName { get; set; }
        public string FathersOccupation { get; set; }
        public Nullable<double> FathersAverageYearlyIncome { get; set; }
        public string FathersEducation { get; set; }
        public string MothersMaidenName { get; set; }
        public string MothersOccupation { get; set; }
        public Nullable<double> MothersAverageYearlyIncome { get; set; }
        public string MothersEducation { get; set; }
        public string GuardiansName { get; set; }
        public string GuardiansOccupation { get; set; }
        public Nullable<double> GuardiansAverageYearlyIncome { get; set; }
        public Nullable<bool> MadrasahEnrolled { get; set; }
        public Nullable<System.DateTime> DateAdmitted { get; set; }
        public string GradeLevel { get; set; }
        public Nullable<double> Average { get; set; }
        public Nullable<bool> Card { get; set; }
        public Nullable<bool> GoodMoral { get; set; }
        public Nullable<bool> BirthCertificate { get; set; }
        public string LastSYAttendedDCFI { get; set; }
        public bool Dismissed { get; set; }
        public bool Graduated { get; set; }
        public string Religion { get; set; }
        public byte[] Image { get; set; }
        public string Gender { get; set; }
        public Nullable<int> ScholarshipDiscountId { get; set; }
        public Nullable<decimal> UnitsFailedLastYear { get; set; }
        public Nullable<int> ranking { get; set; }
        public Nullable<double> RunningBalance { get; set; }
        public string Section { get; set; }
        public string StudentLRN { get; set; }
        public Nullable<double> FirstAverage { get; set; }
        public Nullable<double> SecondAverage { get; set; }
        public Nullable<double> ThirdAverage { get; set; }
        public string GradeBeforeDC { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ScholarshipDiscount ScholarshipDiscount { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sibling> Siblings { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sibling> Siblings1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentEnrollment> StudentEnrollments { get; set; }
    }
}
