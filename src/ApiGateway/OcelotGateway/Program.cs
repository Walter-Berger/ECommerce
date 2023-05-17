using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System.Text;
using OcelotGateway;

var builder = WebApplication.CreateBuilder(args);

var secrets = await DopplerApi.FetchSecretsAsync();

var jsonString = secrets.RoutesForOcelot;
byte[] jsonBytes = Encoding.UTF8.GetBytes(jsonString);
Stream stream = new MemoryStream(jsonBytes);

builder.Configuration.AddJsonStream(stream);
builder.Services.AddOcelot();

var app = builder.Build();
app.UseOcelot().Wait();
app.Run();
