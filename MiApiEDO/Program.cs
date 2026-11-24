var builder = WebApplication.CreateBuilder(args);

// --- ESTO ES CLAVE PARA QUE RENDER NO BLOQUEE TU PÁGINA ---
builder.Services.AddCors(options => {
    options.AddPolicy("AllowAll", policy => {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddControllers();

// Configuración del puerto para Render
var port = Environment.GetEnvironmentVariable("PORT") ?? "10000";
builder.WebHost.UseUrls($"http://0.0.0.0:{port}");

var app = builder.Build();

// El CORS debe ir justo aquí, ANTES de MapControllers
app.UseCors("AllowAll");

app.UseAuthorization();
app.MapControllers();

app.Run();