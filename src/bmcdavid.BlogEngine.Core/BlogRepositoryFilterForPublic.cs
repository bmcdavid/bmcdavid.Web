namespace bmcdavid.BlogEngine.Core
{
    public class BlogRepositoryFilterForPublic : IBlogRepositoryFilter
    {
        /// <summary>
        /// Filters by null, NotFound and NotPublished status
        /// </summary>
        /// <param name="blog"></param>
        /// <returns></returns>
        public virtual bool Filter(IBlogArticle blog)
        {
            var isPublic = blog != null &&
                (
                    blog.Status == BlogStatus.Archived ||
                    blog.Status == BlogStatus.Published
                );

            return isPublic;
        }
    }
}