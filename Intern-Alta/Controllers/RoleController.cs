using Intern_Alta.Models;
using Intern_Alta.Services.Roles;
using Microsoft.AspNetCore.Mvc;

namespace Intern_Alta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public IActionResult GetRoles()
        {
            var roles = _roleService.GetRoles();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public IActionResult GetRoleById(int id)
        {
            var role = _roleService.GetRoleByID(id);
            if (role == null)
            {
                return NotFound("Role not found.");
            }
            return Ok(role);
        }

        [HttpPost]
        public IActionResult CreateRole([FromBody] RoleModel model)
        {
            if (model == null)
            {
                return BadRequest("Invalid role data.");
            }
            var newRole = _roleService.CreateRole(model);
            return CreatedAtAction(nameof(GetRoleById), new { id = newRole.RoleID }, newRole);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateRole(int id, [FromBody] RoleModel model)
        {
            if (model == null)
            {
                return BadRequest("Invalid role data.");
            }
            var updatedRole = _roleService.UpdateRole(id, model);
            return Ok(updatedRole);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRole(int id)
        {
            bool result = _roleService.DeleteRole(id);
            if (!result)
            {
                return NotFound("Role not found.");
            }
            return NoContent();
        }
    }
}
