using Newtonsoft.Json;
using System.Net.Http.Json;

namespace Client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var baseUrl = "https://localhost:7142/api/Students";

            var httpClient = new HttpClient();
            //httpClient.BaseAddress = new Uri(baseUrl);

            //var request = await httpClient.GetAsync(baseUrl);
            //var response = await request.Content.ReadAsStringAsync();

            //var students = JsonConvert.DeserializeObject<List<StudentDto>>(response);

            //foreach (var item in students)
            //{
            //    Console.WriteLine(item);
            //}

            var student = new StudentDto
            {
                Firstname = "Jamal2",
                Lastname = "Jamal2",
                Age = 25
            };
            //Refit
            var response = await httpClient.PostAsJsonAsync(baseUrl, student);

            if (response.IsSuccessStatusCode)
            {
                // Get the URI of the created resource.
                Uri gizmoUrl = response.Headers.Location;
            }

            Console.ReadLine();
        }
    }

    internal class StudentDto
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"{Firstname} {Lastname}";
        }
    }
}