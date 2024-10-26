using Microsoft.AspNetCore.Http;
using Microsoft.FeatureManagement;

namespace Vito.Framework.Api.Filters;

public abstract class FeatureFlagFilter(IFeatureManager FeatureManager) : IEndpointFilter
{
    protected abstract string FeatureFlag { get; }
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var isEnabled = await FeatureManager.IsEnabledAsync(FeatureFlag);
        if (!isEnabled)
        {
            return TypedResults.NotFound();
        }
        return await next(context);
    }
}