using Fase1.Web.DTO.Inputs;
using Fase1.Web.DTO.Results;
using Fase1.Web.Interfaces;
using System.Text;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace Fase1.Web.Services
{
    public class ContatoService : IContatoService
    {
        private readonly HttpClient _httpClient;

        public ContatoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public bool Atualizar(ContatoPut contato)
        {
            try
            {
                var jsonRequest = new StringContent(JsonSerializer.Serialize(contato), Encoding.UTF8, Application.Json);

                var response = _httpClient.PutAsync("Contato", jsonRequest).Result.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                    return true;

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Cadastrar(ContatoPost contato)
        {
            try
            {
                var jsonRequest = new StringContent(JsonSerializer.Serialize(contato), Encoding.UTF8, Application.Json);

                var response = _httpClient.PostAsync("Contato", jsonRequest).Result.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                    return true;

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task Excluir(int id)
        {
            try
            {
                await _httpClient.DeleteAsync($"Contato/{id}");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ContatoResult> GetContatoPorId(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"Contato/{id}");

                if (!response.IsSuccessStatusCode)
                    return null;

                var jsonResult = await response.Content.ReadAsStringAsync();

                var data = JsonSerializer.Deserialize<ContatoResult>(jsonResult);

                return data;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<IEnumerable<ContatoResult>> GetContatos()
        {
            try
            {
                var response = _httpClient.GetAsync("Contato").Result;

                if (!response.IsSuccessStatusCode)
                    return null;

                var jsonResult = await response.Content.ReadAsStringAsync();

                var data = JsonSerializer.Deserialize<List<ContatoResult>>(jsonResult);

                return data;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public async Task<IEnumerable<ContatoResult>> GetContatosPorDDD(string ddd)
        {
            try
            {
                var response = _httpClient.GetAsync($"Contato/ddd/{ddd}").Result;

                if (!response.IsSuccessStatusCode)
                    return null;

                var jsonResult = await response.Content.ReadAsStringAsync();

                var data = JsonSerializer.Deserialize<List<ContatoResult>>(jsonResult);

                return data;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
