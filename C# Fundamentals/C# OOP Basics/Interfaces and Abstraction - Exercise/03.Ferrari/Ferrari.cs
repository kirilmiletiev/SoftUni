public class Ferrari : ICar
{
    public string Model { get; set; }
    public string Name { get; set; }
    public string Brake { get; set; }
    public string Gas { get; set; }

    public Ferrari( string name)
    {
        this.Model = "488-Spider";
        this.Name = name;
        this.Brake = "Brakes!";
        this.Gas = "Zadu6avam sA!";
    }

    public override string ToString()
    {
        return $"488-Spider/Brakes!/Zadu6avam sA!/{this.Name}";
    }
}