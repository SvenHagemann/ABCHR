using Common.Authorization;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Attributes;

public class MustHavePermissionAttribute : AuthorizeAttribute
{
    public MustHavePermissionAttribute(string feature, string action)
    {
        // Weist der abgeleitete Eigenschaft "Policy" den Sting: "Permissions.{feature}.{action}" zu.
        Policy = AppPermission.NameFor(feature, action);
    }
}