namespace SUS.MvcFramework
{
    using SUS.HTTP;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Text;

    public abstract class Controller
    {
        public HttpResponse View([CallerMemberName]string viewPath = null)
        {

            var layout = System.IO.File.ReadAllText("Views/Shared/_Layout.html");


            var viewContent = System.IO. File.ReadAllText (
                "Views/" + 
                this.GetType().Name.Replace("Controller", string.Empty)+ 
                "/" + viewPath + ".html");

            var responseHtml = layout.Replace("@RenderBody()", viewContent);
            
            var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);
            var response = new HttpResponse("text/html", responseBodyBytes);
            return response;
        }

        public HttpResponse File(string filePath, string contentType)
        {
            var fileByte = System.IO.File.ReadAllBytes(filePath);
            var response = new HttpResponse(contentType, fileByte);
            return response;
        }

        public HttpResponse Redirect(string url)
        {
            var response = new HttpResponse(url);
            response.Headers.Add(new Header("Location", url));
            return response;
        }
    }
}
