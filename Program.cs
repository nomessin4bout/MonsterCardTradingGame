using MCTG.Server;
using MCTG.Server.Endpoints;
using MCTG.Server.Http;

var users = new Dictionary<string, User>();
var sessions = new Dictionary<string, string>();

var userEndpoint = new UserEndpoint(users, sessions);
var httpServer = new HttpServer(userEndpoint);

httpServer.Start();
