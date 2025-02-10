// Type not placed in any named NAMESPACE belongs to the global namespace
class NamesFormatter
{
    public string Format(List<string> names) => string.Join(Environment.NewLine, names);
}


