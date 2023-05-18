using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using OcelotGateway;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// ------------ Start Parse Configuration ---------------- //
var secrets = await DopplerApi.FetchSecretsAsync();
var baseUriOcelot = secrets.BaseUriOcelot;
var userServiceConfig = secrets.UserServiceConfigOcelot;

Stream userServiceStream = new MemoryStream(Encoding.UTF8.GetBytes(userServiceConfig));
Stream baseUriStream = new MemoryStream(Encoding.UTF8.GetBytes(baseUriOcelot));
// ------------ End Parse Configuration ------------------ //

builder.Configuration
    .AddJsonStream(baseUriStream)
    .AddJsonStream(userServiceStream);

builder.Services.AddOcelot();

var app = builder.Build();
app.UseOcelot().Wait();
app.Run();
