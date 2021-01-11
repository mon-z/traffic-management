using App1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace App1.Services
{
    class ViPhamWebServices
    {
        private string uri = "http://192.168.1.6/api/ViPhams";

        public ViPhamWebServices()
        {

        }

        public async Task<List<ViPham>> GetViPhamListByDanId(int danId)
        {
            List<ViPham> lst = new List<ViPham>();
            try
            {
                var client = new HttpClient();
                var response = await client.GetAsync(uri + "?danId=" + danId);
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<ViPham>>(content);
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0} alo1234", ex.Message);
            }
            return lst;
        }

        public async Task<List<ViPham>> GetChuaNopPhatListByDanId(int danId)
        {
            List<ViPham> lst = new List<ViPham>();
            try
            {
                var client = new HttpClient();
                var response = await client.GetAsync(uri + "?danChuaNopPhatId=" + danId);
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<ViPham>>(content);
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }
            return lst;
        }

        public async Task<bool> UpdateViPham(ViPham phieu)
        {
            bool ret = false;
            try
            {

                var client = new HttpClient();
                var json = JsonConvert.SerializeObject(phieu);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PutAsync(uri, data);
                ret = response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }
            return ret;
        }
    }
}
