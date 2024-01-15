using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vozila;

namespace MauiAppTest;

public partial class DodajVozilo : ContentPage
{
    private HomePage _homePage;
    public DodajVozilo(HomePage homePage)
    {
        InitializeComponent();
        _homePage = homePage;


    }

    private void Nazaj_OnClicked(object? sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }

    private void IsCheckBoxChanged(object? sender, EventArgs e)
    {

        List<CheckBox> list = new List<CheckBox>() { Avto, Kolo, Coln, Jahta, Vodno, Kopensko };
        CheckBox? check = sender as CheckBox;

        foreach (var i in list)
        {
            if(i == check) continue;
            i.IsChecked = false;
        }

        if (Avto.IsChecked)
        {
            Grid_Kolo.IsVisible = false;
            Grid_Avto.IsVisible = true;
            Grid_Coln.IsVisible = false;
            Grid_Jahta.IsVisible = false;
            Grid_Kopensko.IsVisible = false;
            Grid_Vodno.IsVisible = false;
            Btn_Dodaj.IsEnabled = true;
        }
        else if (Kolo.IsChecked)
        {
            Grid_Kolo.IsVisible = true;
            Grid_Avto.IsVisible = false;
            Grid_Coln.IsVisible = false;
            Grid_Jahta.IsVisible = false;
            Grid_Kopensko.IsVisible = false;
            Grid_Vodno.IsVisible = false;
            Btn_Dodaj.IsEnabled = true;
        }
        else if (Coln.IsChecked)
        {
            Grid_Coln.IsVisible = true;
            Grid_Avto.IsVisible = false;
            Grid_Kolo.IsVisible = false;
            Grid_Jahta.IsVisible = false;
            Grid_Kopensko.IsVisible = false;
            Grid_Vodno.IsVisible = false;
            Btn_Dodaj.IsEnabled = true;
        }
        else if (Jahta.IsChecked)
        {
            Grid_Coln.IsVisible = false;
            Grid_Avto.IsVisible = false;
            Grid_Kolo.IsVisible = false;
            Grid_Jahta.IsVisible = true;
            Grid_Kopensko.IsVisible = false;
            Grid_Vodno.IsVisible = false;
            Btn_Dodaj.IsEnabled = true;
        }
        else if(Kopensko.IsChecked)
        {
            Grid_Coln.IsVisible = false;
            Grid_Avto.IsVisible = false;
            Grid_Kolo.IsVisible = false;
            Grid_Jahta.IsVisible = false;
            Grid_Kopensko.IsVisible = true;
            Grid_Vodno.IsVisible = false;
            Btn_Dodaj.IsEnabled = true;
        }
        else if(Vodno.IsChecked)
        {
            Grid_Coln.IsVisible = false;
            Grid_Avto.IsVisible = false;
            Grid_Kolo.IsVisible = false;
            Grid_Jahta.IsVisible = false;
            Grid_Kopensko.IsVisible = false;
            Grid_Vodno.IsVisible = true;
            Btn_Dodaj.IsEnabled = true;
        }
        else
        {
            Btn_Dodaj.IsEnabled = false;
        }
        
    }

    private void Btn_Dodaj_OnClicked(object? sender, EventArgs e)
    {
        if (Avto.IsChecked)
        {
            Avto avto = new Avto(ImeVozila.Text, double.Parse(CenaVozila.Text),int.Parse(StSedezov.Text),int.Parse(LetnikVozila.Text),int.Parse(StLastnikov.Text),0,int.Parse(MaxHitrost.Text),4,int.Parse(Avto_VelMotorja.Text), int.Parse(Avto_StCilindrov.Text), int.Parse(Avto_MocMotorja.Text), int.Parse(Avto_Poraba.Text), Avto_VrstaGoriva.Text);
            HomePage.VsaVozila.Add(avto);
            _homePage.RefreshList();
            Navigation.PopModalAsync();

        }
    }
}