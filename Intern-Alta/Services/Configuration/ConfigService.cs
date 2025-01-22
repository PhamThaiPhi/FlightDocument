using Intern_Alta.Data;
using Intern_Alta.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intern_Alta.Services.Configuration
{
    public class ConfigService : IConfigService
    {
        private readonly MyDbContext _context;

        public ConfigService(MyDbContext context)
        {
            _context = context;
        }

        public List<ConfigDB> GetAllConfigurations()
        {
            return _context.Configurations
                .Select(d => new ConfigDB
                {
                    ConfigID = d.ConfigID,
                    ConfigName = d.ConfigName,
                    ConfigValue = d.ConfigValue,
                    PermissionID = d.PermissionID,
                    Permission = d.Permission,
                    DocumentTypeID = d.DocumentTypeID,
                    DocumentType = d.DocumentType // Bao gồm cả DocumentType
                })
                .ToList();
        }

        public ConfigDB GetConfigurationById(int id)
        {
            return _context.Configurations.FirstOrDefault(c => c.ConfigID == id);
        }

        public ConfigDB CreateConfiguration(ConfigModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "Model cannot be null.");
            }

            try
            {
                var newDocumentType = new ConfigDB
                {
                    ConfigName = model.ConfigName,
                    ConfigValue = model.ConfigValue,
                    DocumentTypeID = model.DocumentTypeID,
                    PermissionID = model.PermissionID,
                };

                _context.Configurations.Add(newDocumentType);
                _context.SaveChanges();

                return newDocumentType;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating DocumentType: {ex.Message}");
                throw new Exception("An error occurred while creating the DocumentType.", ex);
            }
        }

        public ConfigDB UpdateConfiguration(int id, ConfigModel configuration)
        {
            var existingConfiguration = _context.Configurations.Find(id);

            if (existingConfiguration == null)
            {
                throw new Exception("Configuration not found");
            }

            existingConfiguration.ConfigName = configuration.ConfigName;
            existingConfiguration.ConfigValue = configuration.ConfigValue;
            existingConfiguration.DocumentTypeID = configuration.DocumentTypeID;
            existingConfiguration.PermissionID = configuration.PermissionID;

            _context.SaveChanges();

            return existingConfiguration;
        }

        public bool DeleteConfiguration(int id)
        {
            var configurationToDelete = _context.Configurations.Find(id);

            if (configurationToDelete == null)
            {
                throw new Exception("Configuration not found");
            }

            _context.Configurations.Remove(configurationToDelete);
            _context.SaveChanges();

            return true;
        }
    }
}