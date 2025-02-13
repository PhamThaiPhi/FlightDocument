using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Intern_Alta.Data;
using Intern_Alta.Services.Documents;
using System.Collections.Generic;
using Intern_Alta.Models;

namespace Intern_Alta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly IDocumentService _documentService;

        public DocumentsController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

    
        [HttpGet]
        public ActionResult<List<Document>> GetAllDocuments()
        {
            var documents = _documentService.GetAllDocuments();
            return Ok(documents); 
        }

       
        [HttpGet("{id}")]
        public ActionResult<Document> GetDocumentById(int id)
        {
            var document = _documentService.GetDocumentById(id);
            if (document == null)
            {
                return NotFound();
            }
            return Ok(document);
        }

      
        [HttpPost]
        public IActionResult Create(DocModel model)
        {
            if (model == null)
            {
                return BadRequest(new { Message = "Model cannot be null." });
            }

            try
            {
                var newDocumentType = _documentService.CreateDocument(model);
                return Ok(newDocumentType);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"Internal server error: {ex.Message}" });
            }
        }
  
        [HttpPut("{id}")]
        public ActionResult<Document> UpdateDocument(int id, [FromBody] DocModel document)
        {
            var updatedDocument = _documentService.UpdateDocument(id, document);
            return Ok(updatedDocument); 
        }

       
        [HttpDelete("{id}")]
        public ActionResult DeleteDocument(int id)
        {
            var success = _documentService.DeleteDocument(id);
            if (!success)
            {
                return NotFound(); 
            }
            return NoContent(); 
        }
    }
}