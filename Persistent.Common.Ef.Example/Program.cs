using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistent.Common.Ef.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            OldSchoolExample();
            TestableRepositoryReadSideR();
            TestableRepositoryReadSideCUD();

        }

        private static void TestableRepositoryReadSideCUD()
        {
            Console.WriteLine("---TestableRepositoryReadSideCUD");
            using (IDbContext context = new BlogDbContext())
            {
                context.Insert<Blog>(new Blog { Url = "blog.hede.com" });
                context.SaveChanges();
            }
            TestableRepositoryReadSideR();
        }

        private static void TestableRepositoryReadSideR()
        {
            Console.WriteLine("---TestableRepositoryReadSideR");
            using (IDbContext context = new BlogDbContext())
            {
                IRepository<Blog> blogRepo = new Repository<Blog>(context);
                blogRepo.Fetch()
                    .ToList()
                    .ForEach(p => Console.WriteLine(p.Url));
            }
        }

        private static void OldSchoolExample()
        {
            using (BlogDbContext context = new BlogDbContext())
            {
                context.Set<Blog>().ToList().ForEach(p => Console.WriteLine(p.Url));
            }
        }
    }
}
