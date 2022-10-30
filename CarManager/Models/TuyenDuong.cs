using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CarManager.Models
{
    public class TuyenDuong
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int? TuyenDuongId { get; set; }
        public string? QuangDuong { get; set; }
        public string? Nhaxe { get; set; }
        public DateTime Thoigian { get; set; }
    }
}
