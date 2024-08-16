using AllEars.Server.Entities;
using AllEars.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace AllEars.Server.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class AdminController : ControllerBase
        {
            private readonly IAdminService _adminService;

            public AdminController(IAdminService adminService)
            {
                _adminService = adminService;
            }

            [HttpGet("get")]
            public async Task<IActionResult> GetAllAdmin()
            {
                List<Admin> admins = await _adminService.GetAllAdmin();
                return Ok(admins);
            }

        [HttpGet("getid")]
        public async Task<IActionResult> GetAdminById(int adminId)
        {
            Admin admins = await _adminService.GetAdminById(adminId);
            return Ok(admins);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAdmin(Admin admin) 
        {
            return Ok(await _adminService.CreateAdmin(admin));
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateAdmin(int id, [FromBody] Admin admin)
        {
            var result = await _adminService.UpdateAdmin(id,admin);
            if (result)
            {
                return Ok(new { message = "Admin updated successfully." });
            }
            return BadRequest(new { message = "Failed to update admin." });
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteAdmin(int id)
        {
            var result = await _adminService.DeleteAdmin(id);
            if (result)
            {
                return Ok(new { message = "Admin deleted successfully." });
            }
            return NotFound(new { message = "Admin not found." });
        }
    }
}

