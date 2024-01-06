using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text.Json;

namespace MauiAppTest;


public class serializator
{
    public static BindingList<Oseba>? GetOsebe()
    {
        string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Osebe.txt");

        
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<BindingList<Oseba>>(json);
        }

        return new BindingList<Oseba>();
    }

    public static void SaveOsebe(BindingList<Oseba> osebe)
    {
        string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Osebe.txt");
        File.WriteAllText(filePath, JsonSerializer.Serialize(osebe));
    }
}