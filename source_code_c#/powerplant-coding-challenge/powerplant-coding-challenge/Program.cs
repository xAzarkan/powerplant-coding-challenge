﻿using System.Text.Json.Serialization;
using powerplant_coding_challenge.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMvc()
 .AddJsonOptions(o => {
     o.JsonSerializerOptions
        .ReferenceHandler = ReferenceHandler.IgnoreCycles;
 });

builder.Services.AddControllers();

builder.Services.AddScoped<IProductionPlanRepository, ProductionPlanRepository>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

