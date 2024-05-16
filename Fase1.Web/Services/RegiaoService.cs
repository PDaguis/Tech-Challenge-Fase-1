using Fase1.Web.DTO.Inputs;
using Fase1.Web.DTO.Results;
using Fase1.Web.Interfaces;
using System.Text;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace Fase1.Web.Services
{
    public class RegiaoService : IRegiaoService
    {
        private readonly HttpClient _httpClient;

        public RegiaoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public bool Cadastrar(RegiaoPost regiao)
        {
            try
            {
                var jsonRequest = new StringContent(JsonSerializer.Serialize(regiao), Encoding.UTF8, Application.Json);

                var response = _httpClient.PostAsync("Regiao", jsonRequest).Result.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                    return true;

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<RegiaoResult>> GetRegioes()
        {
            try
            {
                var response = _httpClient.GetAsync("Regiao").Result;

                if (!response.IsSuccessStatusCode)
                    return null;

                var jsonResult = await response.Content.ReadAsStringAsync();

                var data = JsonSerializer.Deserialize<List<RegiaoResult>>(jsonResult);

                return data;
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
