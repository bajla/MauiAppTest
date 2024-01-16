using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vozila;

namespace MauiAppTest;

public partial class VoziloVrnjeno : ContentPage
{
    private Vozilo _vozilo;
    
    public VoziloVrnjeno(Vozilo vozilo)
    {
        InitializeComponent();
        _vozilo = vozilo;

    }

    private void Potrdi_OnClicked(object? sender, EventArgs e)
    {
        HomePage.VsaVozila.Remove(_vozilo);
        _vozilo.PrevozeniKm(int.Parse(PrevozeniKm.Text));
        HomePage.VsaVozila.Add(_vozilo);
        Navigation.PopModalAsync();
    }
}