using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace ToDolistTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new NewsContext())
            {
                Console.Write("输入新闻类型标题: ");
                var name = Console.ReadLine();

                var type_Model = new NewType { Name = name };
                db.NewTypes.Add(type_Model);
                db.SaveChanges();

                Console.WriteLine("查询新闻类型标题:");
                var search_type = Console.ReadLine();
                var query = from b in db.NewTypes
                            where b.Name == search_type
                            select b;

                Console.WriteLine("查询结果:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.Name);
                }

                Console.ReadKey();
            }
        }
    }

    public class New
    {
        [Key]
        public int NewId { get; set; }

        [MaxLength(100)]
        public string Title { get; set; }

        public int NewTypeId { get; set; }
        public virtual NewType NewType { get; set; }
    }

    public class NewType
    {
        [Key]
        public int NewTypeId { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        public int BlogId { get; set; }
        public virtual List<New> New { get; set; }
    }

    public class NewsContext : DbContext
    {
        public DbSet<New> News { get; set; }
        public DbSet<NewType> NewTypes { get; set; }
    }
}
