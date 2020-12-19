using iTextSharp.text;
using iTextSharp.text.pdf;
namespace HealthCertified.Report
{
    class Support : TableSettings
    {
        public static string FontPath;
        public static string PicturePath;
        public static string Picture2Path;
        public static string Picture3Path;
        public static string TheFontPath;
        public static string Convert(string number,bool Hour=false,bool Number=false,bool masculine=false,bool month=false)
        {
            if (month == true)
            {
                if (number == "1")
                    return "كانون الثاني";
                else if (number == "2")
                    return "شباط";
                else if (number == "3")
                    return "آذار";
                else if (number == "4")
                    return "نيسان";
                else if (number == "5")
                    return "آيار";
                else if (number == "6")
                    return "حزيران";
                else if (number == "7")
                    return "تموز";
                else if (number == "8")
                    return "آب";
                else if (number == "9")
                    return "أيلول";
                else if (number == "10")
                    return "تشرين الأول";
                else if (number == "11")
                    return "تشرين الثاني";
                else if (number == "12")
                    return "كانون الأول";
            }
            if (Number == true)
            {
                string Minutes = "";
                if (number.Length == 1)
                {
                    if (masculine == true)
                    {
                        if (number == "0")
                            Minutes += "لا يوجد";
                        else if (number == "1")
                            Minutes += "واحد";
                        else if (number == "2")
                            Minutes += "إثنان";
                        else if (number == "3")
                            Minutes += "ثلاث";
                        else if (number == "4")
                            Minutes += "أربع";
                        else if (number == "5")
                            Minutes += "خمس";
                        else if (number == "6")
                            Minutes += "ستة";
                        else if (number == "7")
                            Minutes += "سبعة";
                        else if (number == "8")
                            Minutes += "ثمانية";
                        else if (number == "9")
                            Minutes += "تسعة";
                    }
                    else
                    {
                        if (number == "1")
                            Minutes += "إحدى";
                        else if (number == "2")
                            Minutes += "إثنان";
                        else if (number == "3")
                            Minutes += "ثلاث";
                        else if (number == "4")
                            Minutes += "أربع";
                        else if (number == "5")
                            Minutes += "خمس";
                        else if (number == "6")
                            Minutes += "ستة";
                        else if (number == "7")
                            Minutes += "سبعة";
                        else if (number == "8")
                            Minutes += "ثمانية";
                        else if (number == "9")
                            Minutes += "تسعة";
                    }
                }
                else
                {
                    if (number[1] == '1')
                        Minutes += "إحدى";
                    else if (number[1] == '2')
                        Minutes += "إثنتا";
                    else if (number[1] == '3')
                        Minutes += "ثلاث";
                    else if (number[1] == '4')
                        Minutes += "أربع";
                    else if (number[1] == '5')
                        Minutes += "خمس";
                    else if (number[1] == '6')
                        Minutes += "ست";
                    else if (number[1] == '7')
                        Minutes += "سبع";
                    else if (number[1] == '8')
                        Minutes += "ثماني";
                    else if (number[1] == '9')
                        Minutes += "تسع";
                    if (number[0] == '1')
                        Minutes = Minutes + " عشرة ";
                    else if (number[0] == '2')
                        Minutes = Minutes + " و عشرون ";
                    else if (number[0] == '3')
                        Minutes = Minutes + " و ثلاثون ";
                    else if (number[0] == '4')
                        Minutes = Minutes + " و أربعون ";
                    else if (number[0] == '5')
                        Minutes = Minutes + " و خمسون ";
                }

                return Minutes;
            }

            if (Hour == true&&number=="1")
                return "الواحد";
            if (number == "10")
                return "العاشر";
            if (number == "11")
                return "الحادي عشر";
            if (Hour == true)
            {
                if (number.Length == 1)
                {
                    if (number == "1")
                        return "الواحدة";
                    else if (number == "2")
                        return "الثانية";
                    else if (number == "3")
                        return "الثالثة";
                    else if (number == "4")
                        return "الرابعة";
                    else if (number == "5")
                        return "الخامسة";
                    else if (number == "6")
                        return "السادسة";
                    else if (number == "7")
                        return "السابعة";
                    else if (number == "8")
                        return "الثامنة";
                    else if (number == "9")
                        return "التاسعة";
                }
                if (number.Length == 2)
                {
                    string thenum = "";
                    if (number[1] == '1')
                        thenum += " الواحدة ";
                    else if (number[1] == '2')
                        thenum += " الثانية ";
                    else if (number[1] == '3')
                        thenum += " الثالثة ";
                    else if (number[1] == '4')
                        thenum += "  الرابعة";
                    else if (number[1] == '5')
                        thenum += " الخامسة ";
                    else if (number[1] == '6')
                        thenum += " السادسة ";
                    else if (number[1] == '7')
                        thenum += " السابعة ";
                    else if (number[1] == '8')
                        thenum += " الثامنة ";
                    else if (number[1] == '9')
                        thenum += " التاسعة ";
                    if (number[0] == '1')
                        thenum += " عشر ";
                    else if (number[0] == '2')
                        thenum += " و العشرون ";
                    else if (number[0] == '3')
                        thenum += " والثلاثون ";
                    return thenum;
                }
            }
            if (number.Length == 1)
            {
                if (number == "1")
                    return "الأول";
                else if (number == "2")
                    return "الثاني";
                else if (number == "3")
                    return "الثالث";
                else if (number == "4")
                    return "الرابع";
                else if (number == "5")
                    return "الخامس";
                else if (number == "6")
                    return "السادس";
                else if (number == "7")
                    return "السابع";
                else if (number == "8")
                    return "الثامن";
                else if (number == "9")
                    return "التاسع";
            }
            if (number.Length == 2)
            {
                string thenum = "";
                if (number[1] == '1')
                    thenum += " الواحد ";
                else if (number[1] == '2')
                    thenum += " الثاني ";
                else if (number[1] == '3')
                    thenum += " الثالث ";
                else if (number[1] == '4')
                    thenum += "  الرابع";
                else if (number[1] == '5')
                    thenum += " الخامس ";
                else if (number[1] == '6')
                    thenum += " السادس ";
                else if (number[1] == '7')
                    thenum += " السابع ";
                else if (number[1] == '8')
                    thenum += " الثامن ";
                else if (number[1] == '9')
                    thenum += " التاسع ";
                if (number[0] == '1')
                    thenum += " عشر ";
                else if (number[0] == '2')
                    thenum += " و العشرون ";
                else if (number[0] == '3')
                    thenum += " والثلاثون ";
                return thenum;
            }
            if (number.Length == 4)
            {
                string year = "";
                if (number[0] == '1')
                    year = year + " ألف و";
                else if (number[0] == '2')
                    year = year + "الفان و ";
                if (number[1] == '1')
                    year = year + " مائة و";
                else if (number[1] == '2')
                    year = year + " مائتان و";
                else if (number[1] == '3')
                    year = year + " ثلاثمائة و";
                else if (number[1] == '4')
                    year = year + " أربعمائة و";
                else if (number[1] == '5')
                    year = year + " خمسمائة و";
                else if (number[1] == '6')
                    year = year + " ستمائة و";
                else if (number[1] == '7')
                    year = year + " سبعمائة و";
                else if (number[1] == '8')
                    year = year + "  ثمانمائة و ";
                else if (number[1] == '9')
                    year = year + " تسعمائة و ";
                if (number[3] == '1')
                    year = year + " واحد ";
                else if (number[3] == '2')
                    year = year + " اثنان ";
                else if (number[3] == '3')
                    year = year + " ثلاثة ";
                else if (number[3] == '4')
                    year = year + " أربعة ";
                else if (number[3] == '5')
                    year = year + " خمسة ";
                else if (number[3] == '6')
                    year = year + " ستة ";
                else if (number[3] == '7')
                    year = year + " سبعة ";
                else if (number[3] == '8')
                    year = year + " ثمانية ";
                else if (number[3] == '9')
                    year = year + " تسعة ";
                if (number[2] == '1')
                    year = year + "عشر";
                else if (number[2] == '2')
                    year = year + "عشرون";
                else if (number[2] == '3')
                    year = year + "ثلاثون";
                else if (number[2] == '4')
                    year = year + "أربعون";
                else if (number[2] == '5')
                    year = year + "خمسون";
                else if (number[2] == '6')
                    year = year + "ستون";
                else if (number[2] == '7')
                    year = year + "سبعون";
                else if (number[2] == '8')
                    year = year + "ثمانون";
                else if (number[2] == '9')
                    year = year + "تسعون";
                return year;
            }
            return "";
        }
        public static void SetPaths(string Fontpth, string Picturepath,string thefontpth) //This Method is Used For Set The Path Of Font(s) And Picture(s)
        {
            TheFontPath = thefontpth;
            PicturePath = Picturepath;
            FontPath = Fontpth;
        }
        public static void SetPaths(string Fontpth, string Picturepath, string Picture2path, string Picture3path, string thefontpth) //This Method is Used For Set The Path Of Font(s) And Picture(s)
        {
            TheFontPath = thefontpth;
            PicturePath = Picturepath;
            Picture2Path = Picture2path;
            Picture3Path = Picture3path;
            FontPath = Fontpth;
        }
        public static Font CreateFont(float fontSize = 12f, int style = 1, bool mark = false, bool white = false,bool Color=false) // This Method is Used For Create The Font And Set properties To The Font
        {
            BaseFont basefont;
            var ColorFont = FontFactory.GetFont(FontPath, BaseFont.IDENTITY_H, true, 12, 1, BaseColor.BLUE, false);
            if (mark)
            {
                ColorFont = FontFactory.GetFont(TheFontPath, BaseFont.IDENTITY_H, true, 12, 1, BaseColor.BLUE, false);
                basefont = BaseFont.CreateFont(TheFontPath, BaseFont.IDENTITY_H, true); /* Here We Check The Font if It To The Mark(True And False) Or To The Other Report Component */
            }
            else basefont = BaseFont.CreateFont(FontPath, BaseFont.IDENTITY_H, true);
            var chunk = new Chunk();
            var theFont = new Font(basefont, fontSize, style, chunk.Font.Color); //Here We Set The properties To The Font
            chunk.Font = theFont;
            var MyFont = FontFactory.GetFont(FontPath, fontSize, BaseColor.YELLOW);
            if (white == true)
                return MyFont;
            if (Color == true)
            {
                return ColorFont;
            }
            return theFont;
        }
        public static Image Picture(int xPos, int yPos, float xSize, float ySize, bool Rotate = false, string path = "", bool Picture = false) //This Method is Used For Add a Picture To The Report
        {
            var image = Image.GetInstance(PicturePath);
            if (Picture == true)
            {
                image = Image.GetInstance(path); // Here We Make Object From image And Put The Path
            }
            image.ScaleAbsolute(xSize, ySize); //Here We Set The image Size
            image.SetAbsolutePosition(xPos, yPos); //Here We Set The image Location
            if (Rotate == true)
                image.RotationDegrees = 270;
            return image;
        }
        public static string ConvertNumerals(string input)
        {
            string[] Arabic = new string[10] { "\u0660", "\u0661", "\u0662", "\u0663", "\u0664", "\u0665", "\u0666", "\u0667", "\u0668", "\u0669" };
            for (int j = 0; j < Arabic.Length; j++)
            {
                input = input.Replace(j.ToString(), Arabic[j]);
            }

            return input;
        }
        public static string NullException(string input)
        {
            if (input == null || input == "") return " ";
            else return input;
        }
    }

}
