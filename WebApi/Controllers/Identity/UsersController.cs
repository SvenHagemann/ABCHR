using Application.Features.Identity.Users.Commands;
using Application.Features.Identity.Users.Queries;
using Common.Authorization;
using Common.Requests.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Attributes;

namespace WebApi.Controllers.Identity;

[Route("api/[controller]")]
public class UsersController : MyBaseController<UsersController>
{
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> RegisterUser([FromBody] UserRegistrationRequest userRegistration)
    {
        var response = await MediatorSender.Send(new UserRegistrationCommand { UserRegistration = userRegistration });

        return response.IsSuccessful ? Ok(response) : BadRequest(response);
    }

    [HttpGet("{userId}")]
    [MustHavePermission(AppFeature.Users, AppAction.Read)]
    public async Task<IActionResult> GetUserById(string userId)
    {
        var response = await MediatorSender.Send(new GetUserByIdQuery { UserId = userId });

        return response.IsSuccessful ? Ok(response) : NotFound(response);
    }

    [HttpGet]
    [MustHavePermission(AppFeature.Users, AppAction.Read)]
    public async Task<IActionResult> GetAllUsers()
    {
        var response = await MediatorSender.Send(new GetAllUsersQuery());

        return response.IsSuccessful ? Ok(response) : NotFound(response);
    }

    [HttpPut]
    [MustHavePermission(AppFeature.Users, AppAction.Update)]
    public async Task<IActionResult> UpdateUserDetails([FromBody] UpdateUserRequest updateUser)
    {
        var response = await MediatorSender.Send(new UpdateUserCommand { UpdateUser = updateUser });

        return response.IsSuccessful ? Ok(response) : NotFound(response);
    }

    [HttpPut("change-password")]
    [AllowAnonymous]
    public async Task<IActionResult> ChangeUserPassword([FromBody] ChangePasswordRequest changePassword)
    {
        var response = await MediatorSender.Send(new ChangeUserPasswordCommand { ChangePassword = changePassword });

        return response.IsSuccessful ? Ok(response) : NotFound(response);
    }

    [HttpPut("change-status")]
    [MustHavePermission(AppFeature.Users, AppAction.Update)]
    public async Task<IActionResult> ChangeUserStatus([FromBody] ChangeUserStatusRequest changeUserStatus)
    {
        var response = await MediatorSender.Send(new ChangeUserStatusCommand { ChangeUserStatus = changeUserStatus });

        return response.IsSuccessful ? Ok(response) : NotFound(response);
    }

    [HttpGet("roles/{userId}")]
    [MustHavePermission(AppFeature.Roles, AppAction.Read)]
    public async Task<IActionResult> GetRoles(string userId)
    {
        var response = await MediatorSender.Send(new GetRolesQuery { UserId = userId });

        return response.IsSuccessful ? Ok(response) : NotFound(response);
    }

    [HttpPut("user-roles")]
    [MustHavePermission(AppFeature.Users, AppAction.Update)]
    public async Task<IActionResult> UpdateUserRoles([FromBody] UpdateUserRolesRequest updateUserRoles)
    {
        var response = await MediatorSender.Send(new UpdateUserRolesCommand { UpdateUserRoles = updateUserRoles });

        return response.IsSuccessful ? Ok(response) : BadRequest(response);
    }
}