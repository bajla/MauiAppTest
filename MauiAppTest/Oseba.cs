using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace MauiAppTest;

public class Oseba
{
    private string _uporabniskoIme;
    private string _geslo;
    private bool _hashed = true;

    public string UporabniskoIme
    {
        get => _uporabniskoIme;
        set => _uporabniskoIme = value;
    }

    [DataMember]
    public bool Hashed => _hashed;

    public string Geslo
    {
        get => _geslo;
    }

    
    public Oseba(string uporabniskoIme, string geslo)
    {

        _uporabniskoIme = uporabniskoIme;
        _geslo = PasswordHelper.HashPassword(geslo);
        
        
    }

    [JsonConstructor]
    public Oseba(string uporabniskoIme, string geslo, bool hashed = true)
    {
        _uporabniskoIme = uporabniskoIme;
        _geslo = geslo;

    }

    public bool PreveriGeslo(string geslo)
    {
        return PasswordHelper.VerifyPassword(geslo, _geslo);
    }

    public bool CheckIfUserExists()
    {
        foreach (var i in MainPage.VseOsebe)
        {
            if (i._uporabniskoIme == _uporabniskoIme)
            {
                return true;
            }
        }

        return false;
    }
}