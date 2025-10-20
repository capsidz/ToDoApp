var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// builder.Services.AddScoped<ValidaAttribute>();

var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();