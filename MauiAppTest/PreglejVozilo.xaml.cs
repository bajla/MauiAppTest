using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vozila;

namespace MauiAppTest;

public partial class PreglejVozilo : ContentPage
{
    private Vozilo _vozilo;
    private HomePage _homePage;
    
    public PreglejVozilo(Vozilo vozilo, HomePage homePage)
    {
        InitializeComponent();
        _vozilo = vozilo;
        _homePage = homePage;
        
        if (_vozilo.JeVoziloNaProdaji())
        {
            Console.WriteLine(_vozilo.JeVoziloNaProdaji());
            Prodaja.IsVisible = false;
            DajVnajem.IsVisible = true;
            VoziloNajeto.IsVisible = false;
            Zbrisi.IsVisible = false;
        }
        else if(_vozilo.Najeto)
        {
            Prodaja.IsVisible = false;
            VoziloNajeto.IsVisible = false;
            VoziloVrnjeno.IsVisible = true;
            Zbrisi.IsVisible = false;
        }
        
        
        
        
        

        Ime.Text += vozilo.Ime;
        Cena.Text += vozilo.Cena;
        StSedezov.Text += vozilo.StSedezov;
        LetnikVozila.Text += vozilo.LetnikVozila;
        StLastnikov.Text += vozilo.StLastnikov;
        MaxHitrost.Text += MaxHitrost;
        Najeto.Text += _vozilo.Najeto;
        StNajemov.Text += _vozilo.StNajemov;
        
        if (vozilo.GetType() == typeof(Avto))
        {
            Avto avto = vozilo as Avto;
            
            Stack_Avto.IsVisible = true;
            Avto_VelikostMotorja.Text += avto.VelikostMotorja;
            Avto_StCilindrov.Text += avto.StCilindrov;
            Avto_MocMotorja.Text += avto.MocMotorja;
            Avto_Poraba.Text += avto.PorabaNa100km;
            Avto_VrstaGoriva.Text += avto.VrstaGoriva;
            Avto_Znamka.Text += avto.Znamka;
        }
        else if (vozilo.GetType() == typeof(Kolo))
        {
            Stack_Kolo.IsVisible = true;

            Kolo kolo = vozilo as Kolo;
            Kolo_Znamka.Text += kolo.Znamka;
        }
        else if(vozilo.GetType() == typeof(Coln))
        {
            Stack_Coln.IsVisible = true;

            Coln coln = vozilo as Coln;
            Coln_StVesel.Text += coln.StVesel;

        }
        else if(vozilo.GetType() == typeof(Jahta))
        {
            Stack_Jahta.IsVisible = true;
            
            Jahta jahta = vozilo as Jahta;
            Jahta_VelikostMotorja.Text += jahta.VelikostMotorja;
            Jahta_StCilindrov.Text += jahta.StCilindrov;
            Jahta_MocMotorja.Text += jahta.MocMotorja;
            Jahta_Poraba.Text += jahta.PorabaNa100km;
            Jahta_VrstaGoriva.Text += jahta.VrstaGoriva;
            Jahta_StMotorjev.Text += jahta.StMotorjev;
            Jahta_StPotnikov.Text += jahta.stPotnikov;
        }
        else if(vozilo.GetType() == typeof(VodnoMotorno))
        {
            Stack_Vodno.IsVisible = true;
            
            VodnoMotorno vodno = vozilo as VodnoMotorno;
            Vodno_VelikostMotorja.Text += vodno.VelikostMotorja;
            Vodno_StCilindrov.Text += vodno.StCilindrov;
            Vodno_MocMotorja.Text += vodno.MocMotorja;
            Vodno_Poraba.Text += vodno.PorabaNa100km;
            Vodno_VrstaGoriva.Text += vodno.VrstaGoriva;
            Vodno_StMotorjev.Text += vodno.StMotorjev;
            
        }
        else if (vozilo.GetType() == typeof(KopnoMotorno))
        {
            Stack_Kopensko.IsVisible = true;
            KopnoMotorno kopno = vozilo as KopnoMotorno;
            Kopensko_VelikostMotorja.Text += kopno.VelikostMotorja;
            Kopensko_StCilindrov.Text += kopno.StCilindrov;
            Kopensko_MocMotorja.Text += kopno.MocMotorja;
            Kopensko_Poraba.Text += kopno.PorabaNa100km;
            Kopensko_VrstaGoriva.Text += kopno.VrstaGoriva;

        }
        
        
    }

    private void Nazaj_OnClicked(object? sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }

    private void Button_OnClicked(object? sender, EventArgs e)
    {
        HomePage.VsaVozila.Remove(_vozilo);
        DisplayMsgBox(_vozilo.DajNaProdajo());
        _vozilo.oseba = MainPage.PrijavljenaOseba.UporabniskoIme;
        HomePage.VsaVozilaNaProdaji.Add(_vozilo);
        _homePage.RefreshList();
        
        //Navigation.PopModalAsync();
    }

    private void DajVnajem_OnClicked(object? sender, EventArgs e)
    {
        HomePage.VsaVozilaNaProdaji.Remove(_vozilo);
        DisplayMsgBox(_vozilo.DajNazajVNajem());
        
        HomePage.VsaVozila.Add(_vozilo);
        _homePage.RefreshList();
        //Navigation.PopModalAsync();
    }

    private void DisplayMsgBox(string sporocilo)
    {
        DisplayAlert("Sporocilo", sporocilo, "OK");
    }

    private void VoziloNajeto_OnClicked(object? sender, EventArgs e)
    {
        
        HomePage.VsaVozila.Remove(_vozilo);
        
        _vozilo.JeNajeto(true);
        HomePage.VsaVozila.Add(_vozilo);
        _homePage.RefreshList();
        Navigation.PopModalAsync();
        
        
    }

    private void VoziloVrnjeno_OnClicked(object? sender, EventArgs e)
    {
        HomePage.VsaVozila.Remove(_vozilo);
        
        _vozilo.JeNajeto(false);
        HomePage.VsaVozila.Add(_vozilo);
        Navigation.PushModalAsync(new VoziloVrnjeno(_vozilo));

        
        _homePage.RefreshList();
        
        
    }

    

    private void Zbrisi_OnClicked(object? sender, EventArgs e)
    {
        HomePage.VsaVozila.Remove(_vozilo);
        _homePage.RefreshList();
        Navigation.PopModalAsync();
    }
}