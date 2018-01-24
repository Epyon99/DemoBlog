using BlogDemo.Library;
using BlogDemo.Servicios.Contexts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDemo.Tests
{
    [TestClass]
    public class PostsDemoContextTest
    {
        [TestMethod]
        public void PostsDemoContext_GuardarPost_Test_Sucess()
        {
            // Arrange
            Post p = new Post() { PostId = Guid.NewGuid() };
            PostsDemoContext postContext = new PostsDemoContext();

            // Act
            var resultado = postContext.GuardarPost(p);

            // Assert
            var guardado = postContext.Posts.FirstOrDefault(g => g.PostId == p.PostId);
            Assert.IsNotNull(guardado);
        }

        [TestMethod]
        public void PostsDemoContext_ActualizarPost_Test_Sucess()
        {
            // Arrange
            Post p = new Post() { PostId = Guid.NewGuid() };
            PostsDemoContext postContext = new PostsDemoContext();
            // Crear un elemento a modificar
            postContext.GuardarPost(p);

            // Datos a modificar
            p.Autor = "Moises";
            p.Titulo = "Clase de Unit Testing";

            // Act
            var resultado = postContext.ActualizarPost(p);

            // Assert
            var actualizacion = postContext.Posts.FirstOrDefault(g => g.PostId == p.PostId);
            Assert.AreEqual(actualizacion.Autor, resultado.Autor);
        }

        [TestMethod]
        public void PostsDemoContext_LeerPost_Test_Sucess()
        {
            // Arrange
            List<Post> posts = new List<Post>()
            {
                new Post{ PostId = Guid.NewGuid() },
                new Post{ PostId = Guid.NewGuid() },
                new Post{ PostId = Guid.NewGuid() },
                new Post{ PostId = Guid.NewGuid() },
                new Post{ PostId = Guid.NewGuid() }
            };
            PostsDemoContext postContext = new PostsDemoContext();
            postContext.Posts.AddRange(posts);
            postContext.SaveChanges();

            // Act
            var resultados = postContext.LeerPost();

            // Assert
            Assert.IsNotNull(resultados.Count);
        }

        [TestMethod]
        public void PostsDemoContext_ActivarPost_Test_Sucess()
        {
            // Arrange
            Post p = new Post() { PostId = Guid.NewGuid(), Activo = false };
            PostsDemoContext postContext = new PostsDemoContext();
            // Crear un elemento a activar
            postContext.GuardarPost(p);

            // Act
            var resultado = postContext.ActivarPost(p);

            // Assert
            var activePost = postContext.Posts.FirstOrDefault(g => g.PostId == p.PostId);
            Assert.AreNotEqual(activePost.Activo, false);
        }

        [TestMethod]
        public void PostsDemoContext_DesactivarPost_Test_Sucess()
        {
            // Arrange
            Post p = new Post() { PostId = Guid.NewGuid(), Activo = true };
            PostsDemoContext postContext = new PostsDemoContext();
            // Crear un elemento a activar
            postContext.GuardarPost(p);

            // Act
            var resultado = postContext.DesactivarPost(p);

            // Assert
            var activePost = postContext.Posts.FirstOrDefault(g => g.PostId == p.PostId);
            Assert.AreNotEqual(activePost.Activo, true);
        }
    }
}
