using App1.Data;
using App1.Models;
using App1.UtilsPages.NopPhatPages;
using App1.WebServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.UtilsPages.ViPhamPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViPhamDetail : ContentPage
    {
        public ViPhamDetail()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            //List<Note> notes = await App.GetDatabase.GetNotesAsync();
            //listView.ItemsSource = notes.OrderBy(d => d.Date).ToList();
            ViPham vipham = (ViPham)BindingContext;
            getData(vipham);
        }

        async void getThongTinViPham(ViPham vipham)
        {
            string tenNguoiViPham = await new DansWebService().getDanName(vipham.nguoi_vi_pham);
            nguoiViPhamTxt.Text = tenNguoiViPham;

            if (vipham.noi_giam_giu_xe != 1)
            {
                DonCongAn doncongan = await new DonCongAnsWebServices().GetDonCongAnById(vipham.noi_giam_giu_xe);
                noiGiamGiuXeTxt.IsVisible = true;
                noiGiamGiuXeTxt.Text = doncongan.ten_don_cong_an + " - " + doncongan.dia_chi;
            }

            nguoiXuPhatTxt.Text = vipham.nguoi_xu_phat.ToString();
            xeViPhamTxt.Text = vipham.xe_vi_pham;
            diaDiemViPhamTxt.Text = vipham.dia_diem_vi_pham;
            tienPhatThemTxt.Text = vipham.tien_phat_them.ToString();
            tongTienPhatTxt.Text = vipham.tong_tien_phat.ToString();
            thoiGianViPhamTxt.Text = vipham.thoi_gian_vi_pham.ToString();
            thoiGianXuPhatTxt.Text = vipham.thoi_gian_xu_phat.ToString();

            if (vipham.flag_da_nop_phat == 1)
            {
                flagNopPhatTxt.Text = "Đã nộp phạt";
                btn.IsVisible = false;
            }
            else
            {
                flagNopPhatTxt.Text = "Chưa nộp phạt";
            }
        }

        async void getThongTinLuat(int ma_vi_pham)
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

        async void getThongTinPhieuNopPhat(int ma_vi_pham)
        {
            PhieuNopPhat phieunopphat = await new PhieuNopPhatsWebServices().GetPhieuNopPhatIdViPhamId(ma_vi_pham);
            if (phieunopphat.dia_chi_ship != null)
            {
                diaChiShipTxt.IsVisible = true;
                diaChiShipTxt.Text = phieunopphat.dia_chi_ship;

                tienShipTxt.IsVisible = true;
                tienShipTxt.Text = phieunopphat.tien_ship.ToString();

                flagDaNhanXeTxt.IsVisible = true;
                if (phieunopphat.flag_da_nhan_xe == 1)
                {
                    flagDaNhanXeTxt.Text = "Đã nhận xe";
                } else
                {
                    flagDaNhanXeTxt.Text = "Chưa nhận xe";
                }
            }

            tongTienNopTxt.Text = phieunopphat.tong_tien_nop.ToString();
            ngayNopPhatTxt.Text = phieunopphat.ngay_nop_phat.ToString();
        }

        async void getData(ViPham vipham)
        {
            getThongTinViPham(vipham);
            
            getThongTinLuat(vipham.ma_vi_pham);

            if (vipham.flag_da_nop_phat == 1)
            {
                PhieuNopPhatSection.IsVisible = true;
                getThongTinPhieuNopPhat(vipham.ma_vi_pham);
            }
        }

        async void NopPhat(object sender, EventArgs e)
        {
            ViPham vipham = (ViPham)BindingContext;
            await Navigation.PushAsync(new NopPhat
            {
                BindingContext = vipham as ViPham
            });
        }
    }
}