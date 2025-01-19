using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Intern_Alta.Data;
using Intern_Alta.Services.DocumentTypes;
using Microsoft.EntityFrameworkCore;

namespace Intern_Alta.Services
{
    public class DocTypeService : IDocTypeService
    {
        private readonly MyDbContext _context;

        public DocTypeService(MyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DocumentType>> GetAllAsync()
        {
            return await _context.DocumentTypes.ToListAsync();
        }

        public async Task<DocumentType> GetByIdAsync(int id)
        {
            return await _context.DocumentTypes.FindAsync(id);
        }

        public async Task<DocumentType> CreateAsync(DocumentType documentType)
        {
            _context.DocumentTypes.Add(documentType);
            await _context.SaveChangesAsync();
            return documentType;
        }

        public async Task<DocumentType> UpdateAsync(DocumentType documentType)
        {
            var existingType = await _context.DocumentTypes.FindAsync(documentType.DocumentTypeID);
            if (existingType == null)
            {
                return null;
            }

            existingType.TypeName = documentType.TypeName;
            await _context.SaveChangesAsync();
            return existingType;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var documentType = await _context.DocumentTypes.FindAsync(id);
            if (documentType == null)
            {
                return false;
            }

            _context.DocumentTypes.Remove(documentType);
            await _context.SaveChangesAsync();
            return true;
        }

        public List<DocumentType> GetAllDocumentTypes()
        {
            throw new NotImplementedException();
        }

        public DocumentType GetDocumentTypeById(int id)
        {
            throw new NotImplementedException();
        }

        public DocumentType CreateDocumentType(DocumentType documentType)
        {
            throw new NotImplementedException();
        }

        public DocumentType UpdateDocumentType(int id, DocumentType documentType)
        {
            throw new NotImplementedException();
        }

        public bool DeleteDocumentType(int id)
        {
            throw new NotImplementedException();
        }
    }
}
