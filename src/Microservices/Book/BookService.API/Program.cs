var builder = WebApplication.CreateBuilder(args);


// ------------ Start Parse Configuration ---------------- //
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// ------------ End Parse Configuration ------------------ //

builder.Logging.AddCustomLogging();
builder.Services.AddDbContext<DatabaseContext>(options => options.UseNpgsql(connectionString));
builder.Services.AddValidatorsFromAssemblyContaining<Program>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());
builder.Services.AddTransient<ExceptionHandlingMiddleware>();
builder.Services.AddScoped<ITimeFactory, TimeFactory>();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.MapApiEndpoints();

app.Run();
