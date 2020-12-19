using System;
using HealthCertified.Model;
namespace HealthCertified.Report
{
    public class Certificate
    {
        //public Certificate(CertificateInfo b)
        //{

        //    HealthDepartment = b.Department.NameDepartment;
        //    OrginazationDate = b.CreateDate;
        //    OrginazationHour = b.CreateTime;

        //    CertificateNumber = b.CertificateNumber;
        //    Year = b.CreateDate.Year.ToString();
        //    DeadName = b.Deceased.FirstName;
        //    Gender = b.Deceased.Gender.GenderType;


        //    DeathDate = b.Deceased.DeathDate.Date;
        //    DeathTimeWrittenHour = b.Deceased.DeathDate.Hour;


        //    SecondName = b.Deceased.SecondName;
        //    DeadJob = b.Deceased.Profession != null ? b.Deceased.Profession.ProfessionName : " ";
        //    DeadNationality = b.Deceased.Nationality.NationalityType;
        //    DeadReligion = b.Deceased.Religion != null ? b.Deceased.Religion.ReligionName : " ";
        //    MotherName = b.Deceased?.MotherFirstName;
        //    RecordNumber = b.Deceased.Identify.Recoerd;
        //    PageNumber = b.Deceased.Identify.PageNumber;
        //    NationalDepartment = b.Deceased.Identify.Directorate;
        //    NationalProvince = b.Deceased.Identify.Governorate != null ?
        //        b.Deceased.Identify.Governorate.GovernorateName : " ";
        //    InformerName = b.Informer.FullName;
        //    InformerLocation = b.Informer.InformerAddress;
        //    InformerRelation = b.Informer.Relation == null ? "لايوجد" : b.Informer.Relation.Name;
        //    MobileNo = b.Informer.PhoneNumber;
        //    DoctorName = b.DoctorDetails.Name;
        //    JobLocation = b.DoctorDetails.AddressWork;
        //    FirstName = b.Deceased.FirstName;
        //    ThirdName = b.Deceased.ThirdName;
        //    MotherFirstName = b.Deceased.MotherFirstName;
        //    MotherSecondName = b.Deceased.MotherSecondName;
        //    MotherThirdName = b.Deceased.MotherThirdName;
        //    Profession = b.Deceased.Profession != null ?
        //        b.Deceased.Profession.ProfessionName : " ";
        //    MaritalStatus = b.Deceased.MaritalStatus != null ?
        //        b.Deceased.MaritalStatus.Id : 0;
        //    DeathBirth = b.Deceased.Birthdate;

        //    //
        //    HospitalName = b.DeathPlaces?.Hospital?.NameHospital;
        //    DeathResonA = b.MedicalCertificate?.ReasonA?.DeathReasonType;
        //    DeathResonB = b.MedicalCertificate?.ReasonB?.DeathReasonType;
        //    DeathResonC = b.MedicalCertificate?.ReasonC?.DeathReasonType;
        //    DeathResonD = b.MedicalCertificate?.ReasonD?.DeathReasonType;
        //    DeathFirstReson = b.JuridicalMedicalCertificate.FirstDeathReason?.DeathReasonType;

        //    SymptomsAndDeath = b.MedicalCertificate.SymptomsAndDeath;
        //    OtherReson = b.MedicalCertificate.OtherReasons;
        //    PregnantTypeId = b.Deceased.Pregnant?.PregnantType?.Id;
        //    PregnantDuration = b.Deceased.Pregnant.PregnantDuration;
        //    DeathLocationID = b.DeathPlaces.Location.Id;
        //    LobbyType = b.DeathPlaces.Lobby != null ?
        //        b.DeathPlaces.Lobby.Name : " ";
        //    //في حال طوارئ نستخدم الرقم الاحصائي
        //    if (b.DeathPlaces.Lobby != null && b.DeathPlaces.Lobby.Code.Equals("0801"))
        //        LobbyNo = b.DeathPlaces.StatisticNumber;
        //    else if (b.DeathPlaces.Lobby != null)
        //        LobbyNo = b.DeathPlaces.BedNumber;
        //    IsPregnant = b.Deceased.Pregnant.IsPregnant;
        //    DoctorWorkAddress = b.DoctorDetails.AddressWork;
        //    JudgeDecision = b.DoctorDetails.JudgeDecision;
        //    DoctorName2 = b.JuridicalMedicalCertificate.DoctorName;
        //    DoctorWorkIn = b.JuridicalMedicalCertificate.AddressWork;
        //    SentFrom = b.JuridicalMedicalCertificate.SendFrom;


        //    NationalNumber = b.Deceased.Identify.NationlityNumber;
        //    IdentifyNumber = b.Deceased.Identify.IdentityNumber;
        //    IdentifierName = b.Deceased.Identify.Directorate;

        //    //Birth info
        //    BirthDistrict = b.Deceased.BornAddress?.District?.NameDistrict;
        //    BirthGovernate = b.Deceased.BornAddress?.Governorate?.GovernorateName;

        //    //Residence
        //    CurrentGovernate = b.Deceased.Address?.Governorate?.GovernorateName;
        //    CurrentDistrict = b.Deceased.Address?.District?.NameDistrict;
        //    CurrentTownship = b.Deceased.Address?.Township?.TownShipName;
        //    CurrentAlley = b.Deceased.Address?.Alley;
        //    CurrentVillage = b.Deceased.Address?.Village;
        //    CurrentHomeNo = b.Deceased.Address?.HomeNumber;

        //    // Death Location info
        //    DeathLocGovernate = b.Deceased.DeathPlaceInfo?.Governorate?.GovernorateName;
        //    DeathLocDistrict = b.Deceased.DeathPlaceInfo?.District?.NameDistrict;
        //    DeathLocTownship = b.Deceased.DeathPlaceInfo?.Township?.TownShipName;
        //    DeathLocVillage = b.Deceased.DeathPlaceInfo?.Village;



        //}

        //Certificate Info
        //public float CertificateNumber { get; set; }
        //public string HealthDepartment { get; set; }
        //public DateTime OrginazationDate { get; set; }
        //public string OrginazationHour { get; set; }

        //public DateTime DeathBirth { get; set; }
        //public DateTime DeathDate { get; set; }
        //public string DeathTimeWrittenHour { get; set; }
        //public string HospitalName { get; set; }
        //public string Year { get; set; }

        ////Deceased Info
        //public string DeadName { get; set; }
        //public string FirstName { get; set; }
        //public string SecondName { get; set; }
        //public string ThirdName { get; set; }
        //public string MotherName { get; set; }
        //public string MotherFirstName { get; set; }
        //public string MotherSecondName { get; set; }
        //public string MotherThirdName { get; set; }

        //public string Gender { get; set; }
        //public string Profession { get; set; }
        //public string DeadJob { get; set; }
        //public int MaritalStatus { get; set; }
        //public string DeadNationality { get; set; }
        //public string DeadReligion { get; set; }


        ////Death Location
        ////Death Place infos
        //public string DeathLocGovernate { get; set; }
        //public string DeathLocDistrict { get; set; }
        //public string DeathLocTownship { get; set; }
        //public string DeathLocVillage { get; set; }


        ////Deceased Birth info
        //public string BirthGovernate { get; set; }
        //public string BirthDistrict { get; set; }

        ////Identity Card
        //public string RecordNumber { get; set; }
        //public string NationalNumber { get; set; }
        //public string IdentifyNumber { get; set; }
        //public string PageNumber { get; set; }
        //public string NationalDepartment { get; set; }
        //public string NationalProvince { get; set; }
        //public string IdentifierName { get; internal set; }//دائرة هوية الاحوال المدنية 

        ////Informer information
        //public string InformerName { get; set; }
        //public string InformerLocation { get; set; }
        //public string InformerRelation { get; set; }
        //public string MobileNo { get; internal set; }

        ////Doctor info
        //public string DoctorName { get; set; }
        //public string DoctorWorkAddress { get; set; }

        //public string JobLocation { get; set; }
        //public string DeathTimeWrittenDay { get; set; }
        //public string DeathTimeWrittenYear { get; set; }
        //public string DeathTimeWrittenMonth { get; set; }
        ////Death Reasons
        //public string DeathResonA { get; set; }
        //public string DeathResonB { get; set; }
        //public string DeathResonC { get; set; }
        //public string DeathResonD { get; set; }
        //public string DeathFirstReson { get; set; }
        //public string DeathlastReson { get; set; }
        //public string SymptomsAndDeath { get; set; }
        //public string OtherReson { get; set; }
        ////Pregnancy info
        //public int? PregnantTypeId { get; set; }
        //public int? PregnantDuration { get; set; }
        //public bool IsPregnant { get; set; }



        //public int DeathLocationID { get; set; }
        //public string LobbyType { get; set; }
        //public string LobbyNo { get; set; }


        //// jurdical doctor

        //public string DoctorName2 { get; set; }
        //public string DoctorWorkIn { get; set; }
        //public string SentFrom { get; set; }


        //public string JudgeDecision { get; set; }
        //public DateTime BookIssueDate { get; internal set; }
        //public string DiskNo { get; internal set; }
        //public DateTime FormIssueDate { get; internal set; }
        //public string FormNo { get; internal set; }
        //public string IssueBook { get; internal set; }
        //public string BookNo { get; internal set; }

        ////Deceased Residence
        //public string CurrentGovernate { get; set; }
        //public string CurrentDistrict { get; set; }
        //public string CurrentTownship { get; set; }
        //public string CurrentAlley { get; set; }
        //public string CurrentVillage { get; set; }
        //public string CurrentHomeNo { get; set; }





    }
}