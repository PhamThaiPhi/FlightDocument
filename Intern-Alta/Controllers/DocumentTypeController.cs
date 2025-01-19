using Intern_Alta.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Intern_Alta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentTypeController : ControllerBase
    {
        private readonly MyDbContext _context;


        public DocumentTypeController(MyDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var documentTypes = await _context.DocumentTypes.ToListAsync();
            return Ok(documentTypes);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var documentType = await _context.DocumentTypes.FindAsync(id);
            if (documentType == null)
            {
                return NotFound(new { Message = $"DocumentType with ID {id} not found." });
            }

            return Ok(documentType);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DocumentType documentType)
        {
            if (documentType == null || string.IsNullOrWhiteSpace(documentType.TypeName))
            {
                return BadRequest(new { Message = "Invalid document type data." });
            }

            _context.DocumentTypes.Add(documentType);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = documentType.DocumentTypeID }, documentType);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DocumentType documentType)
        {
            if (documentType == null || id != documentType.DocumentTypeID)
            {
                return BadRequest(new { Message = "Invalid document type data." });
            }

            var existingType = await _context.DocumentTypes.FindAsync(id);
            if (existingType == null)
            {
                return NotFound(new { Message = $"DocumentType with ID {id} not found." });
            }

            existingType.TypeName = documentType.TypeName;
            await _context.SaveChangesAsync();

            return Ok(existingType);
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var documentType = await _context.DocumentTypes.FindAsync(id);
            if (documentType == null)
            {
                return NotFound(new { Message = $"DocumentType with ID {id} not found." });
            }

            _context.DocumentTypes.Remove(documentType);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
