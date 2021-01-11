using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebTraCuuCamera.Models;

namespace WebTraCuuCamera.Controllers
{
    public class TraCuuCameraController : Controller
    {
        // GET: TraCuuCamera
        [HttpGet]
        public ViewResult Index()
        {
            IEnumerable<Camera_Backup> camera_backup = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44327/api/");
                var respornseTask = client.GetAsync("Camera_Backup");
                respornseTask.Wait();

                var result = respornseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var m = result.Content.ReadAsAsync<List<Camera_Backup>>();
                    m.Wait();
                    camera_backup = m.Result;
                }
                else
                {
                    camera_backup = Enumerable.Empty<Camera_Backup>();
                    ModelState.AddModelError(string.Empty, "Server error. Please contract admin for help");

                }

            }

            Thongtin thongtin = new Thongtin();
            thongtin.Camera_Backup = camera_backup;
            return View(thongtin);
        }
    }
}