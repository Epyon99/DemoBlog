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
            return null;
        }

        [HttpPost]
        public ActionResult Update(Guid id, Post post)
        {
            return null;
        }


        //TODO: Desactivar
        [HttpGet]
        public ActionResult Desactivar(Guid id = default(Guid), string nombre = default(string))
        {
            return null;
        }

        [HttpGet]
        [ActionName("Desactivar")]
        public ActionResult DesactivarPost(Post post)
        {
            return null;
        }

        //TODO: Ver 1 Post
        [HttpGet]
        public ActionResult Detalle(Guid id = default(Guid), string nombre = default(string))
        {
            return null;
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
            return View(service.Leer().ToList());
        }

        //TODO: Paginas
        [HttpGet]
        public ActionResult Paginar(int pagina)
        {
            return null;
        }
    }
}