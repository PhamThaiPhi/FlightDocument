﻿using Intern_Alta.Data;
using Intern_Alta.Models;
using System.Collections.Generic;

namespace Intern_Alta.Services.DocumentTypes
{
    public interface IDocTypeService
    {
        // Lấy danh sách tất cả DocumentType
        List<DocumentType> GetAllDocumentTypes();

        // Lấy thông tin DocumentType theo ID
        DocumentType GetDocumentTypeById(int id);

        // Tạo mới một DocumentType
        DocumentType CreateDocumentType(DocTypeModel model);


        // Cập nhật thông tin một DocumentType
        DocumentType UpdateDocumentType(int id, DocTypeModel documentType);

        // Xóa một DocumentType theo ID
        bool DeleteDocumentType(int id);
        
    }
}
