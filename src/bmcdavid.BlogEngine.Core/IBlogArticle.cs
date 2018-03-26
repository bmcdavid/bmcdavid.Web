using System;
using System.Collections.Generic;

namespace bmcdavid.BlogEngine.Core
{
    public interface IBlogArticle
    {
        Guid Id { get; }

        string CanonicalUrl { get; }

        string Title { get; }

        ICollection<string> Tags { get; }

        DateTime Date { get; }

        BlogStatus Status { get; }

        string Body { get; }

        string Summary { get; }
    }
}