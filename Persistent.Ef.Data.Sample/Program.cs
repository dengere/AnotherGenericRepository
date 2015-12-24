using Persistent.Ef.Common;
using System;
using System.Linq;

namespace Persistent.Ef.Data.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            //FetchSample();
            InsertSample();

        }

        private static void InsertSample()
        {
            using (BloggingContext context = new BloggingContext())
            {
            }
        }

        private static void FetchSample()
        {
            using (BloggingContext context = new BloggingContext())
            {
                IRepository<Blog> blogRepo = new Repository<Blog>(context);
                Console.WriteLine("***");
                blogRepo.Fetch(p => true).ToList().ForEach(p => Console.WriteLine(p.Url));
                Console.WriteLine("***");
                blogRepo.Fetch(pre => pre.BlogId > 1,
                               sort => sort.Asc(a => a.Url, b => b.BlogId))
                        .ToList().ForEach(p => Console.WriteLine(p.Url));
                Console.WriteLine("***");
                blogRepo.Fetch(pre => pre.BlogId > 1,
                               sort => sort.Desc(a => a.Url).Asc(d => d.BlogId))
                        .ToList().ForEach(p => Console.WriteLine(p.Url));
            }
        }
    }
}
