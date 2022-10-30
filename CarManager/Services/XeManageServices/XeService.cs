using Microsoft.AspNetCore.Components;
using CarManager.Models;
using CarManager.Data;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;
using CarManager.Dtos.BusDto;

namespace CarManager.Services.XeManageServices
{
    public class XeService : IXeService
    {
        public readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;
        public List<XeReadDTO> Xeservices { get; set; } = new List<XeReadDTO>();
        public List<GheDTO> Gheservices { get; set; } = new List<GheDTO>();
        public List<CheckGheDTO> CheckGheservices { get; set; } = new List<CheckGheDTO>();
        public List<CheckGheDTO> UnCheckGheservices { get; set; } = new List<CheckGheDTO>();
        public List<BieudoDTO> BieuDoservices { get; set; } = new List<BieudoDTO>();
        public List<SearchXeDTO> SearchXeservices { get; set; } = new List<SearchXeDTO>();

        public XeService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
            _http.BaseAddress = new Uri(_navigationManager.BaseUri);
        }
        public async Task GetXeDetail()
        {
            var result = await _http.GetFromJsonAsync<List<XeReadDTO>>("api/xemanage");
            if (result != null)
            {
                Xeservices = result;
            }
        }
        private async Task SetXe(HttpResponseMessage result)
        {
            Console.WriteLine(result.StatusCode);
            _navigationManager.NavigateTo("CarManage");
        }

        public async Task CreateXe(Xe xe)
        {
            var resutl = await _http.PostAsJsonAsync("api/xemanage", xe);
            await SetXe(resutl);
        }

        public async Task DeleteXe(int id)
        {
            var result = await _http.DeleteAsync($"api/XeManage/{id}");
            await SetXe(result);
        }

        public async Task<Xe> GetIdXe(int id)
        {
            var resutl = await _http.GetFromJsonAsync<Xe>($"api/xemanage/{id}");
            if(resutl == null)
            {
                throw new Exception("not found bus");
            }
            return resutl;
        }

        public async Task UpdateXe(int? id, Xe xe)
        {
            var resutl = await _http.PutAsJsonAsync($"api/xemanage/{id}",xe);
            await SetXe(resutl);
        }

        public async Task GetGheDetail()
        {
            var result = await _http.GetFromJsonAsync<List<GheDTO>>("api/xemanage/ghe");
            if (result != null)
            {
                Gheservices = result;
            }
        }

        public async Task UpdateGhe(int? id, Xe xe)
        {
            var resutl = await _http.PutAsJsonAsync($"api/xemanage/ghe/{id}", xe);
            await SetXe(resutl);
        }

        public async Task CheckGhe()
        {
            var result = await _http.GetFromJsonAsync<List<CheckGheDTO>>("api/xemanage/checkghe");
            if (result != null)
            {
                CheckGheservices = result;
            }
        }
        public async Task UncheckGhe()
        {
            var result = await _http.GetFromJsonAsync<List<CheckGheDTO>>("api/xemanage/uncheckghe");
            if (result != null)
            {
                UnCheckGheservices = result;
            }
        }

        public async Task bieudo()
        {
            var result = await _http.GetFromJsonAsync<List<BieudoDTO>>("api/xemanage/bieudo");
            if (result != null)
            {
                BieuDoservices = result;
            }
        }

        public async Task Search(string Tenxe)
        {
            var result = await _http.GetFromJsonAsync<List<XeReadDTO>>($"api/xemanage/search/{Tenxe}");
            if (result != null)
            {
                Xeservices = result;
            }
        }
    }
}
