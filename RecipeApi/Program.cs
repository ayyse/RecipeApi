using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using RecipeApi.Data;
using RecipeApi.Models;
using RecipeApi.Validators;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddScoped<IValidator<Recipe>, RecipeValidator>();

// Add services to the container.
builder.Services.AddDbContext<RecipeDbContext>(options => options.UseInMemoryDatabase(databaseName: "RecipeDB"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope()) { var services = scope.ServiceProvider; DataGenerator.Initialize(services); }

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
