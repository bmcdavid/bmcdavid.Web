namespace bmcdavid.BlogEngine.FileRepository
{
    public interface IBlogSourceFileStore
    {
        string BlogsBodySourceFolder { get; }

        string GetBlogBody(IBlogArticleWithBodyFile blogArticle, string physicalPath);
    }
}
