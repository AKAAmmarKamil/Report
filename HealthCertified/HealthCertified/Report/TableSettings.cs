using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Collections.Generic;

namespace HealthCertified.Report
{
    class TableSettings //This Class is used to adjust settings
    {
        public static void CellOption(PdfPCell cell, int HorizontalAlignment = 0, //This Method is Used To Set Cell properties
          float PaddingRight = 0, int Colspan = 1, int Rowspan = 1,
         float PaddingBottom = 0,
        float PaddingLeft = 0, float PaddingTop = 0,
         float BorderWidthRight = 0
        , float BorderWidthLeft = 0, float BorderWidthTop = 0,
        float BorderWidthBottom = 0,
            int Rotation = 0, int RunDirection = 1, bool VerticalAlignment = false)
        {
            if (RunDirection == 1)
                cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            cell.HorizontalAlignment = HorizontalAlignment;
            cell.BorderWidthRight = BorderWidthRight;
            cell.BorderWidthLeft = BorderWidthLeft;
            cell.BorderWidthTop = BorderWidthTop;
            cell.BorderWidthBottom = BorderWidthBottom;
            cell.PaddingRight = PaddingRight;
            cell.PaddingLeft = PaddingLeft;
            cell.PaddingTop = PaddingTop;
            cell.PaddingBottom = PaddingBottom;
            cell.Colspan = Colspan;
            cell.Rowspan = Rowspan;
            cell.Rotation = Rotation;
            if (VerticalAlignment)
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
        } 
        //This Method is Used To Add Cell To The Table
       
        public static void AddCellToTable(PdfPTable table, List<PdfPCell> cell)
        {
            table.WidthPercentage = 103.5f;
            for (int i = 0; i < cell.Count; i++)
            {
                if (cell[i] == null) /*Here We Make Sure The Cell is Not Empty*/
                    cell[i] = cell[0];   //Here we fill cells temporarily with the first cell Because We Can't Leave it Null
                else table.AddCell(cell[i]); //  If It's Not Empty We Add it To The Table  
            }
        }
    }
}