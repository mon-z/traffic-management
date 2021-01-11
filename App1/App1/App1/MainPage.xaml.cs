using App1.Data;
using App1.Models;
using App1.UtilsPages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();
        //    //List<Note> notes = await App.GetDatabase.GetNotesAsync();
        //    //listView.ItemsSource = notes.OrderBy(d => d.Date).ToList();
        //}

        async void OnLogin(object sender, EventArgs e)
        {
            Dans dan = await new DansWebService().Login("chanestdevil@gmail.com", "123");
            if (dan == null)
            {
                fail.Text = "Email hoac mat khau khong dung!";
            }
            else
            {
                Application.Current.Properties["userId"] = dan.ma_dan;
                Application.Current.MainPage = new NavigationPage(new Home());
            }
        }
    }
}
