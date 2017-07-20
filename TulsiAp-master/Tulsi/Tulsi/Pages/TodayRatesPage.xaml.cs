﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Tulsi.ViewModels;
using Syncfusion.DataSource;
using SlideOverKit;

namespace Tulsi
{
    public partial class TodayRatesPage : MenuContainerPage
    {
        public TodayRatesPage()
        {
            InitializeComponent();

            TodayRatesViewModel trvm = ((App)Application.Current).TodayRatesVM;
            TodayRatesListView1.ItemsSource = trvm.TodayRatesData;
            TodayRatesListView2.ItemsSource = trvm.TodayRatesData;
            TodayRatesListView3.ItemsSource = trvm.TodayRatesData;

            int hd = DependencyService.Get<IDisplaySize>().GetHeightDiP();
            AbsoluteLayout.SetLayoutBounds(SideMenuOverlay, new Rectangle(0, 0, 0.9, hd - 20));

            //Slide menu creating
            SlideMenu = ((App)Application.Current).SideMenu;

            //Toolbar taps
            TapGestureRecognizer ToolbarTap1 = new TapGestureRecognizer();
            ToolbarTap1.Tapped += (s, e) =>
            {
                this.ShowMenu();
            };
            Menu.GestureRecognizers.Add(ToolbarTap1);

            TapGestureRecognizer ToolbarTap2 = new TapGestureRecognizer();
            ToolbarTap2.Tapped += (s, e) =>
            {
                SearchPage sp = new SearchPage();
                Application.Current.MainPage.Navigation.PushAsync(sp);
            };
            Search.GestureRecognizers.Add(ToolbarTap2);

        }
    }
}
