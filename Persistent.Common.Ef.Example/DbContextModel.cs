namespace Persistent.Common.Ef.Example
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;

    public partial class BlogDbContext : DbContext
    {
        public BlogDbContext()
            : base("name=ExampleDbConn")
        {
        }


        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<Post> Posts { get; set; }

    }

    [Table("Blog")]
    public partial class Blog
    {
        public Blog()
        {
            Posts = new HashSet<Post>();
        }

        public int BlogId { get; set; }

        [Required]
        public string Url { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }

    [Table("Post")]
    public partial class Post
    {
        public int PostId { get; set; }

        public int BlogId { get; set; }

        public string Content { get; set; }

        public string Title { get; set; }

        public virtual Blog Blog { get; set; }
    }
}
