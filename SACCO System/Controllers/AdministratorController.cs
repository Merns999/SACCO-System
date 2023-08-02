using Microsoft.AspNetCore.Mvc;
using SACCO_System.Models;
using SACCO_System.Repository.Wrapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SACCO_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AdministratorController : ControllerBase
    {
        private readonly RepositoryWrapper repositoryWrapper;
        public AdministratorController(RepositoryWrapper repositoryWrapper) => this.repositoryWrapper = repositoryWrapper;

        // GET: api/<AdministratorController>
        [HttpGet, Route("api/GetAdmin")]
        public async Task<ActionResult<IEnumerable<Admin>>> Get()
        {
            try
            {
                var administrators = await repositoryWrapper.AdminRepository.GetAdmins();

                if (administrators == null || !administrators.Any())
                {
                    return NotFound("No administrators found.");
                }

                return Ok(administrators);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        // POST api/<AdministratorController>
        [HttpPost, Route("api/AddAdmin")]
        public async Task<ActionResult> Post([FromBody] Admin admin)
        {
            try
            {
                await repositoryWrapper.AdminRepository.AddAdministrator(admin);
                repositoryWrapper.Save();

                return CreatedAtAction(nameof(Get), new { id = admin.AdminId }, admin);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing your request.");

            }
        }

        // PUT api/<AdministratorController>/5
        [HttpPatch, Route("api/UpdateAdmin")]
        public async Task<ActionResult> Update([FromBody] Admin admin)
        {
            try
            {
                // Update the administrator in the repository asynchronously
                await repositoryWrapper.AdminRepository.UpdateAdministrator(admin);
                repositoryWrapper.Save(); // Save changes to the database

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        // DELETE api/<AdministratorController>/5
        [HttpDelete, Route("api/DeleteAdmin")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var administrator = await repositoryWrapper.AdminRepository.GetAdminById(id);
                if (administrator == null)
                {
                    return NotFound("Administrator not found.");
                }

                await repositoryWrapper.AdminRepository.RemoveAdministrator(administrator);
                repositoryWrapper.Save();

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}
