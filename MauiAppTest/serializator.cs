using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text.Json;
using Vozila;
using Newtonsoft.Json;

namespace MauiAppTest;


public class serializator
{
    public static BindingList<Oseba>? GetOsebe()
    {
        string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Osebe.txt");

        
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            return System.Text.Json.JsonSerializer.Deserialize<BindingList<Oseba>>(json);
        }

        return new BindingList<Oseba>();
    }

    public static void SaveOsebe(BindingList<Oseba> osebe)
    {
        string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Osebe.txt");
        File.WriteAllText(filePath, System.Text.Json.JsonSerializer.Serialize(osebe));
    }

    public static void SaveVozila(BindingList<Vozilo> vozila, string list)
    {
        string filePath;
        if (list == "VsaVozilaNaProdaji")
        {
            filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), list+".txt");
        }
        else
        { 
            filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), MainPage.PrijavljenaOseba.UporabniskoIme + "_" + list+".txt");

        }
        
        File.WriteAllText(filePath, Newtonsoft.Json.JsonConvert.SerializeObject(vozila, Formatting.Indented, new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All
        }));
    }

    public static BindingList<Vozilo>? GetVozila(string list)
    {

        string filePath;
        
        if (list == "VsaVozilaNaProdaji")
        {
             filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), list+".txt");
        }
        else
        { 
            filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), MainPage.PrijavljenaOseba.UporabniskoIme + "_" + list+".txt");

        }
       
        
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            
            return Newtonsoft.Json.JsonConvert.DeserializeObject<BindingList<Vozilo>>(json, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            });
        }

        return new BindingList<Vozilo>();
    }
}