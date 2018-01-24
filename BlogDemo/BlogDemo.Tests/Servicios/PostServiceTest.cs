using BlogDemo.Library;
using BlogDemo.Servicios;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDemo.Tests.Servicios
{
    [TestClass]
    public class PostServiceTest
    {
        [TestMethod]
        public void PostService_Crear_Test_Success()
        {

            // Arrange
            // Fake Variable
            var post = new Post()
            {
                Autor = "Author",
                Activo = true,
                Titulo = "Titulo_Test",
                Texto = "Test",
                PostType = PostType.Post
            };
            // Fake a Context
            IPostDemoContext context = A.Fake<IPostDemoContext>();
            A.CallTo(() => context.GuardarPost(post)).Returns(post);

            // A Real Service with a Fake Dependence
            var postService = new PostService(context);

            // Act
            var resultado = postService.Crear(post);

            // Assert
            Assert.AreEqual("Author", resultado.Autor);
            Assert.AreEqual(true, resultado.Activo);
            Assert.AreEqual("Titulo_Test", resultado.Titulo);
            Assert.AreEqual("Test", resultado.Texto);
            Assert.AreEqual(PostType.Post, resultado.PostType);
            Assert.IsNotNull(resultado.PostId);
            A.CallTo(() => context.GuardarPost(post)).MustHaveHappened();
        }
        
        [TestMethod]
        public void PostService_Crear_Test_Failed()
        {
            // Arrange
            // Fake Variable
            var post = new Post()
            {
                Activo = true,
                Titulo = "Titulo_Test",
                Texto = "Test",
                PostType = PostType.Post
            };
            // Fake a Context
            IPostDemoContext context = A.Fake<IPostDemoContext>();
            A.CallTo(() => context.GuardarPost(post)).Returns(post);

            // A Real Service with a Fake Dependence
            var postService = new PostService(context);

            // Act
            try
            {
                var resultado = postService.Crear(post);
                Assert.IsNull(resultado);
            }
            catch (Exception ex)
            {
                // Assert
                Assert.IsInstanceOfType(ex, typeof(Exception));
            }
        }

        [TestMethod]
        public void PostService_Update_Test_Success()
        {
            // Arrange
            // Fake Variable
            var id = Guid.NewGuid();
            List<Post> data = new List<Post>()
            {
                new Post {
                PostId = id,
                Autor = "Author",
                Activo = true,
                Titulo = "Titulo_Test",
                Texto = "Test",
                PostType = PostType.Post
                }
            };

            var postUpdate = new Post()
            {
                PostId = id,
                Autor = "Author_Modified",
                Titulo = "Titulo_Modified",
                Texto = "Texto Modified",
                PostType = PostType.Pagina,
            };

            // Fake a Context
            IPostDemoContext context = A.Fake<IPostDemoContext>();
            A.CallTo(() => context.LeerPost()).Returns(data);
            A.CallTo(() => context.ActualizarPost(postUpdate)).Returns(postUpdate);
            
            // A Real Service with a Fake Dependence
            var postService = new PostService(context);

            // Act
            var result = postService.Update(postUpdate);

            // Assert
            Assert.IsNotNull(result.FechaModificacion);
            Assert.AreEqual(result.Modificaciones, 1);
            Assert.AreEqual(result.Texto, "Texto Modified");
            Assert.AreEqual(result.Titulo, "Titulo_Modified");
            Assert.AreEqual(result.Autor, "Author");
        }

        [TestMethod]
        public void PostService_Delete_Test_Success()
        {
            // Arrange
            // Fake Variable
            var id = Guid.NewGuid();
            // Una coleccion falsa de la cual vamos a desactivar
            List<Post> data = new List<Post>()
            {
                new Post {
                PostId = id,
                Autor = "Author",
                Activo = true,
                Titulo = "Titulo_Test",
                Texto = "Test",
                PostType = PostType.Post
                }
            };

            // Objeto post con ID a borrar.
            var postToDelete = new Post()
            {
                PostId = id,
                Autor = "Author_Modified",
                Titulo = "Titulo_Modified",
                Texto = "Texto Modified",
                PostType = PostType.Pagina,
            };

            // Fake a Context
            IPostDemoContext context = A.Fake<IPostDemoContext>();
            A.CallTo(() => context.LeerPost()).Returns(data);
            A.CallTo(() => context.DesactivarPost(postToDelete)).WithAnyArguments();

            // Crear un servicio real con la dependencia falsa
            var postService = new PostService(context);

            // Act
            var result = postService.Desactivar(postToDelete);

            // Assert
            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void PostService_GetAll_Test_Success()
        {
            // Arrange
            // Fake Variable
            var id = Guid.NewGuid();
            // Una coleccion falsa de la cual vamos a desactivar
            List<Post> data = new List<Post>()
            {
                new Post {
                PostId = id,
                Autor = "Author",
                Activo = true,
                Titulo = "Titulo_Test",
                Texto = "Test",
                PostType = PostType.Post
                }
            };
            // Fake a Context
            IPostDemoContext context = A.Fake<IPostDemoContext>();
            A.CallTo(() => context.LeerPost()).Returns(data);

            var postService = new PostService(context);

            // Act
            var result = postService.Leer();

            // Assert
            Assert.AreEqual(result.Count, data.Count);
            Assert.AreEqual(result[0].PostId, data[0].PostId);

        }

        [TestMethod]
        public void PostService_Paginar_Test_Success()
        {
            // Arrange
            // Fake Variable
            var numeroDePagina = 2;
            var numeroElementosPorPagina = 2;
            var id = Guid.NewGuid();
            // Una coleccion falsa de la cual vamos a desactivar
            List<Post> data = new List<Post>()
            {
                new Post {
                PostId = Guid.NewGuid(),
                Autor = "Author",
                Activo = true,
                Titulo = "Titulo_Test",
                Texto = "Test",
                PostType = PostType.Post
                },
                new Post {
                PostId = Guid.NewGuid(),
                Autor = "Author",
                Activo = true,
                Titulo = "Titulo_Test",
                Texto = "Test",
                PostType = PostType.Post
                },
                new Post {
                PostId = Guid.NewGuid(),
                Autor = "Author",
                Activo = true,
                Titulo = "Titulo_Test",
                Texto = "Test",
                PostType = PostType.Post
                },
                new Post {
                PostId = Guid.NewGuid(),
                Autor = "Author",
                Activo = true,
                Titulo = "Titulo_Test",
                Texto = "Test",
                PostType = PostType.Post
                },
                new Post {
                PostId = Guid.NewGuid(),
                Autor = "Author",
                Activo = true,
                Titulo = "Titulo_Test",
                Texto = "Test",
                PostType = PostType.Post
                },
                new Post {
                PostId = Guid.NewGuid(),
                Autor = "Author",
                Activo = true,
                Titulo = "Titulo_Test",
                Texto = "Test",
                PostType = PostType.Post
                },
                new Post {
                PostId = Guid.NewGuid(),
                Autor = "Author",
                Activo = true,
                Titulo = "Titulo_Test",
                Texto = "Test",
                PostType = PostType.Post
                },
                new Post {
                PostId = Guid.NewGuid(),
                Autor = "Author",
                Activo = true,
                Titulo = "Titulo_Test",
                Texto = "Test",
                PostType = PostType.Post
                },
                new Post {
                PostId = Guid.NewGuid(),
                Autor = "Author",
                Activo = true,
                Titulo = "Titulo_Test",
                Texto = "Test",
                PostType = PostType.Post
                }
            };

            // Fake a Context
            IPostDemoContext context = A.Fake<IPostDemoContext>();
            A.CallTo(() => context.LeerPost()).Returns(data);

            var postService = new PostService(context);

            // Act
            var result = postService.Paginar(numeroDePagina, numeroElementosPorPagina);

            // Assert
            Assert.AreEqual(result.Count, numeroElementosPorPagina);
            //Assert.AreEqual(result[0].PostId, data[(numeroDePagina - 1) * numeroDePagina].PostId);
        }
    }
}
