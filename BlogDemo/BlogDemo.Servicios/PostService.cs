using BlogDemo.Library;
using BlogDemo.Servicios.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDemo.Servicios
{
    public class PostService
    {
        IPostDemoContext context;

        public PostService()
        {
            context = new PostsDemoContext();
        }

        public PostService(IPostDemoContext c)
        {
            context = c;
        }

        public Post Crear(Post post)
        {
            post.PostId = Guid.NewGuid();

            if (post.Autor == null || post.Titulo == null)
            {
                throw new Exception("Se necesita un Titulo y un Autor ");
            }
            post.FechaCreacion = DateTime.Now.ToShortDateString();
            post.FechaModificacion = DateTime.Now.ToShortDateString();
            post.Modificaciones = 1;

            try
            {
                post = context.GuardarPost(post);
            }
            catch (Exception)
            {
                throw;
            }

            return post;
        }

        public Post Update (Post post)
        {
            //var updatePost = context.Posts.FirstOrDefault(g => g.PostId == post.PostId);
            //updatePost.Copiar(post);

            //if (updatePost.Autor == null && post.Titulo == null)
            //{
            //    throw new Exception("Se necesita un Titulo y un Autor ");
            //}
            //updatePost.FechaModificacion = new DateTime().ToShortDateString();
            //updatePost.Modificaciones++;

            //try
            //{
            //    context.SaveChanges();
            //}
            //catch (Exception)
            //{
            //    throw;
            //}

            //return updatePost;
            return post;
        }

        public bool Desactivar (Post post)
        {
            //var updatePost = context.Posts.FirstOrDefault(g => g.PostId == post.PostId);
            //updatePost.Activo = false;
            //try
            //{
            //    context.SaveChanges();
            //}
            //catch (Exception)
            //{
            //    throw;
            //}
            return true;
        }

        public bool Activar (Post post)
        {
            //var updatePost = context.Posts.FirstOrDefault(g => g.PostId == post.PostId);
            //updatePost.Activo = true;
            //try
            //{
            //    context.SaveChanges();
            //}
            //catch (Exception)
            //{
            //    throw;
            //}
            return true;
        }

        public List<Post> Leer()
        {
            //return context.Posts.ToList();
            return null;
        }
    }
}
