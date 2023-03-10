using DiplomaProject.Backend.BuisnessLayer.Helpers;
using DiplomaProject.Backend.DataLayer.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

DiplomaProject.Backend.DataLayer.Helpers.DI.Add(builder.Configuration, builder.Services);
DiplomaProject.Backend.BuisnessLayer.Helpers.DI.Add(builder.Configuration, builder.Services);

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
