using Intern_Alta.Data;
using Intern_Alta.Models;

namespace Intern_Alta.Services.Documents
{
    public interface IDocumentService
    {
     
        List<Document> GetAllDocuments();

       
        Document GetDocumentById(int id);

    
        Document CreateDocument(DocModel model);

    
        Document UpdateDocument(int id, DocModel document);


        bool DeleteDocument(int id);
    }
}