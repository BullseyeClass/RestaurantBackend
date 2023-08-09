using Microsoft.AspNetCore.Identity;
using Restaurant.API.Configuration;
using Restaurant.Data.Context;
using Restaurant.Data.Entities;
using Restaurant.Data.Seeed;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureAuthentication(builder.Configuration);
builder.Services.ConfigurationIdentity();
builder.Services.AddSwaggerConfiguration();
builder.Services.AddServices();
builder.Services.AddDbConfig(builder.Configuration);

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

// Call your data seeding method here
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
var userManager = services.GetRequiredService<UserManager<Customer>>();
var dbContext = services.GetRequiredService<MyAppContext>();
await Seeder.Seed(roleManager, userManager, dbContext);

app.Run();
