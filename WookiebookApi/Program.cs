using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WookieBooks.Core.IRepository;
using WookieBooks.Core.Repository;
using WookieBooksApi.Data;
using WookieBooksApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase("BookDetails"));

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var serviceProvider = builder.Services.BuildServiceProvider();
var logger = serviceProvider.GetService<ILogger<GlobalExceptionMiddleware>>();
builder.Services.AddSingleton(typeof(ILogger), logger);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware(typeof(GlobalExceptionMiddleware));

app.Run();
