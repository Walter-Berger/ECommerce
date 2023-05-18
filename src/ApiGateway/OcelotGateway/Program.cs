using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using OcelotGateway;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// ------------ Start Parse Configuration ---------------- //
var secrets = await DopplerApi.FetchSecretsAsync();

Stream baseUrlOcelot = new MemoryStream(Encoding.UTF8.GetBytes(secrets.BaseUrlGateway));
Stream userServiceConfig = new MemoryStream(Encoding.UTF8.GetBytes(secrets.UserServiceConfig));
// ------------ End Parse Configuration ------------------ //

builder.Configuration
    .AddJsonStream(baseUrlOcelot)
    .AddJsonStream(userServiceConfig);

builder.Services.AddOcelot();

var app = builder.Build();
app.UseOcelot().Wait();
app.Run();
