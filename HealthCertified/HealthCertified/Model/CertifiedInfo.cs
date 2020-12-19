using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCertified.Model
{
    public class CertifiedInfo
    {
        [Key]
        public int Id { get; set; }
        public string HealthDepartment { get; set; }
        public DateTime OrginazationDate { get; set; }
        public string HealthAuthorities { get; set; }
        public string BirthAndDeathOffice { get; set; }
        public int? Sequence { get; set; }
        public int? Year { get; set; }
        public string BirthName { get; set; }
        public string Gender { get; set; }
        public string Village { get; set; }
        public string Mahallah { get; set; }
        public string Area { get; set; }
        public string District { get; set; }
        public string Province { get; set; }
        public string HealthDepartmentBirth { get; set; }
        public string BirthType { get; set; }
        public string TwinsNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string FatherName { get; set; }
        public int? FatherAge { get; set; }
        public string FatherJob { get; set; }
        public string FatherNationality { get; set; }
        public string FatherReligion { get; set; }
        public string MotherName { get; set; }
        public int? MotherAge { get; set; }
        public string MotherJob { get; set; }
        public string MotherNationality { get; set; }
        public string MotherReligion { get; set; }
        public bool? FatherAndMotherRelation { get; set; }
        public int? AliveBirth { get; set; }
        public int? AliveThenDeath { get; set; }
        public int? DeathBirth { get; set; }
        public int? BirthDisable { get; set; }
        public int? ProjectionNumber { get; set; }
        public string DisableType { get; set; }
        public int? LengthOfPregnancy { get; set; }
        public int? ChildWeight { get; set; }
        public string BirthPlace { get; set; }
        public string HospitalName { get; set; }
        public string BirthBy { get; set; }
        public int? CertifyNumber { get; set; }
        public int? CertifyYear { get; set; }
        public string Other { get; set; }
        public int? HouseNumber { get; set; }
        public int? AlleyNumber { get; set; }
        public string BirthVillage { get; set; }
        public string BirthArea { get; set; }
        public string BirthDistrict { get; set; }
        public string BirthProvince { get; set; }
        public string RecordNumber { get; set; }
        public string PageNumber { get; set; }
        public string NationalDepartment { get; set; }
        public string NationalProvince { get; set; }
        public string FatherNationalNumber { get; set; }
        public string InformerName { get; set; }
        public string InformerLocation { get; set; }
        public string InformerRelation { get; set; }
        public string BirthHelperName { get; set; }
        public string JobLocation { get; set; }
        public string HospitalManager { get; set; }
        public string To { get; set; }
        public string OrganizerName { get; set; }
        public string DoctorName { get; set; }


    }
}
