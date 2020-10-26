using System;

namespace InterfacesChallenge.Domain {
    public class Article {
        private Guid id;

        public Article(string title) {
            Title = title;
            id = Guid.NewGuid();
            CreatedTime = DateTimeOffset.UtcNow;
        }
        
        public string Title { get; private set; }
        public DateTimeOffset CreatedTime { get; }
        
        /// <summary>
        ///     Represents the time at which this <see cref="Article"/>
        ///     is published. Null means the article has not yet been
        ///     published.
        /// </summary>
        public DateTimeOffset? PublishedTime { get; private set; }

        public void Publish() => PublishedTime = DateTimeOffset.UtcNow;
        public void Unpublish() => PublishedTime = null;
    }
}