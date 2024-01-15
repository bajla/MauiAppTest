using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MauiAppTest;

public partial class MainPage : ContentPage
{
    int count = 0;
    public static BindingList<Oseba> VseOsebe;
    public static Oseba PrijavljenaOseba;
    
    
    
    public MainPage()
    {
        InitializeComponent();
        VseOsebe = serializator.GetOsebe();
        NavigationPage.SetHasBackButton(this, false);
        VseOsebe.ListChanged += VseOsebeOnListChanged;
    }

    private void VseOsebeOnListChanged(object? sender, ListChangedEventArgs e)
    {
        serializator.SaveOsebe(VseOsebe);
    }


    private void LogBtn_OnClicked(object? sender, EventArgs e)
    {
        if (UserName.Text != "" && Pass.Text != "")
        {
            foreach (var uporabnik in VseOsebe)
            {
                if (UserName.Text == uporabnik.UporabniskoIme)
                {
                    if (uporabnik.PreveriGeslo(Pass.Text))
                    {
                        PrijavljenaOseba = uporabnik;
                        HomePage page = new HomePage();
                        //NavigationPage.SetHasBackButton(page, false);
                        Navigation.PushModalAsync(page);
                        
                    }
                    else DisplayAlert("Napacno geslo", "Vnesi pravo geslo", "OK");
                }
            }
        }
    }

    private void RegBtn_OnClicked(object? sender, EventArgs e)
    {
        Navigation.PushAsync(new Register());
    }
}