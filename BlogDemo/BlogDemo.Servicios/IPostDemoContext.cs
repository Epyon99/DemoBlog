using BlogDemo.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDemo.Servicios
{
    public interface  IPostDemoContext
    {
        Post GuardarPost(Post p);

        Post ActualizarPost(Post p);

        List<Post> LeerPost();

        bool ActivarPost(Post p);

        bool DesactivarPost(Post p);
    }
}
