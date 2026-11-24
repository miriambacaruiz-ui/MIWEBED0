var builder = WebApplication.CreateBuilder(args);

// 1. Habilitar CORS
builder.Services.AddCors(options => {
    options.AddPolicy("AllowAll", policy => {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

builder.Services.AddControllers();

// 2. Puerto para Render
var port = Environment.GetEnvironmentVariable("PORT") ?? "10000";
builder.WebHost.UseUrls($"http://0.0.0.0:{port}");

var app = builder.Build();

// 3. Usar CORS
app.UseCors("AllowAll");

app.MapControllers();

app.Run();
