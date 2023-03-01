using Newtonsoft.Json;
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
            Console.WriteLine("WELCOME TO API SERVER");

            Console.WriteLine("SELECT ONE RESPONSE THAT U WANT.");
            Console.WriteLine("GET PatientByID : 1");
            Console.WriteLine("GET PatientListByLatest : 2");


            int a = Convert.ToInt32(Console.ReadLine());

            if (a == 1)
            {
                await PatientByID();
            }
            else if (a == 2)
            {
                await PatientListByLatest();
            }
            else
            {
                Console.WriteLine("SELECT 1 r 2");
            }
        }

        public static async Task PatientByID()
        {
            Console.WriteLine("WAIT FOR API RESPONSE....!");

            Console.WriteLine("Enter The Patient ID Which u Want.");
            int PatientByID = Convert.ToInt32(Console.ReadLine());
            string url = "http://ganga.pihms.co.in/Patient/get_PatientByID";

            HttpClient client = new HttpClient();

            var response = await client.PostAsync(url, new StringContent("{\"m_PatientID\":\"" + PatientByID + "\"}", Encoding.UTF8, "application/json"));

            string responseresult = await response.Content.ReadAsStringAsync();

            Console.WriteLine(responseresult);
            Console.ReadLine();
        }
        public static async Task PatientListByLatest()
        {
            Console.WriteLine("WAIT FOR API RESPONSE....!");

            string url = "http://ganga.pihms.co.in/Patient/get_PatientListByLatest";
            Console.WriteLine("Enter The Latest Count of Number Which u Want.");
            string LastCount = Console.ReadLine();
            HttpClient client = new HttpClient();

            var response = await client.PostAsync(url, new StringContent("{\"m_LatestCount\" :\"" + LastCount + "\"}", Encoding.UTF8, "application/json"));

            string responseresult = await response.Content.ReadAsStringAsync();

            var jsonResponse = JsonConvert.DeserializeObject(responseresult);

            Console.WriteLine(jsonResponse);
            Console.ReadLine();

        }


    }
}


