namespace bmcdavid.Web.Models.ViewModels
{
    public class ErrorViewModel : IWebPage
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public string BrowserTitle => "Error";

        public string PageTitle => "Error";

        public string EnvironmentName { get; set; }

    }
}