using AutoMapper;
using MagicVillaAPI.Data;
using MagicVillaAPI.Models;
using MagicVillaAPI.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MagicVillaAPI.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/VillaAPI")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        public ILogger<VillaAPIController> _logger { get; }
        public ApplicationDbContext _db { get; }
        public IMapper _mapper { get; }

        //control dot on windows, creates and assigns property
        public VillaAPIController(ILogger<VillaAPIController> logger, ApplicationDbContext db, IMapper mapper)
        {
            _logger = logger;
            _db = db;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<VillaDto>>> GetVillas() 
        {
            _logger.LogInformation("Getting all villas");

            IEnumerable<Villa> villaList = await _db.Villas.ToListAsync();

            return Ok(_mapper.Map<IEnumerable<VillaDto>>(villaList));
        }

        [HttpGet("{id:int}", Name ="GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<VillaDto>> GetVilla(int id)
        {
            if (id == 0)
            {
                _logger.LogError($"Get villa error with ID {id}");
                return BadRequest();
            }
            var villa = await _db.Villas.FirstOrDefaultAsync(u => u.Id.Equals(id));

            if (villa == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<VillaDto>(villa));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<VillaDto>> CreateVilla([FromBody] VillaDto villa)
        {
            //custom validations 
            if (await _db.Villas.FirstOrDefaultAsync(v => v.Name.ToLower().Equals(villa.Name.ToLower())) != null)
            {
                ModelState.AddModelError("CustomError", "Villa already exists");
                return BadRequest(ModelState);
            }

            if (villa == null)
            {
                return BadRequest(villa); 
            }

            if (villa.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            await _db.Villas.AddAsync(_mapper.Map<Villa>(villa));
            await _db.SaveChangesAsync();

            return CreatedAtRoute("GetVilla", new { id = villa.Id },villa);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteVilla(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var villa = await _db.Villas.FirstOrDefaultAsync(u => u.Id.Equals(id));

            if (villa == null)
            {
                return NotFound();
            }

            _db.Villas.Remove(villa);
            await _db.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{id:int}", Name = "UpdateVilla")]
        public async Task<IActionResult> UpdateVilla(int id, [FromBody] VillaDto villa)
        {
            if (villa == null || id != villa.Id)
            {
                return BadRequest();
            }

            _db.Villas.Update(_mapper.Map<Villa>(villa));
            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}
