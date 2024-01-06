using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppTest;

public partial class Register : ContentPage
{
    public Register()
    {
        InitializeComponent();
    }

    private void RegBtn_OnClicked(object? sender, EventArgs e)
    {
        Oseba oseba = new Oseba(UserName.Text, Pass.Text);
        if (oseba.CheckIfUserExists()) { DisplayAlert("Uporabnik obstaja", "Vnesi novo uporabnisko ime", "OK"); return;}
        MainPage.VseOsebe.Add(oseba);
        Navigation.PopAsync();
    }
}