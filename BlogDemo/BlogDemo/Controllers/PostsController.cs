using BlogDemo.Library;
using BlogDemo.Models;
using BlogDemo.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogDemo.Controllers
{
    public class PostsController : Controller
    {
        PostService service;

        public PostsController()
        {
            service = new PostService();
        }

        //TODO: Agregar
        [HttpGet]
        public ActionResult Crear()
        {
            // TODO: Autorizacion
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(PostCreateView postCreateView)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var post = new Post()
                    {
                        //Autor = User.Identity.Name,
                        Autor = "Moises",
                        Texto = postCreateView.Texto,
                        Titulo = postCreateView.Titulo,
                        PostType = postCreateView.Tipo
                    };
                    var resultado = service.Crear(post);
                    ViewBag.PostCreated = resultado;
                    var mensaje = $"El post '{resultado.Titulo}' se creo correctamente";
                    return RedirectToAction("VerTodos",new { mensaje = mensaje });
                }
                catch (Exception exception)
                {
                    return View("Error", exception);
                }
            }
            return View(postCreateView);

        }

        //TODO: Modificar
        [HttpGet]
        public ActionResult Update(Guid id)
        {
            var post = service.Leer().First(g => g.PostId == id);
            var puv = new PostUpdateView()
            {
                Id = post.PostId,
                Texto = post.Texto,
                Tipo = post.PostType,
                Titulo = post.Titulo
            };
            return View(puv);
        }

        [HttpPost]
        public ActionResult Update(Guid id, PostUpdateView post)
        {
            if (ModelState.IsValid)
            {
                Post postForService = new Post()
                {
                    PostId = post.Id,
                    Titulo = post.Titulo,
                    Texto = post.Texto,
                    PostType = post.Tipo
                };
                service.Update(postForService);
            }
            return View(post);
        }


        //TODO: Desactivar
        [HttpGet]
        public ActionResult Desactivar(Guid id = default(Guid), string nombre = default(string))
        {
            var post = service.Leer().FirstOrDefault(g => g.PostId == id || g.Titulo == nombre);
            PostDeactiveView pdv = new PostDeactiveView()
            {
                Id = post.PostId,
                Message = $"Desea desactivar este Post: {post.Titulo} del autor: {post.Autor}"
            };
            return View(pdv);
        }

        [HttpPost]
        [ActionName("Desactivar")]
        public ActionResult DesactivarPost(PostDeactiveView post)
        {
            if (post.Id != null)
            {
                Post p = new Post { PostId = post.Id };
                service.Desactivar(p);
            }
            return RedirectToAction("VerTodos");
        }

        //TODO: Ver 1 Post
        [HttpGet]
        public ActionResult Detalle(Guid id = default(Guid), string nombre = default(string))
        {
            var post = service.Leer().FirstOrDefault(g => g.PostId == id || g.Titulo == nombre);
            PostReadView prv = new PostReadView()
            {
                Id = post.PostId,
                Autor = post.Autor,
                Actualizacion = post.FechaModificacion != null ? post.FechaModificacion : post.FechaCreacion,
                Texto = post.Texto,
                Tipo = post.PostType,
                Titulo = post.Titulo
            };
            return View(prv);
        }

        //TODO: Buscar
        [HttpGet]
        public ActionResult Buscar(string nombre)
        {
            if (ViewBag.PostCreated != null)
            {
                ViewBag.Message = $"El post '{(ViewBag.PostCreated as Post).Titulo}' se creo correctamente";
            }

            // TODO: Retornar una coleccion Posts
            return View();
        }

        //TODO: Ver Todos
        [HttpGet]
        public ActionResult VerTodos(string mensaje = default(string))
        {
            if (mensaje != string.Empty)
            {
                ViewBag.Message = mensaje;
            }

            // TODO: Retornar una coleccion Posts
            return View(service.Leer().Where(g=>g.Activo).ToList());
        }

        //TODO: Paginas
        [HttpGet]
        public ActionResult Paginar(int pagina)
        {
            return null;
        }
    }
}