using System;
using System.Collections.Generic;

namespace bmcdavid.BlogEngine.Core
{
    public class BlogArticle : IBlogArticle
    {
        public virtual string Body { get; set; }
        public virtual string CanonicalUrl { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual Guid Id { get; set; }
        public virtual BlogStatus Status { get; set; }
        public virtual string Summary { get; set; }
        public virtual ICollection<string> Tags { get; set; }
        public virtual string Title { get; set; }
    }
}