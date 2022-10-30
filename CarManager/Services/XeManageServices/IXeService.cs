using CarManager.Models;
using CarManager.Data;
using CarManager.Dtos.BusDto;

namespace CarManager.Services.XeManageServices
{
    public interface IXeService
    {
        List<XeReadDTO> Xeservices { get; set; }
        List<GheDTO> Gheservices { get; set; }
        List<CheckGheDTO> CheckGheservices { get; set; }
        List<CheckGheDTO> UnCheckGheservices { get; set; }
        List<BieudoDTO> BieuDoservices { get; set; }
        List<SearchXeDTO> SearchXeservices { get; set; }
        Task GetXeDetail();
        Task<Xe> GetIdXe(int id);
        Task UpdateXe(int? id, Xe xe);
        Task UpdateGhe(int? id, Xe xe);
        Task CreateXe(Xe xe);
        Task DeleteXe(int id);
        Task GetGheDetail();
        Task CheckGhe();
        Task UncheckGhe();
        Task bieudo();
        Task Search(string Tenxe);
    }
}
