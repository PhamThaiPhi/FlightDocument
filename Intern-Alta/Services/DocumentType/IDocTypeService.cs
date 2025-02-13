using Intern_Alta.Data;
using Intern_Alta.Models;
using System.Collections.Generic;

namespace Intern_Alta.Services.DocumentTypes
{
    public interface IDocTypeService
    {

        List<DocumentType> GetAllDocumentTypes();

   
        DocumentType GetDocumentTypeById(int id);

 
        DocumentType CreateDocumentType(DocTypeModel model);


        DocumentType UpdateDocumentType(int id, DocTypeModel documentType);

        bool DeleteDocumentType(int id);
        
    }
}
