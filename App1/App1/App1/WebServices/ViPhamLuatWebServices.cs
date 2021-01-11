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
    class ViPhamLuatWebServices
    {
        private string uri = "http://192.168.1.6/api/ViPhamLuats";

        public ViPhamLuatWebServices()
        {

        }
        public async Task<List<ViPhamLuat>> getViPhamLuatList(int viPhamId)
        {
            List<ViPhamLuat> lst = new List<ViPhamLuat>();
            try
            {
                var client = new HttpClient();
                var response = await client.GetAsync(uri + "?viPhamId=" + viPhamId);
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<ViPhamLuat>>(content);
                return result;

            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }
            return lst;
        }
    }
}
