using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppTest;

public partial class HomePage : ContentPage
{
    private bool _osebnaInvSelected = true;
    private bool _najemSelected = true;
    
    
    public HomePage()
    {
        InitializeComponent();
        NavigationPage.SetHasBackButton(this, false);

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
            Text = "Stanje vozila"
        }, 2,0);
        grid.Add(new Label
        {
            Text = "Letnik vozila"
        }, 3,0);
        grid.Add(new Button()
        {
            Text = "Spremeni"
        }, 4,0);

        Vozila_stack.Add(grid);
        
    }


    private void OsebnaInv_btn_OnClicked(object? sender, EventArgs e)
    {
        OsebnaInv_btn.BackgroundColor = Colors.Gray;
        DrugiUpr_btn.BackgroundColor = Colors.DimGray;
        _osebnaInvSelected = true;
    }

    private void DrugiUpr_btn_OnClicked(object? sender, EventArgs e)
    {
        OsebnaInv_btn.BackgroundColor = Colors.DimGray;
        DrugiUpr_btn.BackgroundColor = Colors.Gray;
        _osebnaInvSelected = false;
    }

    private void Najem_btn_OnClicked(object? sender, EventArgs e)
    {
        Najem_btn.BackgroundColor = Colors.Gray;
        Prodaja_btn.BackgroundColor = Colors.DimGray;
        _najemSelected = true;
    }

    private void Prodaja_btn_OnClicked(object? sender, EventArgs e)
    {
        Najem_btn.BackgroundColor = Colors.DimGray;
        Prodaja_btn.BackgroundColor = Colors.Gray;
        _najemSelected = false;
    }

    private void Dodaj_btn_OnClicked(object? sender, EventArgs e)
    {
        
    }
}