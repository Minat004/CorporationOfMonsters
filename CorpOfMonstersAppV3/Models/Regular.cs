using System;

namespace CorpOfMonstersAppV3.Models
{
    internal class Regular: IContract
    {
        private const double DefaultSalary = 4600;
        public Regular(int overHours = 0)
        {
            OverHours = overHours;
        }
        public int OverHours { get; set; }
        public double Salary() => Math.Round(DefaultSalary + OverHours * DefaultSalary / 60, 2);
    }
}
