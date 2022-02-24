using System.Threading.Tasks;

namespace SUS.HTTP
{
    public interface IHttpServer
    {       
        Task StartAsync(int port);

        //void AddRoute
        //(string path, Funl<HttpRequest, HttpResponce>action);

        //void Start(int port);


    }
}
