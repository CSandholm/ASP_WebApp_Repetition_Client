using System.Dynamic;
using System.Text;
using System.Text.Json;

namespace WebApp_Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Run();
        }
        static void Run()
        {
            bool running = true;
            Console.WriteLine("What do you want to do?");
            while (running)
            {
                string input = Console.ReadLine().ToLower();
                switch (input)
                {
                    case "get":
                        Get();
                        break;
                    case "put":
                        Put();
                        break;
                    case "post":
                        Post();
                        break;
                    case "delete":
                        Delete();
                        break;
                    case "getbyid":
                        GetById(); 
                        break;
                    case "q":
                        running = false;
                        break;
                default:
                        break;
            }
            }
        }

        private static void Delete()
        {
            Console.WriteLine("What Id do you want to remove?");
            int catId = Convert.ToInt32(Console.ReadLine());

            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.DeleteAsync("https://localhost:7262/api/values/" + catId).Result;
            string json = response.Content.ReadAsStringAsync().Result;

            Console.WriteLine("Status code: " + response.StatusCode);
            Console.WriteLine("Status code: " + (int)response.StatusCode);
        }

        private static void Post()
        {
            HttpClient client = new HttpClient();
            Uri uri = new Uri("https://localhost:7262/api/values");
            Cat cat = new Cat("Kisse katt 2000", "Green", "Pomperipossa", 17, "image");
            string json = JsonSerializer.Serialize(cat);

            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(uri, content).Result;

            Console.WriteLine("Status code: " + response.StatusCode);
            Console.WriteLine("Status code: " + (int)response.StatusCode);
        }

        private static void Put()
        {
            HttpClient client = new HttpClient();
            Cat cat = new Cat("Arne Kattvakt", "Hungary Red", "Galen Hundson", 9, "image");
            cat.Id = 1;
            Uri uri = new Uri("https://localhost:7262/api/values/"+cat.Id);
            string json = JsonSerializer.Serialize(cat);

            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync(uri, content).Result;

            Console.WriteLine("Status code: " + response.StatusCode);
            Console.WriteLine("Status code: " + (int)response.StatusCode);
        }

        private static void Get()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync("https://localhost:7262/api/values").Result;
            string json = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(json);
        }
        private static void GetById()
        {
            Console.WriteLine("What Id do you wish to fetch?");
            int id = Convert.ToInt32(Console.ReadLine());
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync("https://localhost:7262/api/values/"+id).Result;
            string json = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(json);
        }
    }
}