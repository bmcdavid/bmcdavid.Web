namespace bmcdavid.Web.Models.ViewModels
{
    public class SimpleWebPage : IWebPage
    {
        public string BrowserTitle { get; set; }

        public string PageTitle { get; set; }

        public string EnvironmentName { get; set; }

    }
}
