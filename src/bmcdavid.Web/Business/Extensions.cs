namespace Microsoft.AspNetCore.Http.Extensions
{
    public static class CustomExtensions
    {
        public static string GetRawUrl(this HttpContext httpContext)
        {
            return httpContext.Features.Get<Features.IHttpRequestFeature>().RawTarget;
        }
    }
}
