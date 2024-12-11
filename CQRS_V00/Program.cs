using CQRS_V00;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDependency(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
