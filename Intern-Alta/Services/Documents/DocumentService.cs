using Intern_Alta.Data;
using Intern_Alta.Models;
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
        public Document CreateDocument(DocModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "Model cannot be null.");
            }

            try
            {
                var newDocumentType = new Document
                {
                    Title = model.Title,
                    UploadedAt= model.UploadedAt,
                    DocumentTypeID= model.DocumentTypeID,   
                };

                _context.Documents.Add(newDocumentType);
                _context.SaveChanges();

                return newDocumentType;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating DocumentType: {ex.Message}");
                throw new Exception("An error occurred while creating the DocumentType.", ex);
            }
        }

        // Cập nhật tài liệu theo ID
        public Document UpdateDocument(int id, DocModel document)
        {
            var existingDocument = _context.Documents.Find(id);

            if (existingDocument == null)
            {
                return null; // Không tìm thấy tài liệu
            }

            // Cập nhật thông tin
            existingDocument.Title = document.Title;
            existingDocument.UploadedAt = document.UploadedAt;
            

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
