using App1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace App1.WebServices
{
    class PhieuNopPhatsWebServices
    {
        private string uri = "http://192.168.1.6/api/PhieuNopPhats";

        public PhieuNopPhatsWebServices()
        {

        }
        public async Task<bool> AddPhieuNopPhat(PhieuNopPhat phieu)
        {
            bool ret = false;
            try
            {

                var client = new HttpClient();
                var json = JsonConvert.SerializeObject(phieu);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(uri, data);
                ret = response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }
            return ret;
        }

        public async Task<PhieuNopPhat> GetPhieuNopPhatIdViPhamId(int viPhamId)
        {
            PhieuNopPhat phieunopphat = new PhieuNopPhat();
            try
            {
                var client = new HttpClient();
                var response = await client.GetAsync(uri + "?idViPham=" + viPhamId);
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<PhieuNopPhat>(content);
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0} alo alo bug", ex.Message);
            }
            return phieunopphat;
        }
    }
}
