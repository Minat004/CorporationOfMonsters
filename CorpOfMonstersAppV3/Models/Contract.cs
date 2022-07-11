using CorpOfMonstersAppV3.Services;

namespace CorpOfMonstersAppV3.Models;

public class Contract
{
    public Contract(string? name, int overHours = 0)
    {
        Name = name;
        if (overHours == 0 && name == StringConst.INTERN)
        {
            ContractType = new Intern();
        }
        else
        {
            ContractType = new Regular(overHours);
        }
    }
    public string? Name { get; set; }
    public IContract? ContractType { get; set; }
    
}