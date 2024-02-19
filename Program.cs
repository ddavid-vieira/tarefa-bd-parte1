using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tarefa_bd_parte1;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MainDbContext>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet(
        "/usuario",
        (MainDbContext _context) =>
        {
            return _context.Usuario.ToList();
        }
    )
    .WithName("ListarUsuarios");
app.MapPost(
    "/usuario",
    (Usuario usuario, MainDbContext _context) =>
    {
        _context.Add(usuario);
        _context.SaveChanges();
    }
);

app.Run();

