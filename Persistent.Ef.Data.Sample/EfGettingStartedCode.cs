using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Persistent.Ef.Data.Sample
{
    public partial class Post
    {
        public int PostId { get; set; }
        public int BlogId { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
        public virtual Blog Blog { get; set; }
    }

    public partial class Blog
    {
        public Blog()
        {
            Post = new HashSet<Post>();
        }

        public int BlogId { get; set; }
        public string Url { get; set; }

        public virtual ICollection<Post> Post { get; set; }
    }

    public partial class BloggingContext : DbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    options.UseSqlServer(@"Server=.;Database=Blogging;Trusted_Connection=True;");
        //}

        public IQueryable<TEntity> Queryable<TEntity>() where TEntity : class
        {
            return this.Set<TEntity>();
        }

        public virtual DbSet<Blog> Blog { get; set; }
        public virtual DbSet<Post> Post { get; set; }
    }
}
