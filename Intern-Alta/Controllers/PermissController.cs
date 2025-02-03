using Intern_Alta.Models;
using Intern_Alta.Services.Permissions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Intern_Alta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionService _permissionService;

        public PermissionController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        [HttpGet]
        public IActionResult GetAllPermissions()
        {
            var permissions = _permissionService.GetAllPermissions();
            return Ok(permissions);
        }

        [HttpGet("{id}")]
        public IActionResult GetPermissionById(int id)
        {
            var permission = _permissionService.GetPermissionById(id);
            if (permission == null)
            {
                return NotFound();
            }
            return Ok(permission);
        }

        [HttpPost]
        public IActionResult CreatePermission([FromBody] PerModel model)
        {
            try
            {
                var newPermission = _permissionService.CreatePermission(model);
                return CreatedAtAction(nameof(GetPermissionById), new { id = newPermission.PermissionID }, newPermission);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error creating permission: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePermission(int id, [FromBody] PerModel permission)
        {
            try
            {
                var updatedPermission = _permissionService.UpdatePermission(id, permission);
                return Ok(updatedPermission);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating permission: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePermission(int id)
        {
            try
            {
                var result = _permissionService.DeletePermission(id);
                if (result)
                {
                    return NoContent();
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error deleting permission: {ex.Message}");
            }
        }
    }
}