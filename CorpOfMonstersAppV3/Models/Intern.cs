using System;

namespace CorpOfMonstersAppV3.Models
{
    internal class Intern: IContract
    {
        private const double DefaultSalary = 2000;
        public double Salary() => Math.Round(DefaultSalary);

        public int OverHours { get; set; } = 0;
    }
}
