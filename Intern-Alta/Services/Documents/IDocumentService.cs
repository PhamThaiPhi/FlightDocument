using Intern_Alta.Data;

namespace Intern_Alta.Services.Documents
{
    public interface IDocumentService
    {
        // Lấy tất cả tài liệu
        List<Document> GetAllDocuments();

        // Lấy thông tin tài liệu theo ID
        Document GetDocumentById(int id);

        // Tạo mới một tài liệu
        Document CreateDocument(Document document);

        // Cập nhật tài liệu theo ID
        Document UpdateDocument(int id, Document document);

        // Xóa tài liệu theo ID
        bool DeleteDocument(int id);
    }
}