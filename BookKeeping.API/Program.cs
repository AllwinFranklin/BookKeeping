using BookKeeping.API.Contracts;
using BookKeeping.API.Data;
using BookKeeping.API.Extensions;
using BookKeeping.API.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<BookContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BookKeepingConnectionString"))
);

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<ICitationRepository, CitationRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.MigrateDatabase<BookContext>((context, service) =>
{
    BookContextSeed
        .SeedAsync(context, service.GetService<ILogger<BookContextSeed>>())
        .Wait();
});

app.Run();
