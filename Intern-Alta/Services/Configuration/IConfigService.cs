using Intern_Alta.Data;
using Intern_Alta.Models;
using System.Collections.Generic;

namespace Intern_Alta.Services.Configuration
{
    public interface IConfigService
    {
       
        List<ConfigDB> GetAllConfigurations();

        
        ConfigDB GetConfigurationById(int id);

       
        ConfigDB CreateConfiguration(ConfigModel model);

        
        ConfigDB UpdateConfiguration(int id, ConfigModel configuration);

      
        bool DeleteConfiguration(int id);
    }
}