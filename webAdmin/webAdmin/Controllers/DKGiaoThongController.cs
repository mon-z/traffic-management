using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using webAdmin.Models.DKGiaoThong;


namespace webAdmin.Controllers
{
    public class DKGiaoThongController : Controller
    {
        // GET: DKGiaoThong
        [HttpGet]
        public ViewResult Index()
        {
            IEnumerable<Duongs> duong = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44327/api/");
                var respornseTask = client.GetAsync("Duongs");
                respornseTask.Wait();

                var result = respornseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var chotGT = result.Content.ReadAsAsync<List<Duongs>>();
                    chotGT.Wait();
                    duong = chotGT.Result;
                }
                else
                {
                    duong = Enumerable.Empty<Duongs>();
                    ModelState.AddModelError(string.Empty, "Server error. Please contract admin for help");

                }

            }

            viewDKChotGT chotGiaoThongDetail = new viewDKChotGT();
            chotGiaoThongDetail.Duongs = duong;
            return View(chotGiaoThongDetail);
        }


        [HttpPost]
        public ActionResult Index(FormCollection ten_chotGT)
        {
            viewDKChotGT chotGiaoThongDetail = new viewDKChotGT();
            var a = ten_chotGT.Get("duong1").ToString();
            var b = ten_chotGT.Get("duong2").ToString();
            if(a==b)
            {
                var mes = "Không có cốt giao thông nào là: " + a + " - " + b + " hết!!!!";
                IEnumerable<Duongs> duong = null;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44327/api/");
                    var respornseTask = client.GetAsync("Duongs");
                    respornseTask.Wait();

                    var result = respornseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var chotGTss = result.Content.ReadAsAsync<List<Duongs>>();
                        chotGTss.Wait();
                        duong = chotGTss.Result;
                    }
                    else
                    {
                        duong = Enumerable.Empty<Duongs>();
                        ModelState.AddModelError(string.Empty, "Server error. Please contract admin for help");

                    }

                }
                chotGiaoThongDetail.Duongs = duong;
                chotGiaoThongDetail.mes = mes;
                
                return View(chotGiaoThongDetail);
            }
            else
            {
                var c = a + " - " + b;
                List<ChotGiaoThongs> chot = null;
                
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44327/api/");
                    var link = "ChotGiaoThongs?name=" + c;
                    var respornseTask = client.GetAsync(link);
                    respornseTask.Wait();

                    var result = respornseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var chotGTs = result.Content.ReadAsAsync<List<ChotGiaoThongs>>();
                        chotGTs.Wait();
                        chot = chotGTs.Result;
                    }
                    else
                    {
                        chot = null;
                        ModelState.AddModelError(string.Empty, "Server error. Please contract admin for help");

                    }

                }
                var chotGT = chot[0];
                ChotGiaoThongDetail chotdetail = null;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44327/api/");
                    var link = "ChotGiaoThongDetail/"+chotGT.ma_chotGT;
                    var respornseTask = client.GetAsync(link);
                    respornseTask.Wait();

                    var result = respornseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var chotGTs = result.Content.ReadAsAsync<ChotGiaoThongDetail>();
                        chotGTs.Wait();
                        chotdetail = chotGTs.Result;
                    }
                    else
                    {
                        chot = null;
                        ModelState.AddModelError(string.Empty, "Server error. Please contract admin for help");

                    }

                }
                
                IEnumerable<Duongs> duong = null;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44327/api/");
                    var respornseTask = client.GetAsync("Duongs");
                    respornseTask.Wait();

                    var result = respornseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var chotGTss = result.Content.ReadAsAsync<List<Duongs>>();
                        chotGTss.Wait();
                        duong = chotGTss.Result;
                    }
                    else
                    {
                        duong = Enumerable.Empty<Duongs>();
                        ModelState.AddModelError(string.Empty, "Server error. Please contract admin for help");

                    }

                }
                chotGiaoThongDetail.Duongs = duong;
                NgaDuong ngaDuong1 = new NgaDuong();
                foreach (NgaDuong ngaDuong in chotdetail.ngaDuongs)
                {
                    switch (ngaDuong.stt)
                    {
                        case 1:
                            chotGiaoThongDetail.ngaDuong1 = ngaDuong;
                            break;
                        case 2:
                            chotGiaoThongDetail.ngaDuong2 = ngaDuong;
                            break;
                        case 3:
                            chotGiaoThongDetail.ngaDuong3 = ngaDuong;
                            break;
                        case 4:
                            chotGiaoThongDetail.ngaDuong4 = ngaDuong;
                            break;
                        case 6:
                            chotGiaoThongDetail.ngaDuong6 = ngaDuong;
                            break;
                        case 7:
                            chotGiaoThongDetail.ngaDuong7 = ngaDuong;
                            break;
                        case 8:
                            chotGiaoThongDetail.ngaDuong8 = ngaDuong;
                            break;
                        case 9:
                            chotGiaoThongDetail.ngaDuong9 = ngaDuong;
                            break;
                    }
                }
                return View(chotGiaoThongDetail);
            }
            

        }


    }
}