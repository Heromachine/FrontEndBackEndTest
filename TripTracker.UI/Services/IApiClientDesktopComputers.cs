using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TripTracker.BackService.Models;
namespace TripTracker.UI.Services
{
    public interface IApiClientDesktopComputers
    {        
        Task<List<DesktopComputer>> GetDesktopComputersAsync();
        Task<DesktopComputer> GetDesktopComputerAsync(int id);
        Task PutDesktopComputer(DesktopComputer desktopComputer);
        Task AddDesktopComputer(DesktopComputer addItem);
        Task RemoveDesktopComputerAsync(int id);
    }

    public class ApiClientDesktopComputers : IApiClientDesktopComputers
    {
        private readonly HttpClient _HttpClient;

        public ApiClientDesktopComputers(HttpClient httpClient)
        {
            _HttpClient = httpClient;
        }

        public async Task AddDesktopComputer(DesktopComputer addItem)
        {
            var response = await _HttpClient.PostJsonAsync("/api/DesktopComputers", addItem);
            response.EnsureSuccessStatusCode();
        }

        public async Task<DesktopComputer> GetDesktopComputerAsync(int id)
        {
            var response = await _HttpClient.GetAsync($"/api/DesktopComputers/{id}");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsJsonAsync<DesktopComputer>();
        }

        public async Task<List<DesktopComputer>> GetDesktopComputersAsync()
        {
            var response = await _HttpClient.GetAsync("/DesktopComputers");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsJsonAsync<List<DesktopComputer>>();
        }

        public async Task PutDesktopComputer(DesktopComputer desktopComputer)
        {
            var response = await _HttpClient.PutJsonAsync($"/api/DesktopComputers/{desktopComputer.Id}", desktopComputer);
            response.EnsureSuccessStatusCode();
        }

        public async Task RemoveDesktopComputerAsync(int id)
        {
            var response = await _HttpClient.DeleteAsync($"/DesktopComputers/{id}");
            response.EnsureSuccessStatusCode();
        }
    }

}
