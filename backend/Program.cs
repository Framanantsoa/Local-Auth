using Microsoft.EntityFrameworkCore;
using Utils;

var builder = WebApplication.CreateBuilder(args);

// Logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.SetMinimumLevel(LogLevel.Information);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CONNECTION TO DATABASE
builder.Services.AddDbContext<DbaContext>(op => op.UseNpgsql(
    builder.Configuration.GetConnectionString("Default")
));

// CONTROLLERS AND JSON FORMATS
builder.Services.AddControllers(options => {
    options.Filters.Add<ValidationFilter>();
})
.ConfigureApiBehaviorOptions(options => {
    options.SuppressModelStateInvalidFilter = true;
});

// CORS 
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("Cors1", policy =>
    {
        policy.AllowAnyOrigin()
         .AllowAnyMethod()
         .AllowAnyHeader();
    });
});

// AUTO-INJECTION DES DEPENDANCES
builder.Services.AddProjectServices();


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();
app.UseCors("Cors1");
app.MapControllers();

app.Run();
