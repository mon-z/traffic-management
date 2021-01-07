using App1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace App1.Data
{
    class DansWebService
    {
        private string uri = "http://192.168.1.6/api/Dans";

        public DansWebService()
        {

        }
        public async Task<List<Dans>> GetDanList()
        {
            List<Dans> lst = new List<Dans>();
            try
            {
                var client = new HttpClient();
                var response = await client.GetAsync(uri);
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<Dans>>(content);
                return result;

            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0} alo1234", ex.Message);
            }
            return lst;
        }

        public async Task<Dans> Login(string email, string password)
        {
            Dans dan = new Dans();
            try
            {
                var client = new HttpClient();
                var response = await client.GetAsync(uri + "?email=" + email + "&password=" + password);
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Dans>(content);
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0} alo alo bug", ex.Message);
            }
            return dan;
        }

        public async Task<Dans> GetDanById(int id)
        {
            Dans dan = new Dans();
            try
            {
                var client = new HttpClient();
                var response = await client.GetAsync(uri + "/" + id);
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Dans>(content);
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0} alo alo bug", ex.Message);
            }
            return dan;
        }


        //public async Task<List<Dans>> GetDanList()
        //{
        //    List<Dans> lst = new List<Dans>();
        //    try
        //    {
        //        var client = new HttpClient();
        //        var response = await client.GetAsync(uri);
        //        var content = await response.Content.ReadAsStringAsync();
        //        var result = JsonConvert.DeserializeObject<List<Dans>>(content);
        //        return result;

        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine("\tERROR {0}", ex.Message);
        //    }
        //    return lst;
        //}

        //public async Task<bool> AddLuat(Dans nt)
        //{
        //    bool ret = false;
        //    try
        //    {

        //        var client = new HttpClient();
        //        var json = JsonConvert.SerializeObject(nt);
        //        var data = new StringContent(json, Encoding.UTF8, "application/json");
        //        var response = await client.PostAsync(uri, data);
        //        ret = response.IsSuccessStatusCode;
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine("\tERROR {0}", ex.Message);
        //    }
        //    return ret;
        //}

        //public async Task<bool> UpdateLuat(Dans nt)
        //{
        //    bool ret = false;
        //    try
        //    {
        //        var client = new HttpClient();
        //        var json = JsonConvert.SerializeObject(nt);
        //        var data = new StringContent(json, Encoding.UTF8, "application/json");
        //        var response = await client.PutAsync(uri, data);
        //        ret = response.IsSuccessStatusCode;
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine("\tERROR {0}", ex.Message);
        //    }
        //    return ret;
        //}

        //public async Task<bool> DeleteLuat(int LuatId)
        //{
        //    bool ret = false;
        //    try
        //    {

        //        var client = new HttpClient();
        //        //var json = JsonConvert.SerializeObject(LuatId);
        //        //var data = new StringContent(json, Encoding.UTF8, "application/json");
        //        var response = await client.DeleteAsync(uri + "/" + LuatId.ToString());

        //        ret = response.IsSuccessStatusCode;
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine("\tERROR {0}", ex.Message);
        //    }
        //    return ret;
        //}
    }
}
