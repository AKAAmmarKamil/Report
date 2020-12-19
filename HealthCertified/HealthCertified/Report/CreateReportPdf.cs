using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using HealthCertified.Model;
using System.Globalization;
using System;
using System.Net;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using Microsoft.Extensions.FileProviders;
using System.Collections.Generic;
using System.Drawing;

namespace HealthCertified.Report
{
    class CreateFilePdf :Support
    {
        public static PdfPTable BirthTitle(CertifiedInfo certifiedInfo)
        {
            int start = 7 - certifiedInfo.Id.ToString().Length;
            string Id = certifiedInfo.Id.ToString();
            string[] cell = new string[7];
            for (int i = 0; i < 7; i++)
            {
                if (i < start) cell[i] = "";
                else cell[i] = Id[i - start].ToString();
            }
            PdfPTable CertifiedNumberT = new PdfPTable(7);
            PdfPCell CELL1 = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(cell[0])), CreateFont(12, 1, false, false, true)));
            CellOption(CELL1, 1, 0, 1, 1, 0, 0, 0, 0.5f, 0.5f, 0.5f, 0.5f);
            PdfPCell CELL2 = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(cell[1])), CreateFont(12, 1, false, false, true)));
            CellOption(CELL2, 1, 0, 1, 1, 0, 0, 0, 0.5f, 0.5f, 0.5f, 0.5f);
            PdfPCell CELL3 = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(cell[2])), CreateFont(12, 1, false, false, true)));
            CellOption(CELL3, 1, 0, 1, 1, 0, 0, 0, 0.5f, 0.5f, 0.5f, 0.5f);
            PdfPCell CELL4 = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(cell[3])), CreateFont(12, 1, false, false, true)));
            CellOption(CELL4, 1, 0, 1, 1, 0, 0, 0, 0.5f, 0.5f, 0.5f, 0.5f);
            PdfPCell CELL5 = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(cell[4])), CreateFont(12, 1, false, false, true)));
            CellOption(CELL5, 1, 0, 1, 1, 0, 0, 0, 0.5f, 0.5f, 0.5f, 0.5f);
            PdfPCell CELL6 = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(cell[5])), CreateFont(12, 1, false, false, true)));
            CellOption(CELL6, 1, 0, 1, 1, 0, 0, 0, 0.5f, 0.5f, 0.5f, 0.5f);
            PdfPCell CELL7 = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(cell[6])), CreateFont(12, 1, false, false, true)));
            CellOption(CELL7, 1, 0, 1, 1, 0, 0, 0, 0.5f, 0.5f, 0.5f, 0.5f);
            AddCellToTable(CertifiedNumberT, new List<PdfPCell> { CELL1, CELL2, CELL3, CELL4, CELL5, CELL6, CELL7 });
            PdfPTable Title = new PdfPTable(4);
            float[] Titlewidths = new float[] { 1.5f, 1.5f, 4.6f, 1.4f };
            Title.SetWidths(Titlewidths);
            PdfPCell RepublicOfIraq = new PdfPCell(new Phrase(0, "جمهورية العراق", CreateFont()));
            CellOption(RepublicOfIraq, 0, 5, 4, 1, 5);
            PdfPCell MinistryOfHealth = new PdfPCell(new Phrase(0, "وزارة الصحة", CreateFont()));
            CellOption(MinistryOfHealth, 0, 5, 1, 1, 5);
            PdfPCell BirthCertified = new PdfPCell(new Phrase(0, "شهادة ولادة", CreateFont(16, 1)));
            CellOption(BirthCertified, 1, 125, 1, 2);
            PdfPCell CertifyNumber = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("ط1 رقم الشهادة")), CreateFont()));
            CellOption(CertifyNumber, 1, -8);
            PdfPCell CertifiedNumberV = new PdfPCell(CertifiedNumberT);
            CellOption(CertifiedNumberV, 0);
            PdfPTable HealthDepartmentTable = new PdfPTable(2);
            PdfPCell HealthDepartmentCell = new PdfPCell(new Phrase(0, " دائرة صحة: ", CreateFont()));
            CellOption(HealthDepartmentCell);
            PdfPCell HealthDepartment = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(certifiedInfo.HealthDepartment)), CreateFont(12, 1, false, false, true)));
            CellOption(HealthDepartment, PaddingRight: -8);
            AddCellToTable(HealthDepartmentTable, new List<PdfPCell> { HealthDepartment, HealthDepartmentCell });
            PdfPCell Health = new PdfPCell(HealthDepartmentTable);
            CellOption(Health, 0, 3);
            PdfPTable OrginizeDateTable = new PdfPTable(2);
            PdfPCell OrginizeDateCell = new PdfPCell(new Phrase(0, "تاريخ التنظيم : ", CreateFont()));
            CellOption(OrginizeDateCell, 2, 0, 1, 1, 5, -17);
            PdfPCell OrginizeDate = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(certifiedInfo.OrginazationDate.ToString("d/M/yyyy"))), CreateFont(12, 1, false, false, true)));
            CellOption(OrginizeDate, 2, 0, 1, 1, 5, -7);
            PdfPCell Date = new PdfPCell(OrginizeDateTable);
            CellOption(Date, 2, 0, 1, 1, 5, -5);
            AddCellToTable(OrginizeDateTable, new List<PdfPCell> { OrginizeDate, OrginizeDateCell });
            int Hour = certifiedInfo.OrginazationDate.Hour;
            PdfPTable OrginizeHourTable = new PdfPTable(2);
            PdfPCell OrginizeHourCell = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("الساعة : ")), CreateFont()));
            CellOption(OrginizeHourCell, 2, 0, 1, 1, 5, 5);
            PdfPCell OrginizeHour = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(Hour.ToString() + ":" + certifiedInfo.OrginazationDate.ToString("mm") + " " + certifiedInfo.OrginazationDate.ToString("tt", new CultureInfo("ar-AE")))), CreateFont(12, 1, false, false, true)));
            CellOption(OrginizeHour, 2, 0, 1, 1, 0, 20);
            AddCellToTable(OrginizeHourTable, new List<PdfPCell> { OrginizeHour, OrginizeHourCell });
            PdfPCell HourCell = new PdfPCell(OrginizeHourTable);
            CellOption(HourCell, 2, 0, 1, 1, 0, 5);
            AddCellToTable(Title,new List<PdfPCell>{ RepublicOfIraq, CertifiedNumberV, CertifyNumber, BirthCertified, MinistryOfHealth,
                HourCell, Date, Health });
            return Title;
        }
        public static PdfPTable BirthRotateTable(CertifiedInfo certifiedInfo)
        {
            PdfPTable RotateTable = new PdfPTable(4);
            PdfPCell Nullc = new PdfPCell(new Phrase(0, " ", CreateFont()));
            CellOption(Nullc, 0, 1, 0, 4, 1);
            PdfPTable RecordTable = new PdfPTable(2);
            float[] RecordTablewidths = new float[] { 1, 2 };
            RecordTable.SetWidths(RecordTablewidths);
            PdfPCell recordCell = new PdfPCell(new Phrase(0, " سجلت لدى دائرة صحة : ", CreateFont()));
            PdfPCell record = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("")), CreateFont(12, 1, false, false, true)));
            PdfPTable OfficeTable = new PdfPTable(2);
            float[] OfficeTablewidths = new float[] { 1, 2 };
            OfficeTable.SetWidths(OfficeTablewidths);
            PdfPCell OfficeCell = new PdfPCell(new Phrase(0, " مكتب ولادات و وفيات : ", CreateFont()));
            PdfPCell Office = new PdfPCell(new Phrase(ConvertNumerals(NullException("")), CreateFont(12, 1, false, false, true)));
            CellOption(recordCell, 0, 25, 1, 1, 10, 0, 15);
            CellOption(record, 0, -25, 1, 1, 10, 0, 15);
            CellOption(OfficeCell, 0, 25, 1, 1, 10, 0, 15);
            CellOption(Office, 0, -25, 1, 1, 10, 0, 15);
            AddCellToTable(OfficeTable, new List<PdfPCell> { Office, OfficeCell });
            AddCellToTable(RecordTable, new List<PdfPCell> { record, recordCell });
            PdfPCell RecordTableCell = new PdfPCell(RecordTable);
            CellOption(RecordTableCell, Colspan: 2);
            PdfPCell OfficeTableCell = new PdfPCell(OfficeTable);
            CellOption(OfficeTableCell, Colspan: 2);
            PdfPTable sequenceTable = new PdfPTable(2);
            float[] sequenceTablewidths = new float[] { 3, 1 };
            sequenceTable.SetWidths(sequenceTablewidths);
            PdfPCell sequenceCell = new PdfPCell(new Phrase(0, " تحت تسلسل : ", CreateFont()));
            CellOption(sequenceCell, 0, 30, 1, 1, 10);
            PdfPCell sequence = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("")), CreateFont(12, 1, false, false, true)));
            CellOption(sequence, 0, -25, 1, 1, 10);
            AddCellToTable(sequenceTable, new List<PdfPCell> { sequence, sequenceCell });
            PdfPCell sequenceTableCell = new PdfPCell(sequenceTable);
            CellOption(sequenceTableCell, Colspan: 4);
            PdfPTable YearTable = new PdfPTable(2);
            float[] YearTablewidths = new float[] { 3, 1 };
            YearTable.SetWidths(YearTablewidths);
            PdfPCell ForYearCell = new PdfPCell(new Phrase(0, " لسنة : ", CreateFont()));
            CellOption(ForYearCell, 0, 30);
            PdfPCell ForYear = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("")), CreateFont(12, 1, false, false, true)));
            CellOption(ForYear, 0);
            AddCellToTable(YearTable, new List<PdfPCell> { ForYear, ForYearCell });
            PdfPCell YearTableCell = new PdfPCell(YearTable);
            CellOption(YearTableCell, Colspan: 2);
            PdfPCell Signature = new PdfPCell(new Phrase(0, "الختم\n و التوقيع", CreateFont()));
            CellOption(Signature, 1, 0, 2, 1, 0, 0);
            AddCellToTable(RotateTable, new List<PdfPCell> { OfficeTableCell, RecordTableCell, sequenceTableCell, Signature, YearTableCell});
            return RotateTable;
        }
        public static PdfPTable BirthNameGenderBirthPlace123(CertifiedInfo certifiedInfo)
        {
            PdfPTable NewbornInfo = new PdfPTable(3);
            float[] NewbornInfowidths = new float[] { 2f, 0.665f, 0.665f };
            NewbornInfo.SetWidths(NewbornInfowidths);
            PdfPTable NameTable = new PdfPTable(2);
            PdfPCell NameCell = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(" 1- الإسم : ")), CreateFont()));
            CellOption(NameCell, 0, 5, 1, 1, 5, 0, 5, 0.5f);
            PdfPCell Name = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(certifiedInfo.BirthName)), CreateFont(12, 1, false, false, true)));
            CellOption(Name, 0, -15, 1, 1, 5, 0, 5);
            AddCellToTable(NameTable, new List<PdfPCell> { Name, NameCell });
            PdfPCell NameTableCell = new PdfPCell(NameTable);
            PdfPTable GenderTable = new PdfPTable(2);
            PdfPCell GenderCell = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(" 2- الجنس : ")), CreateFont()));
            CellOption(GenderCell, 0, 5, 1, 1, 5, 0, 5, 0.5f);
            PdfPCell Gender = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(certifiedInfo.Gender)), CreateFont(12, 1, false, false, true)));
            CellOption(Gender, 0, -10, 1, 1, 5, 0, 5);
            AddCellToTable(GenderTable, new List<PdfPCell> { Gender, GenderCell});
            PdfPCell GenderTableCell = new PdfPCell(GenderTable);
            PdfPTable BirthPlaceTable = new PdfPTable(6);
            float[] BirthPlaceTablewidths = new float[] { 1.2f, 1f, 0.6f, 1f, 0.8f, 1.85f };
            BirthPlaceTable.SetWidths(BirthPlaceTablewidths);
            PdfPCell BirthPlaceCell = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("3- محل الولادة : " + " القرية أو المحلة : ")), CreateFont()));
            CellOption(BirthPlaceCell, Colspan: 2);
            PdfPCell BirthVillage = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(certifiedInfo.Village)), CreateFont(12, 1, false, false, true)));
            CellOption(BirthVillage, PaddingRight: -25, Colspan: 2);
            PdfPCell BirthArea = new PdfPCell(new Phrase(0, " الناحية : ", CreateFont()));
            CellOption(BirthArea);
            PdfPCell BirthAreaValue = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(certifiedInfo.Area)), CreateFont(12, 1, false, false, true)));
            CellOption(BirthAreaValue, PaddingRight: -20);
            PdfPCell BirthDistrict = new PdfPCell(new Phrase(0, " القضاء : ", CreateFont()));
            CellOption(BirthDistrict, PaddingTop: 5);
            PdfPCell BirthDistrictValue = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(certifiedInfo.District)), CreateFont(12, 1, false, false, true)));
            CellOption(BirthDistrictValue, PaddingTop: 5, PaddingRight: -70);
            PdfPCell BirthProvince = new PdfPCell(new Phrase(0, " المحافظة : ", CreateFont()));
            CellOption(BirthProvince, PaddingTop: 5);
            PdfPCell BirthProvinceValue = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(certifiedInfo.BirthProvince)), CreateFont(12, 1, false, false, true)));
            CellOption(BirthProvinceValue, PaddingTop: 5, PaddingRight: -15);
            PdfPCell BirthHealthDepartment = new PdfPCell(new Phrase(0, " دائرة صحة : ", CreateFont()));
            CellOption(BirthHealthDepartment, PaddingTop: 5);
            PdfPCell BirthHealthDepartmentValue = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(certifiedInfo.HealthDepartment)), CreateFont(12, 1, false, false, true)));
            CellOption(BirthHealthDepartmentValue, PaddingTop: 5);
            AddCellToTable(BirthPlaceTable, new List<PdfPCell> { BirthAreaValue, BirthArea, BirthVillage, BirthPlaceCell, BirthHealthDepartmentValue, BirthHealthDepartment, BirthProvinceValue, BirthProvince, BirthDistrictValue, BirthDistrict });
            PdfPCell BirthPlace = new PdfPCell(BirthPlaceTable);
            CellOption(BirthPlace, 0, 5, 1, 1, 5, 0, 5, 0.5f);
            AddCellToTable(NewbornInfo, new List<PdfPCell> { BirthPlace, GenderTableCell, NameTableCell });
            return NewbornInfo;
        }
        public static PdfPTable BirthBirthDetails4(CertifiedInfo certifiedInfo)
        {
            PdfPTable BirthDetails = new PdfPTable(4);
            float[] BirthDetailswidths = new float[] { 0.1f, 0.2f, 0.1f, 0.35f };
            BirthDetails.SetWidths(BirthDetailswidths);
            PdfPCell BirthType = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("4- الولادة :" + "\n" + "                طبيعية :")), CreateFont()));
            CellOption(BirthType, 0, 5, 1, 1, 5, 0, 5, 0.5f);
            string sNatural = "", SCaesarean = "";
            if (certifiedInfo.BirthType == "طبيعية")
                sNatural = "";
            else
                SCaesarean = "";

            PdfPCell NaturalMark = new PdfPCell(new Phrase(0, "\n" + sNatural, CreateFont(12, 0, true, false, true)));
            CellOption(NaturalMark, 0, 5, 1, 1, 5, 0, 5);

            PdfPCell Caesarean = new PdfPCell(new Phrase(0, "\nقيصرية : ", CreateFont()));
            CellOption(Caesarean, 0, 5, 1, 1, 5, 0, 5);
            PdfPCell CaesareanMark = new PdfPCell(new Phrase(0, "\n" + SCaesarean, CreateFont(12, 0, true, false, true)));
            CellOption(CaesareanMark, 0, 5, 1, 1, 5, 0, 5);
            string Ssingle = "";
            if (certifiedInfo.TwinsNumber == "مفردة")
                Ssingle = "";
            PdfPCell Single = new PdfPCell(new Phrase(0, "                مفردة :", CreateFont()));
            CellOption(Single, 0, 5, 1, 1, 5, 0, 0, 0.5f);
            PdfPCell SingleMark = new PdfPCell(new Phrase(0, Ssingle, CreateFont(12, 0, true, false, true)));
            CellOption(SingleMark, 0, 5, 1, 1, 5);
            string Stwin = "";
            if (certifiedInfo.TwinsNumber == "توأم")
                Stwin = "";
            PdfPCell Twin = new PdfPCell(new Phrase(0, "تؤام : ", CreateFont()));
            CellOption(Twin, 0, 5, 1, 1, 5);
            PdfPCell TwinMark = new PdfPCell(new Phrase(0, Stwin, CreateFont(12, 0, true, false, true)));
            CellOption(TwinMark, 0, 5, 1, 1, 5);
            string Sthird = "";
            if (certifiedInfo.TwinsNumber == "ثلاثية")
                Sthird = "";
            PdfPCell Triple = new PdfPCell(new Phrase(0, "                ثلاثية :", CreateFont()));
            CellOption(Triple, 0, 5, 1, 1, 5, 0, 0, 0.5f);
            PdfPCell ThreeMark = new PdfPCell(new Phrase(0, Sthird, CreateFont(12, 0, true, false, true)));
            CellOption(ThreeMark, 0, 5, 1, 1, 5);
            string Smore = "";
            if (certifiedInfo.TwinsNumber == "اكثر")
                Smore = "";

            PdfPCell More = new PdfPCell(new Phrase(0, "أكثر : ", CreateFont()));
            CellOption(More, 0, 5, 1, 1, 5);
            PdfPCell MoreMark = new PdfPCell(new Phrase(0, Smore, CreateFont(12, 0, true, false, true)));
            CellOption(MoreMark, 0, 5, 1, 1, 5);
            AddCellToTable(BirthDetails, new List<PdfPCell>{ CaesareanMark, Caesarean, NaturalMark, BirthType, TwinMark, Twin, SingleMark,
                Single, MoreMark, More, ThreeMark, Triple });
            return BirthDetails;
        }
        public static PdfPTable BirthBirthDate5(CertifiedInfo certifiedInfo)
        {
            PdfPTable BirthDate = new PdfPTable(2);
            float[] BirthDatewidths = new float[] { 2f, 2.4f };
            BirthDate.SetWidths(BirthDatewidths);
            //int PM = certifiedInfo.BirthDate.Hour;
            //string ConvertHour = "";
            //    if (PM == 0)
            //        ConvertHour = "منتصف الليل";
            //   else if (PM == 1)
            //        ConvertHour = Convert(PM.ToString(),true);
            //   else ConvertHour = Convert(PM.ToString(),true);
            //string SHour = "";
            //if (PM == 11) ConvertHour = "الحادية عشرة";
            //else if (PM == 12) ConvertHour = "الثانية عشرة";
            //else if (PM >=13||PM<=19) Convert(PM.ToString(),true);
            //string Minute = "";
            //string Min = Convert(certifiedInfo.BirthDate.Minute.ToString(), false, true);
            //if (Min == "")
            //    Min = "صفر";
            //if (certifiedInfo.BirthDate.Minute.ToString().Length > 1&& certifiedInfo.BirthDate.Minute!=10)
            //Minute = "دقيقة";
            //else Minute = "دقائق";
            PdfPTable BirthTimeTable = new PdfPTable(2);
            float[] BirthTimeTablewidths = new float[] { 2.5f, 1f };
            BirthTimeTable.SetWidths(BirthTimeTablewidths);
            PdfPCell BirthDateTextCell = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("5- تاريخ الولادة ( رقماً و كتابة ) : ")), CreateFont()));
            CellOption(BirthDateTextCell, 0, 5, 2, 1, 0, 0, 5);
            PdfPCell BirthHour = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(" الساعة : ")), CreateFont()));
            CellOption(BirthHour, 0, 5, 1, 1, 0, 0, 5);
            PdfPCell BirthDateText = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(/*PM.ToString()+" "+ConvertHour + SHour +" و "+Min+" "+Minute*/"")), CreateFont(12, 1, false, false, true)));
            CellOption(BirthDateText, 0, -15, 1, 1, 0, 0, 5);
            AddCellToTable(BirthTimeTable, new List<PdfPCell> { BirthDateTextCell, BirthDateText, BirthHour });
            PdfPCell BirthTimeTableCell = new PdfPCell(BirthTimeTable);
            CellOption(BirthTimeTableCell);
            PdfPTable DayTable = new PdfPTable(2);
            float[] DayTablewidths = new float[] { 2.5f, 1f };
            DayTable.SetWidths(DayTablewidths);
            PdfPCell TheDayCell = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("\n اليوم : ")), CreateFont()));
            CellOption(TheDayCell, 0, 5, 1, 1, 0, 0, 10);
            PdfPCell TheDay = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("\n" + certifiedInfo.BirthDate.Day.ToString() + " " + certifiedInfo.BirthDate.ToString("dddd", new CultureInfo("ar-AE")))), CreateFont(12, 1, false, false, true)));
            CellOption(TheDay, 0, -15, 1, 1, 0, 0, 10);
            AddCellToTable(DayTable, new List<PdfPCell> { TheDay, TheDayCell });
            PdfPCell DayTableCell = new PdfPCell(DayTable);
            CellOption(DayTableCell);
            PdfPTable MonthTable = new PdfPTable(2);
            float[] MonthTablewidths = new float[] { 2.5f, 1f };
            MonthTable.SetWidths(MonthTablewidths);
            PdfPCell TheMonthCell = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(" الشهر : ")), CreateFont()));
            CellOption(TheMonthCell, 0, 5, 1, 1, 5, 0, 5);
            PdfPCell TheMonth = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(certifiedInfo.BirthDate.Month.ToString() + " " + Convert(certifiedInfo.BirthDate.Month.ToString(), month: true))), CreateFont(12, 1, false, false, true)));
            CellOption(TheMonth, 0, -20, 1, 1, 5, 0, 5);
            AddCellToTable(MonthTable, new List<PdfPCell> { TheMonth, TheMonthCell });
            PdfPCell MonthTableCell = new PdfPCell(MonthTable);
            CellOption(MonthTableCell);
            PdfPTable TheYearTable = new PdfPTable(2);
            float[] TheYearTablewidths = new float[] { 2.5f, 1f };
            TheYearTable.SetWidths(TheYearTablewidths);
            PdfPCell TheYearCell = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(" السنة : ")), CreateFont()));
            CellOption(TheYearCell, 0, 5, 1, 1, 5, 0, 5);
            PdfPCell TheYear = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(certifiedInfo.BirthDate.Year.ToString() + " " + Convert(certifiedInfo.BirthDate.Year.ToString()))), CreateFont(12, 1, false, false, true)));
            CellOption(TheYear, 0, -15, 1, 1, 5, 0, 5);
            AddCellToTable(TheYearTable, new List<PdfPCell> { TheYear, TheYearCell });
            PdfPCell TheYearTableCell = new PdfPCell(TheYearTable);
            CellOption(TheYearTableCell);
            AddCellToTable(BirthDate, new List<PdfPCell> { DayTableCell, BirthTimeTableCell, TheYearTableCell, MonthTableCell });
            return BirthDate;
        }
        public static PdfPTable BirthFatherAndMother6To16(CertifiedInfo certifiedInfo)
        {
            PdfPTable FatherAndMother = new PdfPTable(6);
            float[] FatherAndMotherwidths = new float[] { 1f, 1f, 1f, 1f, 2.68f, 0.34f };
            FatherAndMother.SetWidths(FatherAndMotherwidths);
            PdfPCell FatherText = new PdfPCell(new Phrase(0, "الأب", CreateFont()));
            CellOption(FatherText, 1, 3, 1, 1, 5, 0, 5, 0, 0.5f);
            PdfPTable FatherFullNameTable = new PdfPTable(2);
            PdfPCell FatherFullNameCell = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(" 6- الإسم الثلاثي : ")), CreateFont()));
            CellOption(FatherFullNameCell, 0, 5, 1, 1, 5, 0, 5);
            PdfPCell FatherFullName = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(certifiedInfo.FatherName)), CreateFont(12, 1, false, false, true)));
            CellOption(FatherFullName, 0, -55, 1, 1, 5, 0, 5, 0, 0.5f);
            AddCellToTable(FatherFullNameTable, new List<PdfPCell> { FatherFullName, FatherFullNameCell });
            PdfPCell FatherFullNameTableCell = new PdfPCell(FatherFullNameTable);
            CellOption(FatherFullNameTableCell);
            PdfPTable FatherAgeTable = new PdfPTable(2);
            PdfPCell FatherAgeCell = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(" 7- العمر : ")), CreateFont()));
            CellOption(FatherAgeCell, 0, 5, 1, 1, 5, 0, 5);
            PdfPCell FatherAge = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(certifiedInfo.FatherAge.ToString())), CreateFont(12, 1, false, false, true)));
            CellOption(FatherAge, 0, 5, 1, 1, 5, 0, 5, 0, 0.5f);
            AddCellToTable(FatherAgeTable, new List<PdfPCell> { FatherAge, FatherAgeCell });
            PdfPCell FatherAgeTableCell = new PdfPCell(FatherAgeTable);
            CellOption(FatherAgeTableCell);
            PdfPTable FatherProffesionTable = new PdfPTable(2);
            PdfPCell FatherProffesionCell = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(" 8- المهنة : ")), CreateFont()));
            CellOption(FatherProffesionCell, 0, 5, 1, 1, 5, 0, 5);
            PdfPCell FatherProffesion = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(certifiedInfo.FatherJob)), CreateFont(12, 1, false, false, true)));
            CellOption(FatherProffesion, 0, 5, 1, 1, 5, 0, 5);
            AddCellToTable(FatherProffesionTable, new List<PdfPCell> { FatherProffesion, FatherProffesionCell });
            PdfPCell FatherProffesionTableCell = new PdfPCell(FatherProffesionTable);
            PdfPTable FatherNationalityTable = new PdfPTable(2);
            float[] FatherNationalityTablewidths = new float[] { 1f, 1.3f };
            FatherNationalityTable.SetWidths(FatherNationalityTablewidths);
            PdfPCell FatherNationality = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(" 9- الجنسية : ")), CreateFont()));
            CellOption(FatherNationality, 0, 5, 1, 1, 5, 0, 5);
            PdfPCell FatherNationalityCell = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(certifiedInfo.FatherNationality)), CreateFont(12, 1, false, false, true)));
            CellOption(FatherNationalityCell, 0, 5, 1, 1, 5, 0, 5, 0, 0.5f);
            AddCellToTable(FatherNationalityTable, new List<PdfPCell> { FatherNationalityCell, FatherNationality });
            PdfPCell FatherNationalityTableCell = new PdfPCell(FatherNationalityTable);
            PdfPTable FatherReligionTable = new PdfPTable(2);
            float[] FatherReligionTablewidths = new float[] { 1f, 1.6f };
            FatherReligionTable.SetWidths(FatherReligionTablewidths);
            PdfPCell FatherReligionCell = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(" 10- الديانة : ")), CreateFont()));
            CellOption(FatherReligionCell, 0, 5, 1, 1, 5, 0, 5, 0, 0, 0.5f);
            PdfPCell FatherReligion = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(certifiedInfo.FatherReligion)), CreateFont(12, 0, false, false, true)));
            CellOption(FatherReligion, 0, 0, 1, 1, 5, 0, 5, 0, 0, 0.5f);
            AddCellToTable(FatherReligionTable, new List<PdfPCell> { FatherReligion, FatherReligionCell });
            PdfPCell FatherReligionTableCell = new PdfPCell(FatherReligionTable);
            PdfPCell MotherText = new PdfPCell(new Phrase(0, "الأم", CreateFont()));
            CellOption(MotherText, 1, 3, 1, 1, 5, 0, 5, 0, 0, 0.5f);
            PdfPTable MotherFullNameTable = new PdfPTable(2);
            PdfPCell MotherFullNameCell = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(" 11- الإسم الثلاثي : ")), CreateFont()));
            CellOption(MotherFullNameCell, 0, 5, 1, 1, 5, 0, 5);
            PdfPCell MotherFullName = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(certifiedInfo.MotherName)), CreateFont(12, 1, false, false, true)));
            CellOption(MotherFullName, 0, -50, 1, 1, 5, 0, 5, 0, 0.5f);
            AddCellToTable(MotherFullNameTable, new List<PdfPCell> { MotherFullName, MotherFullNameCell });
            PdfPCell MotherFullNameTableCell = new PdfPCell(MotherFullNameTable);
            PdfPTable MotherAgeTable = new PdfPTable(2);
            float[] MotherAgeTablewidths = new float[] { 1f, 1.2f };
            MotherAgeTable.SetWidths(MotherAgeTablewidths);
            PdfPCell MotherAgeCell = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(" 12- العمر : ")), CreateFont()));
            CellOption(MotherAgeCell, 0, 5, 1, 1, 5, 0, 5, 0, 0, 0.5f);
            PdfPCell MotherAge = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(certifiedInfo.MotherAge.ToString())), CreateFont(12, 1, false, false, true)));
            CellOption(MotherAge, 0, 2, 1, 1, 5, 0, 5, 0, 0.5f, 0.5f);
            AddCellToTable(MotherAgeTable, new List<PdfPCell> { MotherAge, MotherAgeCell });
            PdfPCell MotherAgeTableCell = new PdfPCell(MotherAgeTable);
            CellOption(MotherAgeTableCell);
            PdfPTable MotherProffesionTable = new PdfPTable(2);
            float[] MotherProffesionTablewidths = new float[] { 1f, 1.2f };
            MotherProffesionTable.SetWidths(MotherProffesionTablewidths);
            PdfPCell MotherProffesionCell = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("13- المهنة : ")), CreateFont()));
            CellOption(MotherProffesionCell, 0, 5, 1, 1, 5, 0, 5);
            PdfPCell MotherProffesion = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(certifiedInfo.MotherJob)), CreateFont(12, 1, false, false, true)));
            CellOption(MotherProffesion, 0, 2, 1, 1, 5, 0, 5);
            AddCellToTable(MotherProffesionTable, new List<PdfPCell> { MotherProffesion, MotherProffesionCell });
            PdfPCell MotherProffesionTableCell = new PdfPCell(MotherProffesionTable);
            PdfPTable MotherNationalityTable = new PdfPTable(2);
            float[] MotherNationalityTablewidths = new float[] { 1f, 1.6f };
            MotherNationalityTable.SetWidths(MotherNationalityTablewidths);
            PdfPCell MotherNationality = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("14- الجنسية : ")), CreateFont()));
            CellOption(MotherNationality, 0, 5, 1, 1, 5, 0, 5);
            PdfPCell MotherNationalityCell = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(certifiedInfo.MotherNationality)), CreateFont(12, 1, false, false, true)));
            CellOption(MotherNationalityCell, 0, 0, 1, 1, 5, 0, 5, 0, 0.5f);
            AddCellToTable(MotherNationalityTable, new List<PdfPCell> { MotherNationalityCell, MotherNationality });
            PdfPCell MotherNationalityTableCell = new PdfPCell(MotherNationalityTable);
            PdfPTable MotherReligionTable = new PdfPTable(2);
            float[] MotherReligionTablewidths = new float[] { 1f, 1.6f };
            MotherReligionTable.SetWidths(MotherReligionTablewidths);
            PdfPCell MotherReligionCell = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(" 15- الديانة : ")), CreateFont()));
            CellOption(MotherReligionCell, 0, 5, 1, 1, 5, 0, 5);
            PdfPCell MotherReligion = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(certifiedInfo.MotherReligion)), CreateFont(12, 0, false, false, true)));
            CellOption(MotherReligion, 0, 0, 1, 1, 5, 0, 5);
            AddCellToTable(MotherReligionTable, new List<PdfPCell> { MotherReligion, MotherReligionCell });
            PdfPCell MotherReligionTableCell = new PdfPCell(MotherReligionTable);
            string sRelation = "";
            if (certifiedInfo.FatherAndMotherRelation == true) sRelation = "";
            PdfPCell FatherAndMotherRelationShip =
                new PdfPCell(new Phrase(0, ConvertNumerals(NullException("16- هل هنالك صلة قرابة بين الام والاب؟      توجد ")), CreateFont()));
            CellOption(FatherAndMotherRelationShip, 0, 5, 2, 1, 5, 0, 5, 0, 0, 0.5f);
            PdfPCell ThereAreMark = new PdfPCell(new Phrase(0, sRelation, CreateFont(12, 0, true, false, true)));
            CellOption(ThereAreMark, 0, -50, 1, 1, 0, 0, 5, 0, 0, 0.5f);
            PdfPCell ThereAreNo = new PdfPCell(new Phrase(0, "لا توجد  ", CreateFont()));
            CellOption(ThereAreNo, 0, -110, 2, 1, 5, 0, 5, 0, 0, 0.5f);
            string NoRelation = "";
            if (sRelation == "") NoRelation = "";
            PdfPCell ThereAreNoMark = new PdfPCell(new Phrase(0, NoRelation, CreateFont(12, 0, true, false, true)));
            CellOption(ThereAreNoMark, 0, -260, 1, 1, 0, 0, 5, 0, 0, 0.5f);
            AddCellToTable(FatherAndMother, new List<PdfPCell>{ FatherReligionTableCell, FatherNationalityTableCell, FatherProffesionTableCell, FatherAgeTableCell,
                FatherFullNameTableCell, FatherText,
                MotherReligionTableCell, MotherNationalityTableCell, MotherProffesionTableCell, MotherAgeTableCell, MotherFullNameTableCell, MotherText,
                ThereAreNoMark, ThereAreNo, ThereAreMark, FatherAndMotherRelationShip });
            return FatherAndMother;
        }
        public static PdfPTable BirthPreviousBirth17(CertifiedInfo certifiedInfo)
        {
            PdfPTable PreviousBirth = new PdfPTable(6);
            float[] PreviousBirthwidths = new float[] { 1f, 0.1f, 1f, 1.5f, 1.5f, 1f };
            PreviousBirth.SetWidths(PreviousBirthwidths);
            PdfPCell PreviousBirthText = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("17- عدد المواليد السابقة للام عدا هذا الطفل : ")), CreateFont()));
            CellOption(PreviousBirthText, 0, 5, 6, 1, 5, 0, 5, 0, 0, 0.5f);
            PdfPTable BirthsAliveTable = new PdfPTable(2);
            float[] BirthsAliveTablewidths = new float[] { 1.2f, 1f };
            BirthsAliveTable.SetWidths(BirthsAliveTablewidths);
            PdfPCell BirthsAliveCell = new PdfPCell(new Phrase(0, " أ - الأحياء ", CreateFont()));
            CellOption(BirthsAliveCell, 0, 5, 1, 1, 5);
            PdfPCell BirthsAlive = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(Convert(certifiedInfo.AliveBirth.ToString(), false, true, true))), CreateFont(12, 1, false, false, true)));
            CellOption(BirthsAlive, 0, 5, 1, 1, 5);
            AddCellToTable(BirthsAliveTable, new List<PdfPCell> { BirthsAlive, BirthsAliveCell });
            PdfPCell BirthsAliveTableCell = new PdfPCell(BirthsAliveTable);
            CellOption(BirthsAliveTableCell);
            PdfPTable BirthsAliveAndThenDieTable = new PdfPTable(2);
            float[] BirthsAliveAndThenDieTablewidths = new float[] { 0.2f, 3f };
            BirthsAliveAndThenDieTable.SetWidths(BirthsAliveAndThenDieTablewidths);
            PdfPCell BirthsAliveAndThenDieCell = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(
               " ب -المولودين الأحياء ثم توفوا ")), CreateFont()));
            CellOption(BirthsAliveAndThenDieCell, 2, 0, 1, 1, 0, 40);
            PdfPCell BirthsAliveAndThenDie = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(Convert(certifiedInfo.AliveThenDeath.ToString(), false, true, true))), CreateFont(12, 1, false, false, true)));
            CellOption(BirthsAliveAndThenDie, 0, -30, 1, 1, 0);
            AddCellToTable(BirthsAliveAndThenDieTable, new List<PdfPCell> { BirthsAliveAndThenDie, BirthsAliveAndThenDieCell });
            PdfPCell BirthsAliveAndThenDieTableCell = new PdfPCell(BirthsAliveAndThenDieTable);
            CellOption(BirthsAliveAndThenDieTableCell, Colspan: 2);
            PdfPTable BirthsDieTable = new PdfPTable(2);
            float[] BirthsDieTablewidths = new float[] { 1f, 0.7f };
            BirthsDieTable.SetWidths(BirthsDieTablewidths);
            PdfPCell BirthsDieCell = new PdfPCell(new Phrase(0, " ج - الذين ولدوا أمواتاً ", CreateFont()));
            CellOption(BirthsDieCell, 0, 5, 1, 1, 5);
            PdfPCell BirthsDie = new PdfPCell(new Phrase(0, !certifiedInfo.DeathBirth.HasValue ? "لا يوجد" : NullException(Convert(certifiedInfo.DeathBirth.ToString(), false, true, true)), CreateFont(12, 1, false, false, true)));
            CellOption(BirthsDie, 0, -5, 1, 1, 5);
            AddCellToTable(BirthsDieTable, new List<PdfPCell> { BirthsDie, BirthsDieCell });
            PdfPCell BirthsDieTableCell = new PdfPCell(BirthsDieTable);
            CellOption(BirthsDieTableCell, Colspan: 3);
            PdfPTable BirthsDisabledTable = new PdfPTable(2);
            float[] BirthsDisabledTablewidths = new float[] { 1f, 0.7f };
            BirthsDisabledTable.SetWidths(BirthsDisabledTablewidths);
            PdfPCell BirthsDisabledCell = new PdfPCell(new Phrase(0, " د - الذين ولدوا معوقين ", CreateFont()));
            CellOption(BirthsDisabledCell, 0, 5, 1, 1, 5);
            PdfPCell BirthsDisabled = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(Convert(certifiedInfo.BirthDisable.ToString(), false, true, true))), CreateFont(12, 1, false, false, true)));
            CellOption(BirthsDisabled, 0, -15, 1, 1, 5);
            AddCellToTable(BirthsDisabledTable, new List<PdfPCell> { BirthsDisabled, BirthsDisabledCell });
            PdfPCell BirthsDisabledTableCell = new PdfPCell(BirthsDisabledTable);
            CellOption(BirthsDisabledTableCell, Colspan: 2);
            PdfPTable DisableTable = new PdfPTable(3);
            float[] DisableTablewidths = new float[] { 1.3f, 0.05f, 0.55f };
            DisableTable.SetWidths(DisableTablewidths);
            PdfPTable ProjectionTable = new PdfPTable(2);
            float[] ProjectionTablewidths = new float[] { 1f, 0.7f };
            ProjectionTable.SetWidths(ProjectionTablewidths);
            PdfPCell NumberOfProjectionsIfAnyCell = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(" هـ - عدد الاسقاطات ان وجدت ")), CreateFont()));
            CellOption(NumberOfProjectionsIfAnyCell, 0, -5, 1, 1, 5);
            PdfPCell NumberOfProjectionsIfAny = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(Convert(certifiedInfo.ProjectionNumber.ToString(), false, true, true))), CreateFont(12, 1, false, false, true)));
            CellOption(NumberOfProjectionsIfAny, 0, -50, 1, 1, 5);
            AddCellToTable(ProjectionTable, new List<PdfPCell> { NumberOfProjectionsIfAny, NumberOfProjectionsIfAnyCell });
            PdfPCell ProjectionTableCell = new PdfPCell(ProjectionTable);
            CellOption(ProjectionTableCell, Colspan: 4);
            PdfPCell IsThisBirthDisabled = new PdfPCell(new Phrase(0, "و- هل الولادة الحالية معوقة ( يحدد نوع العوق ) :  " + " ", CreateFont()));
            CellOption(IsThisBirthDisabled, 0, 20, 1, 1, 5, 0, 5);
            PdfPCell IsThisBirthDisabledC = new PdfPCell(DisableTable);
            CellOption(IsThisBirthDisabledC, Colspan: 6);
            string Sdisable = "";
            bool font = true;
            if (certifiedInfo.DisableType == "")
            {
                Sdisable = "لا";
                font = false;
            }
            else
            {
                Sdisable = "";
            }
            PdfPCell DisabledMark = new PdfPCell(new Phrase(0, Sdisable, CreateFont(12, 0, font, false, true)));
            CellOption(DisabledMark, 0, 5, 1, 1, 0, 0, 5);
            PdfPCell DisabledType = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(certifiedInfo.DisableType)), CreateFont(12, 1, false, false, true)));
            CellOption(DisabledType, 0, 10, 1, 1, 5, 0, 5);
            AddCellToTable(DisableTable, new List<PdfPCell> { DisabledType, DisabledMark, IsThisBirthDisabled });
            AddCellToTable(PreviousBirth, new List<PdfPCell>{ PreviousBirthText, BirthsDieTableCell, BirthsAliveAndThenDieTableCell, BirthsAliveTableCell,
                ProjectionTableCell, BirthsDisabledTableCell, IsThisBirthDisabledC });
            return PreviousBirth;
        }
        public static PdfPTable BirthBirthDurationTable18(CertifiedInfo certifiedInfo)
        {
            PdfPTable BirthDurationTable = new PdfPTable(3);
            float[] BirthDurationTablewidths = new float[] { 1, 0.5f, 2f };
            BirthDurationTable.SetWidths(BirthDurationTablewidths);
            PdfPCell BirthDurationText = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("18 - مدة الحمل : ")), CreateFont()));
            CellOption(BirthDurationText, 0, 5, 1, 1, 5, 0, 5, 0, 0, 0.5f);
            PdfPCell BirthDurationValue = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(certifiedInfo.LengthOfPregnancy.ToString())), CreateFont(12, 1, false, false, true)));
            CellOption(BirthDurationValue, 0, 5, 1, 1, 5, 0, 5, 0, 0, 0.5f);
            PdfPCell week = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(" أسبوع ")), CreateFont()));
            CellOption(week, 0, 5, 1, 1, 5, 0, 5, 0, 0.5f, 0.5f);
            AddCellToTable(BirthDurationTable, new List<PdfPCell> { week, BirthDurationValue, BirthDurationText });
            return BirthDurationTable;
        }
        public static PdfPTable BirthChildWeightTable19(CertifiedInfo certifiedInfo)
        {
            PdfPTable ChildWeightTable = new PdfPTable(3);
            float[] ChildWeightwidths = new float[] { 0.45f, 0.7f, 1.55f };
            ChildWeightTable.SetWidths(ChildWeightwidths);
            PdfPCell ChildWeightText = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("19 - وزن الطفل : ")), CreateFont()));
            CellOption(ChildWeightText, 0, 5, 1, 1, 5, 0, 5, 0, 0, 0.5f);
            PdfPCell ChildWeightValue = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(certifiedInfo.ChildWeight.ToString())), CreateFont(12, 1, false, false, true)));
            CellOption(ChildWeightValue, 0, 5, 1, 1, 5, 0, 5, 0, 0, 0.5f);
            PdfPCell gram = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(" غم ")), CreateFont()));
            CellOption(gram, 0, 5, 1, 1, 5, 0, 5, 0, 0.5f, 0.5f);
            AddCellToTable(ChildWeightTable, new List<PdfPCell> { gram, ChildWeightValue, ChildWeightText });
            return ChildWeightTable;
        }
        public static PdfPTable BirthDuration20(CertifiedInfo certifiedInfo)
        {
            PdfPTable BirthDuration = new PdfPTable(7);
            float[] BirthDurationwidths = new float[] { 1.9f, 0.1f, 0.25f, 0.1f, 0.75f, 0.95f, 0.9f };
            BirthDuration.SetWidths(BirthDurationwidths);
            PdfPCell BirthDurationTableCell = new PdfPCell(BirthBirthDurationTable18(certifiedInfo));
            CellOption(BirthDurationTableCell);
            PdfPCell ChildWeightTableCell = new PdfPCell(BirthChildWeightTable19(certifiedInfo));
            CellOption(ChildWeightTableCell);
            string sHouse = "";
            if (certifiedInfo.BirthPlace == "بيت") sHouse = "";
            PdfPCell BirthIn = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("20 -   مكان الولادة :" + " بيت " + " ")), CreateFont()));
            CellOption(BirthIn, 0, 5, 1, 1, 5, 0, 5, 0, 0, 0.5f);
            PdfPCell HouseMark = new PdfPCell(new Phrase(0, sHouse, CreateFont(12, 0, true, false, true)));
            CellOption(HouseMark, 0, 0, 1, 1, 0, 0, 5, 0, 0, 0.5f);
            string sHospital = "";
            if (sHouse.Length == 0) sHospital = "";
            PdfPCell Hospital = new PdfPCell(new Phrase(0, "مستشفى", CreateFont()));
            CellOption(Hospital, 0, 5, 1, 1, 5, 0, 5, 0, 0, 0.5f);
            PdfPCell HospitalMark = new PdfPCell(new Phrase(0, sHospital, CreateFont(12, 0, true, false, true)));
            CellOption(HospitalMark, 0, 0, 1, 1, 0, 0, 5, 0, 0, 0.5f);
            PdfPTable HospitalTable = new PdfPTable(2);
            float[] HospitalTablewidths = new float[] { 1.5f, 1.8f };
            HospitalTable.SetWidths(HospitalTablewidths);
            PdfPCell HospitalNameCell = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(" (اسم المستشفى او المركز الصحي)")), CreateFont()));
            CellOption(HospitalNameCell, 0, 5, 1, 1, 5, 0, 5, 0.5f, 0, 0.5f);
            PdfPCell HospitalName = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(certifiedInfo.HospitalName)), CreateFont(12, 1, false, false, true)));
            CellOption(HospitalName, 0, 5, 1, 1, 5, 0, 5, 0, 0, 0.5f);
            AddCellToTable(HospitalTable, new List<PdfPCell> { HospitalName, HospitalNameCell });
            PdfPCell HospitalTableCell = new PdfPCell(HospitalTable);
            CellOption(HospitalTableCell);
            AddCellToTable(BirthDuration, new List<PdfPCell> { HospitalTableCell, HospitalMark, Hospital, HouseMark, BirthIn, ChildWeightTableCell, BirthDurationTableCell });
            return BirthDuration;
        }
        public static PdfPTable BirthBirthBy21(CertifiedInfo certifiedInfo)
        {
            PdfPTable BirthBy = new PdfPTable(9);
            float[] BirthBywidths = new float[] { 1, 0.05f, 0.2f, 0.1f, 0.3f, 0.1f, 0.6f, 0.1f, 0.8f };
            BirthBy.SetWidths(BirthBywidths);
            string sDoctor = "";
            if (certifiedInfo.BirthBy == "طبيب") sDoctor = "";
            PdfPCell BirthByText = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("21 - حدثت الولادة بواسطة : طبيب")), CreateFont()));
            CellOption(BirthByText, 0, 5, 1, 1, 5, 0, 5, 0, 0, 0.5f);
            PdfPCell DoctorMark = new PdfPCell(new Phrase(0, sDoctor, CreateFont(12, 0, true, false, true)));
            CellOption(DoctorMark, 0, 0, 1, 1, 0, 0, 5, 0, 0, 0.5f);
            string sNurse = "";
            if (certifiedInfo.BirthBy == "ممرضة مجازة بالتوليد") sNurse = "";
            PdfPCell ObstetricNurse = new PdfPCell(new Phrase(0, "ممرضة مجازة بالتوليد ", CreateFont()));
            CellOption(ObstetricNurse, 0, 5, 1, 1, 5, 0, 5, 0, 0, 0.5f);
            PdfPCell NurseMark = new PdfPCell(new Phrase(0, sNurse, CreateFont(12, 0, true, false, true)));
            CellOption(NurseMark, 0, 0, 1, 1, 0, 0, 5, 0, 0, 0.5f);
            string sBirthHelper = "";
            if (certifiedInfo.BirthBy == "قابلة مجازة") sBirthHelper = "";
            PdfPCell Midwife = new PdfPCell(new Phrase(0, "قابلة مجازة", CreateFont()));
            CellOption(Midwife, 0, 5, 1, 1, 5, 0, 5, 0, 0, 0.5f);
            PdfPCell MidwifeMark = new PdfPCell(new Phrase(0, sBirthHelper, CreateFont(12, 0, true, false, true)));
            CellOption(MidwifeMark, 0, 0, 1, 1, 0, 0, 5, 0, 0, 0.5f);
            string OtherS = "";
            if (certifiedInfo.BirthBy == "اخرى") OtherS = "";
            PdfPCell Other = new PdfPCell(new Phrase(0, " أخرى ", CreateFont()));
            CellOption(Other, 0, 5, 1, 1, 5, 0, 5, 0, 0, 0.5f);
            PdfPCell OtherMark = new PdfPCell(new Phrase(0, OtherS, CreateFont(12, 0, true, false, true)));
            CellOption(OtherMark, 0, 5, 1, 1, 5, 0, 5, 0, 0, 0.5f);
            PdfPTable CertifyInfoTable = new PdfPTable(4);
            float[] CertifyInfoTablewidths = new float[] { 1, 1, 1, 2 };
            CertifyInfoTable.SetWidths(CertifyInfoTablewidths);
            PdfPCell CertifyNumberCell = new PdfPCell(new Phrase(0, " رقم الإجازة : ", CreateFont()));
            CellOption(CertifyNumberCell);
            PdfPCell CertifyNumberCellValue = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(certifiedInfo.CertifyNumber.ToString())), CreateFont(12, 1, false, false, true)));
            CellOption(CertifyNumberCellValue);
            PdfPCell CertifyYear = new PdfPCell(new Phrase(0, " السنة : ", CreateFont()));
            CellOption(CertifyYear);
            PdfPCell CertifyYearValue = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(certifiedInfo.CertifyYear.ToString())), CreateFont(12, 1, false, false, true)));
            CellOption(CertifyYearValue);
            AddCellToTable(CertifyInfoTable, new List<PdfPCell> { CertifyYearValue, CertifyYear, CertifyNumberCellValue, CertifyNumberCell });
            PdfPCell CertifyInfo = new PdfPCell(CertifyInfoTable);
            CellOption(CertifyInfo, 0, 5, 1, 1, 5, 0, 5, 0, 0, 0.5f);
            PdfPCell BirthFamilyLocationText = new PdfPCell(BirthBirthFamilyLocation22(certifiedInfo));
            CellOption(BirthFamilyLocationText, 0, 5, 9, 1, 5, 0, 5, 0, 0, 0.5f);
            PdfPCell NationalityInformation = new PdfPCell(BirthNationalityInformationTable23(certifiedInfo));
            CellOption(NationalityInformation, 0, 5, 9, 1, 5, 0, 5, 0, 0, 0.5f);
            PdfPTable NationalNumber = new PdfPTable(2);
            PdfPCell FatherIDCell = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(" الرقم الوطني الموحد للاب أو الأم: ")), CreateFont()));
            CellOption(FatherIDCell, 0, 5, 1, 1, 5, 0, 5);
            PdfPCell FatherID = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(certifiedInfo.FatherNationalNumber)), CreateFont(12, 1, false, false, true)));
            CellOption(FatherID, 0, -200, 1, 1, 5, 0, 5);
            AddCellToTable(NationalNumber, new List<PdfPCell> { FatherID, FatherIDCell });
            PdfPCell NationalNumberCell = new PdfPCell(NationalNumber);
            CellOption(NationalNumberCell, 0, 5, 9, 1, 5, 0, 5);
            AddCellToTable(BirthBy, new List<PdfPCell> { CertifyInfo, OtherMark, Other, MidwifeMark, Midwife, NurseMark, ObstetricNurse, DoctorMark, BirthByText, BirthFamilyLocationText, NationalityInformation, NationalNumberCell });
            return BirthBy;
        }
        public static PdfPTable BirthBirthFamilyLocation22(CertifiedInfo certifiedInfo)
        {
            PdfPTable BirthFamilyLocation = new PdfPTable(6);
            float[] BirthFamilyLocationwidths = new float[] { 1f, 1.1f, 1f, 1, 1f, 2.1f };
            BirthFamilyLocation.SetWidths(BirthFamilyLocationwidths);
            PdfPCell BirthFamilyHouseNumber = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("22 - العنوان الدائم لعائلة المولود :  رقم الدار : ")), CreateFont()));
            CellOption(BirthFamilyHouseNumber);
            PdfPCell BirthFamilyHouseNumberValue = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(certifiedInfo.HouseNumber.ToString())), CreateFont(12, 1, false, false, true)));
            CellOption(BirthFamilyHouseNumberValue, PaddingRight: -20);
            PdfPCell BirthFamilyAlleyNumber = new PdfPCell(new Phrase(0, " زقاق : ", CreateFont()));
            CellOption(BirthFamilyAlleyNumber);
            PdfPCell BirthFamilyAlleyNumberValue = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(certifiedInfo.AlleyNumber.ToString())), CreateFont(12, 1, false, false, true)));
            CellOption(BirthFamilyAlleyNumberValue, PaddingRight: -50);
            PdfPCell BirthFamilyVillage = new PdfPCell(new Phrase(0, "  المحلة أو القرية : ", CreateFont()));
            CellOption(BirthFamilyVillage);
            PdfPCell BirthFamilyVillageValue = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(certifiedInfo.BirthVillage)), CreateFont(12, 1, false, false, true)));
            CellOption(BirthFamilyVillageValue, PaddingRight: -20);
            PdfPCell BirthFamilyArea = new PdfPCell(new Phrase(0, "  ناحية : ", CreateFont()));
            CellOption(BirthFamilyArea);
            PdfPCell BirthFamilyAreaValue = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(certifiedInfo.BirthArea)), CreateFont(12, 1, false, false, true)));
            CellOption(BirthFamilyAreaValue, PaddingRight: -160);
            PdfPCell BirthFamilyDistrict = new PdfPCell(new Phrase(0, " قضاء : ", CreateFont()));
            CellOption(BirthFamilyDistrict);
            PdfPCell BirthFamilyDistrictValue = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(certifiedInfo.BirthDistrict)), CreateFont(12, 1, false, false, true)));
            CellOption(BirthFamilyDistrictValue, PaddingRight: -50);
            PdfPCell BirthFamilyProvince = new PdfPCell(new Phrase(0, " المحافظة : ", CreateFont()));
            CellOption(BirthFamilyProvince);
            PdfPCell BirthFamilyProvinceValue = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(certifiedInfo.BirthProvince)), CreateFont(12, 1, false, false, true)));
            CellOption(BirthFamilyProvinceValue, PaddingRight: -50);
            AddCellToTable(BirthFamilyLocation, new List<PdfPCell>{BirthFamilyVillageValue, BirthFamilyVillage,
                                                BirthFamilyAlleyNumberValue, BirthFamilyAlleyNumber, BirthFamilyHouseNumberValue, BirthFamilyHouseNumber, BirthFamilyProvinceValue, BirthFamilyProvince, BirthFamilyDistrictValue, BirthFamilyDistrict, BirthFamilyAreaValue, BirthFamilyArea
            });
            return BirthFamilyLocation;
        }
        public static PdfPTable BirthNationalityInformationTable23(CertifiedInfo certifiedInfo)
        {
            PdfPTable NationalityInformationTable = new PdfPTable(8);
            float[] NationalityInformationTablewidths = new float[] { 1, 1, 1, 2, 0.5f, 1.25f, 1f, 5f };
            NationalityInformationTable.SetWidths(NationalityInformationTablewidths);
            PdfPCell RecordNumber = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("23 - معلومات خاصة بمديرية الجنسية والأحوال المدنية : رقم السجل : ")), CreateFont()));
            CellOption(RecordNumber);
            PdfPCell RecordNumberValue = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(certifiedInfo.RecordNumber)), CreateFont(12, 1, false, false, true)));
            CellOption(RecordNumberValue);
            PdfPCell PageNumber = new PdfPCell(new Phrase(0, " رقم الصحيفة : ", CreateFont()));
            CellOption(PageNumber);
            PdfPCell PageNumberValue = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(certifiedInfo.PageNumber)), CreateFont(12, 1, false, false, true)));
            CellOption(PageNumberValue);
            PdfPCell NationalDepartment = new PdfPCell(new Phrase(0, "  دائرة جنسية وأحوال : ", CreateFont()));
            CellOption(NationalDepartment);
            PdfPCell NationalDepartmentValue = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(certifiedInfo.NationalDepartment)), CreateFont(12, 1, false, false, true)));
            CellOption(NationalDepartmentValue);
            PdfPCell NationalProvince = new PdfPCell(new Phrase(0, "  محافظة : ", CreateFont()));
            CellOption(NationalProvince);
            PdfPCell NationalProvinceValue = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(certifiedInfo.NationalProvince)), CreateFont(12, 1, false, false, true)));
            CellOption(NationalProvinceValue);
            AddCellToTable(NationalityInformationTable, new List<PdfPCell> { NationalProvinceValue, NationalProvince, NationalDepartmentValue, NationalDepartment, PageNumberValue, PageNumber, RecordNumberValue, RecordNumber });
            return NationalityInformationTable;
        }
        public static PdfPTable BirthInformerTable24(CertifiedInfo certifiedInfo)
        {
            PdfPTable InformerTable = new PdfPTable(6);
            PdfPCell InformerName = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("24 - اسم المخبر : ")), CreateFont()));
            CellOption(InformerName);
            PdfPCell InformerNameValue = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(certifiedInfo.InformerName)), CreateFont(12, 1, false, false, true)));
            CellOption(InformerNameValue, PaddingRight: -10);
            PdfPCell InformerLocation = new PdfPCell(new Phrase(0, " عنوانه : ", CreateFont()));
            CellOption(InformerLocation);
            PdfPCell InformerLocationValue = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(certifiedInfo.InformerLocation)), CreateFont(12, 1, false, false, true)));
            CellOption(InformerLocationValue, PaddingRight: -50);
            PdfPCell InformerRelation = new PdfPCell(new Phrase(0, " صلته بالوليد : ", CreateFont()));
            CellOption(InformerRelation);
            PdfPCell InformerRelationValue = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(certifiedInfo.InformerRelation)), CreateFont(12, 1, false, false, true)));
            CellOption(InformerRelationValue, PaddingRight: -30);
            AddCellToTable(InformerTable, new List<PdfPCell> { InformerRelationValue, InformerRelation, InformerLocationValue, InformerLocation, InformerNameValue, InformerName });
            return InformerTable;
        }
        public static PdfPTable BirthBirthHelperInfoTable25(CertifiedInfo certifiedInfo)
        {
            PdfPTable BirthHelperInfoTable = new PdfPTable(5);
            float[] BirthHelperInfoTablewidths = new float[] { 1, 1, 2, 1, 1 };
            BirthHelperInfoTable.SetWidths(BirthHelperInfoTablewidths);
            PdfPCell BirthHelperName = new PdfPCell(new Phrase(0, "إسم المولد :", CreateFont()));
            CellOption(BirthHelperName);
            PdfPCell BirthHelperNameValue = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(certifiedInfo.BirthHelperName)), CreateFont(12, 1, false, false, true)));
            CellOption(BirthHelperNameValue, PaddingRight: -40);
            PdfPCell BirthHelperJobLocation = new PdfPCell(new Phrase(0, " عنوان الاشتغال :  مستشفى : ", CreateFont()));
            CellOption(BirthHelperJobLocation);
            PdfPCell BirthHelperJobLocationValue = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(certifiedInfo.JobLocation)), CreateFont(12, 1, false, false, true)));
            CellOption(BirthHelperJobLocationValue, PaddingRight: -70);
            PdfPCell SealAndSignature = new PdfPCell(new Phrase(0, "    التوقيع والختم     ", CreateFont()));
            CellOption(SealAndSignature);
            AddCellToTable(BirthHelperInfoTable, new List<PdfPCell> { SealAndSignature, BirthHelperJobLocationValue, BirthHelperJobLocation, BirthHelperNameValue, BirthHelperName });
            return BirthHelperInfoTable;
        }
        public static PdfPTable BirthHospitalManagerTable25(CertifiedInfo certifiedInfo)
        {
            PdfPTable HospitalManagerTable = new PdfPTable(3);
            float[] HospitalManagerTablewidths = new float[] { 1, 2, 2 };
            HospitalManagerTable.SetWidths(HospitalManagerTablewidths);
            PdfPCell HospitalManagerName = new PdfPCell(new Phrase(0, " مدير المستشفى أو من ينوب عنه :   الإسم الثلاثي :  ", CreateFont()));
            CellOption(HospitalManagerName);
            PdfPCell HospitalManagerNameValue = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(certifiedInfo.HospitalManager)), CreateFont(12, 1, false, false, true)));
            CellOption(HospitalManagerNameValue, PaddingRight: -15);
            PdfPCell HospitalManagerSignature = new PdfPCell(new Phrase(0, " التوقيع ", CreateFont()));
            CellOption(HospitalManagerSignature);
            AddCellToTable(HospitalManagerTable, new List<PdfPCell> { HospitalManagerSignature, HospitalManagerNameValue, HospitalManagerName });
            return HospitalManagerTable;
        }
        public static FileStreamResult CreateBirthCertified(CertifiedInfo certifiedInfo)
        {
            MemoryStream m = new MemoryStream();
            var document = new Document(PageSize.A4.Rotate(), 30, 30, 10, 10);
            PdfWriter.GetInstance(document, m).CloseStream = false;
            document.Open();
            PdfPCell Nullc = new PdfPCell(new Phrase(0, " ", CreateFont()));
            CellOption(Nullc, 0, 1, 0, 4, 1);
            PdfPTable BirthText = new PdfPTable(1);
            PdfPCell BirthCell = new PdfPCell(new Phrase(0, "الوليد", CreateFont()));
            CellOption(BirthCell, 1, 0, 1, 1, 5, 0, 50);
            AddCellToTable(BirthText, new List<PdfPCell> { BirthCell });
            PdfPTable LastTable = new PdfPTable(2);
            float[] LastTablewidths = new float[] { 0.5f, 1.9f };
            LastTable.SetWidths(LastTablewidths);
            PdfPCell TheSeal = new PdfPCell(new Phrase(0, "ختم الجهة المسئولة عن تنظيم الشهادة", CreateFont()));
            CellOption(TheSeal, 0, 5, 1, 5, 5, 0, 5, 0.5f, 0, 0.5f);
            PdfPCell DeathCertifyer = new PdfPCell(BirthInformerTable24(certifiedInfo));
            CellOption(DeathCertifyer, 0, 5, 1, 1, 5, 0, 5, 0.5f, 0, 0.5f);
            PdfPCell Oath = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("25 - اشهد بان هذا الطفل ولد حياً في التاريخ المبين أعلاه :")), CreateFont()));
            CellOption(Oath, 0, 5, 1, 1, 5, 0, 5, 0.5f, 0, 0.5f);
            PdfPCell BirthHelperInfo = new PdfPCell(BirthBirthHelperInfoTable25(certifiedInfo));
            CellOption(BirthHelperInfo, 0, 5, 1, 1, 5, 0, 5);
            PdfPCell HospitalManager = new PdfPCell(BirthHospitalManagerTable25(certifiedInfo));
            CellOption(HospitalManager, 0, 5, 1, 1, 5, 0, 5, 0, 0, 0.5f);
            AddCellToTable(LastTable, new List<PdfPCell> { TheSeal, DeathCertifyer, Oath, BirthHelperInfo, HospitalManager });
            PdfPTable BirthInformation = new PdfPTable(2);
            float[] BirthInformationwidths = new float[] { 1.5f, 1f };
            BirthInformation.SetWidths(BirthInformationwidths);
            PdfPCell BirthDetailsc = new PdfPCell(BirthBirthDetails4(certifiedInfo));
            PdfPCell BirthDatec = new PdfPCell(BirthBirthDate5(certifiedInfo));
            AddCellToTable(BirthInformation, new List<PdfPCell> { BirthDatec, BirthDetailsc });
            PdfPTable BirthInfo = new PdfPTable(2);
            float[] BirthInfowidths = new float[] { 30f, 1.5f };
            BirthInfo.SetWidths(BirthInfowidths);
            PdfPCell BirthInformationc = new PdfPCell(BirthInformation);
            PdfPCell NewbornInfoc = new PdfPCell(BirthNameGenderBirthPlace123(certifiedInfo));
            PdfPCell BirthTextc = new PdfPCell(BirthText)
            {
                Rowspan = 2
            };
            PdfPCell FatherAndMotherc = new PdfPCell(BirthFatherAndMother6To16(certifiedInfo));
            CellOption(FatherAndMotherc, 0, 0, 2);
            PdfPCell PreviousBirthc = new PdfPCell(BirthPreviousBirth17(certifiedInfo));
            CellOption(PreviousBirthc, 0, 0, 2);
            PdfPCell BirthDurationc = new PdfPCell(BirthDuration20(certifiedInfo));
            CellOption(BirthDurationc, 0, 0, 2);
            PdfPCell BirthByc = new PdfPCell(BirthBirthBy21(certifiedInfo));
            CellOption(BirthByc, 0, 0, 2);
            PdfPCell LastTablec = new PdfPCell(LastTable);
            CellOption(LastTablec, 0, 0, 2);
            AddCellToTable(BirthInfo, new List<PdfPCell> { NewbornInfoc, BirthTextc, BirthInformationc, FatherAndMotherc, PreviousBirthc, BirthDurationc, BirthByc, LastTablec });
            PdfPTable MainTable = new PdfPTable(2);
            float[] MainTablewidths = new float[] { 6.8f, 1f };
            MainTable.SetWidths(MainTablewidths);
            PdfPCell RotateTablec = new PdfPCell(BirthRotateTable(certifiedInfo))
            {
                Rotation = 90
            };
            PdfPCell BirthInfoc = new PdfPCell(BirthInfo);
            CellOption(Nullc, BorderWidthBottom: 0.5f, BorderWidthLeft: 0.5f, BorderWidthRight: 0.5f, BorderWidthTop: 0.5f);
            AddCellToTable(MainTable, new List<PdfPCell> { BirthInfoc, RotateTablec });
            PdfPTable Footer = new PdfPTable(1);
            PdfPCell FooterCell = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("   نموذج صادر بموجب القانون 148 لسنة 1971 عن وزارة الصحة/ دائرة التخطيط وتنمية الموارد/ قسم الاحصاء الصحي والحياتي               ")), CreateFont()));
            CellOption(FooterCell, 0, 5, 1, 1, 5, 0, 5);
            AddCellToTable(Footer, new List<PdfPCell> { FooterCell });
            document.Add(Picture(580, 530, 60, 60));
            document.Add(BirthTitle(certifiedInfo));
            document.Add(MainTable);
            document.Add(Footer);
            document.Close();
            byte[] byteInfo = m.ToArray();
            m.Write(byteInfo, 0, byteInfo.Length);
            m.Position = 0;
            return new FileStreamResult(m, "application/pdf");
        }
        public static FileStreamResult BirthWithinHealthInstitutions(CertifiedInfo BirthCertify)
        {
            var font = CreateFont(11);
            MemoryStream m = new MemoryStream();
            var document = new Document(PageSize.A4, 20, 20, 10, 10);
            PdfWriter.GetInstance(document, m).CloseStream = false;
            document.Open();
            PdfPTable Border = new PdfPTable(1);
            PdfPTable Title = new PdfPTable(2);
            PdfPCell TheRepublicofIraq = new PdfPCell(new Phrase(0,
                ConvertNumerals("جمهورية العراق \nوزارة الصحة \nقسم الإحصاء الصحي والحياتي"),
                CreateFont()));
            CellOption(TheRepublicofIraq, PaddingRight: 5, PaddingTop: 5, PaddingBottom: 5);
            PdfPCell endorsementNumber = new PdfPCell(new Phrase(0,
                ConvertNumerals("رقم التأييد : \nتاريخ التنظيم :"), CreateFont()));
            CellOption(endorsementNumber, 1, PaddingRight: 5, PaddingTop: 5, PaddingBottom: 5);
            PdfPCell endorsementTitle = new PdfPCell(new Phrase(0,
                ConvertNumerals("تأييد ولادة داخل المؤسسات الصحية"), CreateFont(14, 5)));
            CellOption(endorsementTitle, 1, PaddingRight: 5, Colspan: 2, PaddingBottom: 25);
            AddCellToTable(Title, new List<PdfPCell> { endorsementNumber, TheRepublicofIraq, endorsementTitle });
            string NaturalBirth = "", CaesareanBirth = "";
            if (BirthCertify.BirthType == "طبيعية")
                NaturalBirth = "";
            else if (BirthCertify.BirthType == "قيصرية") CaesareanBirth = "";
            PdfPTable BirthTypeTable = new PdfPTable(6);
            float[] BirthTypeTablewidths = { 1, 0.2f, 1.3f, 0.2f, 2, 4 };
            BirthTypeTable.SetWidths(BirthTypeTablewidths);
            PdfPCell HospitalName = new PdfPCell(new Phrase(0,
                ConvertNumerals("إسم المستشفى : " + BirthCertify.HospitalName), font));
            CellOption(HospitalName, PaddingRight: 5);
            PdfPCell BirthType =
                new PdfPCell(new Phrase(0, ConvertNumerals("نوع الولادة : 1- طبيعية"), font));
            CellOption(BirthType, PaddingRight: 5);
            PdfPCell NaturalBirthMark = new PdfPCell(new Phrase(0,
                ConvertNumerals(NullException(NaturalBirth)), CreateFont(11, 1, true)));
            PdfPCell Caesarean =
                new PdfPCell(new Phrase(0, ConvertNumerals("-2 قيصرية  : "), font));
            CellOption(Caesarean, PaddingRight: 5);
            PdfPCell CaesareanBirthMark = new PdfPCell(new Phrase(0,
                ConvertNumerals(NullException(CaesareanBirth)), CreateFont(11, 1, true)));
            PdfPCell Nullc = new PdfPCell(new Phrase(0, ConvertNumerals(" "), font));
            CellOption(Nullc, PaddingRight: 5);
            AddCellToTable(BirthTypeTable, new List<PdfPCell>{ Nullc, CaesareanBirthMark, Caesarean, NaturalBirthMark,
                BirthType, HospitalName });
            PdfPTable BirthInfo = new PdfPTable(11);
            float[] BirthInfowidths = { 0.25f, 0.25f, 1, 0.25f, 1, 0.25f, 1, 0.25f, 2, 2, 2 };
            BirthInfo.SetWidths(BirthInfowidths);
            string Single = "", Twins = "", Third = "", More = "";
            if (BirthCertify.TwinsNumber == "مفردة")
                Single = "";
            else if (BirthCertify.TwinsNumber == "توأم")
                Twins = "";
            else if (BirthCertify.TwinsNumber == "ثلاثية")
                Third = "";
            else if (BirthCertify.TwinsNumber == "اكثر")
                More = "";
            PdfPCell BirthName = new PdfPCell(new Phrase(0,
                ConvertNumerals("إسم المولود : " + BirthCertify.BirthName), font));
            CellOption(BirthName, PaddingRight: 5);
            PdfPCell BirthGender = new PdfPCell(new Phrase(0,
                ConvertNumerals("الجنس : " + BirthCertify.Gender), font));
            CellOption(BirthGender, PaddingRight: 5);
            PdfPCell SingleCell =
                new PdfPCell(new Phrase(0, ConvertNumerals(" الولادة : مفردة"), font));
            CellOption(SingleCell, PaddingRight: 5);
            PdfPCell SingleMark = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(Single)),
                CreateFont(11, 1, true)));
            PdfPCell TwinsCell = new PdfPCell(new Phrase(0, ConvertNumerals(" توأم"), font));
            CellOption(TwinsCell, PaddingRight: 5);
            PdfPCell TwinsMark = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(Twins)),
                CreateFont(11, 1, true)));
            PdfPCell ThirdCell =
                new PdfPCell(new Phrase(0, ConvertNumerals(NullException(" ثلاثية")), font));
            CellOption(ThirdCell, PaddingRight: 5);
            PdfPCell ThirdMark = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(Third)),
                CreateFont(11, 1, true)));
            PdfPCell MoreCell = new PdfPCell(new Phrase(0, ConvertNumerals(" أكثر"), font));
            CellOption(MoreCell, PaddingRight: 5);
            PdfPCell MoreMark = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(More)),
                CreateFont(11, 1, true)));
            AddCellToTable(BirthInfo, new List<PdfPCell>{ Nullc, MoreMark, MoreCell, ThirdMark, ThirdCell, TwinsMark,
                TwinsCell, SingleMark, SingleCell, BirthGender, BirthName });
            PdfPTable BirthDate = new PdfPTable(4);
            float[] BirthDatewidths = { 1.5f, 1, 1.2f, 1.5f };
            BirthDate.SetWidths(BirthDatewidths);
            PdfPCell BirthDateNumber = new PdfPCell(new Phrase(0,
                ConvertNumerals("تاريخ الولادة رقماً : " +
                                BirthCertify.BirthDate.ToShortDateString()), font));
            CellOption(BirthDateNumber, PaddingRight: 5);
            PdfPCell BirthDateDay = new PdfPCell(new Phrase(0,
                ConvertNumerals("كتابتاً : اليوم : " +
                                Convert(BirthCertify.BirthDate.ToString("dd"))), font));
            CellOption(BirthDateDay, PaddingRight: 5);
            PdfPCell BirthDateMonth = new PdfPCell(new Phrase(0,
                ConvertNumerals(" الشهر : " + Convert(BirthCertify.BirthDate.ToString("MM"))),
                font));
            CellOption(BirthDateMonth, PaddingRight: 5);
            PdfPCell BirthDateYear = new PdfPCell(new Phrase(0,
                ConvertNumerals(" السنة : " + Convert(BirthCertify.BirthDate.ToString("yyyy"))),
                font));
            CellOption(BirthDateYear, PaddingRight: 5);
            AddCellToTable(BirthDate, new List<PdfPCell> { BirthDateYear, BirthDateMonth, BirthDateDay, BirthDateNumber });
            PdfPTable ParentInfo = new PdfPTable(5);
            float[] ParentInfowidths = { 1, 1, 1, 1, 2 };
            ParentInfo.SetWidths(ParentInfowidths);
            PdfPCell FatherName = new PdfPCell(new Phrase(0,
                ConvertNumerals(" إسم الأب الثلاثي : " + BirthCertify.FatherName), font));
            CellOption(FatherName, PaddingRight: 5, PaddingBottom: 5);
            PdfPCell FatherAge = new PdfPCell(new Phrase(0,
                ConvertNumerals(" العمر : " + BirthCertify.FatherAge), font));
            CellOption(FatherAge, PaddingRight: 5, PaddingBottom: 5);
            PdfPCell FatherJob = new PdfPCell(new Phrase(0,
                ConvertNumerals(" المهنة : " + BirthCertify.FatherJob), font));
            CellOption(FatherJob, PaddingRight: 5, PaddingBottom: 5);
            PdfPCell FatherNationality = new PdfPCell(new Phrase(0,
                ConvertNumerals(" الجنسية : " + BirthCertify.FatherNationality), font));
            CellOption(FatherNationality, PaddingRight: 5, PaddingBottom: 5);
            PdfPCell FatherReligion = new PdfPCell(new Phrase(0,
                ConvertNumerals(" الديانة : " + BirthCertify.FatherReligion), font));
            CellOption(FatherReligion, PaddingRight: 5, PaddingBottom: 5);
            PdfPCell MotherName = new PdfPCell(new Phrase(0,
                ConvertNumerals(" إسم الأم الثلاثي : " + BirthCertify.MotherName), font));
            CellOption(MotherName, PaddingRight: 5);
            PdfPCell MotherAge = new PdfPCell(new Phrase(0,
                ConvertNumerals(" العمر : " + BirthCertify.MotherAge), font));
            CellOption(MotherAge, PaddingRight: 5);
            PdfPCell MotherJob = new PdfPCell(new Phrase(0,
                ConvertNumerals(" المهنة : " + BirthCertify.MotherJob), font));
            CellOption(MotherJob, PaddingRight: 5);
            PdfPCell MotherNationality = new PdfPCell(new Phrase(0,
                ConvertNumerals(" الجنسية : " + BirthCertify.MotherNationality), font));
            CellOption(MotherNationality, PaddingRight: 5);
            PdfPCell MotherReligion = new PdfPCell(new Phrase(0,
                ConvertNumerals(" الديانة : " + BirthCertify.MotherReligion), font));
            CellOption(MotherReligion, PaddingRight: 5);
            AddCellToTable(ParentInfo, new List<PdfPCell>{ FatherReligion, FatherNationality, FatherJob, FatherAge,
                FatherName, MotherReligion, MotherNationality, MotherJob, MotherAge, MotherName });
            string ExistRelation = "", NoRelation = "";
            if (BirthCertify.FatherAndMotherRelation == true)
                ExistRelation = "";
            else NoRelation = "";
            string DisableType = "";
            if (BirthCertify.DisableType == null)
                DisableType = "لا";
            else DisableType = BirthCertify.DisableType;
            PdfPTable Relation = new PdfPTable(5);
            float[] Relationwidths = { 0.5f, 0.025f, 0.1f, 0.025f, 0.3f };
            Relation.SetWidths(Relationwidths);
            PdfPCell RelationParentCell = new PdfPCell(new Phrase(0,
                ConvertNumerals(" هل هناك صلة قرابة بين الأب و الأم ؟ 1- يوجد "), font));
            CellOption(RelationParentCell, PaddingRight: 5);
            PdfPCell RelationMark = new PdfPCell(new Phrase(0,
                ConvertNumerals(NullException(ExistRelation)), CreateFont(11, 1, true)));
            PdfPCell NoRelationCell =
                new PdfPCell(new Phrase(0, ConvertNumerals(" 2- لا يوجد "), font));
            CellOption(NoRelationCell, PaddingRight: 5);
            PdfPCell NoRelationMark =
                new PdfPCell(new Phrase(0, ConvertNumerals(NoRelation), CreateFont(11, 1, true)));
            AddCellToTable(Relation, new List<PdfPCell>{ Nullc, NoRelationMark, NoRelationCell, RelationMark,
                RelationParentCell });
            PdfPCell NullRow = new PdfPCell(new Phrase(0, ConvertNumerals(" "), font));
            PdfPTable PreviousBirths = new PdfPTable(7);
            float[] PreviousBirthswidths = { 0.25f, 0.07f, 0.9f, 0.07f, 0.7f, 0.07f, 1 };
            PreviousBirths.SetWidths(PreviousBirthswidths);
            PdfPCell AliveCell = new PdfPCell(new Phrase(0,
                ConvertNumerals(" عدد المواليد السابقة للأم عدا هذا الطفل : 1- الأحياء"), font));
            CellOption(AliveCell, PaddingRight: 5);
            PdfPCell AliveMark = new PdfPCell(new Phrase(0,
                ConvertNumerals(ConvertNumerals(BirthCertify.AliveBirth.ToString())), font));
            PdfPCell AliveThenDeathCell =
                new PdfPCell(new Phrase(0, ConvertNumerals(" 2- الأحياء ثم توفوا "), font));
            CellOption(AliveThenDeathCell, PaddingRight: 5);
            PdfPCell AliveThenDeathMark = new PdfPCell(new Phrase(0,
                ConvertNumerals(ConvertNumerals(BirthCertify.AliveThenDeath.ToString())), font));
            PdfPCell DeathCell =
                new PdfPCell(new Phrase(0, ConvertNumerals(" 3- الذين ولدوا أمواتاً "), font));
            CellOption(DeathCell, PaddingRight: 5);
            PdfPCell DeathMark = new PdfPCell(new Phrase(0,
                ConvertNumerals(ConvertNumerals(BirthCertify.DeathBirth.ToString())), font));
            PdfPCell BirthDisableCell =
                new PdfPCell(new Phrase(0, ConvertNumerals(" 4- الذين ولدوا معوقين"), font));
            CellOption(BirthDisableCell, PaddingRight: 5);
            PdfPCell BirthDisableMark = new PdfPCell(new Phrase(0,
                ConvertNumerals(ConvertNumerals(BirthCertify.BirthDisable.ToString())), font));
            PdfPCell ProjectionNumberCell =
                new PdfPCell(new Phrase(0, ConvertNumerals(" 5- عدد الإسقاطات إن وجدت "), font));
            CellOption(ProjectionNumberCell, PaddingRight: 5);
            PdfPCell ProjectionNumberMark = new PdfPCell(new Phrase(0,
                ConvertNumerals(ConvertNumerals(BirthCertify.ProjectionNumber.ToString())), font));
            PdfPCell DisableTypeCell = new PdfPCell(new Phrase(0,
                ConvertNumerals(" 6- هل الولادة الحالية معوقة؟ يحدد نوع العوق "), font));
            CellOption(DisableTypeCell, PaddingRight: 5);
            CellOption(NullRow, Colspan: 7);
            PdfPCell DisableTypeMark =
                new PdfPCell(new Phrase(0, ConvertNumerals(DisableType), font));
            CellOption(DisableTypeMark, Colspan: 2);
            AddCellToTable(PreviousBirths, new List<PdfPCell>{ Nullc, DeathMark, DeathCell, AliveThenDeathMark,
                AliveThenDeathCell, AliveMark, AliveCell, NullRow, DisableTypeMark, DisableTypeCell,
                ProjectionNumberMark, ProjectionNumberCell, BirthDisableMark, BirthDisableCell });
            string House = "", Hospital = "";
            if (BirthCertify.BirthPlace == "بيت")
                House = "";
            else if (BirthCertify.BirthPlace == "مستشفى")
                Hospital = "";
            PdfPTable BirthDetails = new PdfPTable(7);
            float[] BirthDetailswidths = { 0.15f, 0.1f, 0.4f, 0.1f, 0.7f, 1.1f, 1.1f };
            BirthDetails.SetWidths(BirthDetailswidths);
            PdfPCell LengthOfPregnancy = new PdfPCell(new Phrase(0,
                ConvertNumerals(" مدة الحمل : " + BirthCertify.LengthOfPregnancy), font));
            CellOption(LengthOfPregnancy, PaddingRight: 5);
            PdfPCell ChildWeight = new PdfPCell(new Phrase(0,
                ConvertNumerals(" وزن الطفل : " + BirthCertify.ChildWeight), font));
            CellOption(ChildWeight, PaddingRight: 5);
            PdfPCell BirthPlace =
                new PdfPCell(new Phrase(0, ConvertNumerals(" مكان الولادة : 1- بيت"), font));
            CellOption(BirthPlace, PaddingRight: 5);
            PdfPCell HouseMark =
                new PdfPCell(new Phrase(0, ConvertNumerals(House), CreateFont(11, 1, true)));
            PdfPCell HospitalCell = new PdfPCell(new Phrase(0, ConvertNumerals("2- مستشفى"), font));
            CellOption(HospitalCell, PaddingRight: 5);
            PdfPCell HospitalMark =
                new PdfPCell(new Phrase(0, ConvertNumerals(Hospital), CreateFont(11, 1, true)));
            AddCellToTable(BirthDetails, new List<PdfPCell>{ Nullc, HospitalMark, HospitalCell, HouseMark, BirthPlace,
                ChildWeight, LengthOfPregnancy });
            string Doctor = "", Nurse = "", BirthHelper = "", Other = "";
            if (BirthCertify.BirthBy == "طبيب")
                Doctor = "";
            else if (BirthCertify.BirthBy == "ممرضة مجازة بالتوليد")
                Nurse = "";
            else if (BirthCertify.BirthBy == "قابلة مجازة")
                BirthHelper = "";
            else if (BirthCertify.BirthBy == "اخرى")
                Other = "";
            PdfPTable BirthBy = new PdfPTable(9);
            float[] BirthBywidths = { 1, 0.1f, 0.3f, 0.1f, 0.3f, 0.1f, 0.6f, 0.1f, 0.8f };
            BirthBy.SetWidths(BirthBywidths);
            PdfPCell ByDoctorCell =
                new PdfPCell(new Phrase(0, ConvertNumerals(" حدثت الولادة بواسطة طبيب "), font));
            CellOption(ByDoctorCell, PaddingRight: 5);
            PdfPCell ByDoctorMark =
                new PdfPCell(new Phrase(0, ConvertNumerals(Doctor), CreateFont(11, 1, true)));
            PdfPCell ByNurseCell =
                new PdfPCell(new Phrase(0, ConvertNumerals("ممرضة مجازة بالتوليد"), font));
            CellOption(ByNurseCell, PaddingRight: 5);
            PdfPCell ByNurseMark =
                new PdfPCell(new Phrase(0, ConvertNumerals(Nurse), CreateFont(11, 1, true)));
            PdfPCell ByBirthHelperCell =
                new PdfPCell(new Phrase(0, ConvertNumerals("قابلة مجازة"), font));
            CellOption(ByBirthHelperCell, PaddingRight: 5);
            PdfPCell ByBirthHelperMark = new PdfPCell(new Phrase(0, ConvertNumerals(BirthHelper),
                CreateFont(11, 1, true)));
            PdfPCell OtherCell = new PdfPCell(new Phrase(0, ConvertNumerals("أخرى"), font));
            CellOption(OtherCell, PaddingRight: 5);
            PdfPCell ByOtherMark =
                new PdfPCell(new Phrase(0, ConvertNumerals(Other), CreateFont(11, 1, true)));
            AddCellToTable(BirthBy, new List<PdfPCell>{ Nullc, ByOtherMark, OtherCell, ByBirthHelperMark,
                ByBirthHelperCell, ByNurseMark, ByNurseCell, ByDoctorMark, ByDoctorCell });
            PdfPTable BirthAddress = new PdfPTable(5);
            float[] BirthAddresswidths = { 1, 1, 1, 1, 1.5f };
            BirthAddress.SetWidths(BirthAddresswidths);
            PdfPCell Province = new PdfPCell(new Phrase(0,
                ConvertNumerals("عنوان السكن : المحافظة : " + BirthCertify.BirthProvince), font));
            CellOption(Province, PaddingRight: 5);
            PdfPCell District = new PdfPCell(new Phrase(0,
                ConvertNumerals(" قضاء : " + BirthCertify.BirthDistrict), font));
            CellOption(District, PaddingRight: 5);
            PdfPCell Mahallah = new PdfPCell(new Phrase(0,
                ConvertNumerals(" محلة : " + BirthCertify.Mahallah), font));
            CellOption(Mahallah, PaddingRight: 5);
            PdfPCell AlleyNumber = new PdfPCell(new Phrase(0,
                ConvertNumerals(" زقاق : " + BirthCertify.AlleyNumber), font));
            CellOption(AlleyNumber, PaddingRight: 5);
            PdfPCell HouseNumber = new PdfPCell(new Phrase(0,
                ConvertNumerals(" دار : " + BirthCertify.HouseNumber), font));
            CellOption(HouseNumber, PaddingRight: 5);
            AddCellToTable(BirthAddress, new List<PdfPCell> { HouseNumber, AlleyNumber, Mahallah, District, Province });
            PdfPTable LobbyInfo = new PdfPTable(2);
            PdfPCell LobbyNumber = new PdfPCell(new Phrase(0,
                ConvertNumerals(" رقم ملف ركود الأم ( طبلة الأم ) : " /*+ BirthCertify.lobby*/),
                font));
            CellOption(LobbyNumber, PaddingRight: 5, PaddingBottom: 5);
            PdfPCell EnterDate = new PdfPCell(new Phrase(0,
                ConvertNumerals(" تاريخ الدخول : " /*+ BirthCertify.lobby*/), font));
            CellOption(EnterDate, PaddingRight: 5, PaddingBottom: 5);
            PdfPCell BirthHelperName = new PdfPCell(new Phrase(0,
                ConvertNumerals(" إسم القائم بالتوليد : " /*+ BirthCertify.lobby*/), font));
            CellOption(BirthHelperName, PaddingRight: 5, Colspan: 2);
            AddCellToTable(LobbyInfo, new List<PdfPCell> { EnterDate, LobbyNumber, BirthHelperName });
            PdfPTable MainTable = new PdfPTable(1);
            PdfPCell HealthDepartment = new PdfPCell(new Phrase(0,
                ConvertNumerals("دائرة صحة : " + BirthCertify.HealthDepartment), font));
            CellOption(HealthDepartment, PaddingRight: 5);
            PdfPCell BirthTypeCell = new PdfPCell(BirthTypeTable);
            CellOption(BirthTypeCell, PaddingBottom: 15);
            PdfPCell BirthInfoCell = new PdfPCell(BirthInfo);
            CellOption(BirthInfoCell, PaddingBottom: 15);
            PdfPCell BirthDateCell = new PdfPCell(BirthDate);
            CellOption(BirthDateCell, PaddingBottom: 15);
            PdfPCell ParentInfoCell = new PdfPCell(ParentInfo);
            CellOption(ParentInfoCell, PaddingBottom: 15);
            PdfPCell RelationCell = new PdfPCell(Relation);
            CellOption(RelationCell, PaddingBottom: 15);
            PdfPCell PreviousBirthsCell = new PdfPCell(PreviousBirths);
            CellOption(PreviousBirthsCell, PaddingBottom: 15);
            PdfPCell BirthDetailsCell = new PdfPCell(BirthDetails);
            CellOption(BirthDetailsCell, PaddingBottom: 15);
            PdfPCell BirthByCell = new PdfPCell(BirthBy);
            CellOption(BirthByCell, PaddingBottom: 15);
            PdfPCell BirthAddressCell = new PdfPCell(BirthAddress);
            CellOption(BirthAddressCell, PaddingBottom: 15);
            PdfPCell LobbyInfoCell = new PdfPCell(LobbyInfo);
            CellOption(LobbyInfoCell, PaddingBottom: 15);
            AddCellToTable(MainTable, new List<PdfPCell>{ HealthDepartment, BirthTypeCell, BirthInfoCell, BirthDateCell,
                ParentInfoCell, RelationCell, PreviousBirthsCell, BirthDetailsCell, BirthByCell,
                BirthAddressCell, LobbyInfoCell });
            document.Add(Title);
            PdfPCell MainCell = new PdfPCell(MainTable);
            AddCellToTable(Border, new List<PdfPCell> { MainCell });
            document.Add(Border);
            PdfPTable Signature = new PdfPTable(3);
            PdfPCell OrganizerName = new PdfPCell(new Phrase(0,
                ConvertNumerals(BirthCertify.OrganizerName + "\nإسم وتوقيع منظم التأييد"), font));
            CellOption(OrganizerName, PaddingRight: 5, PaddingTop: 15);
            PdfPCell Seal =
                new PdfPCell(new Phrase(0, ConvertNumerals("\nختم المؤسسة الصحية"), font));
            CellOption(Seal, 1, PaddingRight: 5, PaddingTop: 15);
            PdfPCell HallManager = new PdfPCell(new Phrase(0,
                ConvertNumerals( /*BirthCertify.OrganizerName +*/
                    "\nإسم وتوقيع مسئول صالة الولادة"), font));
            CellOption(HallManager, 2, PaddingRight: 5, PaddingBottom: 25, PaddingTop: 15);
            PdfPCell Notes = new PdfPCell(new Phrase(0,
                ConvertNumerals(
                    "ملاحظة : \n\n      1- على ولي أمر المولود مراجعة المستشفى خلال مدة أقصاها 15 يوم من تاريخ الولادة وجلب المستمسكات الرسمية ( هوية الأحوال المدنية للأب و الأم  ) \n           لغرض إعداد شهادة الولادة .          \n\n      2-" +
                    "لا يعتبر هذا التأييد بديلاً عن شهادة الولادة الرسمية"), font));
            CellOption(Notes, 0, PaddingRight: 5, PaddingTop: 55, Colspan: 3, PaddingBottom: 35);
            PdfPCell StakeholderCopy =
                new PdfPCell(new Phrase(0, ConvertNumerals("نسخة ذوي العلاقة"), font));
            CellOption(StakeholderCopy, PaddingRight: 5, PaddingTop: 150, Colspan: 2);
            PdfPCell HealthInstitutionCopy =
                new PdfPCell(new Phrase(0, ConvertNumerals("نسخة المؤسسة الصحية"), font));
            CellOption(HealthInstitutionCopy, 2, PaddingRight: 5, PaddingTop: 150);
            AddCellToTable(Signature, new List<PdfPCell>{ HallManager, Seal, OrganizerName, Notes,
                HealthInstitutionCopy, StakeholderCopy });
            document.Add(Signature);
            document.Close();
            var byteInfo = m.ToArray();
            m.Write(byteInfo, 0, byteInfo.Length);
            m.Position = 0;
            return new FileStreamResult(m, "application/pdf");
        }
        public static FileStreamResult CreateBirthCertifiedRatification(CertifiedInfo certifiedInfo)
        {
            MemoryStream m = new MemoryStream();
            var document = new Document(PageSize.A4, 20, 20, 10, 10);
            PdfWriter.GetInstance(document, m).CloseStream = false;
            document.Open();
            PdfPTable Title = new PdfPTable(3);
            PdfPCell HealthDepartment = new PdfPCell(new Phrase(0, "وزارة الصحة\n\nدائرة التخطيط و تنمية الموارد\n\nقسم الإحصاء الصحي والحياتي", CreateFont(12, 1)));
            CellOption(HealthDepartment, 1, 5, 1, 1, 5);
            PdfPCell ConstraintImage = new PdfPCell(new Phrase(0, "صورة قيد ولادة\n\nط 1", CreateFont(12, 1)));
            CellOption(ConstraintImage, 1, 5, 1, 1, 5);
            PdfPCell CertifyInfo = new PdfPCell(new Phrase(0, "رقم الشهادة الأصلية : " + certifiedInfo.Id + "\n\nتاريخ تنظيمها : " + certifiedInfo.OrginazationDate.ToString("dd/MM/yyyy"), CreateFont(12, 1)));
            CellOption(CertifyInfo, 1);
            AddCellToTable(Title, new List<PdfPCell> { CertifyInfo, ConstraintImage, HealthDepartment });
            PdfPTable Address = new PdfPTable(2);
            PdfPCell confirm = new PdfPCell(new Phrase(0, "\n\nإلى / " + certifiedInfo.To + "\n\n\n نؤيد لكم بأن الولادة المسجلة أوصافها أدناه قد سجلت لدينا في سجل الولادات ", CreateFont(12, 1)));
            CellOption(confirm, 0, 30, 2, 1, 5);
            PdfPCell Sequence = new PdfPCell(new Phrase(0, "\n\nتحت تسلسل : " + certifiedInfo.Sequence, CreateFont(12, 1)));
            CellOption(Sequence, 0, 30);
            PdfPCell ForYear = new PdfPCell(new Phrase(0, "\n\nلسنة : " + certifiedInfo.Year, CreateFont(12, 1)));
            CellOption(ForYear, 0, 30);
            AddCellToTable(Address, new List<PdfPCell> { confirm, ForYear, Sequence});
            PdfPTable BirthInfo = new PdfPTable(3);
            float[] BirthInfoWidth = new float[] { 1f, 1f, 1.5f };
            BirthInfo.SetWidths(BirthInfoWidth);
            PdfPCell BirthName = new PdfPCell(new Phrase(0, "\n\nإسم المولود : " + certifiedInfo.BirthName, CreateFont(12, 1)));
            CellOption(BirthName, 0, 30);
            PdfPCell Gender = new PdfPCell(new Phrase(0, "\n\nالجنس : " + certifiedInfo.Gender, CreateFont(12, 1)));
            CellOption(Gender, 0, 30, 2);
            PdfPCell FatherName = new PdfPCell(new Phrase(0, "\n\nإسم الأب : " + certifiedInfo.FatherName, CreateFont(12, 1)));
            CellOption(FatherName, 0, 30);
            PdfPCell FatherReligion = new PdfPCell(new Phrase(0, "\n\nألديانة : " + certifiedInfo.FatherReligion, CreateFont(12, 1)));
            CellOption(FatherReligion, 0, 30);
            PdfPCell FatherNationality = new PdfPCell(new Phrase(0, "\n\nجنسية الأب : " + certifiedInfo.FatherNationality, CreateFont(12, 1)));
            CellOption(FatherNationality, 0, 30);
            PdfPCell MotherName = new PdfPCell(new Phrase(0, "\n\nإسم الأم : " + certifiedInfo.MotherName, CreateFont(12, 1)));
            CellOption(MotherName, 0, 30);
            PdfPCell MotherReligion = new PdfPCell(new Phrase(0, "\n\nألديانة : " + certifiedInfo.MotherReligion, CreateFont(12, 1)));
            CellOption(MotherReligion, 0, 30);
            PdfPCell MotherNationality = new PdfPCell(new Phrase(0, "\n\nجنسية الأم : " + certifiedInfo.MotherNationality, CreateFont(12, 1)));
            CellOption(MotherNationality, 0, 30);
            PdfPCell NumericBirthDate = new PdfPCell(new Phrase(0, "\n\nتاريخ الولادة رقماً  : " + certifiedInfo.BirthDate.ToString("dd/MM/yyyy"), CreateFont(12, 1)));
            CellOption(NumericBirthDate, 0, 30, 3);
            PdfPCell WritingBirthDate = new PdfPCell(new Phrase(0, "\n\nتاريخ الولادة كتابةً  : " + Convert(certifiedInfo.BirthDate.Year.ToString())
                                                                   + " الشهر " + Convert(certifiedInfo.BirthDate.Month.ToString(), month: true) + " يوم "
                                                                   + certifiedInfo.BirthDate.ToString("dddd", new CultureInfo("ar-AE")), CreateFont(12, 1)));
            CellOption(WritingBirthDate, 0, 30, 3);
            AddCellToTable(BirthInfo, new List<PdfPCell>{ Gender, BirthName, FatherNationality, FatherReligion, FatherName
                , MotherNationality, MotherReligion, MotherName, NumericBirthDate, WritingBirthDate });
            string HouseS = "", HospitalS = "", OtherS = "";
            if (certifiedInfo.BirthPlace == "بيت") HouseS = "";
            else if (certifiedInfo.BirthPlace == "مستشفى") HospitalS = "";
            else if (certifiedInfo.BirthPlace == "أخرى") OtherS = "";
            PdfPTable BirthPlace = new PdfPTable(6);
            float[] BirthPlaceWidth = new float[] { 0.5f, 1f, 0.5f, 1f, 0.5f, 1.5f };
            BirthPlace.SetWidths(BirthPlaceWidth);
            PdfPCell House = new PdfPCell(new Phrase(0, "\n\n محل وقوع الولادة :        بيت ", CreateFont(12, 1)));
            CellOption(House, 0, 30);
            PdfPCell HouseMark = new PdfPCell(new Phrase(0, "\n\n" + HouseS, CreateFont(12, 0, true)));
            CellOption(HouseMark, 0, 30);
            PdfPCell BirthHospital = new PdfPCell(new Phrase(0, "\n\n مستشفى ", CreateFont(12, 1)));
            CellOption(BirthHospital, 0, 30);
            PdfPCell HospitalMark = new PdfPCell(new Phrase(0, "\n\n" + HospitalS, CreateFont(12, 0, true)));
            CellOption(HospitalMark, 0, 30);
            PdfPCell Other = new PdfPCell(new Phrase(0, "\n\n أخرى ", CreateFont(12, 1)));
            CellOption(Other, 0, 30);
            PdfPCell OtherMark = new PdfPCell(new Phrase(0, "\n\n" + OtherS, CreateFont(12, 0, true)));
            CellOption(OtherMark, 0, 30);
            PdfPCell InformerName = new PdfPCell(new Phrase(0, "\n\n إسم المخبر عن الولادة :  " + certifiedInfo.InformerName, CreateFont(12, 1)));
            CellOption(InformerName, 0, 30, 6);
            PdfPCell NationalityName = new PdfPCell(new Phrase(0, "\n\n معلومات خاصة بمديرية الجنسية و الأحوال المدنية : ", CreateFont(12, 1)));
            CellOption(NationalityName, 0, 30, 2);
            PdfPCell RecordNumber = new PdfPCell(new Phrase(0, "\n\nرقم السجل : " + certifiedInfo.RecordNumber, CreateFont(12, 1)));
            CellOption(RecordNumber, PaddingRight: 30, Colspan: 2);
            PdfPCell PageNumber = new PdfPCell(new Phrase(0, "\n\n رقم الصفحة : " + certifiedInfo.PageNumber, CreateFont(12, 1)));
            CellOption(PageNumber, 0, 50, 2);
            //  PdfPCell IdentifierNo = new PdfPCell(new Phrase(0, "\n\n رقم البطاقة الوطنية : " + certifiedInfo.NationalityNumber, CreateFont(12, 1)));
            //  CellOption(IdentifierNo, 0, 40, 4);
            // PdfPCell PassBoardNumber = new PdfPCell(new Phrase(0, "\n\n رقم الجواز : " /*+ DeathCertify.PassBoardNumber*/, CreateFont(12, 1)));
            // CellOption(PassBoardNumber, 0, 40, 4);
            PdfPCell NationalityDepartment = new PdfPCell(new Phrase(0, "\n\n دائرة جنسية و أحوال : " + certifiedInfo.NationalDepartment, CreateFont(12, 1)));
            CellOption(NationalityDepartment, 2, 0, 3, 1, 0, 25);
            PdfPCell NationalityProvince = new PdfPCell(new Phrase(0, "\n\n محافظة : " + certifiedInfo.NationalProvince, CreateFont(12, 1)));
            CellOption(NationalityProvince, 0, 40, 3);
            PdfPCell OrganizerName = new PdfPCell(new Phrase(0, "\n\n إسم المنظم" + " " + certifiedInfo.OrganizerName + "\n\n\nالتوقيع : ", CreateFont(12, 1)));
            CellOption(OrganizerName, 0, 30, 2);
            PdfPCell DoctorName = new PdfPCell(new Phrase(0, "\n\n إسم الدكتور" + " " + certifiedInfo.DoctorName + "\n\n\nالتوقيع : ", CreateFont(12, 1)));
            CellOption(DoctorName, 0, 5, 4);
            // if()
            //   AddCellToTable(BirthPlace, OtherMark, Other, HospitalMark, BirthHospital, HouseMark, House, InformerName, PassBoardNumber, NationalityName, NationalityProvince, NationalityDepartment, DoctorName, OrganizerName);
            //   if (NationalityType == 1)
            AddCellToTable(BirthPlace, new List<PdfPCell> { OtherMark, Other, HospitalMark, BirthHospital, HouseMark, House, InformerName, PageNumber, RecordNumber, NationalityName, NationalityProvince, NationalityDepartment, DoctorName, OrganizerName });
            //   if (NationalityType == 2)
            //       AddCellToTable(BirthPlace, OtherMark, Other, HospitalMark, BirthHospital, HouseMark, House, InformerName, IdentifierNo, NationalityName, NationalityProvince, NationalityDepartment, DoctorName, OrganizerName);

            document.Add(Title);
            document.Add(Address);
            document.Add(BirthInfo);
            document.Add(BirthPlace);
            document.Add(new Paragraph("\n"));
            document.Close();
            byte[] byteInfo = m.ToArray();
            m.Write(byteInfo, 0, byteInfo.Length);
            m.Position = 0;
            return new FileStreamResult(m, "application/pdf");
        }
        public static PdfPTable DeathTitle(DeathCertified DeathCertify)
        {
            PdfPTable title = new PdfPTable(3)
            {
                WidthPercentage = 104f
            };
            float[] titlewidths = new float[] { 1.2f, 1, 1 };
            title.SetWidths(titlewidths);
            PdfPCell RepublicOfIraq = new PdfPCell(new Phrase(0, "جمهورية العراق", CreateFont()));
            CellOption(RepublicOfIraq, 0, 5, 3, 1, 5f);
            PdfPTable ProvinceTable = new PdfPTable(2);
            PdfPCell ProvinceCell = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("محافظة :  ")), CreateFont()));
            CellOption(ProvinceCell, 0, 5);
            PdfPCell Province = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(DeathCertify.CertificateProvince)), CreateFont(12, 1, false, false, true)));
            CellOption(Province, 0, -80);
            AddCellToTable(ProvinceTable, new List<PdfPCell> { Province, ProvinceCell });
            PdfPCell ProvinceTableCell = new PdfPCell(ProvinceTable);
            CellOption(ProvinceTableCell);
            PdfPTable HealthDepartmentTable = new PdfPTable(2);
            PdfPCell HealthDepartmentCell = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("دائرة صحة : " + " ")), CreateFont()));
            CellOption(HealthDepartmentCell, 0, 5, 1, 1, 5);
            PdfPCell HealthDepartment = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(DeathCertify.CertificateDepartment)), CreateFont(12, 1, false, false, true)));
            CellOption(HealthDepartment, 0, -65, 1, 1, 5);
            AddCellToTable(HealthDepartmentTable, new List<PdfPCell> { HealthDepartment, HealthDepartmentCell });
            PdfPCell HealthDepartmentTableCell = new PdfPCell(HealthDepartmentTable);
            CellOption(HealthDepartmentTableCell);
            PdfPCell DeathCertified = new PdfPCell(new Phrase(0, "شهادة وفاة", CreateFont(20, 1)));
            CellOption(DeathCertified, 1, 0, 1, 2);
            PdfPTable CertifyNumberTable = new PdfPTable(2);
            PdfPCell CertifyNumberCell = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("رقم الشهادة :  ")), CreateFont()));
            CellOption(CertifyNumberCell, 0, 63, 1, 1, 5);
            PdfPCell CertifyNumber = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(DeathCertify.CertificateNo.ToString())), CreateFont(12, 1, false, false, true)));
            CellOption(CertifyNumber, 0, -35, 1, 1, 5);
            AddCellToTable(CertifyNumberTable, new List<PdfPCell> { CertifyNumber, CertifyNumberCell });
            PdfPCell CertifyNumberTableCell = new PdfPCell(CertifyNumberTable);
            CellOption(CertifyNumberTableCell);
            PdfPTable OrginizeDateTable = new PdfPTable(4);
            float[] OrginizeDateTablewidths = new float[] { 1.1f, 0.8f, 1f, 1.8f };
            OrginizeDateTable.SetWidths(OrginizeDateTablewidths);
            PdfPCell DateCell = new PdfPCell(new Phrase(0, "تاريخ التنظيم : ", CreateFont()));
            CellOption(DateCell, 1, 62, 1, 1, 10);
            PdfPCell DateValue = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(DeathCertify.IssueDatetime.ToString("MM/dd/yyyy"))), CreateFont(12, 1, false, false, true)));
            CellOption(DateValue, 1, 5, 1, 1, 10);
            PdfPCell HourCell = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("الساعة : ")), CreateFont()));
            CellOption(HourCell, 1, 5, 1, 1, 10);
            PdfPCell HourValue = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(DeathCertify.IssueDatetime.ToString("hh:mm:ss tt", new CultureInfo("ar-AE")))), CreateFont(12, 1, false, false, true)));
            CellOption(HourValue, 1, -5, 1, 1, 10);
            AddCellToTable(OrginizeDateTable, new List<PdfPCell> { HourValue, HourCell, DateValue, DateCell });
            PdfPCell OrginizeDateTableCell = new PdfPCell(OrginizeDateTable);
            CellOption(OrginizeDateTableCell);
            AddCellToTable(title, new List<PdfPCell> { RepublicOfIraq, CertifyNumberTableCell, DeathCertified, ProvinceTableCell, OrginizeDateTableCell, HealthDepartmentTableCell });
            return title;
        }
        public static PdfPTable DeathRotateTable(DeathCertified DeathCertify)
        {
            PdfPTable RotateTable = new PdfPTable(4);
            float[] RotateTablewidths = new float[] { 1f, 3f, 0.9f, 0.2f };
            RotateTable.SetWidths(RotateTablewidths);
            PdfPCell rectangle = new PdfPCell();
            CellOption(rectangle, 0, 0, 1, 6);
            PdfPCell Nullc = new PdfPCell(new Phrase(0, " ", CreateFont()));
            CellOption(Nullc, 0, 0, 4, 1);
            PdfPCell record = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("سجلت لدى السلطات الصحية في" + " " /*+ DeathCertify.RegisteredDepartment + " " + DeathCertify.RegisteredHospital*/)), CreateFont()));
            CellOption(record, 0, 50, 2, 1, 0, 0, 10);
            PdfPCell sequence = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("تحت تسلسل : " + " " /*+ DeathCertify.RegisteredNo*/)), CreateFont()));
            CellOption(sequence, 1, 55, 3);
            PdfPCell Seal = new PdfPCell(new Phrase(0, "الختم" + " ", CreateFont()));
            CellOption(Seal, 1, 0, 1, 1, 0, 25);
            PdfPCell ForYear = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("لسنة : " + " " /*+ DeathCertify.RegisteredYear*/)), CreateFont()));
            CellOption(ForYear, 1, 45, 3, 1, 15f);
            PdfPCell Signature = new PdfPCell(new Phrase(0, "و التوقيع" + " ", CreateFont()));
            CellOption(Signature, 1, 0, 1, 1, 0, 15f);
            AddCellToTable(RotateTable, new List<PdfPCell> { record, rectangle, Nullc, Seal, sequence, Signature, ForYear });
            return RotateTable;
        }
        public static PdfPTable DeathFullName1To8(DeathCertified DeathCertify)
        {
            PdfPTable DeathFullName = new PdfPTable(4);
            float[] DeathFullNamewidths = new float[] { 1.5f, 1, 1, 1 };
            DeathFullName.SetWidths(DeathFullNamewidths);
            PdfPTable DeathNameTable = new PdfPTable(2);
            PdfPCell DeathNameCell = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("1- إسم المتوفي :  ")), CreateFont()));
            CellOption(DeathNameCell, 0, 5, 1, 1, 5f, 5f, 5f, 0.5f);
            PdfPCell DeathName = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(DeathCertify.FirstName)), CreateFont(12, 1, false, false, true)));
            CellOption(DeathName, 0, -5, 1, 1, 5f, 5f, 5f);
            AddCellToTable(DeathNameTable, new List<PdfPCell> { DeathName, DeathNameCell });
            PdfPCell DeathNameTableCell = new PdfPCell(DeathNameTable);
            CellOption(DeathNameTableCell);
            PdfPTable DeathFatherNameTable = new PdfPTable(2);
            float[] DeathFatherNameTablewidths = new float[] { 1, 2 };
            DeathFatherNameTable.SetWidths(DeathFatherNameTablewidths);
            PdfPCell DeathFatherNameCell = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("2-  إسم والد المتوفي : ")), CreateFont()));
            CellOption(DeathFatherNameCell, 0, 5, 1, 1, 5f, 5f, 5f, 0.5f);
            PdfPCell DeathFatherName = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(DeathCertify.SecondName)), CreateFont(12, 1, false, false, true)));
            CellOption(DeathFatherName, 0, -10, 1, 1, 5f, 5f, 5f);
            AddCellToTable(DeathFatherNameTable, new List<PdfPCell> { DeathFatherName, DeathFatherNameCell });
            PdfPCell DeathFatherNameTableCell = new PdfPCell(DeathFatherNameTable);
            PdfPTable DeathGrandFatherNameTable = new PdfPTable(2);
            float[] DeathGrandFatherNameTablewidths = new float[] { 1, 2 };
            DeathGrandFatherNameTable.SetWidths(DeathGrandFatherNameTablewidths);
            PdfPCell DeathGrandFatherNameCell = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("3-  إسم جد المتوفي : ")), CreateFont()));
            CellOption(DeathGrandFatherNameCell, 0, 5, 1, 1, 5f, 5f, 5f, 0.5f);
            PdfPCell DeathGrandFatherName = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(DeathCertify.ThirdName)), CreateFont(12, 1, false, false, true)));
            CellOption(DeathGrandFatherName, 0, -13, 1, 1, 5f, 5f, 5f);
            AddCellToTable(DeathGrandFatherNameTable, new List<PdfPCell> { DeathGrandFatherName, DeathGrandFatherNameCell });
            PdfPCell DeathGrandFatherNameTableCell = new PdfPCell(DeathGrandFatherNameTable);
            PdfPTable DeathMotherNameTable = new PdfPTable(2);
            PdfPCell DeathMotherNameCell = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("4-  إسم والدة المتوفي : ")), CreateFont()));
            CellOption(DeathMotherNameCell, 0, 5, 1, 1, 5f, 5f, 5f, 0.5f);
            PdfPCell DeathMotherName = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(DeathCertify.MotherFirstName + " " + DeathCertify.MotherSecondName + " " + DeathCertify.MotherThirdName)), CreateFont(12, 1, false, false, true)));
            CellOption(DeathMotherName, 0, -18, 1, 1, 5f, 5f, 5f);
            AddCellToTable(DeathMotherNameTable, new List<PdfPCell> { DeathMotherName, DeathMotherNameCell });
            PdfPCell DeathMotherNameTableCell = new PdfPCell(DeathMotherNameTable);
            PdfPTable DeathGenderTable = new PdfPTable(2);
            PdfPCell DeathGenderCell = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("5- الجنس : ")), CreateFont()));
            CellOption(DeathGenderCell, 0, 5, 1, 1, 5f, 5f, 5f, 0.5f);
            PdfPCell DeathGender = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(DeathCertify.Gender)), CreateFont(12, 1, false, false, true)));
            CellOption(DeathGender, 0, -22, 1, 1, 5f, 5f, 5f);
            AddCellToTable(DeathGenderTable, new List<PdfPCell> { DeathGender, DeathGenderCell });
            PdfPCell DeathGenderTableCell = new PdfPCell(DeathGenderTable);
            PdfPTable DeathNationalityTable = new PdfPTable(2);
            PdfPCell DeathNationalityCell = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("6- الجنسية : ")), CreateFont()));
            CellOption(DeathNationalityCell, 0, 5, 1, 1, 5f, 5f, 5f, 0.5f);
            PdfPCell DeathNationality = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(DeathCertify.Nationality)), CreateFont(12, 1, false, false, true)));
            CellOption(DeathNationality, 0, -20, 1, 1, 5f, 5f, 5f);
            AddCellToTable(DeathNationalityTable, new List<PdfPCell> { DeathNationality, DeathNationalityCell });
            PdfPCell DeathNationalityTableCell = new PdfPCell(DeathNationalityTable);
            PdfPTable DeathReligionTable = new PdfPTable(2);
            PdfPCell DeathReligionCell = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("7- الديانة : ")), CreateFont()));
            CellOption(DeathReligionCell, 0, 5, 1, 1, 5f, 5f, 5f, 0.5f);
            PdfPCell DeathReligion = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(DeathCertify.Religion)), CreateFont(12, 1, false, false, true)));
            CellOption(DeathReligion, 0, -25, 1, 1, 5f, 5f, 5f);
            AddCellToTable(DeathReligionTable, new List<PdfPCell> { DeathReligion, DeathReligionCell });
            PdfPCell DeathReligionTableCell = new PdfPCell(DeathReligionTable);
            PdfPTable DeathProfessionTable = new PdfPTable(2);
            PdfPCell DeathProfessionCell = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("8- المهنة : ")), CreateFont()));
            CellOption(DeathProfessionCell, 0, 5, 1, 1, 5f, 5f, 5f, 0.5f);
            PdfPCell DeathProfession = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(DeathCertify.Occupation)), CreateFont(12, 1, false, false, true)));
            CellOption(DeathProfession, 0, -65, 1, 1, 5f, 5f, 5f);
            AddCellToTable(DeathProfessionTable, new List<PdfPCell> { DeathProfession, DeathProfessionCell });
            PdfPCell DeathProfessionTableCell = new PdfPCell(DeathProfessionTable);
            AddCellToTable(DeathFullName, new List<PdfPCell> { DeathMotherNameTableCell, DeathGrandFatherNameTableCell, DeathFatherNameTableCell, DeathNameTableCell, DeathProfessionTableCell, DeathReligionTableCell, DeathNationalityTableCell, DeathGenderTableCell });
            return DeathFullName;
        }
        public static PdfPTable DeathMaritalStatusText9(DeathCertified DeathCertify)
        {
            string MaritalStatus1 = "", MaritalStatus2 = "", MaritalStatus3 = "", MaritalStatus4 = "";
            if (DeathCertify.RelationID == 1)
            { MaritalStatus1 = ""; }
            else if (DeathCertify.RelationID == 2)
            { MaritalStatus2 = ""; }
            else if (DeathCertify.RelationID == 3)
            { MaritalStatus3 = ""; }
            else if (DeathCertify.RelationID == 4)
            { MaritalStatus4 = ""; }
            PdfPTable MaritalStatusText = new PdfPTable(8);
            float[] MaritalStatusTextwidths = new float[] { 0.4f, 1f, 0.4f, 1f, 0.4f, 1f, 0.4f, 3.2f };
            MaritalStatusText.SetWidths(MaritalStatusTextwidths);
            PdfPCell MaritalStatusTextc = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("9- " + "الحالة الزوجية :" + " " + "أعزب")), CreateFont()));
            CellOption(MaritalStatusTextc, 0, 5, 1, 1, 5f, 5f, 0.5f);
            PdfPCell MaritalStatusTextc1 = new PdfPCell(new Phrase(0, MaritalStatus1, CreateFont(12, 0, true, false, true)));
            CellOption(MaritalStatusTextc1, 1, 5, 1, 1, 5f, 5f);
            PdfPCell MaritalStatusTextc2 = new PdfPCell(new Phrase(0, " " + "متزوج", CreateFont()));
            CellOption(MaritalStatusTextc2, 0, 5, 1, 1, 5f, 5f, -12);
            PdfPCell MaritalStatusTextc3 = new PdfPCell(new Phrase(0, MaritalStatus2, CreateFont(12, 0, true, false, true)));
            CellOption(MaritalStatusTextc3, 1, 5, 1, 1, 5f, 5f);
            PdfPCell MaritalStatusTextc4 = new PdfPCell(new Phrase(0, " " + "أرمل", CreateFont()));
            CellOption(MaritalStatusTextc4, 0, 5, 1, 1, 5f, 5f);
            PdfPCell MaritalStatusTextc5 = new PdfPCell(new Phrase(0, MaritalStatus3, CreateFont(12, 0, true, false, true)));
            CellOption(MaritalStatusTextc5, 0, 5, 1, 1, 5f, 5f);
            PdfPCell MaritalStatusTextc6 = new PdfPCell(new Phrase(0, " " + "مطلق", CreateFont()));
            CellOption(MaritalStatusTextc6, 0, 5, 1, 1, 5f, 5f);
            PdfPCell MaritalStatusTextc7 = new PdfPCell(new Phrase(0, MaritalStatus4 + " ", CreateFont(12, 0, true, false, true)));
            CellOption(MaritalStatusTextc7, 0, 5, 1, 1, 5f, 5f);
            AddCellToTable(MaritalStatusText, new List<PdfPCell> { MaritalStatusTextc7, MaritalStatusTextc6, MaritalStatusTextc5, MaritalStatusTextc4, MaritalStatusTextc3, MaritalStatusTextc2, MaritalStatusTextc1, MaritalStatusTextc });
            return MaritalStatusText;
        }
        public static PdfPTable DeathBirthDateTable10(DeathCertified DeathCertify)
        {
            PdfPTable DeathBirthDateTable = new PdfPTable(2);
            PdfPCell DeathBirthDateCell = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("10- تاريخ الولادة : ")), CreateFont()));
            CellOption(DeathBirthDateCell, 0, 5, 1, 1, 5f, 5f, 0f, 0.5f);
            PdfPCell DeathBirthDate = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(DeathCertify.Birthdate.ToString("MM/dd/yyyy"))), CreateFont(12, 1, false, false, true)));
            CellOption(DeathBirthDate, 0, -5, 1, 1, 5f, 5f, 0f);
            AddCellToTable(DeathBirthDateTable, new List<PdfPCell> { DeathBirthDate, DeathBirthDateCell });
            return DeathBirthDateTable;
        }
        public static PdfPTable DeathBirthplaceTable11(DeathCertified DeathCertify)
        {
            PdfPTable BirthplaceTable = new PdfPTable(4);
            float[] BirthplaceTablewidths = new float[] { 1, 1, 1, 2.7f };
            BirthplaceTable.SetWidths(BirthplaceTablewidths);
            PdfPCell BirthPlaceDistrict = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("11-  محل الولادة : قضاء : ")), CreateFont()));
            CellOption(BirthPlaceDistrict);
            PdfPCell BirthPlaceDistrictValue = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(DeathCertify.BornCounty)), CreateFont(12, 1, false, false, true)));
            CellOption(BirthPlaceDistrictValue, PaddingRight: 5);
            PdfPCell BirthPlaceProvince = new PdfPCell(new Phrase(0, " محافظة : ", CreateFont()));
            CellOption(BirthPlaceProvince);
            PdfPCell BirthPlaceProvinceValue = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(DeathCertify.BornProvince)), CreateFont(12, 1, false, false, true)));
            CellOption(BirthPlaceProvinceValue, PaddingRight: 5);
            AddCellToTable(BirthplaceTable, new List<PdfPCell> { BirthPlaceProvinceValue, BirthPlaceProvince, BirthPlaceDistrictValue, BirthPlaceDistrict });
            return BirthplaceTable;
        }
        public static PdfPTable DeathpermanentResidenceTextTable12(DeathCertified DeathCertify)
        {
            PdfPTable permanentResidenceTextTable = new PdfPTable(6);
            float[] permanentResidenceTextTablewidths = new float[] { 0.5f, 1.2f, 0.8f, 0.5f, 1.2f, 1.8f };
            permanentResidenceTextTable.SetWidths(permanentResidenceTextTablewidths);
            PdfPCell permanentResidenceHouse = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("12- : إقامته الدائمة : رقم الدار  ")), CreateFont()));
            CellOption(permanentResidenceHouse);
            PdfPCell permanentResidenceHouseValue = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(DeathCertify.PermanentHouseNo)), CreateFont(12, 1, false, false, true)));
            CellOption(permanentResidenceHouseValue, PaddingRight: -10);
            PdfPCell permanentResidenceAlley = new PdfPCell(new Phrase(0, "الزقاق: ", CreateFont()));
            CellOption(permanentResidenceAlley);
            PdfPCell permanentResidenceAlleyValue = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(DeathCertify.PermanentAlley)), CreateFont(12, 1, false, false, true)));
            CellOption(permanentResidenceAlleyValue, PaddingRight: -3);
            PdfPCell permanentResidenceVillage = new PdfPCell(new Phrase(0, "المحلة أو القرية : ", CreateFont()));
            CellOption(permanentResidenceVillage);
            PdfPCell permanentResidenceVillageValue = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(DeathCertify.PermanentVillage)), CreateFont(12, 1, false, false, true)));
            CellOption(permanentResidenceVillageValue, PaddingRight: -15);
            PdfPCell permanentResidenceTownship = new PdfPCell(new Phrase(0, "ناحية : ", CreateFont()));
            CellOption(permanentResidenceTownship, PaddingTop: 5);
            PdfPCell permanentResidenceTownshipValue = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(DeathCertify.PermanentTownship)), CreateFont(12, 1, false, false, true)));
            CellOption(permanentResidenceTownshipValue, PaddingTop: 5, PaddingRight: -100);
            PdfPCell permanentResidencePermanentCounty = new PdfPCell(new Phrase(0, "قضاء : ", CreateFont()));
            CellOption(permanentResidencePermanentCounty, PaddingTop: 5);
            PdfPCell permanentResidencePermanentCountyValue = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(DeathCertify.PermanentCounty)), CreateFont(12, 1, false, false, true)));
            CellOption(permanentResidencePermanentCountyValue, PaddingTop: 5, PaddingRight: -5);
            PdfPCell permanentResidencePermanentProvince = new PdfPCell(new Phrase(0, "محافظة : ", CreateFont()));
            CellOption(permanentResidencePermanentProvince, PaddingTop: 5);
            PdfPCell permanentResidencePermanentProvinceValue = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(DeathCertify.PermanentProvince)), CreateFont(12, 1, false, false, true)));
            CellOption(permanentResidencePermanentProvinceValue, PaddingTop: 5, PaddingRight: -50);
            AddCellToTable(permanentResidenceTextTable, new List<PdfPCell> { permanentResidenceVillageValue, permanentResidenceVillage, permanentResidenceAlleyValue, permanentResidenceAlley, permanentResidenceHouseValue, permanentResidenceHouse, permanentResidencePermanentProvinceValue, permanentResidencePermanentProvince, permanentResidencePermanentCountyValue, permanentResidencePermanentCounty, permanentResidenceTownshipValue, permanentResidenceTownship });
            return permanentResidenceTextTable;
        }
        public static PdfPTable DeathPlace13(DeathCertified DeathCertify)
        {
            PdfPTable DeathPlace = new PdfPTable(1);
            PdfPCell DeathPlaceText = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("13- " + " محل الوفاة")), CreateFont()));
            CellOption(DeathPlaceText, 0, 5, 1, 1, 5f);
            PdfPTable DeathPlaceTable = new PdfPTable(4);
            float[] DeathPlaceTablewidths = new float[] { 2.3f, 1f, 1.7f, 2f };
            DeathPlaceTable.SetWidths(DeathPlaceTablewidths);
            PdfPCell DeathvillageCell = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(" المحلة أو القرية : ")), CreateFont()));
            CellOption(DeathvillageCell);
            PdfPCell DeathvillageCellValue = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(DeathCertify.DeathVillage)), CreateFont(12, 1, false, false, true)));
            CellOption(DeathvillageCellValue);
            PdfPCell DeathTownShip = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("الناحية : ")), CreateFont()));
            CellOption(DeathTownShip);
            PdfPCell DeathTownShipValue = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(DeathCertify.DeathTownship)), CreateFont(12, 1, false, false, true)));
            CellOption(DeathTownShipValue);
            PdfPTable CountryAndProvince = new PdfPTable(4);
            float[] CountryAndProvincewidths = new float[] { 2, 1, 2, 1f };
            CountryAndProvince.SetWidths(CountryAndProvincewidths);
            PdfPCell DeathCounty = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("قضاء : ")), CreateFont()));
            CellOption(DeathCounty, PaddingTop: 5);
            PdfPCell DeathCountyValue = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(DeathCertify.DeathCounty)), CreateFont(12, 1, false, false, true)));
            CellOption(DeathCountyValue, PaddingTop: 5, PaddingRight: -10);
            PdfPCell DeathProvince = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("محافظة : ")), CreateFont()));
            CellOption(DeathProvince, PaddingTop: 5);
            PdfPCell DeathProvinceValue = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(DeathCertify.DeathProvince)), CreateFont(12, 1, false, false, true)));
            CellOption(DeathProvinceValue, PaddingTop: 5, PaddingRight: 5);
            AddCellToTable(CountryAndProvince, new List<PdfPCell> { DeathProvinceValue, DeathProvince, DeathCountyValue, DeathCounty });
            PdfPCell CountryAndProvinceCell = new PdfPCell(CountryAndProvince);
            CellOption(CountryAndProvinceCell, Colspan: 4);
            AddCellToTable(DeathPlaceTable, new List<PdfPCell> { DeathTownShipValue, DeathTownShip, DeathvillageCellValue, DeathvillageCell, CountryAndProvinceCell });
            PdfPCell Deathvillage = new PdfPCell(DeathPlaceTable);
            CellOption(Deathvillage, 0, 5, 1, 1, 5);
            AddCellToTable(DeathPlace, new List<PdfPCell> { DeathPlaceText, Deathvillage });
            return DeathPlace;
        }
        public static PdfPTable DeathDateTable14(DeathCertified DeathCertify)
        {
            PdfPTable DeathMonthAndYearTable = new PdfPTable(4);
            float[] DeathMonthAndYearTablewidths = new float[] { 2f, 1f, 2f, 1f };
            DeathMonthAndYearTable.SetWidths(DeathMonthAndYearTablewidths);
            PdfPCell DeathTimeWrittenMonthCell = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("من شهر :")), CreateFont()));
            CellOption(DeathTimeWrittenMonthCell, 0, 5, 1, 1, 5f, 5f, 0f);
            PdfPCell DeathTimeWrittenMonth = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(Convert(DeathCertify.IssueDatetime.Month.ToString(), month: true))), CreateFont(12, 1, false, false, true)));
            CellOption(DeathTimeWrittenMonth, 0, -25, 1, 1, 5f, 5f, 0f);
            PdfPCell DeathTimeWrittenYearCell = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("لسنة :")), CreateFont()));
            CellOption(DeathTimeWrittenYearCell, 0, -5, 1, 1, 5f, 5f, 0f);
            PdfPCell DeathTimeWrittenYear = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(Convert(DeathCertify.IssueDatetime.Year.ToString()))), CreateFont(12, 1, false, false, true)));
            CellOption(DeathTimeWrittenYear, 0, -45, 1, 1, 5f, 5f, 0f);
            AddCellToTable(DeathMonthAndYearTable, new List<PdfPCell> { DeathTimeWrittenYear, DeathTimeWrittenYearCell, DeathTimeWrittenMonth, DeathTimeWrittenMonthCell });
            PdfPTable DeathDateTable = new PdfPTable(4);
            float[] DeathDateTablewidths = new float[] { 2f, 1f, 4.5f, 4f };
            DeathDateTable.SetWidths(DeathDateTablewidths);
            PdfPCell DeathTimeWrittenHourCell = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("14- تاريخ الوفاة (كتابة ) : الساعة : ")), CreateFont()));
            CellOption(DeathTimeWrittenHourCell, 0, 5, 1, 1, 5f, 5f, 0f);
            string DeathHour = "09:33 Am";
            int PM = (System.Convert.ToInt32(DeathHour.Substring(0, 2)) % 12);
            string ConvertHour = "";
            string Hour = "";
            if (PM == 1 || PM == 10)
                Hour = "ة";
            if (PM > 1 && PM < 10)
                Hour = "ـة";
            if (PM == 0)
                ConvertHour = "منتصف الليل";
            else if (PM == 1)
                ConvertHour = Convert(PM.ToString());
            else ConvertHour = Convert(PM.ToString());
            if (PM == 11) ConvertHour = "الحادية عشرة";
            else if (PM == 12) ConvertHour = "الثانية عشرة";
            else if (System.Convert.ToInt32(PM) >= 13 || System.Convert.ToInt32(PM) <= 19) Convert(PM.ToString(), true);
            string Minute = "";
            string Min = Convert(DeathHour.Substring(3, 2), false, true);
            string MinExist = " و ";
            if (System.Convert.ToInt32(DeathHour.Substring(3, 2)) > 10 && System.Convert.ToInt32(DeathHour.Substring(4, 2)) != 10)
                Minute = " دقيقة";
            else Minute = " دقائق";
            if (DeathHour.Substring(4, 1) == "0" && DeathHour.Substring(3, 1) != "1")
            {
                MinExist = "";
            }
            if (System.Convert.ToInt32(DeathHour.Substring(4, 2)) == 0 && DeathHour.Substring(3, 1) == "0")
            {
                Minute = "";
                Min = "";
                MinExist = "";
            }
            if (System.Convert.ToInt32(DeathHour.Substring(4, 2)) == 1 && DeathHour.Substring(3, 1) == "0")
            {
                Minute = " ";
                Min = " دقيقة واحدة ";
            }
            if (System.Convert.ToInt32(DeathHour.Substring(4, 2)) == 2 && DeathHour.Substring(3, 1) == "0")
            {
                Minute = " ";
                Min = " دقيقتان ";
            }
            string Format;
            if (DeathHour.Substring(6, 2) == "Am")
                Format = " صباحاً";
            else Format = " مساءاً";
            PdfPCell DeathTimeWrittenHour = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(ConvertHour + Hour + MinExist + Min + Minute + Format)), CreateFont(12, 1, false, false, true)));
            CellOption(DeathTimeWrittenHour, 0, -5, 1, 1, 5f, 5f, 0f);
            PdfPCell DeathTimeWrittenDayCell = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("يوم :")), CreateFont()));
            CellOption(DeathTimeWrittenDayCell, 0, 5, 1, 1, 5f, 5f, 0f);
            PdfPCell DeathTimeWrittenDay = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(DeathCertify.DeathTimeWrittenDay)), CreateFont(12, 1, false, false, true)));
            CellOption(DeathTimeWrittenDay, 0, -5, 1, 1, 5f, 5f, 0f);
            PdfPCell DeathMonthAndYearTableCell = new PdfPCell(DeathMonthAndYearTable);
            CellOption(DeathMonthAndYearTableCell, Colspan: 4);
            AddCellToTable(DeathDateTable, new List<PdfPCell> { DeathTimeWrittenDay, DeathTimeWrittenDayCell, DeathTimeWrittenHour, DeathTimeWrittenHourCell, DeathMonthAndYearTableCell });
            return DeathDateTable;
        }
        public static PdfPTable DeathDeathCertifyerNameTable15(DeathCertified DeathCertify)
        {
            PdfPTable DeathCertifyerNameTable = new PdfPTable(2);
            float[] DeathCertifyerNameTablewidths = new float[] { 1, 1.2f };
            DeathCertifyerNameTable.SetWidths(DeathCertifyerNameTablewidths);
            PdfPCell DeathCertifyerNameCell = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("15- إسم المبلغ عن الوفاة: ")), CreateFont()));
            CellOption(DeathCertifyerNameCell, 0, 5, 1, 1, 5f, 5f, 5, 0.5f);
            PdfPCell DeathCertifyerName = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(DeathCertify.InformerFullName)), CreateFont(12, 1, false, false, true)));
            CellOption(DeathCertifyerName, 0, -40, 1, 1, 5f, 5f, 5);
            AddCellToTable(DeathCertifyerNameTable, new List<PdfPCell> { DeathCertifyerName, DeathCertifyerNameCell });
            return DeathCertifyerNameTable;
        }
        public static PdfPTable DeathDeathCertifyerRelationTable16(DeathCertified DeathCertify)
        {
            PdfPTable DeathCertifyerRelationTable = new PdfPTable(2);
            float[] DeathCertifyerRelationTablewidths = new float[] { 1, 1.2f };
            DeathCertifyerRelationTable.SetWidths(DeathCertifyerRelationTablewidths);
            PdfPCell DeathCertifyerRelationCell = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("16- صلته بالمتوفي : ")), CreateFont()));
            CellOption(DeathCertifyerRelationCell, 0, 5, 1, 1, 5f, 5f, 5, 0.5f);
            PdfPCell DeathCertifyerRelation = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(DeathCertify.InformerRelation)), CreateFont(12, 1, false, false, true)));
            CellOption(DeathCertifyerRelation, 0, -15, 1, 1, 5f, 5f, 5);
            AddCellToTable(DeathCertifyerRelationTable, new List<PdfPCell> { DeathCertifyerRelation, DeathCertifyerRelationCell });
            return DeathCertifyerRelationTable;
        }
        public static PdfPTable DeathDeathCertifyerLocationTable17(DeathCertified DeathCertify)
        {
            PdfPTable DeathCertifyerLocationTable = new PdfPTable(2);
            float[] DeathCertifyerLocationTablewidths = new float[] { 1, 1.2f };
            DeathCertifyerLocationTable.SetWidths(DeathCertifyerLocationTablewidths);
            PdfPCell DeathCertifyerLocationCell = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("17- عنوان المبلغ الكامل: ")), CreateFont()));
            CellOption(DeathCertifyerLocationCell, 0, 5, 1, 1, 5f, 5f, 5, 0.5f);
            PdfPCell DeathCertifyerLocation = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(DeathCertify.InformerAddress)), CreateFont(12, 1, false, false, true)));
            CellOption(DeathCertifyerLocation, 0, -35, 1, 1, 5f, 5f, 5);
            AddCellToTable(DeathCertifyerLocationTable, new List<PdfPCell> { DeathCertifyerLocation, DeathCertifyerLocationCell });
            return DeathCertifyerLocationTable;
        }
        public static PdfPTable DeathMedicaldeathCertificateDetails18(DeathCertified DeathCertify)
        {
            PdfPTable MedicaldeathCertificateDetails = new PdfPTable(3);
            float[] MedicaldeathCertificateDetailsWidth = new float[] { 2f, 1.6f, 2.6f };
            MedicaldeathCertificateDetails.SetWidths(MedicaldeathCertificateDetailsWidth);
            PdfPCell MedicaldeathCertificateDetailsTitle = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("18- " + " شهادة الوفاة الطبية")), CreateFont()));
            CellOption(MedicaldeathCertificateDetailsTitle, 0, 5, 3, 1, 5, 0, 5f);
            PdfPCell disease = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("(1)" + "  المرض أو الحالة التي أدت للوفاة مباشرةً : " + "              (أ) ")), CreateFont()));
            CellOption(disease, 0, 5, 1, 1, 5);
            PdfPCell diseasev = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(DeathCertify.ReasonA)), CreateFont(12, 1, false, false, true)));
            CellOption(diseasev, 0, -15);
            PdfPCell diseaseCause = new PdfPCell(new Phrase(0, "(تسبب عن أو نتيجة لما يليه)", CreateFont()));
            CellOption(diseaseCause, 2, 0, 1, 1, 0, 5);
            PdfPCell pathologies = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("الحالات المرضية (إن وجدت) والتي أدت للسبب " + "            (ب) ")), CreateFont()));
            CellOption(pathologies, 0, 5, 1, 1, 5);
            PdfPCell pathologiesv = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(DeathCertify.ReasonB)), CreateFont(12, 1, false, false, true)));
            CellOption(pathologiesv, 0, -15);
            PdfPCell originalReason = new PdfPCell(new Phrase(0, "أعلاه مع ذكر السبب الأصلي في النهاية" + "                        (ج) ", CreateFont()));
            CellOption(originalReason, 0, 5, 1, 1, 5);
            PdfPCell originalReasonv = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(DeathCertify.ReasonC)), CreateFont(12, 1, false, false, true)));
            CellOption(originalReasonv, 0, -15);
            PdfPCell originalReasonDCell = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("(د) ")), CreateFont()));
            CellOption(originalReasonDCell, 2, PaddingLeft: 45);
            PdfPCell originalReasonD = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(DeathCertify.ReasonD)), CreateFont(12, 1, false, false, true)));
            CellOption(originalReasonD, PaddingRight: -35, Colspan: 2);
            PdfPCell Otherdisease = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("(2) حالات مهمة أخرى ساعدت على الوفاة ولا صلة لها بالمرض أو الحالة التي سببت الوفاة : ")), CreateFont()));
            CellOption(Otherdisease, 0, 5, 2, 1, 5);
            PdfPCell OtherdiseaseV = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(DeathCertify.OtherReasons)), CreateFont(12, 1, false, false, true)));
            CellOption(OtherdiseaseV, 0, -55, 1, 1, 5);
            AddCellToTable(MedicaldeathCertificateDetails, new List<PdfPCell> { MedicaldeathCertificateDetailsTitle, diseaseCause, diseasev, disease, diseaseCause, pathologiesv, pathologies, diseaseCause, originalReasonv, originalReason, originalReasonD, originalReasonDCell, OtherdiseaseV, Otherdisease });
            return MedicaldeathCertificateDetails;
        }
        public static PdfPTable DeathApproximatePeriodTable18(DeathCertified DeathCertify)
        {
            PdfPTable ApproximatePeriodTable = new PdfPTable(1);
            PdfPCell ApproximatePeriodCell = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("الفترة التقريبية بين ظهور الأعراض و الوفاة : ")), CreateFont()));
            CellOption(ApproximatePeriodCell, 0, 5);
            PdfPCell ApproximatePeriod = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(DeathCertify.SymptomsAndDeath)), CreateFont(12, 1, false, false, true)));
            CellOption(ApproximatePeriod, 0, 5, PaddingTop: 5);
            AddCellToTable(ApproximatePeriodTable, new List<PdfPCell> { ApproximatePeriodCell, ApproximatePeriod });
            return ApproximatePeriodTable;
        }
        public static PdfPTable DeathIfWomenDetails19(DeathCertified DeathCertify)
        {
            PdfPTable DeathIfWomenDetails = new PdfPTable(6);
            float[] DeathIfWomenDetailswidths = new float[] { 1f, 0.2f, 1f, 0.2f, 1f, 4f };
            DeathIfWomenDetails.SetWidths(DeathIfWomenDetailswidths);
            PdfPCell DeathIfWomenDetailsText = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(" 19- هل المتوفي إمرأة وفي مرحلة الحمل أو الإسقاط أو الولادة أو النفاس")), CreateFont()));
            CellOption(DeathIfWomenDetailsText, 0, 5, 1, 1, 5);
            string starYes = "";
            string starNo = "";
            if (DeathCertify.IsPregnant == true && DeathCertify.Gender != "ذكر")
            { starYes = ""; }
            else if (DeathCertify.IsPregnant == false && DeathCertify.Gender != "ذكر")
            {
                starNo = "";
            }
            PdfPCell Yescell = new PdfPCell(new Phrase(0, "نعم", CreateFont()));
            CellOption(Yescell, 1);
            PdfPCell SmallRecYes = new PdfPCell(new Phrase(0, starYes, CreateFont(12, 0, true, false, true)));
            CellOption(SmallRecYes, 0, 5, 1, 1, 0, 0, 2, 1, 1, 1, 1);
            PdfPCell Nocell = new PdfPCell(new Phrase(0, "لا", CreateFont()));
            CellOption(Nocell, 1);
            PdfPCell SmallRecNo = new PdfPCell(new Phrase(0, starNo, CreateFont(12, 0, true, false, true)));
            CellOption(SmallRecNo, 0, 5, 1, 1, 0, 0, 2, 1, 1, 1, 1);
            PdfPCell TheNullcell = new PdfPCell(new Phrase(0, " ", CreateFont()));
            CellOption(TheNullcell, 1);
            PdfPCell TheNullRow = new PdfPCell(new Phrase(0, " ", CreateFont(1, 0)));
            CellOption(TheNullRow, 0, 1, 6, 1, 5f);
            PdfPCell Pregnantc = new PdfPCell(DeathPregnant19(DeathCertify));
            CellOption(Pregnantc, 0, 1, 6);
            PdfPCell TheDeathInc = new PdfPCell(DeathTheDeathIn20(DeathCertify))
            {
                Colspan = 6,
                PaddingTop = -5
            };
            AddCellToTable(DeathIfWomenDetails, new List<PdfPCell> { TheNullRow, TheNullcell, SmallRecNo, Nocell, SmallRecYes, Yescell, DeathIfWomenDetailsText, Pregnantc, TheDeathInc });
            return DeathIfWomenDetails;
        }
        public static PdfPTable DeathPregnant19(DeathCertified DeathCertify)
        {
            string Pregnant1 = "", Pregnant2 = "", Pregnant3 = "", Pregnant4 = "";
            if (DeathCertify.PregnantTypeID == 1)
            {
                Pregnant1 = "";
            }
            else if (DeathCertify.PregnantTypeID == 2)
            { Pregnant2 = ""; }
            else if (DeathCertify.PregnantTypeID == 3)
            { Pregnant3 = ""; }
            else if (DeathCertify.PregnantTypeID == 4)
            { Pregnant4 = ""; }
            PdfPTable Pregnant = new PdfPTable(11);
            float[] Pregnantwidths = new float[] { 0.1f, 0.3f, 2.3f, 0.2f, 3.2f, 0.2f, 2.6f, 0.2f, 1.7f, 0.2f, 3f };
            Pregnant.SetWidths(Pregnantwidths);
            PdfPCell DeathDuring = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(" حدثت الوفاة أثناء :-1 الحمل")), CreateFont()));
            CellOption(DeathDuring, 0, 5, 3, 1, 5);
            PdfPCell Pregnancy = new PdfPCell(new Phrase(0, Pregnant1, CreateFont(12, 0, true, false, true)));
            CellOption(Pregnancy, 0, -10);
            PdfPCell Pregnancy2 = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(" 2- الإجهاض ")), CreateFont()));
            CellOption(Pregnancy2, 0, 5, 1, 1, 5);
            PdfPCell Pregnancy3 = new PdfPCell(new Phrase(0, Pregnant2 + " ", CreateFont(12, 0, true, false, true)));
            CellOption(Pregnancy3, 0, -10, 1, 1, 5);
            PdfPCell Pregnancy4 = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("3- الولادة ")), CreateFont()));
            CellOption(Pregnancy4, 0, 5, 1, 1, 5);
            PdfPCell Pregnancy5 = new PdfPCell(new Phrase(0, Pregnant3 + " ", CreateFont(12, 0, true, false, true)));
            CellOption(Pregnancy5, 0, -50, 1, 1, 5);
            PdfPCell Pregnancy6 = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("4- النفاس (للولادة أو الإجهاض) ")), CreateFont()));
            CellOption(Pregnancy6, 0, -15, 1, 1, 5);
            PdfPCell Pregnancy7 = new PdfPCell(new Phrase(0, Pregnant4 + " ", CreateFont(12, 0, true, false, true)));
            CellOption(Pregnancy7, 0, -30);
            PdfPCell Pregnancy8 = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("تذكر مدة الحمل بالأسابيع ( ")), CreateFont()));
            CellOption(Pregnancy8, 0, -15, 1, 1, 5);
            PdfPCell Pregnancy9 = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(DeathCertify.PregnantDuration.ToString())), CreateFont(12, 1, false, false, true)));
            CellOption(Pregnancy9, 0, -20, 1, 1, 5);
            PdfPCell Pregnancy10 = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(")")), CreateFont()));
            CellOption(Pregnancy10, 0, -20, 1, 1, 5, PaddingLeft: 2);
            AddCellToTable(Pregnant, new List<PdfPCell> { Pregnancy10, Pregnancy9, Pregnancy8, Pregnancy7, Pregnancy6, Pregnancy5, Pregnancy4, Pregnancy3, Pregnancy2, Pregnancy, DeathDuring });
            return Pregnant;
        }
        public static PdfPTable DeathTheDeathIn20(DeathCertified DeathCertify)
        {
            string deathLocation1 = "", deathLocation2 = "", deathLocation3 = "";
            //  if (DeathCertify.DeathLocationID == 1)
            deathLocation1 = "";
            //  else if (DeathCertify.DeathLocationID == 2)
            deathLocation2 = "";
            //  else if (DeathCertify.DeathLocationID == 3)
            deathLocation3 = "";
            PdfPTable TheDeathIn = new PdfPTable(6);
            float[] TheDeathInwidths = new float[] { 0.1f, 1, 0.1f, 1, 0.1f, 1 };
            TheDeathIn.SetWidths(TheDeathInwidths);
            PdfPCell DeathIn = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("20- حدثت الوفاة في :1- البيت ")), CreateFont()));
            CellOption(DeathIn, 0, 5, 1, 1, 5, 0, 5);
            PdfPCell DeathInLocation1 = new PdfPCell(new Phrase(0, deathLocation1 + " ", CreateFont(12, 0, true, false, true)));
            CellOption(DeathInLocation1, 0, -65, 1, 1, 5, 0, 5);
            PdfPCell DeathInLocation2 = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("2- المستشفى ")), CreateFont()));
            CellOption(DeathInLocation2, 0, 5, 1, 1, 5, 0, 5);
            PdfPCell DeathInLocation3 = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(deathLocation2 + " ")), CreateFont(12, 0, true, false, true)));
            CellOption(DeathInLocation3, 0, -130, 1, 1, 5, 0, 5);
            PdfPCell DeathInLocation4 = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("3- مكان آخر ")), CreateFont()));
            CellOption(DeathInLocation4, 0, 5, 1, 1, 5, 0, 5);
            PdfPCell DeathInLocation5 = new PdfPCell(new Phrase(0, deathLocation3 + " ", CreateFont(12, 0, true, false, true)));
            CellOption(DeathInLocation5, 0, -130, 1, 1, 5, 0, 5);
            PdfPTable Hospital = new PdfPTable(6);
            float[] Hospitalwidths = new float[] { 1, 1, 1, 1, 1, 1.5f };
            Hospital.SetWidths(Hospitalwidths);
            PdfPCell HospitalNameCell = new PdfPCell(new Phrase(0, "إسم المستشفى أو المركز الصحي : ", CreateFont()));
            CellOption(HospitalNameCell, 0, 5, 1, 1, 5, 0, 5);
            PdfPCell HospitalName = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(DeathCertify.HospitalName)), CreateFont(12, 1, false, false, true)));
            CellOption(HospitalName, 0, -15, 1, 1, 5, 0, 5);
            PdfPCell LobbyTypeCell = new PdfPCell(new Phrase(0, "نوع الردهة :", CreateFont()));
            CellOption(LobbyTypeCell, 0, -27, 1, 1, 5, 0, 5);
            PdfPCell LobbyType = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(DeathCertify.LobbyType)), CreateFont(12, 1, false, false, true)));
            CellOption(LobbyType, 0, -75, 1, 1, 5, 0, 5);
            PdfPCell LobbyNoCell = new PdfPCell(new Phrase(0, "رقم الطبلة :", CreateFont()));
            CellOption(LobbyNoCell, 0, -12, 1, 1, 5, 0, 5);
            PdfPCell LobbyNo = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(DeathCertify.LobbyNo)), CreateFont(12, 1, false, false, true)));
            CellOption(LobbyNo, 0, -65, 1, 1, 5, 0, 5);
            AddCellToTable(Hospital, new List<PdfPCell> { LobbyNo, LobbyNoCell, LobbyType, LobbyTypeCell, HospitalName, HospitalNameCell });
            PdfPCell HospitalCell = new PdfPCell(Hospital);
            CellOption(HospitalCell, Colspan: 6);
            AddCellToTable(TheDeathIn, new List<PdfPCell> { DeathInLocation5, DeathInLocation4, DeathInLocation3, DeathInLocation2, DeathInLocation1, DeathIn, HospitalCell });
            return TheDeathIn;
        }
        public static PdfPTable DeathDoctorCertified21(DeathCertified DeathCertify)
        {
            PdfPTable DoctorCertified = new PdfPTable(2);
            float[] DoctorCertifiedwidths = new float[] { 1.2f, 2f };
            DoctorCertified.SetWidths(DoctorCertifiedwidths);
            PdfPTable DoctorNameTable = new PdfPTable(2);
            PdfPCell DoctorNameCell = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("إسم الطبيب : ")), CreateFont()));
            CellOption(DoctorNameCell, 0, 5, 1, 1, 5f);
            PdfPCell DoctorName = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(DeathCertify.DoctorName)), CreateFont(12, 1, false, false, true)));
            CellOption(DoctorName, 0, -25, 1, 1, 5f);
            AddCellToTable(DoctorNameTable, new List<PdfPCell> { DoctorName, DoctorNameCell });
            PdfPCell DoctorNameTableCell = new PdfPCell(DoctorNameTable);
            CellOption(DoctorNameTableCell);
            PdfPCell DoctorCertifiedText = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(" 21- أشهد إن الوفاة قد حدثت من الأسباب المبينة أعلاه")), CreateFont()));
            CellOption(DoctorCertifiedText, 0, 5);
            PdfPTable DoctorJobTable = new PdfPTable(2);
            PdfPCell DoctorJobCell = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(" عنوان إشتغال الطبيب : ")), CreateFont()));
            CellOption(DoctorJobCell, 0, 5, 1, 1, 5f);
            PdfPCell DoctorJob = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(DeathCertify.DoctorWorkAddress)), CreateFont(12, 1, false, false, true)));
            CellOption(DoctorJob, 0, -38, 1, 1, 5f);
            AddCellToTable(DoctorJobTable, new List<PdfPCell> { DoctorJob, DoctorJobCell });
            PdfPCell DoctorJobTableCell = new PdfPCell(DoctorJobTable);
            CellOption(DoctorJobTableCell);
            PdfPCell TheDoctorSignature = new PdfPCell(new Phrase(0, "توقيعه", CreateFont()));
            CellOption(TheDoctorSignature);
            AddCellToTable(DoctorCertified, new List<PdfPCell> { DoctorNameTableCell, DoctorCertifiedText, TheDoctorSignature, DoctorJobTableCell });
            return DoctorCertified;
        }
        public static PdfPTable DeathJudgeDecisionTable22(DeathCertified DeathCertify)
        {
            PdfPTable JudgeDecisionTable = new PdfPTable(2);
            float[] JudgeDecisionTablewidths = new float[] { 1f, 3f };
            JudgeDecisionTable.SetWidths(JudgeDecisionTablewidths);
            PdfPCell JudgeDecisionCell = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(" 22- قرار القاضي (في حالة عدم تشريح الجثة) ")), CreateFont()));
            CellOption(JudgeDecisionCell, 0, 5, 1, 1, 5f);
            PdfPCell JudgeDecision = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(DeathCertify.JudgeDecision)), CreateFont(12, 1, false, false, true)));
            CellOption(JudgeDecision, 0, -5, 1, 1, 5f);
            AddCellToTable(JudgeDecisionTable, new List<PdfPCell> { JudgeDecision, JudgeDecisionCell });
            return JudgeDecisionTable;
        }
        public static PdfPTable DeathForensicMedicine23(DeathCertified DeathCertify)
        {
            PdfPTable ForensicMedicine = new PdfPTable(4);
            float[] ForensicMedicinewidths = new float[] { 1, 2, 1, 1 };
            ForensicMedicine.SetWidths(ForensicMedicinewidths);
            PdfPCell ForensicMedicineText = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(" 23- شهادة طبية عدلية ( تملأ و توقع من قبل الطبيب العدلي)")), CreateFont()));
            CellOption(ForensicMedicineText, 0, 5, 4, 1, 0, 0, 5f);
            PdfPTable ForensicMedicineDoctorTable = new PdfPTable(2);
            float[] ForensicMedicineDoctorTablewidths = new float[] { 1f, 3f };
            ForensicMedicineDoctorTable.SetWidths(ForensicMedicineDoctorTablewidths);
            PdfPCell ForensicMedicineDoctorCell = new PdfPCell(new Phrase(0, " إني الموقع أدناه الدكتور : ", CreateFont()));
            CellOption(ForensicMedicineDoctorCell, 0, 5, 1, 1, 5f);
            PdfPCell ForensicMedicineDoctor = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(DeathCertify.DoctorName2)), CreateFont(12, 1, false, false, true)));
            CellOption(ForensicMedicineDoctor, 0, 0, 1, 1, 5f);
            AddCellToTable(ForensicMedicineDoctorTable, new List<PdfPCell> { ForensicMedicineDoctor, ForensicMedicineDoctorCell });
            PdfPCell ForensicMedicineDoctorTableCell = new PdfPCell(ForensicMedicineDoctorTable);
            CellOption(ForensicMedicineDoctorTableCell);
            PdfPTable DoctorWorkTable = new PdfPTable(2);
            PdfPCell DoctorWorkCell = new PdfPCell(new Phrase(0, "الطبيب في: ", CreateFont()));
            CellOption(DoctorWorkCell, 0, 5, 1, 1, 5f);
            PdfPCell DoctorWork = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(DeathCertify.DoctorWorkIn)), CreateFont(12, 1, false, false, true)));
            CellOption(DoctorWork, 0, -15, 1, 1, 5f);
            AddCellToTable(DoctorWorkTable, new List<PdfPCell> { DoctorWork, DoctorWorkCell });
            PdfPCell DoctorWorkTableCell = new PdfPCell(DoctorWorkTable);
            CellOption(DoctorWorkTableCell);
            PdfPTable anatomyTable = new PdfPTable(2);
            float[] anatomyTablewidths = new float[] { 1, 1.2f };
            anatomyTable.SetWidths(anatomyTablewidths);
            PdfPCell anatomyCell = new PdfPCell(new Phrase(0, "قمت بتشريح جثة المتوفي : ", CreateFont()));
            CellOption(anatomyCell, 0, 5, 1, 1, 5f);
            PdfPCell anatomy = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(DeathCertify.FirstName + " " + DeathCertify.SecondName + " " + DeathCertify.ThirdName)), CreateFont(12, 1, false, false, true)));
            CellOption(anatomy, 0, -45, 1, 1, 5f);
            AddCellToTable(anatomyTable, new List<PdfPCell> { anatomy, anatomyCell });
            PdfPCell anatomyTableCell = new PdfPCell(anatomyTable);
            CellOption(anatomyTableCell);
            PdfPTable SentByTable = new PdfPTable(2);
            float[] SentByTablewidths = new float[] { 1, 1.2f };
            SentByTable.SetWidths(SentByTablewidths);
            PdfPCell SentByCell = new PdfPCell(new Phrase(0, "و المرسلة من قبل : ", CreateFont()));
            CellOption(SentByCell, 0, 5, 1, 1, 5f);
            PdfPCell SentBy = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(DeathCertify.SentFrom)), CreateFont(12, 1, false, false, true)));
            CellOption(SentBy, 0, 5, 1, 1, 5f);
            AddCellToTable(SentByTable, new List<PdfPCell> { SentBy, SentByCell });
            PdfPCell SentByTableCell = new PdfPCell(SentByTable);
            CellOption(SentByTableCell);
            PdfPTable FormNumberTable = new PdfPTable(2);
            float[] FormNumberwidths = new float[] { 1, 2f };
            FormNumberTable.SetWidths(FormNumberwidths);
            PdfPCell FormNumberCell = new PdfPCell(new Phrase(0, " و حسب الإستمارة المرقمة : ", CreateFont()));
            CellOption(FormNumberCell, 0, 5, 1, 1, 5f);
            PdfPCell FormNumber = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(DeathCertify.FormNo)), CreateFont(12, 1, false, false, true)));
            CellOption(FormNumber, 0, -75, 1, 1, 5f);
            AddCellToTable(FormNumberTable, new List<PdfPCell> { FormNumber, FormNumberCell });
            PdfPCell FormNumberTableCell = new PdfPCell(FormNumberTable);
            CellOption(FormNumberTableCell, Colspan: 2);
            PdfPTable FormDateTable = new PdfPTable(2);
            float[] FormDatewidths = new float[] { 1, 2f };
            FormDateTable.SetWidths(FormNumberwidths);
            PdfPCell FormDateCell = new PdfPCell(new Phrase(0, "و المؤرخة في : ", CreateFont()));
            CellOption(FormDateCell, 0, 5, 1, 1, 5f);
            PdfPCell FormDate = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(DeathCertify.FormIssueDate.ToString())), CreateFont(12, 1, false, false, true)));
            CellOption(FormDate, 0, -220, 1, 1, 5f);
            AddCellToTable(FormDateTable, new List<PdfPCell> { FormDate, FormDateCell });
            PdfPCell FormDateTableCell = new PdfPCell(FormDateTable);
            CellOption(FormDateTableCell, Colspan: 2);
            PdfPTable FirstReasonTable = new PdfPTable(2);
            float[] FirstReasonTablewidths = new float[] { 3, 1f };
            FirstReasonTable.SetWidths(FirstReasonTablewidths);
            PdfPCell FirstReasonCell = new PdfPCell(new Phrase(0, "فوجدت سبب الوفاة الأولي : ", CreateFont()));
            CellOption(FirstReasonCell, 0, 5, 1, 1, 5f);
            PdfPCell FirstReason = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(DeathCertify.FirstReason)), CreateFont(12, 1, false, false, true)));
            CellOption(FirstReason, 0, -65, 1, 1, 5f);
            AddCellToTable(FirstReasonTable, new List<PdfPCell> { FirstReason, FirstReasonCell });
            PdfPCell FirstReasonTableCell = new PdfPCell(FirstReasonTable);
            CellOption(FirstReasonTableCell, Colspan: 4);
            PdfPTable FinalReasonTable = new PdfPTable(2);
            float[] FinalReasonTablewidths = new float[] { 3, 1f };
            FinalReasonTable.SetWidths(FinalReasonTablewidths);
            PdfPCell FinalReasonCell = new PdfPCell(new Phrase(0, " سبب الوفاة النهائي : ", CreateFont()));
            CellOption(FinalReasonCell, 0, 5, 1, 1, 5f);
            PdfPCell FinalReason = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(DeathCertify.FinalReason)), CreateFont(12, 1, false, false, true)));
            CellOption(FinalReason, 0, -90, 1, 1, 5f);
            AddCellToTable(FinalReasonTable, new List<PdfPCell> { FinalReason, FinalReasonCell });
            PdfPCell FinalReasonTableCell = new PdfPCell(FinalReasonTable);
            CellOption(FinalReasonTableCell, Colspan: 4);
            PdfPCell forensicDoctorSignature = new PdfPCell(new Phrase(0, "توقيع الطبيب : ", CreateFont()));
            CellOption(forensicDoctorSignature, 0, 10, 2);
            PdfPCell ForensicMedicineSeal = new PdfPCell(new Phrase(0, "ختم الطبابة العدلية ", CreateFont()));
            CellOption(ForensicMedicineSeal, 0, 25, 2, 1, 5);
            PdfPCell correction = new PdfPCell(DeathcorrectionTable23(DeathCertify));
            CellOption(correction, 0, 10, 4, 1, 5f);
            AddCellToTable(ForensicMedicine, new List<PdfPCell>{ ForensicMedicineText, SentByTableCell, anatomyTableCell, DoctorWorkTableCell, ForensicMedicineDoctorTableCell
                                           , FormDateTableCell, FormNumberTableCell
                                           , FirstReasonTableCell
                                           , FinalReasonTableCell
                                           , ForensicMedicineSeal, forensicDoctorSignature
                                           , correction });
            return ForensicMedicine;
        }
        public static PdfPTable DeathcorrectionTable23(DeathCertified DeathCertify)
        {
            PdfPTable correctionTable = new PdfPTable(8);
            float[] correctionTablewidths = new float[] { 0.5f, 1f, 1.5f, 0.5f, 0.5f, 0.5f, 1, 2.5f };
            correctionTable.SetWidths(correctionTablewidths);
            PdfPCell correctionCell = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("تم التصحيح بموجب كتاب التصحيح الصادر من : ")), CreateFont()));
            CellOption(correctionCell);
            PdfPCell IssueBook = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(DeathCertify.IssueBook)), CreateFont(12, 1, false, false, true)));
            CellOption(IssueBook, PaddingRight: -30);
            PdfPCell BookNumber = new PdfPCell(new Phrase(0, " المرقم ", CreateFont()));
            CellOption(BookNumber);
            PdfPCell BookNumberValue = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(DeathCertify.BookNo)), CreateFont(12, 1, false, false, true)));
            CellOption(BookNumberValue, PaddingRight: -10);
            PdfPCell In = new PdfPCell(new Phrase(0, "في : ", CreateFont()));
            CellOption(In);
            PdfPCell InValue = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(DeathCertify.BookIssueDate.ToString())), CreateFont(12, 1, false, false, true)));
            CellOption(InValue, PaddingRight: -20);
            PdfPCell DiskNumber = new PdfPCell(new Phrase(0, "رقم القرص : ", CreateFont()));
            CellOption(DiskNumber);
            PdfPCell DiskNumberValue = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(DeathCertify.DiskNo)), CreateFont(12, 1, false, false, true)));
            CellOption(DiskNumberValue, PaddingRight: -30);
            AddCellToTable(correctionTable, new List<PdfPCell> { DiskNumberValue, DiskNumber, InValue, In, BookNumberValue, BookNumber, IssueBook, correctionCell });
            return correctionTable;
        }
        public static PdfPTable DeathNationalityAndCivilStatus24(DeathCertified DeathCertify)
        {
            PdfPTable NationalityAndCivilStatus = new PdfPTable(6);
            float[] NationalityAndCivilStatuswidths = new float[] { 1, 1, 1.6f, 1, 1, 1 };
            NationalityAndCivilStatus.SetWidths(NationalityAndCivilStatuswidths);
            PdfPCell NationalityAndCivilStatusText = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("24- معلومات خاصة بمديرية الجنسية و الأحوال المدنية (تؤخذ من هوية الأحوال المدنية)")), CreateFont()));
            CellOption(NationalityAndCivilStatusText, 0, 5, 4, 1, 0, 5f);
            PdfPTable RecordTable = new PdfPTable(2);
            float[] RecordTablewidths = new float[] { 1f, 1.4f };
            RecordTable.SetWidths(RecordTablewidths);
            PdfPCell RecordCell = new PdfPCell(new Phrase(0, "رقم السجل : ", CreateFont()));
            CellOption(RecordCell, 0, 5, 1, 1, 5f);
            PdfPCell Record = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(DeathCertify.RecordNo)), CreateFont(12, 1, false, false, true)));
            CellOption(Record, 0, -5, 1, 1, 5f);
            AddCellToTable(RecordTable, new List<PdfPCell> { Record, RecordCell });
            PdfPCell RecordTableCell = new PdfPCell(RecordTable);
            CellOption(RecordTableCell);
            PdfPTable NationalStandardNumberTable = new PdfPTable(2);
            float[] NationalStandardNumberTablewidths = new float[] { 1f, 2f };
            NationalStandardNumberTable.SetWidths(NationalStandardNumberTablewidths);
            PdfPCell NationalStandardNumberCell = new PdfPCell(new Phrase(0, "الرقم الوطني : ", CreateFont()));
            CellOption(NationalStandardNumberCell, 0, 5, 1, 1, 5f);
            PdfPCell NationalStandardNumber = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(DeathCertify.FamilyNo)), CreateFont(12, 1, false, false, true)));
            CellOption(NationalStandardNumber, 0, -80, 1, 1, 5f);
            AddCellToTable(NationalStandardNumberTable, new List<PdfPCell> { NationalStandardNumber, NationalStandardNumberCell });
            PdfPCell NationalStandardNumberTableCell = new PdfPCell(NationalStandardNumberTable);
            CellOption(NationalStandardNumberTableCell, Colspan: 2);
            PdfPTable PageNoTable = new PdfPTable(2);
            float[] PageNoTablewidths = new float[] { 1f, 1.4f };
            PageNoTable.SetWidths(PageNoTablewidths);
            PdfPCell PageNoCell = new PdfPCell(new Phrase(0, "رقم الصحيفة : ", CreateFont()));
            CellOption(PageNoCell, 0, 5, 1, 1, 5f);
            PdfPCell PageNo = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(DeathCertify.PageNo)), CreateFont(12, 1, false, false, true)));
            CellOption(PageNo, 0, 0, 1, 1, 5f);
            AddCellToTable(PageNoTable, new List<PdfPCell> { PageNo, PageNoCell });
            PdfPCell PageNoTableCell = new PdfPCell(PageNoTable);
            CellOption(PageNoTableCell);
            PdfPTable TheProvinceTable = new PdfPTable(2);
            PdfPCell TheProvinceCell = new PdfPCell(new Phrase(0, "المحافظة : ", CreateFont()));
            CellOption(TheProvinceCell, 0, 5, 1, 1, 5f);
            PdfPCell TheProvince = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(DeathCertify.Province)), CreateFont(12, 1, false, false, true)));
            CellOption(TheProvince, 0, -5, 1, 1, 5f);
            AddCellToTable(TheProvinceTable, new List<PdfPCell> { TheProvince, TheProvinceCell });
            PdfPCell TheProvinceTableCell = new PdfPCell(TheProvinceTable);
            CellOption(TheProvinceTableCell);
            PdfPTable CivilStatusIDNumberTable = new PdfPTable(2);
            float[] CivilStatusIDNumberTablewidths = new float[] { 1f, 2f };
            CivilStatusIDNumberTable.SetWidths(CivilStatusIDNumberTablewidths);
            PdfPCell IdentifierNoCell = new PdfPCell(new Phrase(0, "رقم هوية الأحوال المدنية : ", CreateFont()));
            CellOption(IdentifierNoCell, 0, 5, 1, 1, 5f);
            PdfPCell IdentifierNo = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(DeathCertify.IdentifierNo)), CreateFont(12, 1, false, false, true)));
            CellOption(IdentifierNo, 0, -5, 1, 1, 5f);
            AddCellToTable(CivilStatusIDNumberTable, new List<PdfPCell> { IdentifierNo, IdentifierNoCell });
            PdfPCell CivilStatusIDNumberTableCell = new PdfPCell(CivilStatusIDNumberTable);
            CellOption(CivilStatusIDNumberTableCell);
            PdfPTable WithCertifiedTable = new PdfPTable(2);
            PdfPCell WithCertifiedCell = new PdfPCell(new Phrase(0, "دائرة الأحوال المدنية : ", CreateFont()));
            CellOption(WithCertifiedCell, 0, 5, 1, 1, 5f);
            PdfPCell WithCertified = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(DeathCertify.IdentifierName)), CreateFont(12, 1, false, false, true)));
            CellOption(WithCertified, 0, -15, 1, 1, 5f);
            AddCellToTable(WithCertifiedTable, new List<PdfPCell> { WithCertified, WithCertifiedCell });
            PdfPCell WithCertifiedTableCell = new PdfPCell(WithCertifiedTable);
            CellOption(WithCertifiedTableCell, Colspan: 2);
            AddCellToTable(NationalityAndCivilStatus, new List<PdfPCell> { NationalStandardNumberTableCell, NationalityAndCivilStatusText, WithCertifiedTableCell, CivilStatusIDNumberTableCell, TheProvinceTableCell, PageNoTableCell, RecordTableCell });
            return NationalityAndCivilStatus;
        }
        public static PdfPTable DeathFootTable(DeathCertified DeathCertify)
        {
            PdfPTable FootTable = new PdfPTable(2);
            float[] FootTablewidths = new float[] { 1, 6 };
            FootTable.SetWidths(FootTablewidths);
            PdfPCell footStringCell = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("ﻧﻤﻮﺫﺝ ﺻﺎﺩﺭ ﺑﻤﻮﺟﺐ ﺍﻟﻘﺎﻧﻮﻥ  ﻟﺴﻨﺔ  ﻋﻦ ﻭﺯﺍﺭﺓ ﺍﻟﺼﺤﺔ ﺩﺍﺋﺮﺓ ﺗﺨﻄﻴﻂ ﻭﺗﻨﻤﻴﺔ ﺍﻟﻤﻮﺍﺭﺩ  ﻗﺴﻢ ﺍﻹﺣﺼﺎﺀ ﺍﻟﺼﺤﻲ ﻭ ﺍﻟﺤﻴﺎﺗﻲ                 ﺭﻗﻢ ﻫﺎﺗﻒ ﺃﻗﺮﺏ ﺷﺨﺺ ﻟﻠﻤﺘﻮﻓﻲ")), CreateFont()));
            CellOption(footStringCell, 0, 5);
            PdfPCell footString = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(DeathCertify.MobileNo)), CreateFont(12, 1, false, false, true)));
            CellOption(footString, 0, -75);
            AddCellToTable(FootTable, new List<PdfPCell> { footString, footStringCell });
            return FootTable;
        }
        public static FileStreamResult CreateDeathCertified(DeathCertified DeathCertify)
        {
            MemoryStream m = new MemoryStream();
            var document = new Document(PageSize.A4.Rotate(), 25, 25, 0, 0);
            PdfWriter.GetInstance(document, m).CloseStream = false;
            document.Open();
            PdfPTable permanentResidenceCollection = new PdfPTable(2);
            float[] permanentResidenceCollectionwidths = new float[] { 2.8f, 5f };
            permanentResidenceCollection.SetWidths(permanentResidenceCollectionwidths);
            PdfPCell DeathPlacec = new PdfPCell(DeathPlace13(DeathCertify));
            CellOption(DeathPlacec, 0, 0, 1, 2);
            PdfPTable MaritalStatus = new PdfPTable(3);
            float[] MaritalStatuswidths = new float[] { 0.8f, 0.6f, 1f };
            MaritalStatus.SetWidths(MaritalStatuswidths);
            PdfPCell MaritalStatusTextcell = new PdfPCell(DeathMaritalStatusText9(DeathCertify));
            PdfPCell DeathBirthDateTableCell = new PdfPCell(DeathBirthDateTable10(DeathCertify));
            PdfPCell BirthPlace = new PdfPCell(DeathBirthplaceTable11(DeathCertify));
            CellOption(BirthPlace, 0, 5, 1, 1, 5f, 5f, 0, 0.5f);
            PdfPTable permanentResidence = new PdfPTable(1);
            PdfPCell permanentResidenceText = new PdfPCell(DeathpermanentResidenceTextTable12(DeathCertify));
            CellOption(permanentResidenceText, 0, 5, 1, 1, 10, 0, 5);
            PdfPCell DeathDateTableCell = new PdfPCell(DeathDateTable14(DeathCertify));
            CellOption(DeathDateTableCell, 0, 5, 1, 1, 3, 0, 3);
            PdfPTable DeathDate = new PdfPTable(1);
            AddCellToTable(DeathDate, new List<PdfPCell> { DeathDateTableCell });
            AddCellToTable(permanentResidence, new List<PdfPCell> { permanentResidenceText });
            AddCellToTable(MaritalStatus, new List<PdfPCell> { BirthPlace, DeathBirthDateTableCell, MaritalStatusTextcell });
            PdfPCell DeathDatec = new PdfPCell(DeathDate);
            PdfPCell permanentResidenceCell = new PdfPCell(permanentResidence);
            AddCellToTable(permanentResidenceCollection, new List<PdfPCell> { DeathPlacec, permanentResidenceCell, DeathDatec });
            PdfPTable DeathCertifyerInfo = new PdfPTable(3);
            float[] DeathCertifyerInfowidths = new float[] { 4f, 3f, 4.2f };
            DeathCertifyerInfo.SetWidths(DeathCertifyerInfowidths);
            PdfPCell DeathCertifyerNameTableCell = new PdfPCell(DeathDeathCertifyerNameTable15(DeathCertify));
            CellOption(DeathCertifyerNameTableCell);
            PdfPCell DeathCertifyerRelationTableCell = new PdfPCell(DeathDeathCertifyerRelationTable16(DeathCertify));
            CellOption(DeathCertifyerRelationTableCell);
            PdfPCell DeathCertifyerLocationTableCell = new PdfPCell(DeathDeathCertifyerLocationTable17(DeathCertify));
            CellOption(DeathCertifyerLocationTableCell);
            AddCellToTable(DeathCertifyerInfo, new List<PdfPCell> { DeathCertifyerLocationTableCell, DeathCertifyerRelationTableCell, DeathCertifyerNameTableCell });
            PdfPTable medicalCertificate = new PdfPTable(2);
            float[] medicalCertificatewidths = new float[] { 1f, 6f };
            medicalCertificate.SetWidths(medicalCertificatewidths);
            PdfPCell ApproximatePeriodTableCell = new PdfPCell(DeathApproximatePeriodTable18(DeathCertify));
            CellOption(ApproximatePeriodTableCell);
            PdfPCell MedicaldeathCertificateDetailsc = new PdfPCell(DeathMedicaldeathCertificateDetails18(DeathCertify));
            CellOption(MedicaldeathCertificateDetailsc, PaddingTop: -5, BorderWidthLeft: 0.5f);
            AddCellToTable(medicalCertificate, new List<PdfPCell> { ApproximatePeriodTableCell, MedicaldeathCertificateDetailsc });
            PdfPTable DeathIfWomen = new PdfPTable(2);
            float[] DeathIfWomenwidths = new float[] { 0.45f, 5f };
            DeathIfWomen.SetWidths(DeathIfWomenwidths);
            PdfPCell healthInstitutionSeal = new PdfPCell(new Phrase(0, "ختم المؤسسة الصحية", CreateFont()));
            CellOption(healthInstitutionSeal, 1, 0, 1, 1, 5f, 0, 5, 0.5f);
            PdfPCell DeathIfWomenDetailscell = new PdfPCell(DeathIfWomenDetails19(DeathCertify));
            CellOption(DeathIfWomenDetailscell, PaddingTop: -5);
            AddCellToTable(DeathIfWomen, new List<PdfPCell> { healthInstitutionSeal, DeathIfWomenDetailscell });
            PdfPTable DoctorCertifiedCollection = new PdfPTable(2);
            float[] DoctorCertifiedCollectionwidths = new float[] { 1.2f, 2f };
            DoctorCertifiedCollection.SetWidths(DoctorCertifiedCollectionwidths);
            PdfPCell JudgeDecisionTableCell = new PdfPCell(DeathJudgeDecisionTable22(DeathCertify));
            CellOption(JudgeDecisionTableCell);
            PdfPCell DoctorCertifiedc = new PdfPCell(DeathDoctorCertified21(DeathCertify));
            AddCellToTable(DoctorCertifiedCollection, new List<PdfPCell> { JudgeDecisionTableCell, DoctorCertifiedc });
            PdfPTable DeathInfo = new PdfPTable(2);
            float[] DeathInfowidths = new float[] { 28f, 1f };
            DeathInfo.SetWidths(DeathInfowidths);
            PdfPCell DeathText = new PdfPCell(new Phrase(0, "المتوفي", CreateFont()));
            CellOption(DeathText, 1, 1, 1, 3, 0, 0, 0, 0, 0, 0, 0, 90);
            PdfPCell DeathNamec = new PdfPCell(DeathFullName1To8(DeathCertify));
            PdfPCell MaritalStatusc = new PdfPCell(MaritalStatus);
            PdfPCell permanentResidenceCollectionc = new PdfPCell(permanentResidenceCollection);
            PdfPCell DeathCertifyerInfoc = new PdfPCell(DeathCertifyerInfo)
            {
                Colspan = 2
            };
            PdfPCell medicalCertificatec = new PdfPCell(medicalCertificate)
            {
                Colspan = 2
            };
            PdfPCell DeathIfWomenc = new PdfPCell(DeathIfWomen)
            {
                Colspan = 2
            };
            PdfPCell DoctorCertifiedCollectionc = new PdfPCell(DoctorCertifiedCollection)
            {
                Colspan = 2
            };
            PdfPCell ForensicMedicinec = new PdfPCell(DeathForensicMedicine23(DeathCertify))
            {
                Colspan = 2,
                PaddingTop = -5

            };
            PdfPCell NationalityAndCivilStatusc = new PdfPCell(DeathNationalityAndCivilStatus24(DeathCertify))
            {
                Colspan = 2,
            };
            AddCellToTable(DeathInfo, new List<PdfPCell> { DeathNamec, DeathText, MaritalStatusc, permanentResidenceCollectionc, DeathCertifyerInfoc, medicalCertificatec, DeathIfWomenc, DoctorCertifiedCollectionc, ForensicMedicinec, NationalityAndCivilStatusc });
            PdfPTable MainTable = new PdfPTable(2);
            float[] MainTablewidths = new float[] { 6.8f, 1f };
            MainTable.SetWidths(MainTablewidths);
            PdfPCell RotateTablec = new PdfPCell(DeathRotateTable(DeathCertify))
            {
                Rotation = 90
            };
            PdfPCell deathInfoc = new PdfPCell(DeathInfo);
            AddCellToTable(MainTable, new List<PdfPCell> { deathInfoc, RotateTablec });
            document.Add(DeathTitle(DeathCertify));
            document.Add(Picture(740, 440, 75, 75));
            document.Add(MainTable);
            document.Add(DeathFootTable(DeathCertify));
            document.Close();
            byte[] byteInfo = m.ToArray();
            m.Write(byteInfo, 0, byteInfo.Length);
            m.Position = 0;
            return new FileStreamResult(m, "application/pdf");
        }
        public static FileStreamResult CreateDeathCertifiedRatification(DeathCertified DeathCertify)
        {
            MemoryStream m = new MemoryStream();
            var document = new Document(PageSize.A4, 20, 20, 10, 10);
            PdfWriter.GetInstance(document, m).CloseStream = false;
            document.Open();
            PdfPTable Title = new PdfPTable(3);
            PdfPCell HealthDepartment = new PdfPCell(new Phrase(0, "وزارة الصحة\n\nدائرة التخطيط و تنمية الموارد\n\nقسم الإحصاء الصحي والحياتي", CreateFont(12, 1)));
            CellOption(HealthDepartment, 1, 5, 1, 1, 5);
            PdfPCell ConstraintImage = new PdfPCell(new Phrase(0, "صورة قيد وفاة\n\nط 1", CreateFont(12, 1)));
            CellOption(ConstraintImage, 1, 5, 1, 1, 5);
            PdfPCell CertifyInfo = new PdfPCell(new Phrase(0, "رقم الشهادة الأصلية : " + DeathCertify.CertificateNo + "\n\nتاريخ تنظيمها : " + DeathCertify.IssueDatetime.ToShortDateString(), CreateFont(12, 1)));
            CellOption(CertifyInfo, 1);
            AddCellToTable(Title, new List<PdfPCell> { CertifyInfo, ConstraintImage, HealthDepartment });
            PdfPTable Address = new PdfPTable(2);
            PdfPCell confirm = new PdfPCell(new Phrase(0, "\n\nإلى / " + DeathCertify.To + "\n\n\n نؤيد لكم بأن الوفاة المسجلة أوصافها أدناه قد سجلت لدينا في سجل الوفيات ", CreateFont(12, 1)));
            CellOption(confirm, 0, 30, 2, 1, 5);
            PdfPCell Sequence = new PdfPCell(new Phrase(0, "\n\nتحت تسلسل : " + DeathCertify.RegisteredNo, CreateFont(12, 1)));
            CellOption(Sequence, 0, 30);
            PdfPCell ForYear = new PdfPCell(new Phrase(0, "\n\nلسنة : " + DeathCertify.RegisteredYear, CreateFont(12, 1)));
            CellOption(ForYear, 0, 30);
            AddCellToTable(Address, new List<PdfPCell> { confirm, ForYear, Sequence });
            PdfPTable BirthInfo = new PdfPTable(3);
            float[] BirthInfoWidth = new float[] { 1f, 1f, 1.5f };
            BirthInfo.SetWidths(BirthInfoWidth);
            PdfPCell BirthName = new PdfPCell(new Phrase(0, "\n\nإسم المتوفي : " + DeathCertify.FirstName, CreateFont(12, 1)));
            CellOption(BirthName, 0, 30);
            PdfPCell Gender = new PdfPCell(new Phrase(0, "\n\nالجنس : " + DeathCertify.Gender, CreateFont(12, 1)));
            CellOption(Gender, 0, 30, 2);
            PdfPCell FatherName = new PdfPCell(new Phrase(0, "\n\nإسم الأب : " + DeathCertify.SecondName + " " + DeathCertify.ThirdName, CreateFont(12, 1)));
            CellOption(FatherName, 0, 30);
            PdfPCell FatherReligion = new PdfPCell(new Phrase(0, "\n\nألديانة : " + DeathCertify.FatherReligion, CreateFont(12, 1)));
            CellOption(FatherReligion, 0, 30);
            PdfPCell FatherNationality = new PdfPCell(new Phrase(0, "\n\nجنسية الأب : " + DeathCertify.FatherNationality, CreateFont(12, 1)));
            CellOption(FatherNationality, 0, 30);
            PdfPCell MotherName = new PdfPCell(new Phrase(0, "\n\nإسم الأم : " + DeathCertify.MotherFirstName + " " + DeathCertify.MotherSecondName + " " + DeathCertify.MotherThirdName, CreateFont(12, 1)));
            CellOption(MotherName, 0, 30);
            PdfPCell MotherReligion = new PdfPCell(new Phrase(0, "\n\nألديانة : " + DeathCertify.MotherReligion, CreateFont(12, 1)));
            CellOption(MotherReligion, 0, 30);
            PdfPCell MotherNationality = new PdfPCell(new Phrase(0, "\n\nجنسية الأم : " + DeathCertify.MotherNationality, CreateFont(12, 1)));
            CellOption(MotherNationality, 0, 30);
            PdfPCell NumericBirthDate = new PdfPCell(new Phrase(0, "\n\nتاريخ الوفاة رقماً  : " + DeathCertify.DeathDate.ToShortDateString(), CreateFont(12, 1)));
            CellOption(NumericBirthDate, 0, 30, 3);
            PdfPCell WritingBirthDate = new PdfPCell(new Phrase(0, "\n\nتاريخ الوفاة كتابةً  : " + Convert(DeathCertify.DeathDate.Year.ToString())
                                                                   + " الشهر " + Convert(DeathCertify.DeathDate.Month.ToString()) + " يوم "
                                                                   + DeathCertify.DeathDate.ToString("dddd", new CultureInfo("ar-AE")), CreateFont(12, 1)));
            CellOption(WritingBirthDate, 0, 30, 3);
            AddCellToTable(BirthInfo, new List<PdfPCell>{ Gender, BirthName, FatherNationality, FatherReligion, FatherName
                , MotherNationality, MotherReligion, MotherName, NumericBirthDate, WritingBirthDate });
            string HouseS = "", HospitalS = "", OtherS = "";
            if (DeathCertify.DeathPlace == "بيت") HouseS = "";
            else if (DeathCertify.DeathPlace == "مستشفى") HospitalS = "";
            else if (DeathCertify.DeathPlace == "أخرى") OtherS = "";
            PdfPTable BirthPlace = new PdfPTable(6);
            float[] BirthPlaceWidth = new float[] { 0.5f, 1f, 0.5f, 1f, 0.5f, 1.5f };
            BirthPlace.SetWidths(BirthPlaceWidth);
            PdfPCell House = new PdfPCell(new Phrase(0, "\n\n محل وقوع الوفاة :        بيت ", CreateFont(12, 1)));
            CellOption(House, 0, 30);
            PdfPCell HouseMark = new PdfPCell(new Phrase(0, "\n\n" + HouseS, CreateFont(12, 0, true)));
            CellOption(HouseMark, 0, 30);
            PdfPCell BirthHospital = new PdfPCell(new Phrase(0, "\n\n مستشفى ", CreateFont(12, 1)));
            CellOption(BirthHospital, 0, 30);
            PdfPCell HospitalMark = new PdfPCell(new Phrase(0, "\n\n" + HospitalS, CreateFont(12, 0, true)));
            CellOption(HospitalMark, 0, 30);
            PdfPCell Other = new PdfPCell(new Phrase(0, "\n\n أخرى ", CreateFont(12, 1)));
            CellOption(Other, 0, 30);
            PdfPCell OtherMark = new PdfPCell(new Phrase(0, "\n\n" + OtherS, CreateFont(12, 0, true)));
            CellOption(OtherMark, 0, 30);
            PdfPCell InformerName = new PdfPCell(new Phrase(0, "\n\n إسم المخبر عن الوفاة :  " + DeathCertify.InformerFullName, CreateFont(12, 1)));
            CellOption(InformerName, 0, 30, 6);
            PdfPCell NationalityName = new PdfPCell(new Phrase(0, "\n\n معلومات خاصة بمديرية الجنسية و الأحوال المدنية : ", CreateFont(12, 1)));
            CellOption(NationalityName, 0, 30, 2);
            PdfPCell RecordName = new PdfPCell(new Phrase(0, "\n\nرقم السجل : " + DeathCertify.RecordNo, CreateFont(12, 1)));
            CellOption(RecordName, PaddingRight: 30, Colspan: 2);
            PdfPCell PageNumber = new PdfPCell(new Phrase(0, "\n\n رقم الصفحة : " + DeathCertify.PageNo, CreateFont(12, 1)));
            CellOption(PageNumber, 0, 50, 2);
            PdfPCell IdentifierNo = new PdfPCell(new Phrase(0, "\n\n رقم البطاقة الوطنية : " + DeathCertify.IdentifierNo, CreateFont(12, 1)));
            CellOption(IdentifierNo, 0, 40, 4);
            PdfPCell PassBoardNumber = new PdfPCell(new Phrase(0, "\n\n رقم الجواز : " /*+ DeathCertify.PassBoardNumber*/, CreateFont(12, 1)));
            CellOption(PassBoardNumber, 0, 40, 4);
            PdfPCell NationalityDepartment = new PdfPCell(new Phrase(0, "\n\n دائرة جنسية و أحوال : " + DeathCertify.NationalDepartment, CreateFont(12, 1)));
            CellOption(NationalityDepartment, 2, 0, 3, 1, 0, 25);
            PdfPCell NationalityProvince = new PdfPCell(new Phrase(0, "\n\n محافظة : " + DeathCertify.NationalProvince, CreateFont(12, 1)));
            CellOption(NationalityProvince, 0, 40, 3);
            PdfPCell OrganizerName = new PdfPCell(new Phrase(0, "\n\n إسم المنظم : " + " " + DeathCertify.OrganizerName + "\n\n\nالتوقيع : ", CreateFont(12, 1)));
            CellOption(OrganizerName, 0, 30, 2);
            PdfPCell DoctorName = new PdfPCell(new Phrase(0, "\n\n  إسم الدكتور : " + " " + DeathCertify.DoctorName + "\n\n\nالتوقيع : ", CreateFont(12, 1)));
            CellOption(DoctorName, 0, 5, 4);
            /*  if (DeathCertify.IdentifierNo != null || DeathCertify.IdentifierNo != "")
              {
                  AddCellToTable(BirthPlace, OtherMark, Other, HospitalMark, BirthHospital, HouseMark, House, InformerName, IdentifierNo, NationalityName, NationalityProvince, NationalityDepartment, DoctorName, OrganizerName);
              }
              if()
              {
                  AddCellToTable(BirthPlace, OtherMark, Other, HospitalMark, BirthHospital, HouseMark, House, InformerName, PassBoardNumber, NationalityName, NationalityProvince, NationalityDepartment, DoctorName, OrganizerName);
              }
              if ()
              {*/
            AddCellToTable(BirthPlace, new List<PdfPCell> { OtherMark, Other, HospitalMark, BirthHospital, HouseMark, House, InformerName, PageNumber, RecordName, NationalityName, NationalityProvince, NationalityDepartment, DoctorName, OrganizerName });
            //}
            document.Add(Title);
            document.Add(Address);
            document.Add(BirthInfo);
            document.Add(BirthPlace);
            document.Add(new Paragraph("\n"));
            document.Close();
            byte[] byteInfo = m.ToArray();
            m.Write(byteInfo, 0, byteInfo.Length);
            m.Position = 0;
            return new FileStreamResult(m, "application/pdf");
        }
        public static FileStreamResult CreatePublicationCorrectness(DeathCertified DeathCertify)
        {
            MemoryStream m = new MemoryStream();
            var document = new Document(PageSize.A4, 20, 20, 10, 10);
            PdfWriter.GetInstance(document, m).CloseStream = false;
            document.Open();
            PdfPTable Border = new PdfPTable(1);
            PdfPTable Title = new PdfPTable(4);
            PdfPCell TheRepublicofIraq = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("جمهورية العراق \nوزارة الصحة \nدائرة " + DeathCertify.CertificateDepartment + "" +
                "\nمستشفى " + DeathCertify.HospitalName + "\nشعبة الإحصاء \nوحدة الوفيات")), CreateFont()));
            CellOption(TheRepublicofIraq, PaddingRight: 5, PaddingTop: 5, PaddingBottom: 5);
            PdfPCell MapCell = new PdfPCell(Picture(100, 100, 100, 100));
            CellOption(MapCell, PaddingTop: 5, PaddingBottom: 5);
            PdfPCell LogoCell = new PdfPCell(Picture(100, 100, 100, 100, false, Picture3Path, true));
            CellOption(LogoCell, PaddingTop: 5, PaddingBottom: 5);
            PdfPCell Business = new PdfPCell(Picture(100, 100, 100, 100, false, Picture2Path, true));
            CellOption(Business, PaddingTop: 5, PaddingBottom: 5);
            AddCellToTable(Title, new List<PdfPCell> { Business, LogoCell, MapCell, TheRepublicofIraq });
            PdfPCell TitleCell = new PdfPCell(Title);
            PdfPTable MainTable = new PdfPTable(2);
            float[] MainTableWidth = new float[] { 2f, 1.5f };
            MainTable.SetWidths(MainTableWidth);
            PdfPCell NumberAndDate = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("العدد : \n\n التاريخ : ")), CreateFont()));
            CellOption(NumberAndDate, PaddingRight: 5, Colspan: 2);
            PdfPCell To = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("إلى /")), CreateFont()));
            CellOption(To, PaddingTop: 10, PaddingRight: 45, Colspan: 2);
            PdfPCell Subject = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("م / تأييد وفاة")), CreateFont()));
            CellOption(Subject, 1, PaddingRight: 5, Colspan: 2);
            PdfPCell Text = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("\n إشارة إلى كتابكم المرقم ( " + "        "/*DeathCertify.BookNo*/ + " ) في " + "               "/*DeathCertify.BookIssueDate.ToString("dd/MM/yyyy")*/
                + " نود إعلامكم بإن الوفاة المسجلة أوصافها أدناه قد سجلت لدينا في سجل الوفيات تحت تسلسل  " + " ( " + DeathCertify.CertificateNo + " ) " + " لسنة ( " + DeathCertify.BookIssueDate.Year + " ) " +
                "\n\n للتقضل بالإطلاع مع التقدير ...... ")), CreateFont()));
            CellOption(Text, 0, PaddingRight: 5, Colspan: 2);
            PdfPCell Signature = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("الجراح الإستشاري \n" /*DeathCertify+*/)), CreateFont()));
            CellOption(Signature, 2, PaddingLeft: 5, Colspan: 2, PaddingTop: 150);
            PdfPCell HospitalManager = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("\n مدير مستشفى " + DeathCertify.HospitalName)), CreateFont()));
            CellOption(HospitalManager, 2, PaddingLeft: 5, Colspan: 2);
            PdfPCell Descriptions = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("(( الأوصاف ))")), CreateFont()));
            CellOption(Descriptions, 1, PaddingRight: 5, Colspan: 2, PaddingBottom: 15);
            PdfPCell DeathName = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("1- إسم المتوفي : " + DeathCertify.FirstName)), CreateFont()));
            CellOption(DeathName, 0, PaddingRight: 5);
            PdfPCell DeathDate = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("10- تاريخ الوفاة : " + DeathCertify.DeathDate.ToString("dd/MM/yyyy"))), CreateFont()));
            CellOption(DeathDate, 0, PaddingRight: 5);
            PdfPCell DeathFatherName = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("2- إسم الأب : " + DeathCertify.SecondName)), CreateFont()));
            CellOption(DeathFatherName, 0, PaddingRight: 5, PaddingTop: 5);
            PdfPCell OrginazationDate = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("11- تاريخ التنظيم : " + DeathCertify.IssueDatetime.ToString("dd/MM/yyyy"))), CreateFont()));
            CellOption(OrginazationDate, 0, PaddingRight: 5, PaddingTop: 5);
            PdfPCell DeathMotherName = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("3- إسم الأم : " + DeathCertify.MotherFirstName)), CreateFont()));
            CellOption(DeathMotherName, 0, PaddingRight: 5, PaddingTop: 5);
            PdfPCell CertificateNumber = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("12- رقم شهادة الوفاة  : " + DeathCertify.CertificateNo)), CreateFont()));
            CellOption(CertificateNumber, 0, PaddingRight: 5, PaddingTop: 5);
            PdfPCell DeathGender = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("4- الجنس : " + DeathCertify.Gender)), CreateFont()));
            CellOption(DeathGender, 0, PaddingRight: 5, PaddingTop: 5);
            PdfPCell MaritalStatus = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("13- الحالة المدنية : " + DeathCertify.RelationID)), CreateFont()));
            CellOption(MaritalStatus, 0, PaddingRight: 5, PaddingTop: 5);
            PdfPCell DeadNationality = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("5- الجنسية : " + DeathCertify.Nationality)), CreateFont()));
            CellOption(DeadNationality, 0, PaddingRight: 5, PaddingTop: 5);
            PdfPCell RecordNumber = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("14- رقم السجل : " + DeathCertify.RecordNo)), CreateFont()));
            CellOption(RecordNumber, 0, PaddingRight: 5, PaddingTop: 5);
            PdfPCell DeadReligion = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("6- الديانة : " + DeathCertify.Religion)), CreateFont()));
            CellOption(DeadReligion, 0, PaddingRight: 5, PaddingTop: 5);
            PdfPCell PageNumber = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("15- رقم الصحيفة  : " + DeathCertify.PageNo)), CreateFont()));
            CellOption(PageNumber, 0, PaddingRight: 5, PaddingTop: 5);
            PdfPCell DeadJob = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("7- المهنة : " + DeathCertify.Occupation)), CreateFont()));
            CellOption(DeadJob, 0, PaddingRight: 5, PaddingTop: 5);
            PdfPCell DoctorName = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("16- إسم الطبيب  : " + DeathCertify.DoctorName)), CreateFont()));
            CellOption(DoctorName, 0, PaddingRight: 5, PaddingTop: 5);
            PdfPCell DeadAge = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("8- العمر : " + (DateTime.Now.Year - DeathCertify.Birthdate.Year).ToString())), CreateFont()));
            CellOption(DeadAge, 0, PaddingRight: 5, PaddingTop: 5, Colspan: 2);
            PdfPCell DeathReason = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("9- سبب الوفاة  : ( " + DeathCertify.FirstReason + " )")), CreateFont()));
            CellOption(DeathReason, 0, PaddingRight: 5, PaddingTop: 5, Colspan: 2);
            PdfPCell MortalityUnitOfficial = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(" مسئول وحدة الوفيات ")), CreateFont()));
            CellOption(MortalityUnitOfficial, 1, PaddingRight: 5, PaddingTop: 210, PaddingBottom: 10);
            PdfPCell StatisticsManager = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(/*DeathCertify.DoctorName */"" + "\n" + " مدير شعبة الإحصاء ")), CreateFont()));
            CellOption(StatisticsManager, 1, PaddingRight: 5, PaddingTop: 200, PaddingBottom: 10);
            AddCellToTable(MainTable, new List<PdfPCell>{ NumberAndDate, To, Subject, Text, Descriptions, DeathDate, DeathName,
                           OrginazationDate, DeathFatherName, CertificateNumber, DeathMotherName, MaritalStatus, DeathGender
                           , RecordNumber, DeadNationality, DoctorName, DeadJob, DeadAge, DeathReason, Signature, HospitalManager, StatisticsManager, MortalityUnitOfficial });
            PdfPCell MainCell = new PdfPCell(MainTable);
            AddCellToTable(Border, new List<PdfPCell> { TitleCell, MainCell });
            document.Add(Border);
            document.Close();
            var byteInfo = m.ToArray();
            m.Write(byteInfo, 0, byteInfo.Length);
            m.Position = 0;
            return new FileStreamResult(m, "application/pdf");
        }
        public static FileStreamResult CreateDeathEndorsement(DeathCertified DeathCertify)
        {
            MemoryStream m = new MemoryStream();
            var document = new Document(PageSize.A4, 20, 20, 10, 10);
            PdfWriter.GetInstance(document, m).CloseStream = false;
            document.Open();
            PdfPTable Border = new PdfPTable(1);
            PdfPTable Title = new PdfPTable(4);
            PdfPCell TheRepublicofIraq = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("جمهورية العراق \nوزارة الصحة \nدائرة " + DeathCertify.CertificateDepartment + "" +
                "\nمستشفى " + DeathCertify.HospitalName + "\nشعبة الإحصاء \nوحدة الوفيات")), CreateFont()));
            CellOption(TheRepublicofIraq, PaddingRight: 5, PaddingTop: 5, PaddingBottom: 5);
            PdfPCell MapCell = new PdfPCell(Picture(100, 100, 100, 100));
            CellOption(MapCell, PaddingTop: 5, PaddingBottom: 5);
            PdfPCell LogoCell = new PdfPCell(Picture(100, 100, 100, 100, false, Picture3Path, true));
            CellOption(LogoCell, PaddingTop: 5, PaddingBottom: 5);
            PdfPCell Business = new PdfPCell(Picture(100, 100, 100, 100, false, Picture2Path, true));
            CellOption(Business, PaddingTop: 5, PaddingBottom: 5);
            AddCellToTable(Title, new List<PdfPCell> { Business, LogoCell, MapCell, TheRepublicofIraq });
            PdfPCell TitleCell = new PdfPCell(Title);
            PdfPTable MainTable = new PdfPTable(2);
            PdfPCell NumberAndDate = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("العدد : \n\n التاريخ : ")), CreateFont()));
            CellOption(NumberAndDate, PaddingRight: 5, Colspan: 2);
            PdfPCell To = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("إلى /")), CreateFont()));
            CellOption(To, PaddingTop: 10, PaddingRight: 45, Colspan: 2);
            PdfPCell Subject = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("م / صحة صدور")), CreateFont()));
            CellOption(Subject, 1, PaddingRight: 5, Colspan: 2);
            PdfPCell Text = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("تحية طيبة ..\n\n إشارة إلى كتابكم المرقم ( " + DeathCertify.BookNo + " ) في " + DeathCertify.BookIssueDate.ToString("dd/MM/yyyy") + " "
                + " نؤيد لكم صحة صدور شهادة الوفاة المرقمة " + "(" + DeathCertify.CertificateNo + ")" + " في " + DeathCertify.IssueDatetime.ToString("dd / MM / yyyy") +
                " والعائدة للمتوفي " + DeathCertify.FirstName + " " + DeathCertify.SecondName + " " + DeathCertify.ThirdName + " وإسم الأم ( " + DeathCertify.MotherFirstName + " ) "
                + "علماً إن سبب الوفاة ( " + DeathCertify.ReasonA + " ) " + "ونظمت من قبل الطبيب " + DeathCertify.DoctorName + " في  " + DeathCertify.IssueDatetime.ToString("dd / MM / yyyy")
                + " راجين التفضل بالإطلاع مع التقدير ......")), CreateFont()));
            CellOption(Text, 0, PaddingRight: 5, Colspan: 2);
            PdfPCell Signature = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("الجراح الإستشاري \n" +/*DeathCertify+*/"\n مدير مستشفى " + DeathCertify.HospitalName)), CreateFont()));
            CellOption(Signature, 2, PaddingLeft: 5, PaddingTop: 250, Colspan: 2);
            PdfPCell MortalityUnitOfficial = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(" مسئول وحدة الوفيات ")), CreateFont()));
            CellOption(MortalityUnitOfficial, 1, PaddingRight: 5, PaddingTop: 240, PaddingBottom: 10);
            PdfPCell StatisticsManager = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(/*DeathCertify.DoctorName*/"        " + "\n" + " مدير شعبة الإحصاء ")), CreateFont()));
            CellOption(StatisticsManager, 1, PaddingRight: 5, PaddingTop: 225, PaddingBottom: 10);
            AddCellToTable(MainTable,new List<PdfPCell> { NumberAndDate, To, Subject, Text, Signature, StatisticsManager, MortalityUnitOfficial });
            PdfPCell MainCell = new PdfPCell(MainTable);
            AddCellToTable(Border, new List<PdfPCell> { TitleCell, MainCell });
            document.Add(Border);
            document.Close();
            var byteInfo = m.ToArray();
            m.Write(byteInfo, 0, byteInfo.Length);
            m.Position = 0;
            return new FileStreamResult(m, "application/pdf");
        }
        public static FileStreamResult CreateDeathNew(DeathCertified DeathCertify)
        {
            MemoryStream m = new MemoryStream();
            var document = new Document(PageSize.A4, 20, 20, 10, 10);
            PdfWriter.GetInstance(document, m).CloseStream = false;
            document.Open();
            PdfPTable Border = new PdfPTable(1);
            PdfPTable Title = new PdfPTable(2);
            PdfPCell TheRepublicofIraq = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("جمهورية العراق \nوزارة الصحة والبيئة  \nدائرة : " + DeathCertify.CertificateDepartment)), CreateFont()));
            CellOption(TheRepublicofIraq, PaddingRight: 5, Colspan: 2);
            PdfPCell PlaningDepartment = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("قسم التخطيط وتنمية الموارد ")), CreateFont()));
            CellOption(PlaningDepartment, PaddingRight: 5);
            PdfPCell Number = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(" العدد : ")), CreateFont()));
            CellOption(Number, 1);
            PdfPCell Office = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("مكتب الولادات و الوفيات ")), CreateFont()));
            CellOption(Office, PaddingRight: 5, PaddingBottom: 10);
            PdfPCell Date = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(" التاريخ : " + "      /       /2020")), CreateFont()));
            CellOption(Date, 1, 80, PaddingBottom: 10);
            document.Add(Picture(260, 760, 70, 70));
            AddCellToTable(Title, new List<PdfPCell> { TheRepublicofIraq, Number, PlaningDepartment, Date, Office });
            PdfPCell TitleCell = new PdfPCell(Title);
            PdfPTable MainTable = new PdfPTable(2);
            PdfPCell To = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("إلى /")), CreateFont()));
            CellOption(To, PaddingTop: 10, PaddingRight: 45, Colspan: 2);
            PdfPCell Subject = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("م / صورة قيد وفاة مع صحة صدور")), CreateFont(16, 1)));
            CellOption(Subject, 1, PaddingRight: 5, Colspan: 2);
            PdfPCell Text = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("تحية طيبة ..\n\n إستناداً إلى كتابكم ذي العدد ( " + DeathCertify.BookNo + " ) بتاريخ " + DeathCertify.BookIssueDate.ToString("dd/MM/yyyy") + " "
                + "\n\n نرفق لكم صورة قيد وفاة " + "(" + DeathCertify.FirstName + " " + DeathCertify.SecondName + " " + DeathCertify.ThirdName + " ) " + " صاحب شهادة الوفاة \n\n المرقمة  " + DeathCertify.CertificateNo + " بتاريخ تنظيم  "
                + DeathCertify.IssueDatetime.ToString("dd/MM/yyyy") + "\n\n نؤكد صحة صدور قيد الوفاة العائدة له قدر تعلق مكتب الولادات و الوفيات في دائرتنا \n\n علماً إن الوفاة حدثت في مستشفى " + DeathCertify.HospitalName + " في دائرة " + DeathCertify.CertificateDepartment + ".")), CreateFont()));
            CellOption(Text, 0, PaddingRight: 5, Colspan: 2);
            PdfPCell WithRespect = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("***  مع الإحترام  ***")), CreateFont(16, 1)));
            CellOption(WithRespect, 1, PaddingTop: 10, PaddingRight: 45, Colspan: 2);

            PdfPCell accompanyingTitle = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("المرافقات : ")), CreateFont(14, 5)));
            CellOption(accompanyingTitle, 0, PaddingRight: 10, PaddingTop: 25);

            PdfPCell accompanying = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("كتابكم المرقم اعلاه .                ( نسخة ضوئية )" + "\n\n صور قيد وفاة المرقمة    " + DeathCertify.CertificateNo + "      (نسخة ضوئية ) ")), CreateFont()));
            CellOption(accompanying, 0, PaddingRight: -225, PaddingTop: 28);

            PdfPCell Signature = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("الدكتور ")), CreateFont()));
            CellOption(Signature, 2, PaddingLeft: 50, PaddingTop: 180, Colspan: 2);

            PdfPCell CopiesTitle = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("صورة عنه إلى  : ")), CreateFont(14, 5)));
            CellOption(CopiesTitle, 0, PaddingRight: 10, PaddingTop: 180, PaddingBottom: 50);

            PdfPCell Copies = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("قسم التخطيط و تنمية الموارد / مكتب الولادات و الوفيات / " + DeathCertify.FirstName + " " + DeathCertify.SecondName + " " + DeathCertify.ThirdName + "\n\n" + DateTime.Now.ToString("dd/MM/yyyy"))), CreateFont()));
            CellOption(Copies, 0, PaddingRight: -190, PaddingTop: 183, PaddingBottom: 50);

            AddCellToTable(MainTable, new List<PdfPCell> { To, Subject, Text, WithRespect, accompanying, accompanyingTitle, Signature, Copies, CopiesTitle });
            PdfPCell MainCell = new PdfPCell(MainTable);
            AddCellToTable(Border, new List<PdfPCell> { TitleCell, MainCell});
            document.Add(Border);
            document.Close();
            var byteInfo = m.ToArray();
            m.Write(byteInfo, 0, byteInfo.Length);
            m.Position = 0;
            return new FileStreamResult(m, "application/pdf");
        }
        public static FileStreamResult CreateDeathNew2(DeathCertified DeathCertify)
        {
            MemoryStream m = new MemoryStream();
            var document = new Document(PageSize.A4, 20, 20, 10, 10);
            PdfWriter.GetInstance(document, m).CloseStream = false;
            document.Open();
            PdfPTable Border = new PdfPTable(1);
            PdfPTable Title = new PdfPTable(2);
            PdfPCell TheRepublicofIraq = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("جمهورية العراق \nوزارة الصحة والبيئة  \nدائرة : " + DeathCertify.CertificateDepartment)), CreateFont()));
            CellOption(TheRepublicofIraq, PaddingRight: 5, Colspan: 2);
            PdfPCell PlaningDepartment = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("قسم التخطيط وتنمية الموارد ")), CreateFont()));
            CellOption(PlaningDepartment, PaddingRight: 5);
            PdfPCell Number = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(" العدد : ")), CreateFont()));
            CellOption(Number, 1);
            PdfPCell Office = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("مكتب الولادات و الوفيات ")), CreateFont()));
            CellOption(Office, PaddingRight: 5, PaddingBottom: 10);
            PdfPCell Date = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(" التاريخ : " + "      /       /2020")), CreateFont()));
            CellOption(Date, 1, 80, PaddingBottom: 10);
            document.Add(Picture(260, 760, 70, 70));
            AddCellToTable(Title, new List<PdfPCell> { TheRepublicofIraq, Number, PlaningDepartment, Date, Office });
            PdfPCell TitleCell = new PdfPCell(Title);
            PdfPTable MainTable = new PdfPTable(2);
            PdfPCell To = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("إلى / قسم الأمور الإدارية والمالية والقانونية / شعبة القانونية ")), CreateFont()));
            CellOption(To, PaddingTop: 10, PaddingRight: 45, Colspan: 2, PaddingBottom: 15);
            PdfPCell Subject = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("م / صورة قيد وفاة مع صحة صدور")), CreateFont(16, 1)));
            CellOption(Subject, 1, PaddingRight: 5, Colspan: 2);
            PdfPCell Text = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("تحية طيبة ..\n\n إستناداً إلى كتاب محكمة الأحوال الشخصية ذي العدد (               " + /*DeathCertify.BookNo +*/ " ) بتاريخ " /*+ DeathCertify.BookIssueDate.ToString("dd/MM/yyyy")*/ + " "
                + "\n\n نرفق لكم صورة قيد وفاة " + "(" + DeathCertify.FirstName + " " + DeathCertify.SecondName + " " + DeathCertify.ThirdName + " ) " + " صاحب شهادة الوفاة \n\n المرقمة  " + DeathCertify.CertificateNo + " بتاريخ تنظيم  "
                + DeathCertify.IssueDatetime.ToString("dd/MM/yyyy") + "\n\n نؤكد صحة صدور قيد الوفاة العائدة له قدر تعلق مكتب الولادات و الوفيات في دائرتنا \n\n علماً إن الوفاة حدثت في مستشفى " + DeathCertify.HospitalName + " في دائرة " + DeathCertify.CertificateDepartment + ".")), CreateFont()));
            CellOption(Text, 0, PaddingRight: 5, Colspan: 2);
            PdfPCell WithRespect = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("***  مع الإحترام  ***")), CreateFont(16, 1)));
            CellOption(WithRespect, 1, PaddingTop: 10, PaddingRight: 45, Colspan: 2);

            PdfPCell accompanyingTitle = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("المرافقات : ")), CreateFont(14, 5)));
            CellOption(accompanyingTitle, 0, PaddingRight: 10, PaddingTop: 25);

            PdfPCell accompanying = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("كتاب المحكمة اعلاه .                ( نسخة ضوئية )" + "\n\n صور قيد وفاة المرقمة    " + DeathCertify.CertificateNo + "      (نسخة أصلية ) ")), CreateFont()));
            CellOption(accompanying, 0, PaddingRight: -225, PaddingTop: 28);

            PdfPCell Signature = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("الصيدلانية  ")), CreateFont()));
            CellOption(Signature, 2, PaddingLeft: 50, PaddingTop: 210, Colspan: 2);

            PdfPCell CopiesTitle = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("صورة عنه إلى  : ")), CreateFont(14, 5)));
            CellOption(CopiesTitle, 0, PaddingRight: 10, PaddingTop: 180, PaddingBottom: 50);

            PdfPCell Copies = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("قسم التخطيط و تنمية الموارد / مكتب الولادات و الوفيات / " + DeathCertify.FirstName + " " + DeathCertify.SecondName + " " + DeathCertify.ThirdName)), CreateFont()));
            CellOption(Copies, 0, PaddingRight: -190, PaddingTop: 183, PaddingBottom: 50);

            AddCellToTable(MainTable, new List<PdfPCell> { To, Subject, Text, WithRespect, accompanying, accompanyingTitle, Signature, Copies, CopiesTitle });
            PdfPCell MainCell = new PdfPCell(MainTable);
            AddCellToTable(Border, new List<PdfPCell> { TitleCell, MainCell });
            document.Add(Border);
            document.Close();
            var byteInfo = m.ToArray();
            m.Write(byteInfo, 0, byteInfo.Length);
            m.Position = 0;
            return new FileStreamResult(m, "application/pdf");
        }
        public static FileStreamResult CreateBirthEndorsement(CertifiedInfo certifiedInfo)
        {
            MemoryStream m = new MemoryStream();
            var document = new Document(PageSize.A4, 20, 20, 10, 10);
            PdfWriter.GetInstance(document, m).CloseStream = false;
            document.Open();
            PdfPTable Border = new PdfPTable(1);
            PdfPTable Title = new PdfPTable(3);
            PdfPCell TheRepublicofIraq = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("جمهورية العراق \nوزارة الصحة والبيئة\nدائرة " + certifiedInfo.HealthDepartment + " قسم التخطيط و تنمية الموارد \n مكتب الولادات و الوفيات")), CreateFont()));
            CellOption(TheRepublicofIraq, PaddingRight: 5, PaddingTop: 15, PaddingBottom: 5);
            PdfPCell LogoCell = new PdfPCell(Picture(100, 100, 100, 100, false, PicturePath, true));
            CellOption(LogoCell, 1, PaddingTop: 5);
            PdfPCell NumberAndDate = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("العدد : \n التاريخ : ")), CreateFont()));
            CellOption(NumberAndDate, PaddingRight: 5, PaddingTop: 40);
            AddCellToTable(Title, new List<PdfPCell> { NumberAndDate, LogoCell, TheRepublicofIraq });
            PdfPCell TitleCell = new PdfPCell(Title);
            CellOption(TitleCell, PaddingBottom: 25, BorderWidthBottom: 0, BorderWidthRight: 0.5f, BorderWidthTop: 0.5f, BorderWidthLeft: 0.5f);
            PdfPTable MainTable = new PdfPTable(2);
            PdfPCell To = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("إلى /")), CreateFont()));
            CellOption(To, 1, 0, PaddingTop: 10, PaddingBottom: 5, Colspan: 2);
            PdfPCell Subject = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(" م / صحة صدور شهادة ولادة")), CreateFont()));
            CellOption(Subject, 1, PaddingRight: 5, Colspan: 2);
            PdfPCell Text1 = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("تحية طيبة ..\n\n إستناداً إلى كتابكم ذي العدد  (               )  بتاريخ  " +
                "        /        /            "
                + " نرفق لكم نسخة ضوئية من شهادة الولادة المرقمة " + "(" + certifiedInfo.CertifyNumber + ")  بتاريخ  ")), CreateFont()));
            CellOption(Text1, PaddingRight: 5, PaddingBottom: 5, Colspan: 2);
            PdfPCell Text2 = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(" تنظيم  " + certifiedInfo.OrginazationDate.ToString("dd / MM / yyyy" +
                " وتاريخ ولادة " + certifiedInfo.BirthDate.ToString("dd / MM / yyyy") + " والعائدة للمولودة " + "(" + certifiedInfo.BirthName + " " + certifiedInfo.FatherName + ") " +
                "نؤكد صحة صدور شهادة الولادة العائدة لها  "))), CreateFont()));
            CellOption(Text2, PaddingRight: 5, PaddingBottom: 5, Colspan: 2);
            PdfPCell Text3 = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(" والصادرة من مكتب" + " الولادات و الوفيات في دائرة " + certifiedInfo.HealthDepartment + " إستناداً لكتاب تأييد الولادة الصادر من مستشفى " + certifiedInfo.HospitalName)), CreateFont()));
            CellOption(Text3, PaddingRight: 5, PaddingBottom: 5, Colspan: 2);
            PdfPCell Text4 = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(" المرقم " + "                       " + "بتاريخ " + "                              ")), CreateFont()));
            CellOption(Text4, PaddingRight: 5, PaddingBottom: 5, Colspan: 2);
            PdfPCell WithRespect = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("........ مع الإحترام .")), CreateFont()));
            CellOption(WithRespect, 1, PaddingRight: 5, PaddingBottom: 5, Colspan: 2);
            PdfPCell Attachments = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("المرفقات : كتابكم المرقم أعلاه\n              نسخة ضوئية من شهادة الولادة المرقمة أعلاه")), CreateFont()));
            CellOption(Attachments, 0, PaddingRight: 5, PaddingBottom: 5, Colspan: 2);
            PdfPCell DoctorSignature = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(" الدكتور")), CreateFont()));
            CellOption(DoctorSignature, 2, PaddingLeft: 40, PaddingTop: 200, Colspan: 2);
            PdfPCell PositionSignature = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("\n سحر عبد الوهاب أحمد\n\n" + "معاون المدير العام")), CreateFont()));
            CellOption(PositionSignature, 2, PaddingLeft: 20, PaddingTop: 5, Colspan: 2);
            PdfPCell DateSignature = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("  /     /       ")), CreateFont()));
            CellOption(DateSignature, 2, PaddingLeft: 40, PaddingTop: 5, Colspan: 2);
            PdfPCell Copy = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("نسخة منه إلى  \n" + "قسم التخطيط وتنمية الموارد / مكتب الولادات والوفيات")), CreateFont()));
            CellOption(Copy, 0, PaddingRight: 5, PaddingTop: 50, PaddingBottom: 155, Colspan: 2);
            AddCellToTable(MainTable, new List<PdfPCell> { To, Subject, Text1, Text2, Text3, Text4, WithRespect, Attachments, DoctorSignature, PositionSignature, DateSignature, Copy });
            PdfPCell MainCell = new PdfPCell(MainTable);
            CellOption(MainCell, BorderWidthBottom: 0.5f, BorderWidthRight: 0.5f, BorderWidthTop: 0, BorderWidthLeft: 0.5f);
            AddCellToTable(Border, new List<PdfPCell> { TitleCell, MainCell });
            document.Add(Border);
            document.Close();
            var byteInfo = m.ToArray();
            m.Write(byteInfo, 0, byteInfo.Length);
            m.Position = 0;
            return new FileStreamResult(m, "application/pdf");
        }
        public static FileStreamResult CreateBirthStatistics(CertifiedInfo certifiedInfo,List<List<int>> MainTableList,List<List<int>> MutiBirthList)
        {
            MemoryStream m = new MemoryStream();
            var document = new Document(PageSize.A3, 30, 30, 10, 10);
            PdfWriter.GetInstance(document, m).CloseStream = false;
            document.Open();
            PdfPTable Title = new PdfPTable(5);
            PdfPCell TheRepublicofIraq = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("وزارة الصحة \n دائرة التخطيط و تنمية الموارد\n قسم الإحصاء الصحي و الحياتي")), CreateFont()));
            CellOption(TheRepublicofIraq, 1, Colspan: 5, PaddingRight: 525,  PaddingBottom: 5);
            PdfPCell HealthDepartment = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("دائرة الصحة")), CreateFont()));
            CellOption(HealthDepartment, PaddingRight: 40,  PaddingBottom: 5);
            PdfPCell HealthDepartmentValue = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(certifiedInfo.HealthDepartment)), CreateFont()));
            CellOption(HealthDepartmentValue, PaddingBottom: 5);
            PdfPCell BirthStatistics = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("إستمارة إحصاء الولادات")), CreateFont()));
            CellOption(BirthStatistics, PaddingRight: -25,  PaddingBottom: 5);
            PdfPCell Month = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("شهر")), CreateFont()));
            CellOption(Month, PaddingRight: 40,  PaddingBottom: 5);
            PdfPCell MonthValue = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(DateTime.Now.Month.ToString())), CreateFont()));
            CellOption(MonthValue, PaddingRight: 22,  PaddingBottom: 5);
            PdfPCell HealthInstitution = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("المؤسسة الصحية")), CreateFont()));
            CellOption(HealthInstitution, Colspan: 3, PaddingRight: 30,  PaddingBottom: 5);
            PdfPCell Year = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("سنة")), CreateFont()));
            CellOption(Year, PaddingRight: 40,  PaddingBottom: 5);
            PdfPCell YearValue = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(DateTime.Now.Year.ToString())), CreateFont()));
            CellOption(YearValue, PaddingRight: 10, PaddingBottom: 5);
            AddCellToTable(Title, new List<PdfPCell> { TheRepublicofIraq, MonthValue, Month, BirthStatistics, HealthDepartmentValue, HealthDepartment, YearValue, Year, HealthInstitution });
            var TablesFont = CreateFont(8);
            PdfPTable MainTable = new PdfPTable(13);
            PdfPCell Pointer = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("المؤشر")), TablesFont));
            CellOption(Pointer, 1, Rowspan: 2, Colspan: 3, PaddingTop: 5, PaddingBottom: 5, BorderWidthLeft: 0.5f);
            Pointer.VerticalAlignment = Element.ALIGN_MIDDLE;
            PdfPCell BirthInHealthInstitution = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("ولادات داخل المؤسسة الصحية")), TablesFont));
            CellOption(BirthInHealthInstitution, 1, Colspan: 5, PaddingTop: 5, PaddingBottom: 5, BorderWidthLeft: 0.5f);
            PdfPCell BirthOutHealthInstitution = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("ولادات خارج المؤسسة الصحية")), TablesFont));
            CellOption(BirthOutHealthInstitution, 1, Colspan: 5, PaddingTop: 5, PaddingBottom: 5);
            PdfPCell SingleLiveBirthIn = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("ولادة حية مفردة")), TablesFont));
            CellOption(SingleLiveBirthIn, 1, PaddingTop: 5, PaddingBottom: 5, BorderWidthTop: 0.5f, BorderWidthLeft: 0.5f);
            PdfPCell MultipleLiveBirthIn = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("ولادة حية متعددة")), TablesFont));
            CellOption(MultipleLiveBirthIn, 1, PaddingTop: 5, PaddingBottom: 5, BorderWidthTop: 0.5f, BorderWidthLeft: 0.5f);
            PdfPCell SingleDeadBirthIn = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("ولادة ميتة مفردة")), TablesFont));
            CellOption(SingleDeadBirthIn, 1, PaddingTop: 5, PaddingBottom: 5, BorderWidthTop: 0.5f, BorderWidthLeft: 0.5f);
            PdfPCell MultipleDeadBirthIn = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("ولادة ميتة متعددة")), TablesFont));
            CellOption(MultipleDeadBirthIn, 1, PaddingTop: 5, PaddingBottom: 5, BorderWidthTop: 0.5f, BorderWidthLeft: 0.5f);
            PdfPCell TotalIn = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("المجموع")), TablesFont));
            CellOption(TotalIn, 1, PaddingTop: 5, PaddingBottom: 5, BorderWidthTop: 0.5f, BorderWidthLeft: 0.5f);
            PdfPCell SingleLiveBirthOut = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("ولادة حية مفردة")), TablesFont));
            CellOption(SingleLiveBirthOut, 1, PaddingTop: 5, PaddingBottom: 5, BorderWidthTop: 0.5f, BorderWidthLeft: 0.5f);
            PdfPCell MultipleLiveBirthOut = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("ولادة حية متعددة")), TablesFont));
            CellOption(MultipleLiveBirthOut, 1, PaddingTop: 5, PaddingBottom: 5, BorderWidthTop: 0.5f, BorderWidthLeft: 0.5f);
            PdfPCell SingleDeadBirthOut = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("ولادة ميتة مفردة")), TablesFont));
            CellOption(SingleDeadBirthOut, 1, PaddingTop: 5, PaddingBottom: 5, BorderWidthTop: 0.5f, BorderWidthLeft: 0.5f);
            PdfPCell MultipleDeadBirthOut = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("ولادة ميتة متعددة")), TablesFont));
            CellOption(MultipleDeadBirthOut, 1, PaddingTop: 5, PaddingBottom: 5, BorderWidthTop: 0.5f, BorderWidthLeft: 0.5f);
            PdfPCell TotalOut = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("المجموع")), TablesFont));
            CellOption(TotalOut, 1, PaddingTop: 5, PaddingBottom: 5, BorderWidthTop: 0.5f);
            PdfPTable CurrentMonthTable = new PdfPTable(3);
            PdfPCell CurrentMonthBirths = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("ولادات الشهر الجاري و المسجلة هذا الشهر-نظمت لها شهادة")), TablesFont));
            CellOption(CurrentMonthBirths, 1, Rowspan: 8, PaddingTop: 5, PaddingBottom: 5, BorderWidthTop: 0.5f, BorderWidthLeft: 0.5f, Rotation: 90);
            CurrentMonthBirths.VerticalAlignment = Element.ALIGN_MIDDLE;
            PdfPCell CurrentMonthNormalBirths = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("ولادة \nطبيعية (1)")), TablesFont));
            CellOption(CurrentMonthNormalBirths, 1, PaddingTop: 5, PaddingBottom: 5, BorderWidthTop: 0.5f, BorderWidthLeft: 0.5f, Rotation: 90);
            CurrentMonthNormalBirths.VerticalAlignment = Element.ALIGN_MIDDLE;
            PdfPTable Gender = new PdfPTable(1);
            PdfPCell CurrentMonthNormalMaleBirths = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("ذكر")), TablesFont));
            CellOption(CurrentMonthNormalMaleBirths, 1, PaddingTop: 5, PaddingBottom: 5, BorderWidthTop: 0.5f);
            PdfPCell CurrentMonthNormalfemaleBirths = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("أنثى")), TablesFont));
            CellOption(CurrentMonthNormalfemaleBirths, 1, PaddingTop: 5, PaddingBottom: 5, BorderWidthTop: 0.5f);
            PdfPCell CurrentMonthNormalTotalBirths = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("المجموع")), TablesFont));
            CellOption(CurrentMonthNormalTotalBirths, 1, PaddingTop: 5, PaddingBottom: 5, BorderWidthTop: 0.5f);
            PdfPCell GenderCell = new PdfPCell(Gender);
            CellOption(GenderCell);
            AddCellToTable(Gender, new List<PdfPCell> { CurrentMonthNormalMaleBirths, CurrentMonthNormalfemaleBirths, CurrentMonthNormalTotalBirths });
            PdfPCell CurrentMonthCaesareanBirths = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("ولادة\n قيصرية (2)")), TablesFont));
            CellOption(CurrentMonthCaesareanBirths, 1, PaddingTop: 5, PaddingBottom: 5, BorderWidthTop: 0.5f, BorderWidthLeft: 0.5f, Rotation: 90);
            CurrentMonthCaesareanBirths.VerticalAlignment = Element.ALIGN_MIDDLE;
            PdfPCell CurrentMonthOtherBirths = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("أخرى \n ( ملقط - الشفط ) \n(3)")), TablesFont));
            CellOption(CurrentMonthOtherBirths, 1, PaddingTop: 5, PaddingBottom: 5, BorderWidthTop: 0.5f, BorderWidthLeft: 0.5f, Rotation: 90);
            CurrentMonthOtherBirths.VerticalAlignment = Element.ALIGN_MIDDLE;
            PdfPCell CurrentMonthTotalBirths = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("المجموع لمختلف أنواع الولادات \n (1+2+3)")), TablesFont));
            CellOption(CurrentMonthTotalBirths, 1, Colspan: 2, PaddingTop: 5, PaddingBottom: 5, BorderWidthTop: 0.5f);
            PdfPCell CurrentMonthOverWeightBirths = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("المواليد بوزن 2500 غم فأكثر (4)")), TablesFont));
            CellOption(CurrentMonthOverWeightBirths, 1, Colspan: 2, PaddingTop: 5, PaddingBottom: 5, BorderWidthTop: 0.5f);
            PdfPCell CurrentMonthLessWeightBirths = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("المواليد بوزن أقل من 2500 غم (5)")), TablesFont));
            CellOption(CurrentMonthLessWeightBirths, 1, Colspan: 2, PaddingTop: 5, PaddingBottom: 5, BorderWidthTop: 0.5f);
            PdfPCell CurrentMonthUnWeightBirths = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("المواليد غير الموزونة (6)")), TablesFont));
            CellOption(CurrentMonthUnWeightBirths, 1, Colspan: 2, PaddingTop: 5, PaddingBottom: 5, BorderWidthTop: 0.5f);
            PdfPCell CurrentMonthTotalWeightBirths = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("مجموع (4+5+6)")), TablesFont));
            CellOption(CurrentMonthTotalWeightBirths, 1, Colspan: 2, PaddingTop: 5, PaddingBottom: 5, BorderWidthTop: 0.5f);
            AddCellToTable(CurrentMonthTable, new List<PdfPCell>{ GenderCell, CurrentMonthNormalBirths, CurrentMonthBirths
                                             , GenderCell, CurrentMonthCaesareanBirths, GenderCell,
                                             CurrentMonthOtherBirths, CurrentMonthTotalBirths, CurrentMonthOverWeightBirths, CurrentMonthLessWeightBirths, CurrentMonthUnWeightBirths, CurrentMonthTotalWeightBirths });
            PdfPCell ThisMonthBirths = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("ولادات الشهر \n الحالي نظمت لها \n حجج ولادة")), TablesFont));
            CellOption(ThisMonthBirths, 1, PaddingTop: 5, PaddingBottom: 5, BorderWidthTop: 0.5f, BorderWidthLeft: 0.5f, Rotation: 90);
            ThisMonthBirths.VerticalAlignment = Element.ALIGN_MIDDLE;
            PdfPCell PreviousMonthBirths = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("ولادات الأشهر \n السابقة نظمت لها \n حجج ولادة مسجلة \n في هذا الشهر")), TablesFont));
            CellOption(PreviousMonthBirths, 1, PaddingTop: 5, PaddingBottom: 5, BorderWidthTop: 0.5f, BorderWidthLeft: 0.5f, Rotation: 90);
            PreviousMonthBirths.VerticalAlignment = Element.ALIGN_MIDDLE;
            CellOption(GenderCell, Colspan: 2);
            AddCellToTable(CurrentMonthTable, new List<PdfPCell> { GenderCell, ThisMonthBirths, GenderCell, PreviousMonthBirths });
            CellOption(GenderCell, Colspan: 1);
            PdfPCell PreviousMonthBirthsTitle = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("ولادات الأشهر السابقة من هذه السنة التي نظمت لها شهادة بالإستناد إلى تأييد ولادة والمسجلة هذا الشهر")), TablesFont));
            CellOption(PreviousMonthBirthsTitle, 1, Rowspan: 8, PaddingTop: 5, PaddingBottom: 5, BorderWidthTop: 0.5f, BorderWidthLeft: 0.5f, Rotation: 90);
            PreviousMonthBirthsTitle.VerticalAlignment = Element.ALIGN_MIDDLE;
            PdfPCell TotalhermaphroditeBirths = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("المجموع الكلي لولادات الخنثى")), TablesFont));
            CellOption(TotalhermaphroditeBirths, 1, Colspan: 2, PaddingTop: 5, PaddingBottom: 5, BorderWidthTop: 0.5f);
            PdfPCell Nullc = new PdfPCell();
            CellOption(Nullc, BorderWidthTop: 0.5f, BorderWidthLeft: 0.5f);
            AddCellToTable(CurrentMonthTable, new List<PdfPCell>{ GenderCell, CurrentMonthNormalBirths, PreviousMonthBirthsTitle
                                             , GenderCell, CurrentMonthCaesareanBirths, GenderCell,
                                             CurrentMonthOtherBirths, CurrentMonthTotalBirths, CurrentMonthOverWeightBirths, CurrentMonthLessWeightBirths,
                                             CurrentMonthUnWeightBirths, CurrentMonthTotalWeightBirths, TotalhermaphroditeBirths, Nullc });
            PdfPCell CurrentMonthTableCell = new PdfPCell(CurrentMonthTable);
            CellOption(CurrentMonthTableCell, BorderWidthBottom: 0.5f, BorderWidthLeft: 0, BorderWidthRight: 0.5f, BorderWidthTop: 0.5f);
            CellOption(CurrentMonthTableCell, Colspan: 3, Rowspan: 35);
            //PdfPTable ContentTable = new PdfPTable(10);
            PdfPCell ContentCell;
            AddCellToTable(MainTable, new List<PdfPCell>{ BirthOutHealthInstitution, BirthInHealthInstitution, Pointer, TotalOut, MultipleDeadBirthOut, SingleDeadBirthOut,
                MultipleLiveBirthOut, SingleLiveBirthOut, TotalIn, MultipleDeadBirthIn, SingleDeadBirthIn, MultipleLiveBirthIn, SingleLiveBirthIn });

            for (int Row = 0; Row < 35; Row++)
            {

                for (int Column = 0; Column < 10; Column++)
                {
                    ContentCell = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(MainTableList[Row][9-Column].ToString())), TablesFont));
                    CellOption(ContentCell, 1, PaddingTop: 5, PaddingBottom: 5, BorderWidthRight: 0.5f, BorderWidthTop: 0.5f);
                    if (Row == 19)
                        CellOption(ContentCell, 1, PaddingTop: 6.8f, PaddingBottom: 6.8f, BorderWidthRight: 0.5f, BorderWidthTop: 0.5f);

                    if (Row == 9 || Row == 29)
                        CellOption(ContentCell, 1, PaddingTop: 9.05f, PaddingBottom: 9.05f, BorderWidthRight: 0.5f, BorderWidthTop: 0.5f);
                    if (Row == 33)
                        CellOption(ContentCell, 1, PaddingTop: 7.8f, PaddingBottom: 7.8f, BorderWidthRight: 0.5f, BorderWidthTop: 0.5f);
                    MainTable.AddCell(ContentCell);
                }
               
                if (Row == 0)
                {
                    MainTable.AddCell(CurrentMonthTableCell);
                }   
            }
            PdfPCell MainCell = new PdfPCell(MainTable);
            CellOption(MainCell,BorderWidthBottom:0.5f,BorderWidthLeft:0.5f,BorderWidthRight:0.5f,BorderWidthTop:0.5f);
            PdfPTable Border = new PdfPTable(1);
            AddCellToTable(Border, new List<PdfPCell> { MainCell });
            PdfPTable MultiBirthInOutTable = new PdfPTable(7);
            float[] MultiBirthInOutTablewidths = new float[] { 1,1,1,1,1,1.5f,4 };
            MultiBirthInOutTable.SetWidths(MultiBirthInOutTablewidths);
            PdfPCell MultiBirthInOut = new PdfPCell(new Phrase(0,"الولادات المتعددة (داخل وخارج المؤسسات الصحية)",TablesFont));
            CellOption(MultiBirthInOut,1,Rowspan:2,BorderWidthLeft:0.5f,BorderWidthRight:0.5f,BorderWidthTop:0.5f);
            MultiBirthInOut.VerticalAlignment = Element.ALIGN_MIDDLE;
            PdfPCell TotalAllCases = new PdfPCell(new Phrase(0, "عدد الحالات \n الكلية", TablesFont));
            CellOption(TotalAllCases,1, Rowspan: 2,   BorderWidthTop: 0.5f);
            TotalAllCases.VerticalAlignment = Element.ALIGN_MIDDLE;
            PdfPCell BirthType = new PdfPCell(new Phrase(0, "نوع الولادة", TablesFont));
            CellOption(BirthType,1, Colspan: 3,PaddingBottom:5,  BorderWidthRight: 0.5f, BorderWidthTop: 0.5f);
            PdfPCell TotalBirth = new PdfPCell(new Phrase(0, "عدد الولادات", TablesFont));
            CellOption(TotalBirth,1, Colspan: 2, PaddingBottom: 5,  BorderWidthRight: 0.5f, BorderWidthTop: 0.5f,BorderWidthLeft: 0.5f);
            PdfPCell NormalBirth = new PdfPCell(new Phrase(0, "ولادة طبيعية", TablesFont));
            CellOption(NormalBirth, 1, BorderWidthRight: 0.5f,BorderWidthTop:0.5f,PaddingBottom:5,PaddingTop:5);
            PdfPCell CaesareanBirth = new PdfPCell(new Phrase(0, "ولادة قيصرية", TablesFont));
            CellOption(CaesareanBirth, 1, BorderWidthRight: 0.5f, BorderWidthTop: 0.5f, PaddingBottom: 5, PaddingTop: 5);
            PdfPCell OtherBirth = new PdfPCell(new Phrase(0, "أخرى", TablesFont));
            CellOption(OtherBirth, 1, BorderWidthRight: 0.5f, BorderWidthTop: 0.5f, PaddingBottom: 5, PaddingTop: 5);
            PdfPCell AliveBirth = new PdfPCell(new Phrase(0, "الحية", TablesFont));
            CellOption(AliveBirth, 1, BorderWidthRight: 0.5f, BorderWidthTop: 0.5f, PaddingBottom: 5, PaddingTop: 5);
            PdfPCell DeadBirth = new PdfPCell(new Phrase(0, "الميتة", TablesFont));
            CellOption(DeadBirth, 1, BorderWidthLeft: 0.5f, BorderWidthRight: 0.5f, BorderWidthTop: 0.5f, PaddingBottom: 5, PaddingTop: 5);
            AddCellToTable(MultiBirthInOutTable, new List<PdfPCell> { TotalBirth, BirthType, TotalAllCases, MultiBirthInOut, DeadBirth, AliveBirth, OtherBirth, CaesareanBirth, NormalBirth });
            PdfPCell MultiContentCell;
            string BirthsNumber="";
            for (int Row = 0; Row < 4; Row++)
            {
                for (int Column = 0; Column < 7; Column++)
                {
                    if (Column!=6)
                     {
                        MultiContentCell = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(MutiBirthList[Row][5-Column].ToString())), TablesFont));
                        CellOption(MultiContentCell, 1, PaddingTop: 5, PaddingBottom: 5, BorderWidthRight: 0.5f, BorderWidthTop: 0.5f);
                    if (Column == 0)
                        CellOption(MultiContentCell, 1, PaddingTop: 5, PaddingBottom: 5, BorderWidthRight: 0.5f, BorderWidthTop: 0.5f, BorderWidthLeft: 0.5f);
                        MultiBirthInOutTable.AddCell(MultiContentCell); 
                    }
                    else
                    {
                        if (Row == 0)
                            BirthsNumber = "الولادات التوآمية";
                        if (Row == 1)
                            BirthsNumber = "الولادات الثلاثية";
                        if (Row == 2)
                            BirthsNumber = "الولادات الرباعية فأكثر";
                        if (Row == 3)
                            BirthsNumber = "المجموع";
                        MultiContentCell = new PdfPCell(new Phrase(0, BirthsNumber, TablesFont));
                        CellOption(MultiContentCell, 1, PaddingTop: 5, PaddingBottom: 5, BorderWidthRight: 0.5f, BorderWidthTop: 0.5f);
                        MultiBirthInOutTable.AddCell(MultiContentCell);
                    }
                }
            }
            PdfPCell MultiBirthInOutTableCell = new PdfPCell(MultiBirthInOutTable);
            PdfPTable MultiBirthTable = new PdfPTable(1);
            AddCellToTable(MultiBirthTable, new List<PdfPCell> { MultiBirthInOutTableCell });
            MultiBirthTable.WidthPercentage = 80;
            PdfPTable SignsTable = new PdfPTable(3);
            PdfPCell ManagerSign = new PdfPCell(new Phrase(0,"إسم و توقيع مدير المؤسسة",CreateFont()));
            CellOption(ManagerSign, 2, PaddingTop: 200);
            PdfPCell StatisticsManagerSign = new PdfPCell(new Phrase(0, "إسم و توقيع مدير شعبة الإحصاء", CreateFont()));
            CellOption(StatisticsManagerSign, 1, PaddingTop: 200);
            PdfPCell OrganizerSign = new PdfPCell(new Phrase(0, "إسم و توقيع منظم الإستمارة", CreateFont()));
            CellOption(OrganizerSign, 0,PaddingTop:200);
            AddCellToTable(SignsTable, new List<PdfPCell> { ManagerSign, StatisticsManagerSign, OrganizerSign });
            document.Add(Title);
            document.Add(Border);
            document.Add(new Paragraph(" "));
            document.Add(MultiBirthTable);
            document.Add(new Paragraph(" "));
            document.Add(SignsTable);
            document.Close();
            var byteInfo = m.ToArray();
            m.Write(byteInfo, 0, byteInfo.Length);
            m.Position = 0;
            return new FileStreamResult(m, "application/pdf");
        }
        public static FileStreamResult DeathFormWomenInChildbearingAge(DeathCertified DeathCertify)
        {
            var Font = CreateFont();
            var ColorFont = FontFactory.GetFont(FontPath, BaseFont.IDENTITY_H, true, 12, 1, BaseColor.RED, false);
            MemoryStream m = new MemoryStream();
            var document = new Document(PageSize.A4, 20, 20, 20, 80);
            PdfWriter.GetInstance(document, m).CloseStream = false;
            PdfWriter writer = PdfWriter.GetInstance(document, m);
            writer.CloseStream = false;
            document.Open();
            PdfPTable Border = new PdfPTable(3);
            float[] BorderWidth = new float[] { 0.1f, 0.8f, 0.1f };
            Border.SetWidths(BorderWidth);
            PdfPTable Title = new PdfPTable(1);
            PdfPCell FormTitle = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("إستمارة وفيات النساء في سن الإنجاب (12-49) سنة " + "((" +
                                           Convert(DateTime.Now.Month.ToString(), month: true)) + " " + DateTime.Now.Year.ToString()) + "))", ColorFont));
            CellOption(FormTitle, 1, PaddingTop: 10, PaddingBottom: 10);
            AddCellToTable(Title, new List<PdfPCell> { FormTitle });
            PdfPCell TitleCell = new PdfPCell(Title);
            CellOption(TitleCell, Colspan: 3);
            PdfPTable ContentTable = new PdfPTable(9);
            float[] ContentTableWidth = new float[] { 0.75f, 1.5f, 0.5f, 0.75f, 0.75f, 1, 0.75f, 1, 0.3f };
            ContentTable.SetWidths(ContentTableWidth);
            PdfPCell DoctorName = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("إسم الطبيب")), Font));
            CellOption(DoctorName, 1, BorderWidthTop: 0.5f, BorderWidthLeft: 0.5f, BorderWidthBottom: 0.5f, PaddingBottom: 5);
            PdfPCell DeathReason = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("سبب الوفاة")), Font));
            CellOption(DeathReason, 1, BorderWidthTop: 0.5f, BorderWidthLeft: 0.5f, BorderWidthBottom: 0.5f, PaddingBottom: 5);
            PdfPCell Age = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("العمر")), Font));
            CellOption(Age, 1, BorderWidthTop: 0.5f, BorderWidthLeft: 0.5f, BorderWidthBottom: 0.5f, PaddingBottom: 5);
            PdfPCell MotherName = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("إسم الأم")), Font));
            CellOption(MotherName, 1, BorderWidthTop: 0.5f, BorderWidthLeft: 0.5f, BorderWidthBottom: 0.5f, PaddingBottom: 5);
            PdfPCell MaritalStatus = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("الحالة الزوجية")), Font));
            CellOption(MaritalStatus, 1, BorderWidthTop: 0.5f, BorderWidthLeft: 0.5f, BorderWidthBottom: 0.5f, PaddingBottom: 5);
            PdfPCell DeathDate = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("تاريخ الوفاة")), Font));
            CellOption(DeathDate, 1, BorderWidthTop: 0.5f, BorderWidthLeft: 0.5f, BorderWidthBottom: 0.5f, PaddingBottom: 5);
            PdfPCell CertificateNo = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("رقم الشهادة")), Font));
            CellOption(CertificateNo, 1, BorderWidthTop: 0.5f, BorderWidthLeft: 0.5f, BorderWidthBottom: 0.5f, PaddingBottom: 5);
            PdfPCell DeathName = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("إسم المتوفية")), Font));
            CellOption(DeathName, 1, BorderWidthTop: 0.5f, BorderWidthLeft: 0.5f, BorderWidthBottom: 0.5f, PaddingBottom: 5);
            PdfPCell ID = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("ت")), Font));
            CellOption(ID, 1, BorderWidthTop: 0.5f, BorderWidthLeft: 0.5f, BorderWidthRight: 0.5f, BorderWidthBottom: 0.5f, PaddingBottom: 5);
            AddCellToTable(ContentTable, new List<PdfPCell> { DoctorName, DeathReason, Age, MotherName, MaritalStatus, DeathDate, CertificateNo, DeathName, ID });
            PdfPCell ContentCell;
            int Total = 53;
            PdfPCell ContentTableCell = new PdfPCell(ContentTable);
            PdfPCell Nullc = new PdfPCell(new Phrase(0, " ", Font));
            CellOption(Nullc);
            if (Total < 53)
            {
                for (int Row = 0; Row < Total; Row++)
                {
                    for (int Column = 0; Column < 9; Column++)
                    {
                        ContentCell = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("1")), Font));
                        CellOption(ContentCell, 1, BorderWidthBottom: 0.5f, BorderWidthRight: 0.5f);
                        ContentTable.AddCell(ContentCell);
                    }
                }
                AddCellToTable(Border, new List<PdfPCell> { TitleCell, Nullc, ContentTableCell, Nullc });
            }
            else
            {
                PdfPTable ExtraData = new PdfPTable(9);
                float[] ExtraDataWidth = new float[] { 0.75f, 1.5f, 0.5f, 0.75f, 0.75f, 1, 0.75f, 1, 0.3f };
                ExtraData.SetWidths(ExtraDataWidth);
                for (int Row = 0; Row < 53; Row++)
                {
                    for (int Column = 0; Column < 9; Column++)
                    {
                        ContentCell = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("1")), Font));
                        CellOption(ContentCell, 1, BorderWidthBottom: 0.5f, BorderWidthRight: 0.5f);
                        ContentTable.AddCell(ContentCell);
                    }
                }
                for (int Row = 53; Row < Total; Row++)
                {
                    for (int Column = 0; Column < 9; Column++)
                    {
                        ContentCell = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("1")), Font));
                        CellOption(ContentCell, 1, BorderWidthBottom: 0.5f, BorderWidthRight: 0.5f);
                        ExtraData.AddCell(ContentCell);
                    }
                }
                PdfPCell ExtraDataCell = new PdfPCell(ExtraData);
                if (ExtraData.Rows.Count()==0)
                    CellOption(ExtraDataCell);
                AddCellToTable(Border, new List<PdfPCell> { TitleCell, Nullc, ContentTableCell, Nullc, Nullc, ExtraDataCell, Nullc });
            }
            document.Add(Border);
            PdfPTable FooterTabe = new PdfPTable(3);
            FooterTabe.TotalWidth = document.Right;
            PdfPCell HospitalManagerSign = new PdfPCell(new Phrase(0, "إسم وتوقيع \n\n مدير مستشفى " + DeathCertify.HospitalName, Font));
            CellOption(HospitalManagerSign, 1, 50);
            PdfPCell StatisticsManagerSign = new PdfPCell(new Phrase(0, "إسم وتوقيع \n\n مدير شعبة الإحصاء ", Font));
            CellOption(StatisticsManagerSign, 1);
            PdfPCell OrganizerSign = new PdfPCell(new Phrase(0, "إسم وتوقيع \n\n منظم الشهادة\n\n" + DeathCertify.OrganizerName, Font));
            CellOption(OrganizerSign, 1, -75);
            AddCellToTable(FooterTabe, new List<PdfPCell> { HospitalManagerSign, StatisticsManagerSign, OrganizerSign });
            FooterTabe.WriteSelectedRows(0, -1, 0, document.BottomMargin, writer.DirectContent);
            document.Close();
            var byteInfo = m.ToArray();
            m.Write(byteInfo, 0, byteInfo.Length);
            m.Position = 0;
            return new FileStreamResult(m, "application/pdf");
        }
        public static FileStreamResult CreateDeathStatistics(DeathCertified DeathCertify, DeceasedFormatDto deceasedFormatDto)
        {
            MemoryStream m = new MemoryStream();
            var document = new Document(PageSize.A4.Rotate(), 30, 30, 10, 10);
            PdfWriter.GetInstance(document, m).CloseStream = false;
            PdfWriter writer = PdfWriter.GetInstance(document, m);
            writer.CloseStream = false;
            document.Open();
            PdfContentByte content = writer.DirectContent;
            content.MoveTo(752, 551);
            content.LineTo(825, 489);
            //content.MoveTo(752, 1147); A3
            //content.LineTo(825, 1085);
            content.Stroke();
            PdfPTable Title = new PdfPTable(3);
            PdfPCell HealthDepartment = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("دائرة الصحة " + DeathCertify.CertificateDepartment)), CreateFont()));
            CellOption(HealthDepartment, PaddingRight: 40, PaddingBottom: 5);
            PdfPCell Month = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("شهر")), CreateFont()));
            CellOption(Month, PaddingRight: 40, PaddingBottom: 5);
            PdfPCell MonthValue = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(DateTime.Now.Month.ToString())), CreateFont()));
            CellOption(MonthValue, PaddingRight: 22, PaddingBottom: 5);
            PdfPCell HealthInstitution = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("المؤسسة " + DeathCertify.HospitalName)), CreateFont()));
            CellOption(HealthInstitution, Colspan: 3, PaddingRight: 30, PaddingBottom: 5);
            PdfPCell Year = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("سنة")), CreateFont()));
            CellOption(Year, PaddingRight: 40, PaddingBottom: 5);
            PdfPCell YearValue = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(DateTime.Now.Year.ToString())), CreateFont()));
            CellOption(YearValue, PaddingRight: 10, PaddingBottom: 5);
            AddCellToTable(Title, new List<PdfPCell> { MonthValue, Month, HealthDepartment, YearValue, Year, HealthInstitution });
            var TablesFont = CreateFont(8);
            PdfPTable MainTable = new PdfPTable(22);
            PdfPTable Gender = new PdfPTable(3);
            PdfPCell CurrentMonthNormalMaleBirths = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("ذكر")), TablesFont));
            CellOption(CurrentMonthNormalMaleBirths, 1, PaddingTop: 5, PaddingBottom: 5, BorderWidthTop: 0.5f, BorderWidthLeft: 0.5f);
            PdfPCell CurrentMonthNormalfemaleBirths = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("أنثى")), TablesFont));
            CellOption(CurrentMonthNormalfemaleBirths, 1, PaddingTop: 5, PaddingBottom: 5, BorderWidthTop: 0.5f, BorderWidthLeft: 0.5f);
            PdfPCell CurrentMonthNormalTotalBirths = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("المجموع")), TablesFont));
            CellOption(CurrentMonthNormalTotalBirths, 1, PaddingTop: 5, PaddingBottom: 5, BorderWidthTop: 0.5f, BorderWidthLeft: 0.5f);
            AddCellToTable(Gender, new List<PdfPCell> { CurrentMonthNormalTotalBirths, CurrentMonthNormalfemaleBirths, CurrentMonthNormalMaleBirths });
            Gender.WidthPercentage = 99;
            PdfPCell GenderCell = new PdfPCell(Gender);
            CellOption(GenderCell, Colspan: 3);
            PdfPTable PointerTable = new PdfPTable(1);
            PdfPCell DeathDuration = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("فترة حدوث \n الوفاة")), TablesFont));
            CellOption(DeathDuration, 0, 5, BorderWidthLeft: 0.5f);
            PdfPCell DeathPlace = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(" مكان الوفاة \n والفئة العمرية ")), TablesFont));
            CellOption(DeathPlace, 2, PaddingLeft: 5, BorderWidthLeft: 0.5f);
            PdfPCell GenderTitle = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("الجنس")), TablesFont));
            CellOption(GenderTitle, 2, PaddingLeft: 5, PaddingTop: 10, BorderWidthLeft: 0.5f);
            AddCellToTable(PointerTable, new List<PdfPCell> { DeathDuration, DeathPlace, GenderTitle });
            PointerTable.WidthPercentage = 99;
            PdfPCell PointerTableCell = new PdfPCell(PointerTable);
            PdfPCell Pointer = new PdfPCell(PointerTableCell);
            CellOption(Pointer, 1,Colspan:2, Rowspan: 3, PaddingTop: 5, PaddingBottom: 5, BorderWidthLeft: 0.5f);
            PdfPCell HermaphroditeDeath = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("وفيات الخنثى نظمت لها شهادة وفاة")), TablesFont));
            CellOption(HermaphroditeDeath, 1,Rowspan:2, PaddingTop: 5, PaddingBottom: 5, BorderWidthTop: 0.5f, VerticalAlignment: true);
            PdfPCell HermaphroditeDeath3 = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("وفيات الخنثى نظمت لها شهادة وفاة(3)")), TablesFont));
            CellOption(HermaphroditeDeath3, 1, Rowspan: 2, PaddingTop: 5, PaddingBottom: 5, BorderWidthTop: 0.5f, BorderWidthLeft: 0.5f, VerticalAlignment: true);
            PdfPCell PreviousMonthsDeath = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("وفيات الأشهر السابقة والمسجلة في هذا الشهر")), TablesFont));
            CellOption(PreviousMonthsDeath, 1,Colspan:7, PaddingTop: 5, PaddingBottom: 5, BorderWidthTop: 0.5f, BorderWidthLeft: 0.5f, VerticalAlignment: true);
            PdfPCell CurrentMonthDeath = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("وفيات الشهر الجاري والمسجلة في هذا الشهر")), TablesFont));
            CellOption(CurrentMonthDeath, 1, Colspan: 7, PaddingTop: 5, PaddingBottom: 5, BorderWidthTop: 0.5f, BorderWidthLeft: 0.5f, VerticalAlignment: true);
            PreviousMonthsDeath.BackgroundColor = new BaseColor(149, 179, 215);
            CurrentMonthDeath.BackgroundColor = new BaseColor(149, 179, 215);
            PdfPCell ForensicMedicine = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("نظمت لها شهادة وفاة من الطبابة العدلية")), TablesFont));
            CellOption(ForensicMedicine, 1, Colspan: 3, PaddingTop: 5, PaddingBottom: 5, BorderWidthTop: 0.5f, BorderWidthLeft: 0.5f, VerticalAlignment: true);
            PdfPCell DeathArgument = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("نظمت لها حجة وفاة")), TablesFont));
            CellOption(DeathArgument, 1, Colspan: 3, PaddingTop: 5, PaddingBottom: 5, BorderWidthTop: 0.5f, BorderWidthLeft: 0.5f, VerticalAlignment: true);
            PdfPCell FinalTotal = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("مجموع (1+2+3)")), TablesFont));
            CellOption(FinalTotal, 1, Colspan: 3, Rowspan:2, PaddingTop: 5, PaddingBottom: 5, BorderWidthTop: 0.5f, BorderWidthLeft: 0.5f, VerticalAlignment: true);
            PdfPCell ThisMonth = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("الوفيات التي حدثت هذا الشهر \n وأحيلت إلى الطبابة العدلية \n ولم تنظم لها شهادة خلال هذا الشهر")), TablesFont));
            CellOption(ThisMonth, 1, Colspan: 3, Rowspan: 2, PaddingTop: 5, PaddingBottom: 5, BorderWidthTop: 0.5f, BorderWidthLeft: 0.5f, VerticalAlignment: true);
            PdfPCell Nullc = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(" ")), TablesFont));
            CellOption(Nullc, 1, Colspan: 3, PaddingTop: 5, PaddingBottom: 5, BorderWidthTop: 0.5f, BorderWidthLeft: 0.5f, VerticalAlignment: true);
            PdfPCell CertifyInHospital = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("نظمت لها شهادة وفاة من المركز الصحي أو المستشفى (1)")), TablesFont));
            CellOption(CertifyInHospital, 1, Colspan: 3, PaddingTop: 5, PaddingBottom: 5, BorderWidthTop: 0.5f, BorderWidthLeft: 0.5f, VerticalAlignment: true);
            PdfPCell ContentCell;
            AddCellToTable(MainTable, new List<PdfPCell>{PreviousMonthsDeath, FinalTotal,ThisMonth,CurrentMonthDeath,Pointer,
                HermaphroditeDeath, ForensicMedicine, DeathArgument, HermaphroditeDeath3, Nullc, CertifyInHospital
                , GenderCell, GenderCell, GenderCell, GenderCell, GenderCell, GenderCell });
            PdfPTable DeathInOutHealthDepartment = new PdfPTable(2);
            PdfPCell DeathInHealthDepartment = new PdfPCell(new Phrase(0, "وفيات داخل المؤسسات الصحية", TablesFont));
            CellOption(DeathInHealthDepartment, 1, PaddingBottom: 5, Rowspan: 8, Rotation: 270, BorderWidthRight: 0.5f, BorderWidthBottom: 0.5f, VerticalAlignment: true);
            PdfPCell ZeroToSeven = new PdfPCell(new Phrase(ConvertNumerals(NullException("0-7 يوم")), TablesFont));
            CellOption(ZeroToSeven, 1, PaddingBottom: 5, BorderWidthRight: 0.5f, BorderWidthBottom: 0.5f, VerticalAlignment: true);
            PdfPCell EightToTwentyEight = new PdfPCell(new Phrase(ConvertNumerals(NullException("8-28 يوم")), TablesFont));
            CellOption(EightToTwentyEight, 1, PaddingBottom: 5, BorderWidthRight: 0.5f, BorderWidthBottom: 0.5f, VerticalAlignment: true);
            PdfPCell TwentyNineToOneYear = new PdfPCell(new Phrase(ConvertNumerals(NullException("29 يوم-أقل من سنة")), TablesFont));
            CellOption(TwentyNineToOneYear, 1, PaddingBottom: 5, BorderWidthRight: 0.5f, BorderWidthBottom: 0.5f, VerticalAlignment: true);
            PdfPCell OneToFourYear = new PdfPCell(new Phrase(ConvertNumerals(NullException("1-4 سنة")), TablesFont));
            CellOption(OneToFourYear, 1, PaddingBottom: 5, BorderWidthRight: 0.5f, BorderWidthBottom: 0.5f, VerticalAlignment: true);
            PdfPCell FiveYear = new PdfPCell(new Phrase(ConvertNumerals(NullException("5 سنة فأكثر")), TablesFont));
            CellOption(FiveYear, 1, PaddingBottom: 5, BorderWidthRight: 0.5f, BorderWidthBottom: 0.5f, VerticalAlignment: true);
            PdfPCell Total = new PdfPCell(new Phrase(ConvertNumerals(NullException("المجموع")), TablesFont));
            CellOption(Total, 1, PaddingBottom: 5, BorderWidthRight: 0.5f, BorderWidthBottom: 0.5f, VerticalAlignment: true);
            PdfPCell WomenInhildbearingAge = new PdfPCell(new Phrase(ConvertNumerals(NullException("وفيات النساء في سن الانجاب 12-49 سنة")), TablesFont));
            CellOption(WomenInhildbearingAge, 1, PaddingBottom: 5, BorderWidthRight: 0.5f, BorderWidthBottom: 0.5f, VerticalAlignment: true);
            PdfPCell MothersDeath = new PdfPCell(new Phrase(ConvertNumerals(NullException("وفيات الأمهات بسبب الحمل والولادة والنفاس")), TablesFont));
            CellOption(MothersDeath, 1, PaddingBottom: 5, BorderWidthRight: 0.5f, BorderWidthBottom: 0.5f, VerticalAlignment: true);
            PdfPCell DeathOutHealthDepartment = new PdfPCell(new Phrase(0, "وفيات خارج المؤسسات الصحية", TablesFont));
            CellOption(DeathOutHealthDepartment, 1, PaddingBottom: 5, Rowspan: 8, Rotation: 270, BorderWidthRight: 0.5f, BorderWidthBottom: 0.5f, VerticalAlignment: true);
                          AddCellToTable(DeathInOutHealthDepartment, new List<PdfPCell>{ ZeroToSeven, DeathInHealthDepartment, EightToTwentyEight, TwentyNineToOneYear, OneToFourYear, FiveYear, Total, WomenInhildbearingAge, MothersDeath
                                                     , ZeroToSeven, DeathOutHealthDepartment, EightToTwentyEight, TwentyNineToOneYear, OneToFourYear, FiveYear, Total, WomenInhildbearingAge, MothersDeath });
                PdfPCell DeathInOutHealthDepartmentCell = new PdfPCell(DeathInOutHealthDepartment);
                CellOption(DeathInOutHealthDepartmentCell,Colspan:2,Rowspan:16,BorderWidthTop:0.5f);
                List<List<string>> MainTableList=new List<List<string>>();
                MainTableList.Add(new List<string> {" ", " ", " ", " ", " ", " "," ", (deceasedFormatDto.Day7Male+
                deceasedFormatDto.Day7FeMale).ToString(),deceasedFormatDto.Day7FeMale.ToString(),deceasedFormatDto.Day7Male.ToString()," ", " ", " ", " ", " ", " ", " ", (deceasedFormatDto.Day7Male+
                deceasedFormatDto.Day7FeMale).ToString(),deceasedFormatDto.Day7FeMale.ToString(),deceasedFormatDto.Day7Male.ToString() });
                MainTableList.Add(new List<string> {" "," ", " ", " ", " ", " ", " ", (deceasedFormatDto.Day28Male+
                deceasedFormatDto.Day28FeMale).ToString(),deceasedFormatDto.Day28FeMale.ToString(),deceasedFormatDto.Day28Male.ToString()," ", " ", " ", " ", " ", " ", " ", (deceasedFormatDto.Day28Male+
                deceasedFormatDto.Day28FeMale).ToString(),deceasedFormatDto.Day28FeMale.ToString(),deceasedFormatDto.Day28Male.ToString() });
                for (int i = 0; i < 2; i++)
                {
                MainTableList.Add(new List<string> {" "," ", " ", " ", " ", " ", " "," ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " " });
                }
                MainTableList.Add(new List<string> {" "," ", " ", " ", " ", " ", " ", (deceasedFormatDto.Day5yMale+
                deceasedFormatDto.Day5yFeMale).ToString(),deceasedFormatDto.Day5yFeMale.ToString(),deceasedFormatDto.Day5yMale.ToString(), " "," ", " ", " ", " ", " ", " ", (deceasedFormatDto.Day5yMale+
                deceasedFormatDto.Day5yFeMale).ToString(),deceasedFormatDto.Day5yFeMale.ToString(),deceasedFormatDto.Day5yMale.ToString() });
                MainTableList.Add(new List<string> {" ", " ", " ", " ", " ", " ", " ", (deceasedFormatDto.Day7Male+
                deceasedFormatDto.Day7FeMale+deceasedFormatDto.Day28Male+
                deceasedFormatDto.Day28FeMale+deceasedFormatDto.Day5yMale+
                deceasedFormatDto.Day5yFeMale).ToString() , (deceasedFormatDto.Day7FeMale+deceasedFormatDto.Day28FeMale+deceasedFormatDto.Day5yFeMale).ToString(),
                                                    (deceasedFormatDto.Day7Male+deceasedFormatDto.Day28Male+deceasedFormatDto.Day5yMale).ToString() , " ", " ", " ", " ", " ", " ", " ",(deceasedFormatDto.Day7Male+
                deceasedFormatDto.Day7FeMale+deceasedFormatDto.Day28Male+
                deceasedFormatDto.Day28FeMale+deceasedFormatDto.Day5yMale+
                deceasedFormatDto.Day5yFeMale).ToString() , (deceasedFormatDto.Day7FeMale+deceasedFormatDto.Day28FeMale+deceasedFormatDto.Day5yFeMale).ToString(),
                                                    (deceasedFormatDto.Day7Male+deceasedFormatDto.Day28Male+deceasedFormatDto.Day5yMale).ToString() });
                 MainTableList.Add(new List<string> { " ", " ", " ", " ", " ", " "," ", deceasedFormatDto.Day12y48FeMale.ToString(), deceasedFormatDto.Day12y48FeMale.ToString(), " ", " ", " ", " ", " ", " ", " ", " ", deceasedFormatDto.Day12y48FeMale.ToString(), deceasedFormatDto.Day12y48FeMale.ToString(), " " });
                 MainTableList.Add(new List<string> { " ", " ", " ", " ", " ", " ", " ", deceasedFormatDto.MothersFeMale.ToString(), deceasedFormatDto.MothersFeMale.ToString(), " ", " ", " ", " ", " ", " ", " ", " ", deceasedFormatDto.MothersFeMale.ToString(), deceasedFormatDto.MothersFeMale.ToString(), " " });
                 for (int i = 0; i < 8; i++)
                 {
                  MainTableList.Add(new List<string> { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " " });
                 }
                 for (int Row = 0; Row < 16; Row++)
                 {
                 for (int Column = 0; Column < 20; Column++)
                 {
                    ContentCell = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(MainTableList[Row][Column].ToString())), TablesFont));         
                    CellOption(ContentCell, 1, PaddingTop: 2.4f, PaddingBottom: 2.4f, BorderWidthRight: 0.5f, BorderWidthTop: 0.5f, VerticalAlignment:true);
                    if ((Row < 8 && (Column == 4 || Column == 5 || Column == 6))||((Row > 5 && Row<8) && (Column == 0 || Column == 3 || Column == 9 || Column == 12 || Column == 13 || Column == 16 || Column == 19))
                        || ((Row > 13 && Row < 16) && (Column == 0 || Column == 3 || Column == 9 || Column == 12 || Column == 13 || Column == 16 || Column == 19)))
                        ContentCell.BackgroundColor = BaseColor.BLACK;
                    if(Row==2||Row==10)
                     CellOption(ContentCell, 1, PaddingTop: 6.7f, PaddingBottom: 6.7f, BorderWidthRight: 0.5f, BorderWidthTop: 0.5f,VerticalAlignment : true);
                    if (Row == 4||Row==12 )
                        CellOption(ContentCell, 1, PaddingTop: 2.5f, PaddingBottom: 2.5f, BorderWidthRight: 0.5f, BorderWidthTop: 0.5f, VerticalAlignment : true);

                    if (Row == 6 || Row == 7|| Row == 14 || Row == 15)
                        CellOption(ContentCell, 1, PaddingTop: 14.5f, PaddingBottom: 14.5f, BorderWidthRight: 0.5f, BorderWidthTop: 0.5f, VerticalAlignment : true);

                    MainTable.AddCell(ContentCell);
                }
                if (Row == 0)
                {
                    MainTable.AddCell(DeathInOutHealthDepartmentCell);
                }
            }
            PdfPCell MainCell = new PdfPCell(MainTable);
            CellOption(MainCell, BorderWidthBottom: 0.5f, BorderWidthLeft: 0.5f, BorderWidthRight: 0.5f, BorderWidthTop: 0.5f);
            PdfPTable Border = new PdfPTable(1);
            AddCellToTable(Border, new List<PdfPCell> { MainCell });
            PdfPTable SignsTable = new PdfPTable(3);
            PdfPCell ManagerSign = new PdfPCell(new Phrase(0, "مدير المؤسسة الصحية", CreateFont()));
            CellOption(ManagerSign, 1,PaddingTop:75);
            PdfPCell StatisticsManagerSign = new PdfPCell(new Phrase(0, "مدير شعبة الإحصاء", CreateFont()));
            CellOption(StatisticsManagerSign, 1, PaddingTop: 75);
            PdfPCell OrganizerSign = new PdfPCell(new Phrase(0, "إسم منظم الإستمارة\n\n"+DeathCertify.OrganizerName, CreateFont()));
            CellOption(OrganizerSign, 1, PaddingTop: 75);
            AddCellToTable(SignsTable, new List<PdfPCell> { ManagerSign, StatisticsManagerSign, OrganizerSign });
            document.Add(Title);
            document.Add(Border);
            document.Add(new Paragraph(" "));
            document.Add(SignsTable);
            document.Close();
            var byteInfo = m.ToArray();
            m.Write(byteInfo, 0, byteInfo.Length);
            m.Position = 0;
            return new FileStreamResult(m, "application/pdf");
        }
        public static FileStreamResult DeathBirth(DeathCertified DeathCertify, List<List<string>> List)
        {
            var Font = CreateFont();
            MemoryStream m = new MemoryStream();
            var document = new Document(PageSize.A4, 20, 20, 20, 80);
            PdfWriter.GetInstance(document, m).CloseStream = false;
            PdfWriter writer = PdfWriter.GetInstance(document, m);
            writer.CloseStream = false;
            document.Open();
            PdfPTable Border = new PdfPTable(3);
            float[] BorderWidth = new float[] { 0.1f, 0.8f, 0.1f };
            Border.SetWidths(BorderWidth);
            PdfPTable Title = new PdfPTable(1);
            PdfPCell FormTitle = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("إحصائية الولادات الميتة لشهر  " + "((" +
                                           Convert(DateTime.Now.Month.ToString(), month: true)) + " " + DateTime.Now.Year.ToString()) + "))", Font));
            CellOption(FormTitle, 1, PaddingTop: 10, PaddingBottom: 10);
            AddCellToTable(Title, new List<PdfPCell> { FormTitle });
            PdfPCell TitleCell = new PdfPCell(Title);
            CellOption(TitleCell, Colspan: 3);
            PdfPTable ContentTable = new PdfPTable(3);
            float[] ContentTableWidth = new float[] {1,3,1 };
            ContentTable.SetWidths(ContentTableWidth);
            PdfPCell DoctorName = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("العدد")), Font));
            CellOption(DoctorName, 1, BorderWidthTop: 0.5f, BorderWidthLeft: 0.5f, BorderWidthBottom: 0.5f, PaddingBottom: 5, VerticalAlignment: true);
            PdfPCell DeathReason = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("سبب الولادة الميتة")), Font));
            CellOption(DeathReason, 1, BorderWidthTop: 0.5f, BorderWidthLeft: 0.5f, BorderWidthBottom: 0.5f, PaddingBottom: 5, VerticalAlignment: true);
            PdfPCell ID = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("ت")), Font));
            CellOption(ID, 1, BorderWidthTop: 0.5f, BorderWidthLeft: 0.5f, BorderWidthRight: 0.5f, BorderWidthBottom: 0.5f, PaddingBottom: 5, VerticalAlignment: true);
            AddCellToTable(ContentTable, new List<PdfPCell> { DoctorName, DeathReason, ID });
            PdfPCell ContentCell;
            int Total = 10;
            PdfPCell ContentTableCell = new PdfPCell(ContentTable);
            PdfPCell Nullc = new PdfPCell(new Phrase(0, " ", Font));
            CellOption(Nullc);
            int Sum = 0;
            for (int Row = 0; Row < List.Count; Row++)
            {
                if(List[Row][2]!=null)
                Sum +=int.Parse(List[Row][2]);
            }
            PdfPCell SumCell = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(Sum.ToString())), Font));
            CellOption(SumCell, 1, BorderWidthBottom: 0.5f, BorderWidthRight: 0.5f, VerticalAlignment: true, PaddingBottom: 5);

            if (Total < 53)
            {
                for (int Row = 0; Row < Total; Row++)
                {
                    for (int Column = 0; Column < 3; Column++)
                    {
                        ContentCell = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(List[Row][2 - Column])), Font));
                        CellOption(ContentCell, 1, BorderWidthBottom: 0.5f, BorderWidthRight: 0.5f, VerticalAlignment: true,PaddingBottom:5);
                        ContentTable.AddCell(ContentCell);
                    }
                }
                ContentCell = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(" المجموع ")), Font));
                CellOption(ContentCell, 1, BorderWidthBottom: 0.5f, BorderWidthRight: 0.5f, VerticalAlignment: true, PaddingBottom: 5);
                CellOption(Nullc, 1, BorderWidthBottom: 0.5f, BorderWidthRight: 0.5f, VerticalAlignment: true, PaddingBottom: 5);
                AddCellToTable(ContentTable, new List<PdfPCell> { SumCell, Nullc, ContentCell });
                ContentTable.WidthPercentage = 100;
                CellOption(Nullc);
                AddCellToTable(Border, new List<PdfPCell> { TitleCell, Nullc, ContentTableCell, Nullc });
            }
            else
            {
                PdfPTable ExtraData = new PdfPTable(3);
                float[] ExtraDataWidth = new float[] { 1,3,1 };
                ExtraData.SetWidths(ExtraDataWidth);
                for (int Row = 0; Row < 53; Row++)
                {
                    for (int Column = 0; Column < 3; Column++)
                    {
                        ContentCell = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(List[Row][2 - Column])), Font));
                        CellOption(ContentCell, 1, BorderWidthBottom: 0.5f, BorderWidthRight: 0.5f, VerticalAlignment: true);
                        ContentTable.AddCell(ContentCell);
                    }
                }
                for (int Row = 53; Row < Total; Row++)
                {
                    for (int Column = 0; Column < 3; Column++)
                    {
                        ContentCell = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(List[Row][2 - Column])), Font));
                        CellOption(ContentCell, 1, BorderWidthBottom: 0.5f, BorderWidthRight: 0.5f,VerticalAlignment:true);
                        ExtraData.AddCell(ContentCell);
                    }
                }
                PdfPCell ExtraDataCell = new PdfPCell(ExtraData);
                if (ExtraData.Rows.Count() == 0)
                    CellOption(ExtraDataCell);
                ContentCell = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(" المجموع ")), Font));
                CellOption(ContentCell, 1, BorderWidthBottom: 0.5f, BorderWidthRight: 0.5f, VerticalAlignment: true, PaddingBottom: 5);
                CellOption(Nullc, 1, BorderWidthBottom: 0.5f, BorderWidthRight: 0.5f, VerticalAlignment: true, PaddingBottom: 5);
                AddCellToTable(ExtraData, new List<PdfPCell> { SumCell, Nullc, ContentCell });
                ExtraData.WidthPercentage = 100;
                CellOption(Nullc);
                AddCellToTable(Border, new List<PdfPCell> { TitleCell, Nullc, ContentTableCell, Nullc, Nullc, ExtraDataCell, Nullc });
            }
            document.Add(Border);
            PdfPTable FooterTabe = new PdfPTable(2);
            FooterTabe.TotalWidth = document.Right;
            PdfPCell StatisticsManagerSign = new PdfPCell(new Phrase(0, " مدير شعبة الإحصاء ", Font));
            CellOption(StatisticsManagerSign, 1);
            PdfPCell OrganizerSign = new PdfPCell(new Phrase(0, "إسم منظم الإستمارة\n\n" + DeathCertify.OrganizerName, Font));
            CellOption(OrganizerSign, 1, -75);
            AddCellToTable(FooterTabe, new List<PdfPCell> { StatisticsManagerSign, OrganizerSign });
            FooterTabe.WriteSelectedRows(0, -1, 0, document.BottomMargin, writer.DirectContent);
            document.Close();
            var byteInfo = m.ToArray();
            m.Write(byteInfo, 0, byteInfo.Length);
            m.Position = 0;
            return new FileStreamResult(m, "application/pdf");
        }
        public static FileStreamResult DeathFormWomenInChildbearingAgeExcel(DeathCertified DeathCertify, List<List<string>> List)
        {
            var Font = CreateFont();
            MemoryStream m = new MemoryStream();
            var document = new Document(PageSize.A4, 20, 20, 20, 80);
            PdfWriter.GetInstance(document, m).CloseStream = false;
            PdfWriter writer = PdfWriter.GetInstance(document, m);
            writer.CloseStream = false;
            document.Open();
            PdfPTable Border = new PdfPTable(3);
            float[] BorderWidth = new float[] { 0.05f, 0.9f, 0.05f };
            Border.SetWidths(BorderWidth);
            PdfPTable ContentTable = new PdfPTable(3);
            float[] ContentTableWidth = new float[] { 6,4,1 };
            ContentTable.SetWidths(ContentTableWidth);
            PdfPCell Pregnancy = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("Pregnancy , Childbirth and the Peurperium ")), Font));
            CellOption(Pregnancy, 1, BorderWidthTop: 0.5f, BorderWidthLeft: 0.5f, BorderWidthBottom: 0.5f, PaddingBottom: 5, VerticalAlignment: true);
            PdfPCell DeathReason = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("الحمل و الولادة و النفاس")), Font));
            CellOption(DeathReason, 1, BorderWidthTop: 0.5f, BorderWidthLeft: 0.5f, BorderWidthBottom: 0.5f, PaddingBottom: 5, VerticalAlignment: true);
            PdfPCell ID = new PdfPCell(new Phrase(0, ConvertNumerals(NullException("الرمز")), Font));
            CellOption(ID, 1, BorderWidthTop: 0.5f, BorderWidthLeft: 0.5f, BorderWidthRight: 0.5f, BorderWidthBottom: 0.5f, PaddingBottom: 5, VerticalAlignment: true);
            Pregnancy.BackgroundColor = new BaseColor(216, 216, 216);
            DeathReason.BackgroundColor = new BaseColor(216, 216, 216);
            ID.BackgroundColor = new BaseColor(216, 216, 216);
            AddCellToTable(ContentTable, new List<PdfPCell> { Pregnancy, DeathReason, ID });
            PdfPCell ContentCell;
            int Total = 100;
            PdfPCell ContentTableCell = new PdfPCell(ContentTable);
            PdfPCell Nullc = new PdfPCell(new Phrase(0, " ", Font));
            CellOption(Nullc);
            if (Total < 53)
            {
                for (int Row = 0; Row < Total; Row++)
                {
                    for (int Column = 0; Column < 3; Column++)
                    {
                        ContentCell = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(List[Row][2 - Column])), Font));
                        CellOption(ContentCell, 1, BorderWidthBottom: 0.5f, BorderWidthRight: 0.5f, VerticalAlignment: true, PaddingBottom: 5);
                        ContentTable.AddCell(ContentCell);
                    }
                }
                AddCellToTable(Border, new List<PdfPCell> { Nullc, ContentTableCell, Nullc });
            }
            else
            {
                PdfPTable ExtraData = new PdfPTable(3);
                float[] ExtraDataWidth = new float[] { 6, 4, 1 };
                ExtraData.SetWidths(ExtraDataWidth);
                for (int Row = 0; Row < 53; Row++)
                {
                    for (int Column = 0; Column < 3; Column++)
                    {
                        ContentCell = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(List[Row][2 - Column])), Font));
                        CellOption(ContentCell, 1, BorderWidthBottom: 0.5f, BorderWidthRight: 0.5f, VerticalAlignment: true);
                        ContentTable.AddCell(ContentCell);
                    }
                }
                for (int Row = 53; Row < Total; Row++)
                {
                    for (int Column = 0; Column < 3; Column++)
                    {
                        ContentCell = new PdfPCell(new Phrase(0, ConvertNumerals(NullException(List[Row][2 - Column])), Font));
                        CellOption(ContentCell, 1, BorderWidthBottom: 0.5f, BorderWidthRight: 0.5f, VerticalAlignment: true);
                        ExtraData.AddCell(ContentCell);
                    }
                }
                PdfPCell ExtraDataCell = new PdfPCell(ExtraData);
                if (ExtraData.Rows.Count() == 0)
                    CellOption(ExtraDataCell);
                AddCellToTable(Border, new List<PdfPCell> { Nullc, ContentTableCell, Nullc, Nullc, ExtraDataCell, Nullc });
            }
            document.Add(Border);
            document.Close();
            var byteInfo = m.ToArray();
            m.Write(byteInfo, 0, byteInfo.Length);
            m.Position = 0;
            return new FileStreamResult(m, "application/pdf");
        }

    }
}   