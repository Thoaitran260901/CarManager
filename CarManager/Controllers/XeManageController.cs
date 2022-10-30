using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarManager.Data;
using CarManager.Models;
using CarManager.Dtos.BusDto;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using System.Collections.Specialized;
using System.Text;
using Microsoft.Data.SqlClient;

namespace CarManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class XeManageController : ControllerBase
    {
        private readonly CarManageDbContext _context;
        public XeManageController(CarManageDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<XeDTO>>> GetXeDetail()
        {
            List<String> ListData = new List<String>();
            try
            {
                var jsonResult = new StringBuilder();
                var data = new StringBuilder();
                var ListDiemdanh = new List<OrderedDictionary>();
                using (var cmd = _context.Database.GetDbConnection().CreateCommand())
                {
                    cmd.CommandText = "sp_api_GetCarManager";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    if (cmd.Connection.State != System.Data.ConnectionState.Open) cmd.Connection.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var dictionary = new OrderedDictionary();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            if (reader[i] == DBNull.Value)
                            {
                                dictionary.Add(reader.GetName(i), "0");
                            }
                            else
                            {
                                dictionary.Add(reader.GetName(i), reader[i].ToString());
                            }
                        }
                        ListDiemdanh.Add(dictionary);
                    }
                    return Ok(ListDiemdanh);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult<List<Xe>>> CreateSinhVien(Xe xe)
        {
            _context.tb_Xe.Add(xe);
            await _context.SaveChangesAsync();

            return Ok(xe);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Xe>>> DeleteXe(int id)
        {
            var dbXe = await _context.tb_Xe.FirstOrDefaultAsync(sh => sh.Id == id);
            if (dbXe == null)
                return NotFound("Sorry, but no student for you. :/");

            _context.tb_Xe.Remove(dbXe);
            await _context.SaveChangesAsync();

            return Ok(dbXe);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Xe>>> GetXeId(int id)
        {
            var xe = await _context.tb_Xe.FirstOrDefaultAsync(sh => sh.Id == id);
            if(xe == null)
            {
                return NotFound("no bus here");
            }
            return Ok(xe);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Xe>>> UpdateXe([FromBody]Xe xe, int id)
        {
            var dbXe = await _context.tb_Xe
                .FirstOrDefaultAsync(sh => sh.Id == id);
            if (dbXe == null)
                return NotFound("Sorry, but no hero for you. :/");
            dbXe.XeId = xe.XeId;
            dbXe.TenXe = xe.TenXe;
            dbXe.BienSo = xe.BienSo;
            dbXe.TaiTrong = xe.TaiTrong;
            dbXe.HangHoa = xe.HangHoa;
            dbXe.GheId = xe.GheId;
            dbXe.TuyenDuongId = xe.TuyenDuongId;
            await _context.SaveChangesAsync();

            return Ok(xe);
        }
        [HttpPut("ghe/{id}")]
        public async Task<ActionResult<List<Xe>>> UpdateGhe([FromBody] Xe xe, int id)
        {
            var dbXe = await _context.tb_Xe
                .FirstOrDefaultAsync(sh => sh.Id == id);
            if (dbXe == null)
                return NotFound("Sorry, but no hero for you. :/");
           
            dbXe.GheId = xe.GheId;
            await _context.SaveChangesAsync();

            return Ok(xe);
        }
        [HttpGet("ghe")]
        public async Task<ActionResult> DetailGhe()
        {
            var resutl = await _context.tb_Ghe.ToListAsync();
            return Ok(resutl);
        }
        [HttpGet("checkghe")]
        public async Task<ActionResult> CheckGhe()
        {
            List<String> ListData = new List<String>();
            try
            {
                var jsonResult = new StringBuilder();
                var data = new StringBuilder();
                var ListDiemdanh = new List<OrderedDictionary>();
                using (var cmd = _context.Database.GetDbConnection().CreateCommand())
                {
                    cmd.CommandText = "sp_api_CheckGhe";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    if (cmd.Connection.State != System.Data.ConnectionState.Open) cmd.Connection.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var dictionary = new OrderedDictionary();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            if (reader[i] == DBNull.Value)
                            {
                                dictionary.Add(reader.GetName(i), "0");
                            }
                            else
                            {
                                dictionary.Add(reader.GetName(i), reader[i].ToString());
                            }
                        }
                        ListDiemdanh.Add(dictionary);
                    }
                    return Ok(ListDiemdanh);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("uncheckghe")]
        public async Task<ActionResult> UnCheckGhe()
        {
            List<String> ListData = new List<String>();
            try
            {
                var jsonResult = new StringBuilder();
                var data = new StringBuilder();
                var ListDiemdanh = new List<OrderedDictionary>();
                using (var cmd = _context.Database.GetDbConnection().CreateCommand())
                {
                    cmd.CommandText = "sp_api_CheckUnableGhe";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    if (cmd.Connection.State != System.Data.ConnectionState.Open) cmd.Connection.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var dictionary = new OrderedDictionary();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            if (reader[i] == DBNull.Value)
                            {
                                dictionary.Add(reader.GetName(i), "0");
                            }
                            else
                            {
                                dictionary.Add(reader.GetName(i), reader[i].ToString());
                            }
                        }
                        ListDiemdanh.Add(dictionary);
                    }
                    return Ok(ListDiemdanh);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("bieudo")]
        public async Task<ActionResult> GetBieudo()
        {
            List<String> ListData = new List<String>();
            try
            {
                var jsonResult = new StringBuilder();
                var data = new StringBuilder();
                var ListDiemdanh = new List<OrderedDictionary>();
                using (var cmd = _context.Database.GetDbConnection().CreateCommand())
                {
                    cmd.CommandText = "sp_api_Bieudo";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    if (cmd.Connection.State != System.Data.ConnectionState.Open) cmd.Connection.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var dictionary = new OrderedDictionary();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            if (reader[i] == DBNull.Value)
                            {
                                dictionary.Add(reader.GetName(i), "0");
                            }
                            else
                            {
                                dictionary.Add(reader.GetName(i), reader[i].ToString());
                            }
                        }
                        ListDiemdanh.Add(dictionary);
                    }
                    return Ok(ListDiemdanh);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("search/{Tenxe}")]
        public async Task<ActionResult> Search(string Tenxe)
        {
            var tenxe = new SqlParameter("@Tenxe", Tenxe);
            List<String> ListData = new List<String>();
            try
            {
                var jsonResult = new StringBuilder();
                var data = new StringBuilder();
                var ListDiemdanh = new List<OrderedDictionary>();
                using (var cmd = _context.Database.GetDbConnection().CreateCommand())
                {
                    cmd.CommandText = "sp_api_tenxe";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    if (cmd.Connection.State != System.Data.ConnectionState.Open) cmd.Connection.Open();
                    cmd.Parameters.Add(tenxe);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var dictionary = new OrderedDictionary();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            if (reader[i] == DBNull.Value)
                            {
                                dictionary.Add(reader.GetName(i), "0");
                            }
                            else
                            {
                                dictionary.Add(reader.GetName(i), reader[i].ToString());
                            }
                        }
                        ListDiemdanh.Add(dictionary);
                    }
                    return Ok(ListDiemdanh);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
