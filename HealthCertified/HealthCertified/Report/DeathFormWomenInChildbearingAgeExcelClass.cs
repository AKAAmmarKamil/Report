using System;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Linq;
using HealthCertified.Model;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;

namespace HealthCertified.Report
{
     class DeathFormWomenInChildbearingAgeExcelClass : Support
    {
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
            float[] ContentTableWidth = new float[] { 6, 4, 1 };
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
            AddCellToTable( ContentTable, new List<PdfPCell> { Pregnancy, DeathReason, ID });
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
                AddCellToTable(Border, new List<PdfPCell> { Nullc, ContentTableCell, Nullc});
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
                AddCellToTable(Border,new List<PdfPCell> { Nullc, ContentTableCell, Nullc, Nullc, ExtraDataCell, Nullc });
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