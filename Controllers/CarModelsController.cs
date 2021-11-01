using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UnixAuto.Models;

namespace UnixAuto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarModelsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CarModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CarModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarModel>>> GetCarModels()
        {
            
            return await _context.CarModels.Include(a => a.CarManufacturer).Include(b => b.ModelDetail).ToListAsync();
        }

        // GET: api/CarModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarModel>> GetCarModel(int id)
        {
            var carModel = await _context.CarModels.Include(a => a.CarManufacturer).Include(b => b.ModelDetail).FirstOrDefaultAsync(m => m.Id == id);

            if (carModel == null)
            {
                return NotFound();
            }

            return carModel;
        }

        // PUT: api/CarModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarModel(int id, CarModel carModel)
        {
            if (id != carModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(carModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CarModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CarModel>> CreateOrUpdate(CarModel carModel)
        {
            if (carModel.Id == 0)
            {
                if (_context.CarManufacturers.FirstOrDefault(x => x.Name == carModel.CarManufacturer.Name) != null)
                {
                    carModel.CarManufacturerId = _context.CarManufacturers.FirstOrDefault(x => x.Name == carModel.CarManufacturer.Name).Id;
                    carModel.CarManufacturer = null;
                    _context.CarModels.Add(carModel);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    _context.CarModels.Add(carModel);
                    await _context.SaveChangesAsync();
                }

                return CreatedAtAction("GetCarModel", new { id = carModel.Id }, carModel); 
            }
            else
            {
                if(_context.CarManufacturers.FirstOrDefault(x => x.Name == carModel.CarManufacturer.Name) != null)
                {
                    carModel.CarManufacturerId = _context.CarManufacturers.FirstOrDefault(x => x.Name == carModel.CarManufacturer.Name).Id;
                    carModel.CarManufacturer = null;
                    _context.Attach(carModel).State = EntityState.Modified;
                    _context.Attach(carModel.ModelDetail).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    var manufacturer = new CarManufacturer();
                    manufacturer.Name = carModel.CarManufacturer.Name;
                    _context.CarManufacturers.Add(manufacturer);
                    await _context.SaveChangesAsync();
                    carModel.CarManufacturerId = manufacturer.Id;
                    _context.Attach(carModel).State = EntityState.Modified;
                    _context.Attach(carModel.ModelDetail).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                return CreatedAtAction("GetCarModel", new { id = carModel.Id }, carModel);
            }
        }

        // DELETE: api/CarModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarModel(int id)
        {
            var carModel = await _context.CarModels.FindAsync(id);
            if (carModel == null)
            {
                return NotFound();
            }

            _context.CarModels.Remove(carModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarModelExists(int id)
        {
            return _context.CarModels.Any(e => e.Id == id);
        }
    }
}
