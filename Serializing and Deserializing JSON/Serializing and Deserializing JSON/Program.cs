using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Serializing_and_Deserializing_JSON
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Creating Blog
            List<Blog> blogs = new List<Blog>();

            for (int i = 0; i< 5; i++)
            {
                var myBlog = new Blog()
                {
                    Title = $"Title {i}",
                    Body = $"Body {i}",
                    Author = $"Author {i}",
                    IsPublic = true,
                    PublishDate = DateTime.Now,
                };

                blogs.Add(myBlog);

            }

            //Serializing blog - converting the state of an object into a form (string, byte array, or stream) that can be persisted or transported. 

            var myBlogJson = JsonConvert.SerializeObject(blogs);
            Console.WriteLine(myBlogJson);

            //Deserializing blog - converting the serialized stream of data into the original object state
            //JsonConvert.DeserializeObject<Type>(source)
            //Since there is list of objects , type will be List<Blog>
            var myBlogObj = JsonConvert.DeserializeObject<List<Blog>>(myBlogJson);

            foreach (var item in myBlogObj)
            {
                Console.WriteLine(item.Title);
            }
            //Console.WriteLine(myBlogObj.Count);
            Console.ReadKey();

        }
    }
    public class Blog
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string Author { get; set; }
        public bool IsPublic { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
