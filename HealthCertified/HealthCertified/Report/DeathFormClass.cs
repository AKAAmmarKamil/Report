using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HealthCertified.Model;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;

namespace HealthCertified.Report
{
    public class DeathFormClass : Border
    {
        public static FileStreamResult DeathForm(DeathCertified DeathCertify)
        {
            var ColorFont = FontFactory.GetFont(Support.FontPath, BaseFont.IDENTITY_H, true, 12, 1, BaseColor.RED, false);
            var Font = Support.CreateFont();
            MemoryStream m = new MemoryStream();
            var document = new Document(PageSize.A4, 20, 20, 20, 20);
            PdfWriter.GetInstance(document, m).CloseStream = false;
            PdfWriter writer = PdfWriter.GetInstance(document, m);
            writer.CloseStream = false;
            HealthCertified.Report.Border border = new Border();
            writer.PageEvent = border;
            document.Open();
            PdfPTable Border = new PdfPTable(3);
            float[] BorderWidth = new float[] { 0.1f, 0.8f, 0.1f };
            Border.SetWidths(BorderWidth);
            PdfPTable Title = new PdfPTable(1);
            PdfPCell DeprtmentName = new PdfPCell(new Phrase(0, Support.ConvertNumerals(Support.NullException("دائرة " + DeathCertify.CertificateDepartment + "\nمستتشفى " + DeathCertify.HospitalName + "\nشعبة الإحصاء")), Font));
            Support.CellOption(DeprtmentName, PaddingRight: 25, PaddingTop: 25);
            PdfPCell FormTitle = new PdfPCell(new Phrase(0, Support.ConvertNumerals(Support.NullException("إستمارة الوفيات العامة " + DeathCertify.HospitalName
                + " لشهر" + Support.Convert(DateTime.Now.Month.ToString(), month: true)) + " " + DateTime.Now.Year.ToString()), ColorFont));
            Support.CellOption(FormTitle, 1, PaddingTop: 10, PaddingBottom: 10);
            Support.AddCellToTable(Title, new List<PdfPCell> { DeprtmentName, FormTitle });
            PdfPCell TitleCell = new PdfPCell(Title);
            Support.CellOption(TitleCell, Colspan: 3);
            PdfPTable ContentTable = new PdfPTable(9);
            float[] ContentTableWidth = new float[] { 1, 0.5f, 0.5f, 1, 1, 1.5f, 1, 1, 0.3f };
            ContentTable.SetWidths(ContentTableWidth);
            PdfPCell DoctorName = new PdfPCell(new Phrase(0, Support.ConvertNumerals(Support.NullException("إسم الطبيب")), Font));
            Support.CellOption(DoctorName, 1, BorderWidthTop: 0.5f, BorderWidthLeft: 0.5f, BorderWidthBottom: 0.5f, PaddingBottom: 5);
            PdfPCell StayInHospital = new PdfPCell(new Phrase(0, Support.ConvertNumerals(Support.NullException("مدة الرقود بالأيام")), Font));
            Support.CellOption(StayInHospital, 1, BorderWidthTop: 0.5f, BorderWidthLeft: 0.5f, BorderWidthBottom: 0.5f, PaddingBottom: 5);
            PdfPCell Gender = new PdfPCell(new Phrase(0, Support.ConvertNumerals(Support.NullException("الجنس")), Font));
            Support.CellOption(Gender, 1, BorderWidthTop: 0.5f, BorderWidthLeft: 0.5f, BorderWidthBottom: 0.5f, PaddingBottom: 5);
            PdfPCell Age = new PdfPCell(new Phrase(0, Support.ConvertNumerals(Support.NullException("العمر")), Font));
            Support.CellOption(Age, 1, BorderWidthTop: 0.5f, BorderWidthLeft: 0.5f, BorderWidthBottom: 0.5f, PaddingBottom: 5);
            PdfPCell DeathPlace = new PdfPCell(new Phrase(0, Support.ConvertNumerals(Support.NullException("مكان الوفاة")), Font));
            Support.CellOption(DeathPlace, 1, BorderWidthTop: 0.5f, BorderWidthLeft: 0.5f, BorderWidthBottom: 0.5f, PaddingBottom: 5);
            PdfPCell DeathReason = new PdfPCell(new Phrase(0, Support.ConvertNumerals(Support.NullException("سبب الوفاة")), Font));
            Support.CellOption(DeathReason, 1, BorderWidthTop: 0.5f, BorderWidthLeft: 0.5f, BorderWidthBottom: 0.5f, PaddingBottom: 5);
            PdfPCell CertificateNo = new PdfPCell(new Phrase(0, Support.ConvertNumerals(Support.NullException("رقم الشهادة")), Font));
            Support.CellOption(CertificateNo, 1, BorderWidthTop: 0.5f, BorderWidthLeft: 0.5f, BorderWidthBottom: 0.5f, PaddingBottom: 5);
            PdfPCell DeathName = new PdfPCell(new Phrase(0, Support.ConvertNumerals(Support.NullException("إسم المتوفي")), Font));
            Support.CellOption(DeathName, 1, BorderWidthTop: 0.5f, BorderWidthLeft: 0.5f, BorderWidthBottom: 0.5f, PaddingBottom: 5);
            PdfPCell ID = new PdfPCell(new Phrase(0, Support.ConvertNumerals(Support.NullException("ت")), Font));
            Support.CellOption(ID, 1, BorderWidthTop: 0.5f, BorderWidthLeft: 0.5f, BorderWidthRight: 0.5f, BorderWidthBottom: 0.5f, PaddingBottom: 5);
            Support.AddCellToTable(ContentTable, new List<PdfPCell> { DoctorName, StayInHospital, Gender, Age, DeathPlace, DeathReason, CertificateNo, DeathName, ID });
            PdfPCell ContentCell;
            int Total = 56;
            PdfPCell ContentTableCell = new PdfPCell(ContentTable);
            PdfPCell Nullc = new PdfPCell(new Phrase(0, " ", Font));
            Support.CellOption(Nullc);
            if (Total < 53)
            {
                for (int Row = 0; Row < Total; Row++)
                {
                    for (int Column = 0; Column < 9; Column++)
                    {
                        ContentCell = new PdfPCell(new Phrase(0, Support.ConvertNumerals(Support.NullException((Row+1).ToString())), Font));
                        Support.CellOption(ContentCell, 1, BorderWidthBottom: 0.5f, BorderWidthRight: 0.5f);
                        ContentTable.AddCell(ContentCell);
                    }
                }
                Support.AddCellToTable(Border,new List<PdfPCell> { TitleCell, Nullc, ContentTableCell, Nullc, Nullc, Nullc, Nullc });
            }
            else
            {
                PdfPTable ExtraData = new PdfPTable(9);
                float[] ExtraDataWidth = new float[] { 1, 0.5f, 0.5f, 1, 1, 1.5f, 1, 1, 0.3f };
                ExtraData.SetWidths(ExtraDataWidth);
                for (int Row = 0; Row < 53; Row++)
                {
                    for (int Column = 0; Column < 9; Column++)
                    {
                        ContentCell = new PdfPCell(new Phrase(0, Support.ConvertNumerals(Support.NullException((Row + 1).ToString())), Font));
                        Support.CellOption(ContentCell, 1, BorderWidthBottom: 0.5f, BorderWidthRight: 0.5f);
                        ContentTable.AddCell(ContentCell);
                    }
                }
                for (int Row = 53; Row < Total; Row++)
                {
                    for (int Column = 0; Column < 9; Column++)
                    {
                        ContentCell = new PdfPCell(new Phrase(0, Support.ConvertNumerals(Support.NullException((Row + 1).ToString())), Font));
                        Support.CellOption(ContentCell, 1, BorderWidthBottom: 0.5f, BorderWidthRight: 0.5f);
                        ExtraData.AddCell(ContentCell);
                    }
                }
                PdfPCell ExtraDataCell = new PdfPCell(ExtraData);
                if (ExtraData.Rows.Count() == 0)
                    Support.CellOption(ExtraDataCell);
                Support.AddCellToTable(Border, new List<PdfPCell> { TitleCell, Nullc, ContentTableCell, Nullc, Nullc, ExtraDataCell, Nullc, Nullc, Nullc, Nullc });
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