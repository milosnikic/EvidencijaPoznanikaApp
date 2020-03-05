using System.Collections.Generic;
using System.Threading.Tasks;
using EvidencijaPoznanika.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EvidencijaPoznanika.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OsobaController : ControllerBase
    {
        private readonly EvidencijaPoznanikaContext _dbContext;

        public OsobaController(EvidencijaPoznanikaContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("addNumbers")]
        public int? AddNumbers(List<int> numbers)
        {
            if(numbers == null || numbers.Count == 0)
            {
                return null;
            }
            int sum = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                sum += numbers[i];
            }
            return sum;
        }


        [HttpGet]
        public async Task<IActionResult> GetOsobe()
        {
            var osobe = await _dbContext.Osoba.ToListAsync();
            return Ok(osobe);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOsoba(long id)
        {
            var param = new SqlParameter("@Id", id);
            var osoba = await _dbContext.Osoba.FromSqlInterpolated($"exec selOSOBA @Id = {param}").FirstOrDefaultAsync();
            if (osoba == null)
            {
                return BadRequest("Specified user does not exist");
            }
            return Ok(osoba);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOsoba(long id)
        {
            var param = new SqlParameter("@Id", id);
            var osobe = await _dbContext.Osoba.FromSqlInterpolated($"exec selOSOBA @Id = {param}").ToListAsync();
            if (osobe.Count == 0)
            {
                return BadRequest("Specified user does not exist");
            }

            await _dbContext.Database.ExecuteSqlInterpolatedAsync($"exec delOSOBA @Id = {param}");
            return Ok("Specified user has been deleted");
        }

        [HttpPost("insert")]
        public async Task<IActionResult> InsertOsoba([FromBody]Osoba osobaZaDodavanje)
        {
            try
            {
                await _dbContext.Osoba.AddAsync(osobaZaDodavanje);
                if (await _dbContext.SaveChangesAsync() > 0)
                {
                    return Ok();
                }
            }
            catch (System.Exception e)
            {
                return BadRequest("User has not been saved!\n" + e.InnerException.Message);
            }

            return BadRequest("User has not been saved!");
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateOsoba([FromBody]Osoba osobaZaIzmenu)
        {
            // Iz nekog razloga je javljalo gresku prilikom pozivanja metode,
            // i kada sam u SQL profileru pogledao video sam da za vrednost visina nalazi default
            // potrebno je proveriti da li su vrednosti null pa ih nakon toga dodati kao parametre
            // ovo ostaje da se zavrsi.. do tada se koristi funkcionalnost entity frameworka Update

            // var param  = new SqlParameter("@Id", osobaZaIzmenu.Id);
            // var maticniBroj = new SqlParameter("@Maticni_broj", osobaZaIzmenu.MaticniBroj);
            // var ime = new SqlParameter("@Ime", osobaZaIzmenu.Ime);
            // var prezime = new SqlParameter("@Prezime", osobaZaIzmenu.Prezime);
            // var visina = new SqlParameter("@Visina", osobaZaIzmenu.Visina ?? null);
            // var tezina = new SqlParameter("@Tezina",osobaZaIzmenu.Tezina ?? null);
            // var bojaOciju = new SqlParameter("@Boja_ociju", osobaZaIzmenu.BojaOciju ?? null);
            // var telefon = new SqlParameter("@Telefon", osobaZaIzmenu.Telefon ?? null);
            // var email = new SqlParameter("@Email", osobaZaIzmenu.Email);
            // var rodjendan = new SqlParameter("@Rodjendan", osobaZaIzmenu.Rodjendan);
            // var adresa = new SqlParameter("@Adresa", osobaZaIzmenu.Adresa ?? null);
            // var prebivaliste = new SqlParameter("@Prebivaliste", osobaZaIzmenu.Prebivaliste);

            // var osobe = await _dbContext.Osoba.FromSqlInterpolated($"exec selOSOBA @Id = {param}").ToListAsync();
            // if (osobe.Count == 0)
            // {
            //     return BadRequest("Specified user does not exist");
            // }

            // await _dbContext.Database.ExecuteSqlInterpolatedAsync($"exec updOSOBA @Id = {param}, @Maticni_broj = {maticniBroj}, @Ime = {ime} , @Prezime = {prezime}, @Visina = {visina}, @Tezina = {tezina}, @Boja_ociju = {bojaOciju}, @Telefon = {telefon}, @Email = {email}, @Rodjendan = {rodjendan}, @Adresa = {adresa} ,@Prebivaliste = {prebivaliste}");

            var record = await _dbContext.Osoba.FirstOrDefaultAsync(o => o.Id == osobaZaIzmenu.Id);
            if (record != null)
            {
                record.Ime = osobaZaIzmenu.Ime;
                record.Prezime = osobaZaIzmenu.Prezime;
                record.Visina = osobaZaIzmenu.Visina;
                record.Tezina = osobaZaIzmenu.Tezina;
                record.BojaOciju = osobaZaIzmenu.BojaOciju;
                record.Telefon = osobaZaIzmenu.Telefon;
                record.Email = osobaZaIzmenu.Email;
                record.Rodjendan = osobaZaIzmenu.Rodjendan;
                record.Adresa = osobaZaIzmenu.Adresa;
                record.Prebivaliste = osobaZaIzmenu.Prebivaliste;
                if (await _dbContext.SaveChangesAsync() > 0)
                {
                    return NoContent();
                }
            }
            return BadRequest("Specified user has not been updated");
        }

        [HttpGet("smederevci")]
        public async Task<IActionResult> GetSmederevci()
        {
            var smederevci = await _dbContext.Smederevci.ToListAsync();
            return Ok(smederevci);
        }


        [HttpGet("punoletni")]
        public async Task<IActionResult> GetPunoletni()
        {
            var punoletni = await _dbContext.Punoletni.ToListAsync();
            return Ok(punoletni);
        }

        [HttpGet("maxVisina")]
        public async Task<IActionResult> GetMaxVisina()
        {
            var resultParam = new SqlParameter
            {
                ParameterName = "@maxVisina",
                SqlDbType = System.Data.SqlDbType.SmallInt,
                Direction = System.Data.ParameterDirection.Output
            };
            await _dbContext.Database.ExecuteSqlRawAsync("select @maxVisina = dbo.fnMaxVisina()", resultParam);
            return Ok((short)resultParam.Value);
        }

        [HttpGet("srednjaStarost")]
        public async Task<IActionResult> GetSrednjaStarost()
        {

            var resultParam = new SqlParameter
            {
                ParameterName = "@srednjaStarost",
                SqlDbType = System.Data.SqlDbType.Float,
                Direction = System.Data.ParameterDirection.Output
            };
            await _dbContext.Database.ExecuteSqlRawAsync("select @srednjaStarost = dbo.fnSrednjaStarost()", resultParam);


            return Ok((double)resultParam.Value);
        }
    }

}