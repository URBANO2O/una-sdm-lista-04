using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Iniciando requisição para obter dados de um conselho...");
        
        string url = "https://api.adviceslip.com/advice";

        using (HttpClient client = new HttpClient())
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string json = await response.Content.ReadAsStringAsync();

                var adviceResponse = JsonSerializer.Deserialize<AdviceResponse>(json);

                Console.WriteLine("\nConselho de Hoje:");
                Console.WriteLine(adviceResponse.slip.advice);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao consumir API:");
                Console.WriteLine(ex.Message);
            }
        }

        Console.WriteLine("\nFim da requisição.");
    }
}