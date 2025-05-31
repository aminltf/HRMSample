using HRM.Shared.Kernel.Constants;
using HRM.Shared.Kernel.Enums;

namespace HRM.Shared.Kernel.Extensions;

public static class RoleMapperExtensions
{
    public static string ToRoleName(this UserRole role)
    {
        return role switch
        {
            UserRole.Admin => Roles.Admin,
            UserRole.Manager => Roles.Manager,
            _ => throw new ArgumentOutOfRangeException(nameof(role), role, null)
        };
    }
}
