using HRM.Infrastructure.Identity.Seeds;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace HRM.Infrastructure.Identity.Extensions;

public static class IdentityAppBuilderExtensions
{
    public static async Task UseIdentitySeederAsync(this IApplicationBuilder app)
    {
        if (app == null) throw new ArgumentNullException(nameof(app));

        using var scope = app.ApplicationServices.CreateScope();
        var services = scope.ServiceProvider;

        await IdentityDbInitializer.SeedAsync(services);
    }
}
