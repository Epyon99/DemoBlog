using BlogDemo.Library;
using BlogDemo.Servicios.Contexts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            var updatePost = context.LeerPost().FirstOrDefault(g => g.PostId == post.PostId);
            updatePost.Copiar(post);

            if (updatePost.Autor == null && post.Titulo == null)
            {
                throw new Exception("Se necesita un Titulo y un Autor ");
            }
            updatePost.FechaModificacion = new DateTime().ToShortDateString();
            updatePost.Modificaciones++;

            try
            {
                context.ActualizarPost(updatePost);
            }
            catch (Exception)
            {
                throw;
            }

            return updatePost;
        }

        public bool Desactivar (Post post)
        {
            var postToDelete = context.LeerPost().FirstOrDefault(g => g.PostId == post.PostId);
            postToDelete.Activo = false;
            try
            {
                context.DesactivarPost(postToDelete);
            }
            catch (Exception ex)
            {
                // Log the exception somewhere
                Trace.WriteLine(ex.Message + ex.StackTrace);
                return false;
            }
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
            return context.LeerPost();
        }

        public List<Post> Paginar(int pagina, int numeroElementoPorPagina)
        {
            var objetos = context.LeerPost();
            objetos = objetos.Skip(pagina-1 * numeroElementoPorPagina).ToList();
            return objetos.Take(numeroElementoPorPagina).ToList();
        }
    }
}
