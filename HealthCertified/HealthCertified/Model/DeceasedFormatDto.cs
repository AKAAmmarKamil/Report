using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCertified.Model
{
    public class DeceasedFormatDto
    {
        [Key]
        public int Day7Male { get; set; }
        public int Day7FeMale { get; set; }
        public int Day28Male { get; set; }
        public int Day28FeMale { get; set; }
        public int? Day1yMale { get; set; }
        public int? Day1yFeMale { get; set; }
        public int? Day4yMale { get; set; }
        public int? Day4yFeMale { get; set; }
        public int Day5yMale { get; set; }
        public int Day5yFeMale { get; set; }
        public int Day12y48FeMale { get; set; }
        public int MothersFeMale { get; set; }

    }
}
