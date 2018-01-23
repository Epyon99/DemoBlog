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
    }
}
