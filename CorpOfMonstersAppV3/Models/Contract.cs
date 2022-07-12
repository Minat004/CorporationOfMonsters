using CorpOfMonstersAppV3.Services;

namespace CorpOfMonstersAppV3.Models;

public class Contract
{
    public Contract(string? name, int overHours = 0)
    {
        Name = name;
        ContractType = name switch
        {
            StringConst.INTERN => new Intern(),
            StringConst.REGULAR => new Regular(overHours),
            _ => ContractType
        };
    }
    public string? Name { get; set; }
    public IContract? ContractType { get; set; }
    
}