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
            var activatePost = Posts.First(g => g.PostId == p.PostId);
            activatePost.Activo = true;
            SaveChanges();
            return true;
        }

        public Post ActualizarPost(Post p)
        {
            // Busca el objeto dentro del entity framework y reemplaza los valores
            Set<Post>().Attach(p);
            // Cambia el estado del objeto en entity framework a modificado
            Entry(p).State = EntityState.Modified;
            // Guarda los cambios.
            SaveChanges();
            return p;
        }

        public bool DesactivarPost(Post p)
        {
            var activatePost = Posts.First(g => g.PostId == p.PostId);
            activatePost.Activo = false;
            SaveChanges();
            return true;
        }

        public Post GuardarPost(Post p)
        {
            Posts.Add(p);
            SaveChanges();
            return p;
        }

        public List<Post> LeerPost()
        {
            return Posts.ToList();
        }
    }
}