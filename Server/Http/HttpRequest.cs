using System.IO;

namespace MCTG.Server.Http
{
    internal class HttpRequest
    {
        public string Method { get; private set; }
        public string Path { get; private set; }
        public int ContentLength { get; private set; }
        public string Body { get; private set; } = "";

        public HttpRequest(string requestLine, StreamReader reader)
        {
            var requestParts = requestLine.Split(' ');
            Method = requestParts[0];
            Path = requestParts[1];

            ContentLength = ParseHeaders(reader);
            Body = ReadRequestBody(reader, ContentLength);
        }

        private int ParseHeaders(StreamReader reader)
        {
            string? line;
            int contentLength = 0;

            while ((line = reader.ReadLine()) != null && line != "")
            {
                var headerParts = line.Split(':');
                if (headerParts.Length == 2 && headerParts[0] == "Content-Length")
                {
                    contentLength = int.Parse(headerParts[1].Trim());
                }
            }
            return contentLength;
        }

        private string ReadRequestBody(StreamReader reader, int contentLength)
        {
            if (contentLength <= 0) return string.Empty;

            var buffer = new char[contentLength];
            reader.Read(buffer, 0, contentLength);
            return new string(buffer);
        }
    }
}
