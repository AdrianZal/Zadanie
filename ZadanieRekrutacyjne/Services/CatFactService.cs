using System.Net.Http.Json;
using ZadanieRekrutacyjne.Models;

namespace ZadanieRekrutacyjne.Services
{
    public class CatFactService(HttpClient _httpClient) : ICatFactService
    {
        public async Task<CatFactResponse?> GetCatFactAsync()
        {
            return await _httpClient.GetFromJsonAsync<CatFactResponse>("fact");
        }
    }
}
