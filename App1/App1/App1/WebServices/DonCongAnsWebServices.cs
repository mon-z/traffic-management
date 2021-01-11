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
    class DonCongAnsWebServices
    {
        private string uri = "http://192.168.1.6/api/DonCongAns";

        public DonCongAnsWebServices()
        {

        }
        public async Task<DonCongAn> GetDonCongAnById(int id)
        {
            DonCongAn dca = new DonCongAn();
            try
            {
                var client = new HttpClient();
                var response = await client.GetAsync(uri + "/" + id);
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<DonCongAn>(content);
                return result;

            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }
            return dca;
        }
    }
}
