using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using N5Company.Data;
using N5Company.Models;

namespace N5Company.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionTypesController : ControllerBase
    {
        private readonly N5CompanyContext _context;

        public PermissionTypesController(N5CompanyContext context)
        {
            _context = context;
        }

        // GET: api/PermissionTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PermissionTypes>>> GetPermissionTypes()
        {
            return await _context.PermissionTypes.ToListAsync();
        }

        // GET: api/PermissionTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PermissionTypes>> GetPermissionTypes(int id)
        {
            var permissionTypes = await _context.PermissionTypes.FindAsync(id);

            if (permissionTypes == null)
            {
                return NotFound();
            }

            return permissionTypes;
        }

        // PUT: api/PermissionTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPermissionTypes(int id, PermissionTypes permissionTypes)
        {
            if (id != permissionTypes.ID)
            {
                return BadRequest();
            }

            _context.Entry(permissionTypes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PermissionTypesExists(id))
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

        // POST: api/PermissionTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PermissionTypes>> PostPermissionTypes(PermissionTypes permissionTypes)
        {
            _context.PermissionTypes.Add(permissionTypes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPermissionTypes", new { id = permissionTypes.ID }, permissionTypes);
        }

        // DELETE: api/PermissionTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePermissionTypes(int id)
        {
            var permissionTypes = await _context.PermissionTypes.FindAsync(id);
            if (permissionTypes == null)
            {
                return NotFound();
            }

            _context.PermissionTypes.Remove(permissionTypes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PermissionTypesExists(int id)
        {
            return _context.PermissionTypes.Any(e => e.ID == id);
        }
    }
}
