using Domain.Distracom.Commands;
using Domain.Distracom.Data;
using Domain.Distracom.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Distracom.Host.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatioController : ControllerBase
    {
        private DistracomDbContext _context;

        public StatioController(DistracomDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAllStations()
        {
            return Ok(_context.Stations.Include(s => s.Company));  
        }

        [HttpGet("{id}")]
        public IActionResult GetStationById(int id)
        {
            var station = _context.Stations.Include(s => s.Company).FirstOrDefault(s => s.StationId == id);
            if (station == null)
            {
                return NotFound("La estación no fue encontrada.");
            }

            return Ok(station);
        }

        [HttpPost]
        public IActionResult Post([FromBody] InsertNewStation station)
        {
            if (station == null)
            {
                return BadRequest("Los datos de la estación son inválidos.");
            }

            var newStation = new Station
            {
                Name = station.Name,
                Address = station.Address,
                Ubication = station.Ubication,
                Type = station.Type,
                CompanyId = station.CompanyId // Asegúrate de que el CompanyId sea correcto
            };

            _context.Stations.Add(newStation);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetStationById), new { id = newStation.StationId }, newStation);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateStation station)
        {
            var existingStation = _context.Stations.FirstOrDefault(s => s.StationId == id);
            if (existingStation == null)
            {
                return NotFound("La estación no fue encontrada.");
            }

            existingStation.Name = station.Name;
            existingStation.Address = station.Address;
            existingStation.Ubication = station.Ubication;
            existingStation.Type = station.Type;
            existingStation.CompanyId = station.CompanyId;

            _context.Stations.Update(existingStation);
            _context.SaveChanges();

            return Ok(existingStation);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var station = _context.Stations.Find(id);
            if (station == null)
            {
                return NotFound("La estación no fue encontrada.");
            }

            _context.Stations.Remove(station);
            _context.SaveChanges();

            return NoContent(); 
        }


    }
}
