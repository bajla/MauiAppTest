using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vozila;

namespace MauiAppTest;

public partial class HomePage : ContentPage
{
    private bool _osebnaInvSelected = true;
    private bool _najemSelected = true;

    public static BindingList<Vozilo> VsaVozila;
    public static BindingList<Vozilo> VozilaNaProdaji;
    public static BindingList<Vozilo> VsaVozilaNaProdaji;
    
    public HomePage()
    {
        InitializeComponent();
        NavigationPage.SetHasBackButton(this, false);
        
        VsaVozila = serializator.GetVozila("Vozila");
        VozilaNaProdaji = serializator.GetVozila("VozilaNaProdaji");
        VsaVozilaNaProdaji = serializator.GetVozila("VsaVozilaNaProdaji");
        RefreshList();

        VsaVozila.ListChanged += (sender, args) => { serializator.SaveVozila(VsaVozila, "Vozila"); };
        VozilaNaProdaji.ListChanged += (sender, args) => { serializator.SaveVozila(VozilaNaProdaji, "VozilaNaProdaji" ); };
        VsaVozilaNaProdaji.ListChanged += (sender, args) => { serializator.SaveVozila(VsaVozilaNaProdaji, "VsaVozilaNaProdaji"); };
    }

    ~HomePage()
    {
        serializator.SaveVozila(VsaVozila, "Vozila");
    }


    private void OsebnaInv_btn_OnClicked(object? sender, EventArgs e)
    {
        OsebnaInv_btn.BackgroundColor = Colors.Gray;
        DrugiUpr_btn.BackgroundColor = Colors.DimGray;
        Najem_btn.IsVisible = true;
        Prodaja_btn.IsVisible = true;
        _osebnaInvSelected = true;
        RefreshList();
    }

    private void DrugiUpr_btn_OnClicked(object? sender, EventArgs e)
    {
        OsebnaInv_btn.BackgroundColor = Colors.DimGray;
        DrugiUpr_btn.BackgroundColor = Colors.Gray;
        Najem_btn.IsVisible = false;
        Prodaja_btn.IsVisible = false;
        _osebnaInvSelected = false;
        RefreshList();
    }

    private void Najem_btn_OnClicked(object? sender, EventArgs e)
    {
        Najem_btn.BackgroundColor = Colors.Gray;
        Prodaja_btn.BackgroundColor = Colors.DimGray;
        _najemSelected = true;
        RefreshList();
    }

    private void Prodaja_btn_OnClicked(object? sender, EventArgs e)
    {
        Najem_btn.BackgroundColor = Colors.DimGray;
        Prodaja_btn.BackgroundColor = Colors.Gray;
        _najemSelected = false;
        RefreshList();
    }

    private void Dodaj_btn_OnClicked(object? sender, EventArgs e)
    {
        Navigation.PushModalAsync(new DodajVozilo(this));
    }

    int t = 0;
    public void RefreshList()
    {
        Vozila_stack.Clear();
        
        Grid grid = new Grid
        {
            RowDefinitions =
            {
                new RowDefinition()
            },
            ColumnDefinitions =
            {
                new ColumnDefinition(),
                new ColumnDefinition(),
                new ColumnDefinition(),
                new ColumnDefinition(),
                new ColumnDefinition()
            }
        };
        
        grid.Add(new Label
        {
            Text = "Ime vozila"
        }, 0,0);
        grid.Add(new Label
        {
            Text = "Cena vozila"
        }, 1,0);
        grid.Add(new Label
        {
            Text = "Vrsta vozila"
        }, 2,0);
        grid.Add(new Label
        {
            Text = "Letnik vozila"
        }, 3,0);
        grid.Add(new Label()
        {
            Text = "Spremeni"
        }, 4,0);

        Vozila_stack.Add(grid);
        
       
        if (_osebnaInvSelected && _najemSelected)
        {



            t = 0;
            foreach (var i in VsaVozila)
            {
                Console.WriteLine(i.Ime);
                
                Grid grid1 = new Grid
                {
                    RowDefinitions =
                    {
                        new RowDefinition()
                    },
                    ColumnDefinitions =
                    {
                        new ColumnDefinition(),
                        new ColumnDefinition(),
                        new ColumnDefinition(),
                        new ColumnDefinition(),
                        new ColumnDefinition()
                    }
                };

                grid1.Add(new Label
                {
                    Text = i.Ime
                }, 0, 0);
                grid1.Add(new Label
                {
                    Text = i.Cena.ToString()
                }, 1, 0);
                grid1.Add(new Label
                {
                    Text = i.GetType().ToString()
                }, 2, 0);
                grid1.Add(new Label
                {
                    Text = i.LetnikVozila.ToString()
                }, 3, 0);

                Button button = new Button()
                {
                    Text = "Spremeni",
                    ClassId = t.ToString()
                };
                button.Clicked += PreglejVoziloPage;
                grid1.Add(button, 4, 0);

                Vozila_stack.Add(grid1);
                t++;
            }
        }
        else if (_osebnaInvSelected && !_najemSelected)
        {
            t = 0;
            foreach (var i in VsaVozilaNaProdaji)
            {
                if(i.oseba != MainPage.PrijavljenaOseba.UporabniskoIme)
                    continue;
                
                Grid grid1 = new Grid
                {
                    RowDefinitions =
                    {
                        new RowDefinition()
                    },
                    ColumnDefinitions =
                    {
                        new ColumnDefinition(),
                        new ColumnDefinition(),
                        new ColumnDefinition(),
                        new ColumnDefinition(),
                        new ColumnDefinition()
                    }
                };

                grid1.Add(new Label
                {
                    Text = i.Ime
                }, 0, 0);
                grid1.Add(new Label
                {
                    Text = i.Cena.ToString()
                }, 1, 0);
                grid1.Add(new Label
                {
                    Text = i.GetType().ToString()
                }, 2, 0);
                grid1.Add(new Label
                {
                    Text = i.LetnikVozila.ToString()
                }, 3, 0);

                Button button = new Button()
                {
                    Text = "Spremeni",
                    ClassId = t.ToString()
                };
                button.Clicked += PreglejVoziloPageProdaja;
                grid1.Add(button, 4, 0);

                Vozila_stack.Add(grid1);
                t++;
            }
        }
        else if (!_osebnaInvSelected)
        {
            t = 0;
            foreach (var i in VsaVozilaNaProdaji)
            {
                if(i.oseba == MainPage.PrijavljenaOseba.UporabniskoIme)
                    continue;
                
                Grid grid1 = new Grid
                {
                    RowDefinitions =
                    {
                        new RowDefinition()
                    },
                    ColumnDefinitions =
                    {
                        new ColumnDefinition(),
                        new ColumnDefinition(),
                        new ColumnDefinition(),
                        new ColumnDefinition(),
                        new ColumnDefinition()
                    }
                };

                grid1.Add(new Label
                {
                    Text = i.Ime
                }, 0, 0);
                grid1.Add(new Label
                {
                    Text = i.Cena.ToString()
                }, 1, 0);
                grid1.Add(new Label
                {
                    Text = i.GetType().ToString()
                }, 2, 0);
                grid1.Add(new Label
                {
                    Text = i.LetnikVozila.ToString()
                }, 3, 0);

                Button button = new Button()
                {
                    Text = "Spremeni",
                    ClassId = t.ToString()
                };
                button.Clicked += VoziloPageProdaja;
                grid1.Add(button, 4, 0);

                Vozila_stack.Add(grid1);
                t++;
            }
        }
        
    }

    private void PreglejVoziloPage(object? sender, EventArgs e)
    {
        Navigation.PushModalAsync(new PreglejVozilo(VsaVozila[int.Parse((sender as Button).ClassId)], this));
    }
    
    private void PreglejVoziloPageProdaja(object? sender, EventArgs e)
    {
        Navigation.PushModalAsync(new PreglejVozilo(VsaVozilaNaProdaji[int.Parse((sender as Button).ClassId)], this));
    }

    private void VoziloPageProdaja(object? sender, EventArgs e)
    {
        Navigation.PushModalAsync(new KupiVozilo(VsaVozilaNaProdaji[int.Parse((sender as Button).ClassId)]));
    }

    private void Odjava_btn_OnClicked(object? sender, EventArgs e)
    {
        MainPage.PrijavljenaOseba = null;
        Navigation.PopModalAsync();
        
    }
}