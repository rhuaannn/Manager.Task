using Manager.Task.Application.Interfaces;
using Manager.Task.Application.Services;
using Manager.Task.Infra.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRouting(options => options.LowercaseUrls = true);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<DbContextApi>(options =>
    options.UseMySQL(connectionString,
        b => b.MigrationsAssembly("Manager.Task.Infra")));



builder.Services.AddAutoMapper(typeof(MappingProfile)); 
builder.Services.AddScoped<ITask, TaskServices>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
