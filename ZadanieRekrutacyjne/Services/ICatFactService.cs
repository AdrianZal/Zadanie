using ZadanieRekrutacyjne.Models;

namespace ZadanieRekrutacyjne.Services
{
    public interface ICatFactService
    {
        Task<CatFactResponse?> GetCatFactAsync();
    }
}
