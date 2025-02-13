// Type not placed in any named NAMESPACE belongs to the global namespace
public class Names
{
    public List<string> All { get; } = new List<string>();
    private readonly NamesValidator _namesValidator = new NamesValidator();
    
    public void AddNames(List<string> stringFromFile)
    {
        foreach (var name in stringFromFile)
        {
            AddName(name);
        }
    }

    public void AddName(string name)
    {       
        if (_namesValidator.IsValid(name))
        {          
            All.Add(name);
        }
    }
}