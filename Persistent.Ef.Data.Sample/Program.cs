using Persistent.Ef.Common;
using System;
using System.Linq;

namespace Persistent.Ef.Data.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            using (BloggingContext context = new BloggingContext())
            {
                IRepository<Blog> blogRepo = new Repository<Blog>(context);
                blogRepo.Fetch(p => true).ToList().ForEach(p => Console.WriteLine(p.Url));
            }
        }
    }
}
