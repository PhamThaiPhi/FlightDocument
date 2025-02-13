using System;
using System.Collections.Generic;
using System.Linq;
using Intern_Alta.Data;
using Intern_Alta.Models;
using Intern_Alta.Services.DocumentTypes;

namespace Intern_Alta.Services
{
    public class DocTypeService : IDocTypeService
    {
        private readonly MyDbContext _context;

        public DocTypeService(MyDbContext context)
        {
            _context = context;
        }

        
        public List<DocumentType> GetAllDocumentTypes()
        {
            return _context.DocumentTypes.ToList();
        }

     
        public DocumentType GetDocumentTypeById(int id)
        {
            var documentType = _context.DocumentTypes.FirstOrDefault(dt => dt.DocumentTypeID == id);
            if (documentType == null)
            {
                throw new KeyNotFoundException($"DocumentType with ID {id} was not found.");
            }

            return documentType;
        }

    
        public DocumentType CreateDocumentType(DocTypeModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "Model cannot be null.");
            }

            try
            {
                var newDocumentType = new DocumentType
                {
                    TypeName = model.TypeName
                };

                _context.DocumentTypes.Add(newDocumentType);
                _context.SaveChanges();

                return newDocumentType;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating DocumentType: {ex.Message}");
                throw new Exception("An error occurred while creating the DocumentType.", ex);
            }
        }




        public DocumentType UpdateDocumentType(int id, DocTypeModel documentType)
        {
            var existingType = _context.DocumentTypes.FirstOrDefault(dt => dt.DocumentTypeID == id);
            if (existingType == null)
            {
                throw new KeyNotFoundException($"DocumentType with ID {id} was not found.");
            }

            if (documentType == null)
            {
                throw new ArgumentNullException(nameof(documentType), "DocumentType cannot be null.");
            }

            existingType.TypeName = documentType.TypeName;
            

            _context.SaveChanges();
            return existingType;
        }

        
        public bool DeleteDocumentType(int id)
        {
            var documentType = _context.DocumentTypes.FirstOrDefault(dt => dt.DocumentTypeID == id);
            if (documentType == null)
            {
                throw new KeyNotFoundException($"DocumentType with ID {id} was not found.");
            }

            _context.DocumentTypes.Remove(documentType);
            _context.SaveChanges();
            return true;
        }

       
        
    }
}
