using Intern_Alta.Data;
using Intern_Alta.Models;
using Intern_Alta.Services.DocumentTypes;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Intern_Alta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentTypeController : ControllerBase
    {
        private readonly IDocTypeService _docTypeService;

        // Inject IDocTypeService qua constructor
        public DocumentTypeController(IDocTypeService docTypeService)
        {
            _docTypeService = docTypeService ?? throw new ArgumentNullException(nameof(docTypeService));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var documentTypes = _docTypeService.GetAllDocumentTypes();
                return Ok(documentTypes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"Internal server error: {ex.Message}" });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var documentType = _docTypeService.GetDocumentTypeById(id);
                return Ok(documentType);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"Internal server error: {ex.Message}" });
            }
        }

        [HttpPost]
        public IActionResult Create(DocTypeModel model)
        {
            if (model == null)
            {
                return BadRequest(new { Message = "Model cannot be null." });
            }

            try
            {
                var newDocumentType = _docTypeService.CreateDocumentType(model);
                return Ok(newDocumentType);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"Internal server error: {ex.Message}" });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] DocTypeModel documentType)
        {      
                var updatedDocumentType = _docTypeService.UpdateDocumentType(id, documentType);
                return Ok(updatedDocumentType);

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var success = _docTypeService.DeleteDocumentType(id);
                if (success)
                {
                    return NoContent();
                }

                return NotFound(new { Message = $"DocumentType with ID {id} not found." });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"Internal server error: {ex.Message}" });
            }
        }
    }
}
