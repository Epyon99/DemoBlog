using BlogDemo.Library;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BlogDemo.Servicios.Contexts
{
    public class PostsDemoContext : DbContext, IPostDemoContext
    {
        public DbSet<Post> Posts { get; set; }

        public DbSet<Menu> Menues { get; set; }

        public DbSet<Link> Links { get; set; }

        public bool ActivarPost(Post p)
        {
            throw new NotImplementedException();
        }

        public Post ActualizarPost(Post p)
        {
            throw new NotImplementedException();
        }

        public bool DesactivarPost(Post p)
        {
            throw new NotImplementedException();
        }

        public Post GuardarPost(Post p)
        {
            Posts.Add(p);
            SaveChanges();
            return p;
        }

        public List<Post> LeerPost()
        {
            throw new NotImplementedException();
        }
    }
}