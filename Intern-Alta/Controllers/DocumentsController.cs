using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Intern_Alta.Data;
using Intern_Alta.Services.Documents;
using System.Collections.Generic;

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

        // Lấy tất cả tài liệu
        [HttpGet]
        public ActionResult<List<Document>> GetAllDocuments()
        {
            var documents = _documentService.GetAllDocuments();
            return Ok(documents); // Trả về danh sách tài liệu
        }

        // Lấy tài liệu theo ID
        [HttpGet("{id}")]
        public ActionResult<Document> GetDocumentById(int id)
        {
            var document = _documentService.GetDocumentById(id);
            if (document == null)
            {
                return NotFound(); // Trả về 404 nếu tài liệu không tồn tại
            }
            return Ok(document); // Trả về tài liệu
        }

        // Tạo mới tài liệu
        [HttpPost]
        public ActionResult<Document> CreateDocument([FromBody] Document document)
        {
            if (document == null)
            {
                return BadRequest(); // Trả về 400 nếu tài liệu không hợp lệ
            }

            var createdDocument = _documentService.CreateDocument(document);
            return CreatedAtAction(nameof(GetDocumentById), new { id = createdDocument.DocumentID }, createdDocument);
        }

        // Cập nhật tài liệu theo ID
        [HttpPut("{id}")]
        public ActionResult<Document> UpdateDocument(int id, [FromBody] Document document)
        {
            if (document == null || id != document.DocumentID)
            {
                return BadRequest(); // Trả về 400 nếu tài liệu không hợp lệ
            }

            var updatedDocument = _documentService.UpdateDocument(id, document);
            return Ok(updatedDocument); // Trả về tài liệu đã cập nhật
        }

        // Xóa tài liệu theo ID
        [HttpDelete("{id}")]
        public ActionResult DeleteDocument(int id)
        {
            var success = _documentService.DeleteDocument(id);
            if (!success)
            {
                return NotFound(); // Trả về 404 nếu tài liệu không tồn tại
            }
            return NoContent(); // Trả về 204 khi xóa thành công
        }
    }
}