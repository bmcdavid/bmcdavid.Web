namespace bmcdavid.Web.Models
{
    public interface IWebPage
    {
        string BrowserTitle { get; }

        string PageTitle { get; }

        string EnvironmentName { get; set; }
    }
}
