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
