using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace HealthCertified.Model
{
    public class DeathCertified
    {
        [Key]
        public int CertificateNo { get; set; }
        public DateTime IssueDatetime { get; set; }

        public string CertificateProvince { get; set; }
        public string CertificateDepartment { get; set; }

        public string RegisteredDepartment { get; set; }
        public string RegisteredHospital { get; set; }
        public string RegisteredNo { get; set; }
        public string RegisteredYear { get; set; }
        public DateTime DeathDate { get; set; }

        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string FatherReligion { get; set; }
        public string FatherNationality { get; set; }
        public string ThirdName { get; set; }
        public string MotherFirstName { get; set; }
        public string MotherSecondName { get; set; }
        public string MotherReligion { get; set; }
        public string MotherNationality { get; set; }
        public string MotherThirdName { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public string Religion { get; set; }
        public string Occupation { get; set; }
        public int RelationID { get; set; }
        public DateTime Birthdate { get; set; }
        public string To { get; set; }
        public string BornProvince { get; set; }
        public string BornCounty { get; set; }
        public string DeathPlace { get; set; }
        public string PermanentProvince { get; set; }
        public string PermanentCounty { get; set; }
        public string PermanentTownship { get; set; }
        public string PermanentVillage { get; set; }
        public string PermanentAlley { get; set; }
        public string PermanentHouseNo { get; set; }

        public string DeathProvince { get; set; }
        public string DeathCounty { get; set; }
        public string DeathTownship { get; set; }
        public string DeathVillage { get; set; }

        public string DeathTimeWrittenHour { get; set; }
        public string DeathTimeWrittenDay { get; set; }
        public string DeathTimeWrittenMonth { get; set; }
        public string DeathTimeWrittenYear { get; set; }

        public string InformerFullName { get; set; }
        public string InformerAddress { get; set; }
        public string InformerRelation { get; set; }

        public string ReasonA { get; set; }
        public string ReasonB { get; set; }
        public string ReasonC { get; set; }
        public string ReasonD { get; set; }
        public string OtherReasons { get; set; }
        public string SymptomsAndDeath { get; set; }

        public bool? IsPregnant { get; set; }
        public int? PregnantTypeID { get; set; }
        public int? PregnantDuration { get; set; }

        public int DeathLocationID { get; set; }
        public string HospitalName { get; set; }
        public string LobbyType { get; set; }
        public string LobbyNo { get; set; }

        public string DoctorName { get; set; }
        public string DoctorWorkAddress { get; set; }

        public string JudgeDecision { get; set; }

        public string DoctorName2 { get; set; }
        public string DoctorWorkIn { get; set; }
        public string SentFrom { get; set; }
        public string FormNo { get; set; }
        public DateTime FormIssueDate { get; set; }
        public string FirstReason { get; set; }
        public string FinalReason { get; set; }

        public string IssueBook { get; set; }
        public string BookNo { get; set; }
        public DateTime BookIssueDate { get; set; }
        public string DiskNo { get; set; }

        public string RecordNo { get; set; }
        public string PageNo { get; set; }
        public string Province { get; set; }
        public string IdentifierNo { get; set; }
        public string IdentifierName { get; set; }
        public string FamilyNo { get; set; }

        public string NationalDepartment { get; set; }
        public string NationalProvince { get; set; }
        public string OrganizerName { get; set; }

        public string MobileNo { get; set; }
    }

}
