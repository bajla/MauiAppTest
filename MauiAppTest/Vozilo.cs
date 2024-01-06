namespace MauiAppTest;

public abstract class Vozilo
{
    public string Ime { get; set; }
    public double Cena { get; private set; }
    public bool Najeto { get; private set; }
    
    public int StSedezov { get; set; }
    public int LetnikVozila { get; set; }
    public int StLastnikov { get; set; }
    public int StNajemov { get; private set; }
    public int MaxHitrost { get; set; }
    public int MaxStPotnikov { get; set; }

    public void NastaviCeno(int cena)
    {
        Cena = cena;
    }

    public void JeNajeto(bool stanje)
    {
        Najeto = stanje;
    }

    public void Najem()
    {
        StNajemov++;
    }

    protected Vozilo(string ime, double cena, int stSedezov, int letnikVozila, int stLastnikov, int stNajemov, int maxHitrost, int maxStPotnikov)
    {
        Ime = ime;
        Cena = cena;
        StSedezov = stSedezov;
        LetnikVozila = letnikVozila;
        StLastnikov = stLastnikov;
        StNajemov = stNajemov;
        MaxHitrost = maxHitrost;
        MaxStPotnikov = maxStPotnikov;
    }
}
//---
public class KopnoVozilo : Vozilo
{
    public KopnoVozilo(string ime, double cena, int stSedezov, int letnikVozila, int stLastnikov, int stNajemov, int maxHitrost, int maxStPotnikov, int stKoles, int velikostKoles) 
        : base(ime, cena, stSedezov, letnikVozila, stLastnikov, stNajemov, maxHitrost, maxStPotnikov)
    {
        StKoles = stKoles;
        VelikostKoles = velikostKoles;
    }

    public int StKoles { get; set; }
    public int VelikostKoles { get; set; }
}

public class KopnoMotorno : KopnoVozilo, IMotorno
{
    public KopnoMotorno(string ime, double cena, int stSedezov, int letnikVozila, int stLastnikov, int stNajemov, int maxHitrost, int maxStPotnikov, int stKoles, int velikostKoles, int velikostMotorja, int stCilindrov, int mocMotorja, int poraba, string vrstaGoriva) 
        : base(ime, cena, stSedezov, letnikVozila, stLastnikov, stNajemov, maxHitrost, maxStPotnikov, stKoles, velikostKoles)
    {
        VelikostMotorja = velikostMotorja;
        StCilindrov = stCilindrov;
        MocMotorja = mocMotorja;
        PorabaNa100km = poraba;
        VrstaGoriva = vrstaGoriva;
    }

    public int VelikostMotorja { get; set; }
    public int StCilindrov { get; set; }
    public int MocMotorja { get; set; }
    
    public string VrstaGoriva { get; set; }

    public int PorabaNa100km { get; set; }
    
    public int StanjeGoriva { get; private set; }
    
    public void NatankajVozilo(int litri)
    {
        StanjeGoriva += litri;
    }

    public void KmPrevozenih(int km)
    {
        StanjeGoriva -= (PorabaNa100km/100) * km;
    }
    
}

public class KopnoNemotorno : KopnoVozilo, INemotorno
{
    public KopnoNemotorno(string ime, double cena, int stSedezov, int letnikVozila, int stLastnikov, int stNajemov, int maxHitrost, int maxStPotnikov, int stKoles, int velikostKoles) 
        : base(ime, cena, stSedezov, letnikVozila, stLastnikov, stNajemov, maxHitrost, maxStPotnikov, stKoles, velikostKoles)
    {
        
    }

    public bool Prenosljiva { get; set; }
    public bool Zlozljiva { get; set; }
    public int Luci { get; set; }
    
    public int StPrestav { get; set; }
}
//---
public class VodnoVozilo : Vozilo
{
    public VodnoVozilo(string ime, double cena, int stSedezov, int letnikVozila, int stLastnikov, int stNajemov, int maxHitrost, int maxStPotnikov) 
        : base(ime, cena, stSedezov, letnikVozila, stLastnikov, stNajemov, maxHitrost, maxStPotnikov)
    {
        
    }

    public string VrstaTrupa { get; set; }
    public int MaxGlobinaVode { get; set; }
    public string NavigacijskiSistem { get; set; }
}

public class VodnoMotorno : VodnoVozilo, IMotorno
{
    public VodnoMotorno(string ime, double cena, int stSedezov, int letnikVozila, int stLastnikov, int stNajemov, int maxHitrost, int maxStPotnikov, int velikostMotorja, int stCilindrov, int mocMotorja, int poraba, string vrstaGoriva, int stMotorjev) 
        : base(ime, cena, stSedezov, letnikVozila, stLastnikov, stNajemov, maxHitrost, maxStPotnikov)
    {
        VelikostMotorja = velikostMotorja;
        StCilindrov = stCilindrov;
        MocMotorja = mocMotorja;
        PorabaNa100km = poraba;
        VrstaGoriva = vrstaGoriva;
        StMotorjev = stMotorjev;
    }

    public int VelikostMotorja { get; set; }
    public int StCilindrov { get; set; }
    public int MocMotorja { get; set; }
    public string VrstaGoriva { get; set; }
    
    public int StMotorjev { get; set; }
    
    public int PorabaNa100km { get; set; }
    
    public int StanjeGoriva { get; private set; }
    
    public void NatankajVozilo(int litri)
    {
        StanjeGoriva += litri;
    }

    public void KmPrevozenih(int km)
    {
        StanjeGoriva -= (PorabaNa100km/100) * km;
    }
}

public class VodnoNemotorno : VodnoVozilo, INemotorno
{
    public VodnoNemotorno(string ime, double cena, int stSedezov, int letnikVozila, int stLastnikov, int stNajemov, int maxHitrost, int maxStPotnikov) 
        : base(ime, cena, stSedezov, letnikVozila, stLastnikov, stNajemov, maxHitrost, maxStPotnikov)
    {
        
    }

    public bool Prenosljiva { get; set; }
    public bool Zlozljiva { get; set; }
    public int Luci { get; set; }
    
    
}


