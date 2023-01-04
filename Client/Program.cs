namespace Client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var baseUrl = "https://localhost:7021/api/Students";

            var httpClient = new HttpClient();

            //httpClient.BaseAddress = new Uri(baseUrl);

            var request = await httpClient.GetAsync(baseUrl);

        }
    }
}