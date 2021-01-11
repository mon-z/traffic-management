using App1.Data;
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
    public partial class NopPhat : ContentPage
    {
        public NopPhat()
        {
            InitializeComponent();

            paymentPicker.Items.Add("Chuyển khoản ngân hàng");
            paymentPicker.Items.Add("MOMO");
            paymentPicker.Items.Add("Viettel Pay");
            paymentPicker.Items.Add("Zalo Pay");
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //List<Note> notes = await App.GetDatabase.GetNotesAsync();
            //listView.ItemsSource = notes.OrderBy(d => d.Date).ToList();
            ViPham vipham = (ViPham)BindingContext;
            getData(vipham);
        }

        async void getUserName(int nguoi_vi_pham)
        {
            string tenNguoiViPham = await new DansWebService().getDanName(nguoi_vi_pham);
            nguoiViPhamTxt.Text = tenNguoiViPham;
        }

        async void getDonCongAnName(int noi_giam_giu_xe)
        {
            if (noi_giam_giu_xe != 1)
            {
                noiGiamGiuXeTxt.IsVisible = true;
                DonCongAn doncongan = await new DonCongAnsWebServices().GetDonCongAnById(noi_giam_giu_xe);
                noiGiamGiuXeTxt.Text = doncongan.ten_don_cong_an + " - " + doncongan.dia_chi;
            }
        }

        async void getListLuatViPham(int ma_vi_pham)
        {
            List<ViPhamLuat> viphamluat = await new ViPhamLuatWebServices().getViPhamLuatList(ma_vi_pham);

            List<LuatDetail> lstLuatDetail = new List<LuatDetail>();

            foreach (ViPhamLuat vpl in viphamluat)
            {
                LuatDetail luatdetail = new LuatDetail();
                Luat luat = await new LuatWebServices().GetLuatById(vpl.ma_luat);
                luatdetail.ma_luat = luat.ma_luat;
                luatdetail.ten_luat = luat.ten_luat;
                luatdetail.noi_dung = luat.noi_dung;
                luatdetail.ngay_ban_hanh = luat.ngay_ban_hanh;
                luatdetail.muc_xu_phat = luat.muc_xu_phat;
                luatdetail.mo_ta_vi_pham = vpl.mo_ta_vi_pham;

                lstLuatDetail.Add(luatdetail);
            }

            listView.ItemsSource = lstLuatDetail.OrderBy(d => d.muc_xu_phat).ToList();
        }

        async void getData(ViPham vipham)
        {
            nguoiXuPhatTxt.Text = vipham.nguoi_xu_phat.ToString();
            xeViPhamTxt.Text = vipham.xe_vi_pham;
            diaDiemViPhamTxt.Text = vipham.dia_diem_vi_pham;
            tienPhatThemTxt.Text = vipham.tien_phat_them.ToString();
            tongTienPhatTxt.Text = vipham.tong_tien_phat.ToString();
            thoiGianViPhamTxt.Text = vipham.thoi_gian_vi_pham.ToString();
            thoiGianXuPhatTxt.Text = vipham.thoi_gian_xu_phat.ToString();

            if (vipham.noi_giam_giu_xe != 1)
            {
                diachiEntry.IsVisible = true;
            }

            getUserName(vipham.nguoi_vi_pham);
            getDonCongAnName(vipham.noi_giam_giu_xe);
            getListLuatViPham(vipham.ma_vi_pham);
        }

        //Tính phí ship xe
        private int TinhTienShip()
        {
            //Thay thế cho API tính khoảng cách giữa nơi giam giữ xe và nơi giao đến
            Random rnd = new Random();
            int fakeDistance = rnd.Next(30);

            return fakeDistance * 100000 + 30000;
        }

        private async void NopPhatBtn(object sender, EventArgs e)
        {
            if (paymentPicker.SelectedIndex < 0)
            {
                paymentPicker.BackgroundColor = Color.Red;
            } else
            {
                paymentPicker.BackgroundColor = Color.White;

                ViPham vipham = (ViPham)BindingContext;

                NopPhats nopphat = new NopPhats();

                nopphat.ma_vi_pham = vipham.ma_vi_pham;
                nopphat.tien_phat_them = vipham.tien_phat_them;
                nopphat.tong_tien_phat = vipham.tong_tien_phat;
                nopphat.thoi_gian_vi_pham = vipham.thoi_gian_vi_pham;
                nopphat.thoi_gian_xu_phat = vipham.thoi_gian_xu_phat;
                nopphat.flag_da_nop_phat = vipham.flag_da_nop_phat;
                nopphat.nguoi_vi_pham = vipham.nguoi_vi_pham;
                nopphat.nguoi_xu_phat = vipham.nguoi_xu_phat;
                nopphat.dia_diem_vi_pham = vipham.dia_diem_vi_pham;
                nopphat.xe_vi_pham = vipham.xe_vi_pham;
                nopphat.noi_giam_giu_xe = vipham.noi_giam_giu_xe;

                nopphat.phuong_thuc_dong_phat = paymentPicker.Items[paymentPicker.SelectedIndex];

                if (string.IsNullOrEmpty(diachiEntry.Text))
                {
                    nopphat.dia_chi_ship = "";
                    nopphat.tien_ship = 0;
                    nopphat.flag_ship = 0;
                } else
                {
                    nopphat.dia_chi_ship = diachiEntry.Text;
                    nopphat.tien_ship = TinhTienShip();
                    nopphat.flag_ship = 1;
                }
                nopphat.tong_tien_phat = vipham.tong_tien_phat;
                nopphat.tong_tien_nop = vipham.tong_tien_phat + nopphat.tien_ship;

                await Navigation.PushAsync(new XacNhanNopPhat
                {
                    BindingContext = nopphat as NopPhats
                });
            }
        }

    }
}