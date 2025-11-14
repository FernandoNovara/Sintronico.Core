using Application.Mappers;
using Domain.Enums;

namespace Sintronico.Api.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Gets a paginated list of users optionally filtered by role.
        /// </summary>
        [HttpGet]
        [Route("User")]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUsers([FromQuery] int page = 1,
                                                 [FromQuery] int size = 10,
                                                 [FromQuery] UserRole? role = null)
        {
            try
            {
                var result = await _userService.GetPagedAsync(page, size, role);

                return Ok(result);
            }
            catch (InfrastructureException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error was detected while executing the service.Error:" + ex.Message);
            }
        }

        /// <summary>
        /// Gets a single user by its unique identifier.
        /// </summary>
        [HttpGet]
        [Route("User/{UserId:Guid}")]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUser([FromRoute, Required] Guid UserId)
        {
            try
            {
                var result = await _userService.GetByIdAsync(UserId);

                return Ok(result);
            }
            catch (InfrastructureException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error was detected while executing the service.Error:" + ex.Message);
            }
        }

        /// <summary>
        /// Creates a new user.
        /// </summary>
        [HttpPost]
        [Route("User")]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddUser([FromBody] UserDto entity)
        {
            try
            {
                var result = await _userService.CreateAsync(UserMapper.ToDomain(entity));

                return Ok(result);
            }
            catch (InfrastructureException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error was detected while executing the service.Error:" + ex.Message);
            }
        }


        /// <summary>
        /// Authenticates a user with credentials.
        /// </summary>
        [HttpPost]
        [Route("Login")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUsers([FromQuery] string user,
                                                 [FromQuery] string password)
        {
            try
            {
                var result = await _userService.Login(user, password);

                return Ok(result);
            }
            catch (InfrastructureException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error was detected while executing the service.Error:" + ex.Message);
            }
        }

        /// <summary>
        /// Changes a user's password.
        /// </summary>
        [HttpPost]
        [Route("ChangePassword")]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ChangePassword([FromQuery] Guid UserId, [FromQuery] string NewPassword)
        {
            try
            {
                var result = await _userService.ChangePassword(UserId, NewPassword);

                return Ok(result);
            }
            catch (InfrastructureException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error was detected while executing the service.Error:" + ex.Message);
            }
        }

        /// <summary>
        /// Updates an existing user.
        /// </summary>
        [HttpPut]
        [Route("User")]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateUser([FromBody] UserDto entity)
        {
            try
            {
                var result = await _userService.UpdateAsync(UserMapper.ToDomain(entity));

                return Ok(result);
            }
            catch (InfrastructureException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error was detected while executing the service.Error:" + ex.Message);
            }
        }

        /// <summary>
        /// Deletes a user by its unique identifier.
        /// </summary>
        [HttpDelete]
        [Route("User")]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteUser([FromQuery] Guid UserId)
        {
            try
            {
                var result = await _userService.DeleteAsync(UserId);

                return Ok(result);
            }
            catch (InfrastructureException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error was detected while executing the service.Error:" + ex.Message);
            }
        }

    }
}
