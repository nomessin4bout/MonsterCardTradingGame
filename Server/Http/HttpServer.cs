using System.Net;
using System.Net.Sockets;
using MCTG.Server.Endpoints;

namespace MCTG.Server.Http
{
    internal class HttpServer
    {
        private TcpListener tcpListener;
        private UserEndpoint userEndpoint;

        public HttpServer(UserEndpoint userEndpoint, int port = 10001)
        {
            this.userEndpoint = userEndpoint;
            tcpListener = new TcpListener(IPAddress.Loopback, port);
        }

        public void Start()
        {
            tcpListener.Start();
            Console.WriteLine($"Server läuft auf: http://localhost:10001/");
            Console.WriteLine(".........................................\n\n\n");

            while (true)
            {
                using var clientSocket = tcpListener.AcceptTcpClient();
                using var writer = new StreamWriter(clientSocket.GetStream()) { AutoFlush = true };
                using var reader = new StreamReader(clientSocket.GetStream());

                string? requestLine = reader.ReadLine();
                if (requestLine == null) continue;

                Console.WriteLine(requestLine);
                var request = new HttpRequest(requestLine, reader);
                var response = new HttpResponse(writer);

                userEndpoint.HandleRequest(request, response);

                Console.WriteLine("\n------------------------------------------------\n");
            }
        }
    }
}
