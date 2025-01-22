using Intern_Alta.Data;
using Intern_Alta.Models;

namespace Intern_Alta.Services.Documents
{
    public interface IDocumentService
    {
        // Lấy tất cả tài liệu
        List<Document> GetAllDocuments();

        // Lấy thông tin tài liệu theo ID
        Document GetDocumentById(int id);

        // Tạo mới một tài liệu
        Document CreateDocument(DocModel model);

        // Cập nhật tài liệu theo ID
        Document UpdateDocument(int id, DocModel document);

        // Xóa tài liệu theo ID
        bool DeleteDocument(int id);
    }
}