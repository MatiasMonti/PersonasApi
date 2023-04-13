using PeoplesApi.Aplication;
using Microsoft.EntityFrameworkCore;
using PersonasApi.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AplicationDBContext>(options => options.UseSqlServer("name =DefaultConection"));
builder.Services.AddScoped<IPeopleServices, PeopleServices>();
builder.Services.AddAutoMapper(Assembly.Load("PersonasApi"));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var AplicationDBContext = scope.ServiceProvider.GetRequiredService<AplicationDBContext>();
    AplicationDBContext.Database.Migrate();
}

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
