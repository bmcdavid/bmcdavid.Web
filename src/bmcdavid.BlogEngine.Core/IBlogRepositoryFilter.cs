namespace bmcdavid.BlogEngine.Core
{
    public interface IBlogRepositoryFilter
    {
        bool Filter(IBlogArticle blog);
    }
}