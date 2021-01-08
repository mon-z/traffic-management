using DataRepository;
using DataRepository.entity;
using DataRepository.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class ThongtinController : ApiController
    {

        Camera_Backup_Repository repo = new Camera_Backup_Repository();

        public ThongtinModel Get()
        {
            IList<Camera_Backup> camera_Backups = repo.Read();
            ThongtinModel model = new ThongtinModel();
            foreach (Camera_Backup camera in camera_Backups)
            {
                if (camera.images != null)
                {
                    ThongtinModel.Detail d = new ThongtinModel.Detail()
                    {
                        camera_id = camera.ma_camera,
                        image = camera.images,
                        thoi_gian = camera.thoi_gian,
                        TenDuong = camera.Duong.ten_duong,

                    };
                    model.details.Add(d);
                }
            }
            return model;
        }

        // GET: api/Thongtin/5

        public IHttpActionResult Get(int id)
        {
            IList<Camera_Backup> camera_Backups = repo.Read();
            var cameraId = camera_Backups.FirstOrDefault((c) => c.ma_camera == id);
            if (cameraId == null)
            {
                return NotFound();
            }
            return Ok(cameraId);
        }

        // GET: api/Thongtin/5/thoigian

        public IHttpActionResult Get(int id, DateTime time)
        {
            IList<Camera_Backup> camera_Backups = repo.Read();
            ThongtinModel model = new ThongtinModel();
            foreach (Camera_Backup camera in camera_Backups)
            {
                if (camera.ma_camera == id && camera.thoi_gian == time)
                {
                    ThongtinModel.Detail d = new ThongtinModel.Detail()
                    {
                        camera_id = camera.ma_camera,
                        image = camera.images,
                        thoi_gian = camera.thoi_gian,
                        TenDuong = camera.Duong.ten_duong,

                    };
                    model.details.Add(d);
                }
            }
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }


        // GET: api/Thongtin/5/thoigian/duong
        public IHttpActionResult Get(int id, DateTime time, Duong duong)
        {
            IList<Camera_Backup> camera_Backups = repo.Read();
            ThongtinModel model = new ThongtinModel();
            foreach (Camera_Backup camera in camera_Backups)
            {
                if (camera.ma_camera == id && camera.thoi_gian == time && camera.Duong.ten_duong == duong.ten_duong)
                {
                    ThongtinModel.Detail d = new ThongtinModel.Detail()
                    {
                        camera_id = camera.ma_camera,
                        image = camera.images,
                        thoi_gian = camera.thoi_gian,
                        TenDuong = camera.Duong.ten_duong,

                    };
                    model.details.Add(d);
                }
            }
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        // GET: api/Thongtin/thoigian/duong
        public IHttpActionResult Get(DateTime time, Duong duong)
        {
            IList<Camera_Backup> camera_Backups = repo.Read();
            ThongtinModel model = new ThongtinModel();
            foreach (Camera_Backup camera in camera_Backups)
            {
                if (camera.thoi_gian == time && camera.Duong.ten_duong == duong.ten_duong)
                {
                    ThongtinModel.Detail d = new ThongtinModel.Detail()
                    {
                        camera_id = camera.ma_camera,
                        image = camera.images,
                        thoi_gian = camera.thoi_gian,
                        TenDuong = camera.Duong.ten_duong,

                    };
                    model.details.Add(d);
                }
            }
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }


        // GET: api/Thongtin/id/image
        public IHttpActionResult Get(int id, string image)
        {
            IList<Camera_Backup> camera_Backups = repo.Read();
            ThongtinModel model = new ThongtinModel();
            foreach (Camera_Backup camera in camera_Backups)
            {
                if (camera.ma_camera == id && camera.images == image)
                {
                    ThongtinModel.Detail d = new ThongtinModel.Detail()
                    {
                        camera_id = camera.ma_camera,
                        image = camera.images,
                        thoi_gian = camera.thoi_gian,
                        TenDuong = camera.Duong.ten_duong,

                    };
                    model.details.Add(d);
                }
            }
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }







        // GET: api/Thongtin
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/Thongtin/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Thongtin
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Thongtin/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Thongtin/5
        public void Delete(int id)
        {
        }
    }
}
