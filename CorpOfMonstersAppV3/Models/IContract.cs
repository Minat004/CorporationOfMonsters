namespace CorpOfMonstersAppV3.Models
{
    public interface IContract
    {
        public double Salary();
        
        public int OverHours { get; set; }
    }
}
