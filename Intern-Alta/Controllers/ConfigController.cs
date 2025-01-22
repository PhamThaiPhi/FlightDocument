using Intern_Alta.Data;
using Intern_Alta.Models;
using Intern_Alta.Services.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Intern_Alta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigController : ControllerBase
    {
        private readonly IConfigService _configService;

        public ConfigController(IConfigService configService)
        {
            _configService = configService;
        }

        [HttpGet]
        public IActionResult GetAllConfigurations()
        {
            var configurations = _configService.GetAllConfigurations();
            return Ok(configurations);
        }

        [HttpGet("{id}")]
        public IActionResult GetConfigurationById(int id)
        {
            var configuration = _configService.GetConfigurationById(id);
            if (configuration == null)
            {
                return NotFound();
            }
            return Ok(configuration);
        }

        [HttpPost]
        public IActionResult CreateConfiguration([FromBody] ConfigModel model)
        {
            try
            {
                var newConfiguration = _configService.CreateConfiguration(model);
                return CreatedAtAction(nameof(GetConfigurationById), new { id = newConfiguration.ConfigID }, newConfiguration);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error creating configuration: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateConfiguration(int id, [FromBody] ConfigModel configuration)
        {
            try
            {
                var updatedConfiguration = _configService.UpdateConfiguration(id, configuration);
                return Ok(updatedConfiguration);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating configuration: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteConfiguration(int id)
        {
            try
            {
                var result = _configService.DeleteConfiguration(id);
                if (result)
                {
                    return NoContent();
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error deleting configuration: {ex.Message}");
            }
        }
    }
}