using Microsoft.Extensions.DependencyInjection;
using ZadanieRekrutacyjne.Services;

namespace ZadanieRekrutacyjne
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var services = new ServiceCollection();

            services.AddHttpClient<ICatFactService, CatFactService>(client =>
            {
                client.BaseAddress = new Uri("https://catfact.ninja/");
            });

            services.AddSingleton<IFileService, FileService>();

            var serviceProvider = services.BuildServiceProvider();

            var catFactService =
                serviceProvider.GetRequiredService<ICatFactService>();

            var fileService =
                serviceProvider.GetRequiredService<IFileService>();

            Console.WriteLine("Press ENTER, to get a cat fact.");
            Console.WriteLine("Write 'q', to exit.");

            while (true)
            {
                var input = Console.ReadLine();

                if (input?.ToLower() == "q")
                {
                    break;
                }

                try
                {
                    var response = await catFactService.GetCatFactAsync();

                    if (response is not null)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"fact: {response.Fact}");
                        Console.WriteLine($"length: {response.Length}");

                        await fileService.SaveFactAsync(
                            $"fact: {response.Fact} | length: {response.Length}"
                        );

                        Console.WriteLine("Data has been saved to the file catfacts.txt");
                        Console.WriteLine();
                    }
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"API communication error: {ex.Message}");
                }
            }
        }
    }
}
