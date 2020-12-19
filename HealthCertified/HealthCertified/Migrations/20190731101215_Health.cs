using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthCertified.Migrations
{
    public partial class Health : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CertifiedInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HealthDepartment = table.Column<string>(nullable: true),
                    OrginazationDate = table.Column<DateTime>(nullable: false),
                    HealthAuthorities = table.Column<string>(nullable: true),
                    BirthAndDeathOffice = table.Column<string>(nullable: true),
                    Sequence = table.Column<int>(nullable: true),
                    Year = table.Column<int>(nullable: true),
                    BirthName = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    Village = table.Column<string>(nullable: true),
                    Mahallah = table.Column<string>(nullable: true),
                    Area = table.Column<string>(nullable: true),
                    District = table.Column<string>(nullable: true),
                    Province = table.Column<string>(nullable: true),
                    HealthDepartmentBirth = table.Column<string>(nullable: true),
                    BirthType = table.Column<string>(nullable: true),
                    TwinsNumber = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    FatherName = table.Column<string>(nullable: true),
                    FatherAge = table.Column<int>(nullable: true),
                    FatherJob = table.Column<string>(nullable: true),
                    FatherNationality = table.Column<string>(nullable: true),
                    FatherReligion = table.Column<string>(nullable: true),
                    MotherName = table.Column<string>(nullable: true),
                    MotherAge = table.Column<int>(nullable: true),
                    MotherJob = table.Column<string>(nullable: true),
                    MotherNationality = table.Column<string>(nullable: true),
                    MotherReligion = table.Column<string>(nullable: true),
                    FatherAndMotherRelation = table.Column<bool>(nullable: true),
                    AliveBirth = table.Column<int>(nullable: true),
                    AliveThenDeath = table.Column<int>(nullable: true),
                    DeathBirth = table.Column<int>(nullable: true),
                    BirthDisable = table.Column<int>(nullable: true),
                    ProjectionNumber = table.Column<int>(nullable: true),
                    DisableType = table.Column<string>(nullable: true),
                    LengthOfPregnancy = table.Column<int>(nullable: true),
                    ChildWeight = table.Column<int>(nullable: true),
                    BirthPlace = table.Column<string>(nullable: true),
                    HospitalName = table.Column<string>(nullable: true),
                    BirthBy = table.Column<string>(nullable: true),
                    CertifyNumber = table.Column<int>(nullable: true),
                    CertifyYear = table.Column<int>(nullable: true),
                    Other = table.Column<string>(nullable: true),
                    HouseNumber = table.Column<int>(nullable: true),
                    AlleyNumber = table.Column<int>(nullable: true),
                    BirthVillage = table.Column<string>(nullable: true),
                    BirthArea = table.Column<string>(nullable: true),
                    BirthDistrict = table.Column<string>(nullable: true),
                    BirthProvince = table.Column<string>(nullable: true),
                    RecordNumber = table.Column<string>(nullable: true),
                    PageNumber = table.Column<string>(nullable: true),
                    NationalDepartment = table.Column<string>(nullable: true),
                    NationalProvince = table.Column<string>(nullable: true),
                    FatherNationalNumber = table.Column<string>(nullable: true),
                    InformerName = table.Column<string>(nullable: true),
                    InformerLocation = table.Column<string>(nullable: true),
                    InformerRelation = table.Column<string>(nullable: true),
                    BirthHelperName = table.Column<string>(nullable: true),
                    JobLocation = table.Column<string>(nullable: true),
                    HospitalManager = table.Column<string>(nullable: true),
                    To = table.Column<string>(nullable: true),
                    OrganizerName = table.Column<string>(nullable: true),
                    DoctorName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CertifiedInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeathCertified",
                columns: table => new
                {
                    CertificateNo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IssueDatetime = table.Column<DateTime>(nullable: false),
                    CertificateProvince = table.Column<string>(nullable: true),
                    CertificateDepartment = table.Column<string>(nullable: true),
                    RegisteredDepartment = table.Column<string>(nullable: true),
                    RegisteredHospital = table.Column<string>(nullable: true),
                    RegisteredNo = table.Column<string>(nullable: true),
                    RegisteredYear = table.Column<string>(nullable: true),
                    DeathDate = table.Column<DateTime>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    SecondName = table.Column<string>(nullable: true),
                    FatherReligion = table.Column<string>(nullable: true),
                    FatherNationality = table.Column<string>(nullable: true),
                    ThirdName = table.Column<string>(nullable: true),
                    MotherFirstName = table.Column<string>(nullable: true),
                    MotherSecondName = table.Column<string>(nullable: true),
                    MotherReligion = table.Column<string>(nullable: true),
                    MotherNationality = table.Column<string>(nullable: true),
                    MotherThirdName = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    Nationality = table.Column<string>(nullable: true),
                    Religion = table.Column<string>(nullable: true),
                    Occupation = table.Column<string>(nullable: true),
                    RelationID = table.Column<int>(nullable: false),
                    Birthdate = table.Column<DateTime>(nullable: false),
                    To = table.Column<string>(nullable: true),
                    BornProvince = table.Column<string>(nullable: true),
                    BornCounty = table.Column<string>(nullable: true),
                    DeathPlace = table.Column<string>(nullable: true),
                    PermanentProvince = table.Column<string>(nullable: true),
                    PermanentCounty = table.Column<string>(nullable: true),
                    PermanentTownship = table.Column<string>(nullable: true),
                    PermanentVillage = table.Column<string>(nullable: true),
                    PermanentAlley = table.Column<string>(nullable: true),
                    PermanentHouseNo = table.Column<string>(nullable: true),
                    DeathProvince = table.Column<string>(nullable: true),
                    DeathCounty = table.Column<string>(nullable: true),
                    DeathTownship = table.Column<string>(nullable: true),
                    DeathVillage = table.Column<string>(nullable: true),
                    DeathTimeWrittenHour = table.Column<string>(nullable: true),
                    DeathTimeWrittenDay = table.Column<string>(nullable: true),
                    DeathTimeWrittenMonth = table.Column<string>(nullable: true),
                    DeathTimeWrittenYear = table.Column<string>(nullable: true),
                    InformerFullName = table.Column<string>(nullable: true),
                    InformerAddress = table.Column<string>(nullable: true),
                    InformerRelation = table.Column<string>(nullable: true),
                    ReasonA = table.Column<string>(nullable: true),
                    ReasonB = table.Column<string>(nullable: true),
                    ReasonC = table.Column<string>(nullable: true),
                    ReasonD = table.Column<string>(nullable: true),
                    OtherReasons = table.Column<string>(nullable: true),
                    SymptomsAndDeath = table.Column<string>(nullable: true),
                    IsPregnant = table.Column<bool>(nullable: true),
                    PregnantTypeID = table.Column<int>(nullable: true),
                    PregnantDuration = table.Column<int>(nullable: true),
                    DeathLocationID = table.Column<int>(nullable: false),
                    HospitalName = table.Column<string>(nullable: true),
                    LobbyType = table.Column<string>(nullable: true),
                    LobbyNo = table.Column<string>(nullable: true),
                    DoctorName = table.Column<string>(nullable: true),
                    DoctorWorkAddress = table.Column<string>(nullable: true),
                    JudgeDecision = table.Column<string>(nullable: true),
                    DoctorName2 = table.Column<string>(nullable: true),
                    DoctorWorkIn = table.Column<string>(nullable: true),
                    SentFrom = table.Column<string>(nullable: true),
                    FormNo = table.Column<string>(nullable: true),
                    FormIssueDate = table.Column<DateTime>(nullable: false),
                    FirstReason = table.Column<string>(nullable: true),
                    FinalReason = table.Column<string>(nullable: true),
                    IssueBook = table.Column<string>(nullable: true),
                    BookNo = table.Column<string>(nullable: true),
                    BookIssueDate = table.Column<DateTime>(nullable: false),
                    DiskNo = table.Column<string>(nullable: true),
                    RecordNo = table.Column<string>(nullable: true),
                    PageNo = table.Column<string>(nullable: true),
                    Province = table.Column<string>(nullable: true),
                    IdentifierNo = table.Column<string>(nullable: true),
                    IdentifierName = table.Column<string>(nullable: true),
                    FamilyNo = table.Column<string>(nullable: true),
                    NationalDepartment = table.Column<string>(nullable: true),
                    NationalProvince = table.Column<string>(nullable: true),
                    OrganizerName = table.Column<string>(nullable: true),
                    MobileNo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeathCertified", x => x.CertificateNo);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CertifiedInfo");

            migrationBuilder.DropTable(
                name: "DeathCertified");
        }
    }
}
