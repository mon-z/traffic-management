using App1.Models;
using App1.Services;
using App1.WebServices;
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
    public partial class XacNhanNopPhat : ContentPage
    {
        public XacNhanNopPhat()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //List<Note> notes = await App.GetDatabase.GetNotesAsync();
            //listView.ItemsSource = notes.OrderBy(d => d.Date).ToList();
            NopPhats nopphat = (NopPhats)BindingContext;

            if (nopphat.dia_chi_ship.Length > 0)
            {
                diaChiShipTxt.IsVisible = true;
                diaChiShipTxt.Text = nopphat.dia_chi_ship;

                tienShipTxt.IsVisible = true;
                tienShipTxt.Text = nopphat.tien_ship.ToString();
            }

            tongTienPhatTxt.Text = nopphat.tong_tien_phat.ToString();
            tongTienThanhToanTxt.Text = nopphat.tong_tien_nop.ToString();
            hinhThucNopPhatTxt.Text = nopphat.phuong_thuc_dong_phat;
        }

        private async void NopPhatBtn(object sender, EventArgs e)
        {
            NopPhats nopphat = (NopPhats)BindingContext;

            ViPham vipham = new ViPham();

            vipham.ma_vi_pham = nopphat.ma_vi_pham;
            vipham.tien_phat_them = nopphat.tien_phat_them;
            vipham.tong_tien_phat = nopphat.tong_tien_phat;
            vipham.thoi_gian_vi_pham = nopphat.thoi_gian_vi_pham;
            vipham.thoi_gian_xu_phat = nopphat.thoi_gian_xu_phat;
            vipham.flag_da_nop_phat = nopphat.flag_da_nop_phat;
            vipham.nguoi_vi_pham = nopphat.nguoi_vi_pham;
            vipham.nguoi_xu_phat = nopphat.nguoi_xu_phat;
            vipham.dia_diem_vi_pham = nopphat.dia_diem_vi_pham;
            vipham.xe_vi_pham = nopphat.xe_vi_pham;
            vipham.noi_giam_giu_xe = nopphat.noi_giam_giu_xe;

            PhieuNopPhat phieunopphat = new PhieuNopPhat();

            phieunopphat.ma_vi_pham = nopphat.ma_vi_pham;
            phieunopphat.flag_ship = nopphat.flag_ship;
            phieunopphat.tien_phat = nopphat.tong_tien_phat;
            phieunopphat.tien_ship = nopphat.tien_ship;
            phieunopphat.tong_tien_nop = nopphat.tong_tien_nop;
            phieunopphat.phuong_thuc_dong_phat = nopphat.phuong_thuc_dong_phat;
            phieunopphat.dia_chi_ship = nopphat.dia_chi_ship;
            phieunopphat.flag_da_nhan_xe = 0;
            phieunopphat.ngay_nop_phat = DateTime.Now;

            bool status = await new PhieuNopPhatsWebServices().AddPhieuNopPhat(phieunopphat);
            if (status)
            {
                bool status1 = await new ViPhamWebServices().UpdateViPham(vipham);
                await DisplayAlert("Info", status1 ? "Nộp phạt hoàn tất!" : "Error", "Cancel");
            }

            await Navigation.PushAsync(new ListChuaNopPhat());
        }
    }
}