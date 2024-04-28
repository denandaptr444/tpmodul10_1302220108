using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace tpmodul10_1302220108.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Mahasiswa : ControllerBase
    {
        private static List<MahasiswaModel> arrMahasiswa = new List<MahasiswaModel>
        {
            new MahasiswaModel { Nama = "I Wayan Denanda Permana Putra", Nim = "1302220108" },
            new MahasiswaModel { Nama = "Harits Azfa", Nim = "1302223045" },
            new MahasiswaModel { Nama = "Fajar Jelang", Nim = "1302223146" },
            new MahasiswaModel { Nama = "M Aldino", Nim = "1302223071" },
            new MahasiswaModel { Nama = "M Ghifari", Nim = "1302220033" },
            new MahasiswaModel { Nama = "Fransiskus Abel", Nim = "1302223138" }
            
        };

        [HttpGet]
        public IEnumerable<MahasiswaModel> Get()
        {
            return arrMahasiswa;
        }

        [HttpGet("{id}")]
        public ActionResult<MahasiswaModel> Get(int id)
        {
            if (id < 0 || id >= arrMahasiswa.Count)
            {
                return NotFound();
            }

            return arrMahasiswa[id];
        }

        [HttpPost]
        public IActionResult Post([FromBody] MahasiswaModel mahasiswa)
        {
            arrMahasiswa.Add(mahasiswa);
            return CreatedAtAction(nameof(Get), new { id = arrMahasiswa.IndexOf(mahasiswa) }, mahasiswa);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id < 0 || id >= arrMahasiswa.Count)
            {
                return NotFound();
            }

            arrMahasiswa.RemoveAt(id);
            return NoContent();
        }
    }

    public class MahasiswaModel
    {
        public string Nama { get; set; }
        public string Nim { get; set; }
    }
}
