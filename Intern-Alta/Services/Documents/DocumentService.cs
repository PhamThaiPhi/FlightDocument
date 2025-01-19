using Intern_Alta.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intern_Alta.Services.Documents
{
    public class DocumentService : IDocumentService
    {
        private readonly MyDbContext _context;

        public DocumentService(MyDbContext context)
        {
            _context = context;
        }

        // Lấy tất cả tài liệu
        public List<Document> GetAllDocuments()
        {
            return _context.Documents
                .Select(d => new Document
                {
                    DocumentID = d.DocumentID,
                    Title = d.Title,
                    UploadedAt = d.UploadedAt,
                    UserID = d.UserID,
                    DocumentTypeID = d.DocumentTypeID,
                    DocumentType = d.DocumentType // Bao gồm cả DocumentType
                })
                .ToList();
        }

        // Lấy thông tin tài liệu theo ID
        public Document GetDocumentById(int id)
        {
            return _context.Documents
                .Where(d => d.DocumentID == id)
                .Select(d => new Document
                {
                    DocumentID = d.DocumentID,
                    Title = d.Title,
                    UploadedAt = d.UploadedAt,
                    UserID = d.UserID,
                    DocumentTypeID = d.DocumentTypeID,
                    DocumentType = d.DocumentType
                })
                .FirstOrDefault();
        }

        // Tạo mới một tài liệu
        public Document CreateDocument(Document document)
        {
            // Kiểm tra DocumentTypeID có tồn tại không
            if (!_context.DocumentTypes.Any(dt => dt.DocumentTypeID == document.DocumentTypeID))
            {
                throw new ArgumentException("DocumentTypeID không hợp lệ.");
            }

            _context.Documents.Add(document); // Thêm tài liệu
            _context.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
            return document;
        }

        // Cập nhật tài liệu theo ID
        public Document UpdateDocument(int id, Document document)
        {
            var existingDocument = _context.Documents.Find(id);

            if (existingDocument == null)
            {
                return null; // Không tìm thấy tài liệu
            }

            // Cập nhật thông tin
            existingDocument.Title = document.Title;
            existingDocument.UploadedAt = document.UploadedAt;
            existingDocument.UserID = document.UserID;

            // Kiểm tra DocumentTypeID mới có hợp lệ không
            if (!_context.DocumentTypes.Any(dt => dt.DocumentTypeID == document.DocumentTypeID))
            {
                throw new ArgumentException("DocumentTypeID không hợp lệ.");
            }

            existingDocument.DocumentTypeID = document.DocumentTypeID;

            _context.SaveChanges(); // Lưu thay đổi
            return existingDocument;
        }

        // Xóa tài liệu theo ID
        public bool DeleteDocument(int id)
        {
            var document = _context.Documents.Find(id);

            if (document == null)
            {
                return false; // Không tìm thấy tài liệu
            }

            _context.Documents.Remove(document); // Xóa tài liệu
            _context.SaveChanges(); // Lưu thay đổi
            return true;
        }
    }
}
