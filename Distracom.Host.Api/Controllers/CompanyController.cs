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
    public class CompanyController : ControllerBase
    {
        private DistracomDbContext _context;

        public CompanyController(DistracomDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllCompanys()
        {
            return Ok(_context.Companies.Include(s=> s.Stations));
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetCompanyById(int id)
        {
            return Ok(_context.Companies.Include(s=> s.Stations).FirstOrDefault(c => c.CompanyId == id));
        }
        [HttpPost]
        public IActionResult Post([FromBody] InsertNewCompany company)
        {
            if (company == null)
            {
                return BadRequest("Los datos de la compañía son inválidos.");
            }

            var newCompany = new Company
            {
                Name = company.Name,
                Address = company.Address,
                Tel = company.Tel,
                Email = company.Email
            };

            _context.Companies.Add(newCompany);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetCompanyById), new { id = newCompany.CompanyId }, newCompany);
        }


        [HttpPut("{id}")]
            public IActionResult Put(int id, [FromBody] UpdateCompany company)
            {
               

                var existingCompany = _context.Companies.FirstOrDefault(c => c.CompanyId == id);
                if (existingCompany == null)
                {
                    return NotFound("La empresa no fue encontrada.");
                }

                existingCompany.Name = company.Name;
                existingCompany.Address = company.Address;
                existingCompany.Tel = company.Tel;
                existingCompany.Email = company.Email;
                existingCompany.Stations = company.Stations;

                _context.Companies.Update(existingCompany);
                _context.SaveChanges();

                return Ok(existingCompany);
            }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var company = _context.Companies.Find(id);
            if (company == null)
            {
                return NotFound("La empresa no fue encontrada.");
            }

            _context.Companies.Remove(company);
            _context.SaveChanges();

            return NoContent();  
        }



    }
}
