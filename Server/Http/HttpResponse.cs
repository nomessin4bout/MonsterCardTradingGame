using System.IO;

namespace MCTG.Server.Http
{
    internal class HttpResponse
    {
        private StreamWriter writer;

        public HttpResponse(StreamWriter writer)
        {
            this.writer = writer;
        }

        public void WriteResponse(string status, string body)
        {
            var writerToConsole = new StreamTracer(writer);
            writerToConsole.WriteLine(status);
            writerToConsole.WriteLine("Content-Type: text/html; charset=utf-8");
            writerToConsole.WriteLine();
            writerToConsole.WriteLine(body);
        }
    }
}
