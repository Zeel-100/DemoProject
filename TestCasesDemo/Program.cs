using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using TestCaseDemo.Models.Validation;
using TestCaseDemo.Services.Interface;
using TestCaseDemo.Services.Services;
using TestCaseDemo.Models.DataContext;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation(c => c.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddScoped<FilmDtoValidator>();
builder.Services.AddScoped<FilmUpdateDtoValidator>();
builder.Services.AddScoped<IGetFilmService, GetFilmService>();
builder.Services.AddScoped<ICreateFilmService, CreateFilmService>();
builder.Services.AddScoped<IDeleteFilmService, DeleteFilmService>();
builder.Services.AddScoped<IUpdateFilmService, UpdateFilmService>();


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

app.Run();
