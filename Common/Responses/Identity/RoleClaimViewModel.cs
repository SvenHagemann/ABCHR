namespace Common.Responses.Identity;

public class RoleClaimViewModel
{
    public string RoleId { get; set; }
    public string ClaimType { get; set; } // permission
    public string ClaimValue { get; set; } // Permissions.Users.Create
    public string Description { get; set; }
    public string Group { get; set; } // SystemAccess oder ManagementHierarchy

    // Bezieht sich auf die Role-Eigenschaft im RoleClaimResponse.
    public bool IsAssignedToRole { get; set; }
}