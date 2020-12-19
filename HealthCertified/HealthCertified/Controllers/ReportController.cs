using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using HealthCertified.Model;
using HealthCertified.Report;
using System.Linq;

namespace HealthCertified.Controllers
{
    [Route("api/[action]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        [Obsolete]
        private readonly IHostingEnvironment _environment;
        private readonly HealthContext _dbContext;

        [Obsolete]
        public ReportController(HealthContext dbContext, IHostingEnvironment environment)
        {
            _dbContext = dbContext;
            _environment = environment;
        }
        [HttpGet]
        [Obsolete]
        public async Task<FileStreamResult> BirthCertified(int Id)
        {
            List<List<int>> MainTableList = new List<List<int>>();
            List<List<int>> MutiBirthList = new List<List<int>>();
            int[] MinTableListRow = new int[10];
            int[] MutiBirthListRow = new int[6];
            Random rnd = new Random();
            int Number = 0;
            for (int i = 0; i < 35; i++)
            {
                for (int ColumnCounter = 0; ColumnCounter < 10; ColumnCounter++)
                {
                    Number = rnd.Next(0, 9);
                    MinTableListRow[ColumnCounter] = Number;
                }
                MainTableList.Add(new List<int> { MinTableListRow[0], MinTableListRow[1], MinTableListRow[2], MinTableListRow[3], MinTableListRow[4],
                MinTableListRow[5], MinTableListRow[6], MinTableListRow[7], MinTableListRow[8], MinTableListRow[9] });
            }
            for (int i = 0; i < 4; i++)
            {
                for (int ColumnCounter = 0; ColumnCounter < 6; ColumnCounter++)
                {
                    Number = rnd.Next(0, 9);
                    MutiBirthListRow[ColumnCounter] = Number;
                }
                MutiBirthList.Add(new List<int> { MutiBirthListRow[0], MutiBirthListRow[1], MutiBirthListRow[2], MutiBirthListRow[3], MutiBirthListRow[4], MutiBirthListRow[5]});
            }
            _environment.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Files\");
            Console.WriteLine(_environment.WebRootPath);
            var result = await _dbContext.CertifiedInfo.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (result != null)
            {
                Support.SetPaths(_environment.WebRootPath + @"\MainFont.ttf",
                               _environment.WebRootPath + @"\Logo.jpg",
                               _environment.WebRootPath + @"\Wingdings Regular.ttf");
                var res =CreateFilePdf.CreateBirthStatistics(result, MainTableList, MutiBirthList);
                return res;
            }
            return null;
        }
        [HttpGet]
        [Obsolete]
        public async Task<FileStreamResult> BirthCertifiedRatification(int Id)
        {

            _environment.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Files\");
            Console.WriteLine(_environment.WebRootPath);
            var result = await _dbContext.CertifiedInfo.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (result != null)
            {
                Support.SetPaths(_environment.WebRootPath + @"\MainFont.ttf",
                                 _environment.WebRootPath + @"\Logo.jpg",
                                 _environment.WebRootPath + @"\Wingdings Regular.ttf");
                var res = CreateFilePdf.CreateBirthCertified(result);
                return res;
            }
            return null;
        }
        [HttpGet]
        [Obsolete]
        public async Task<FileStreamResult> DeathCertified(int Id)
        {
            List<List<string>> MainTableList = new List<List<string>>();
            string[] MinTableListRow = new string[21];
            Random rnd = new Random();
            string Number = "0";
            for (int i = 0; i < 100; i++)
            {
                for (int ColumnCounter = 0; ColumnCounter < 3; ColumnCounter++)
                {
                    //if (i % 2 == 0)
                        Number = (rnd.Next(0, 9)).ToString();
                    //else
                    //    Number = null;
                    MinTableListRow[ColumnCounter] = Number;
                }
                MainTableList.Add(new List<string> { MinTableListRow[0], MinTableListRow[1], MinTableListRow[2]/*, MinTableListRow[3], MinTableListRow[4],
                MinTableListRow[5], MinTableListRow[6], MinTableListRow[7], MinTableListRow[8], MinTableListRow[9],
                MinTableListRow[10], MinTableListRow[11], MinTableListRow[12], MinTableListRow[13], MinTableListRow[14],
                MinTableListRow[15], MinTableListRow[16], MinTableListRow[17], MinTableListRow[18], MinTableListRow[19], MinTableListRow[20]*/});
            }
            DeceasedFormatDto DeceasedFormatDto = new DeceasedFormatDto();
            DeceasedFormatDto.Day7Male = 5;
            DeceasedFormatDto.Day7FeMale = 3;
            DeceasedFormatDto.Day28Male = 1;

            DeceasedFormatDto.Day28FeMale = 0;
            DeceasedFormatDto.Day1yMale = null;
            DeceasedFormatDto.Day1yFeMale = null;

            DeceasedFormatDto.Day4yMale = null;
            DeceasedFormatDto.Day4yFeMale = null;
            DeceasedFormatDto.Day5yMale = 108;

            DeceasedFormatDto.Day5yFeMale = 106;
            DeceasedFormatDto.Day12y48FeMale = 25;
            DeceasedFormatDto.MothersFeMale = 0;

            _environment.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Files\");
            Console.WriteLine(_environment.WebRootPath);
            var result = await _dbContext.DeathCertified.Where(x => x.CertificateNo == Id).FirstOrDefaultAsync();
           if (result != null)
            {
                Support.SetPaths(_environment.WebRootPath + @"\MainFont.ttf",
                    _environment.WebRootPath + @"\Logo.jpg",
                    _environment.WebRootPath + @"\Map.jpg",
                    _environment.WebRootPath + @"\Report.jpg",
                    _environment.WebRootPath + @"\Wingdings Regular.ttf");
               var res= CreateFilePdf.CreateDeathCertified(result);
                return res;
            }
            return null;
        }
        [HttpGet]
        [Obsolete]
        public async Task<FileStreamResult> DeathCertifiedRatification(int Id)
        {
            _environment.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Files\");
            Console.WriteLine(_environment.WebRootPath);
            var result = await _dbContext.DeathCertified.Where(x => x.CertificateNo == Id).FirstOrDefaultAsync();
            if (result != null)
            {
                Support.SetPaths(_environment.WebRootPath + @"\MainFont.ttf",
                    _environment.WebRootPath + @"\Logo.jpg",
                    _environment.WebRootPath + @"\Wingdings Regular.ttf");
                var res = CreateFilePdf.CreateDeathCertifiedRatification(result);
                return res;
            }
            return null;
        }
    }
}