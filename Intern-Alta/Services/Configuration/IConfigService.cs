using Intern_Alta.Data;
using Intern_Alta.Models;
using System.Collections.Generic;

namespace Intern_Alta.Services.Configuration
{
    public interface IConfigService
    {
        // Lấy danh sách tất cả cấu hình
        List<ConfigDB> GetAllConfigurations();

        // Lấy thông tin cấu hình theo ID
        ConfigDB GetConfigurationById(int id);

        // Tạo mới một cấu hình
        ConfigDB CreateConfiguration(ConfigModel model);

        // Cập nhật thông tin cấu hình
        ConfigDB UpdateConfiguration(int id, ConfigModel configuration);

        // Xóa cấu hình theo ID
        bool DeleteConfiguration(int id);
    }
}