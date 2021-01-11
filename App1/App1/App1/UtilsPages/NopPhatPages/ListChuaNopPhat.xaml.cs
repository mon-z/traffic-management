using App1.Data;
using App1.Models;
using App1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.UtilsPages.NopPhatPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListChuaNopPhat : ContentPage
    {
        public ListChuaNopPhat()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            //List<Note> notes = await App.GetDatabase.GetNotesAsync();
            //listView.ItemsSource = notes.OrderBy(d => d.Date).ToList();
            GetData(Int16.Parse(Application.Current.Properties["userId"].ToString()));
            getDanById();
        }


        async void GetData(int danId)
        {
            List<ViPham> vipham = await new ViPhamWebServices().GetChuaNopPhatListByDanId(danId);
            listView.ItemsSource = vipham.OrderBy(d => d.thoi_gian_xu_phat).ToList();
        }

        async void getDanById()
        {
            Dans dan = await new DansWebService().GetDanById(Int16.Parse(Application.Current.Properties["userId"].ToString()));
            userName.Text = "Welcome, " + dan.ho_ten;
        }

        void toHome(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new Home());
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new NopPhat
                {
                    BindingContext = e.SelectedItem as ViPham
                });
            }
        }
    }
}