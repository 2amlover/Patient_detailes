using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace demo
{
    class Program
    {

        static async Task Main(string[] args)
        {
            Console.WriteLine("WAIT FOR API RESPONSE....!");
           
            string url = "http://ganga.pihms.co.in/Patient/get_PatientByID";

            HttpClient client = new HttpClient();

            var response = await client.PostAsync(url, new StringContent("{\"m_PatientID\":\"114378\"}", Encoding.UTF8, "application/json"));

            string responseresult = await response.Content.ReadAsStringAsync();

            Console.WriteLine(responseresult);
            Console.ReadLine();
        }

    }
}
