using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using CarManager.Models;
namespace CarManager.Dtos.BusDto
{
    public class XeDTO
    {
        public int Id { get; set; }
        [Required]
        public string? XeId { get; set; }
        public string? TenXe { get; set; }
        public string? BienSo { get; set; }
        public string? TaiTrong { get; set; }
        public string? HangHoa { get; set; }
        public int? TuyenDuongId { get; set; }
        public int? GheId { get; set; }
        public TuyenDuong? tuyenDuong { get; set; }
        public Ghe? ghe { get; set; }
    }
}
