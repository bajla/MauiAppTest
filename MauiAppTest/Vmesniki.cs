namespace MauiAppTest;

public interface IMotorno
{
    public int VelikostMotorja { get; set; }
    public int StCilindrov { get; set; }
    public int MocMotorja { get; set; }
    public int PorabaNa100km { get; set; }
    public string VrstaGoriva { get; set; }
    
    public int StanjeGoriva { get; }

    public void NatankajVozilo(int litri);

    public void KmPrevozenih(int km);
}

public interface INemotorno
{
    public bool Prenosljiva { get; set; }
    public bool Zlozljiva { get; set; }
    public int Luci { get; set; }
}