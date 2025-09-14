using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var countries = new[]
{
    "United States", "Canada", "Mexico", "Brazil", "Argentina", "United Kingdom",
    "France", "Germany", "Italy", "Spain", "Russia", "China", "Japan", "India",
    "Australia", "South Africa", "Egypt", "Nigeria", "Kenya", "Morocco",
    "Sweden", "Norway", "Finland", "Denmark", "Netherlands", "Belgium",
    "Switzerland", "Austria", "Poland", "Czech Republic", "Hungary", "Romania",
    "Greece", "Turkey", "Israel", "Saudi Arabia", "UAE", "Iran", "Iraq",
    "Thailand", "Vietnam", "Indonesia", "Philippines", "Malaysia", "Singapore",
    "South Korea", "North Korea", "Mongolia", "Kazakhstan", "Ukraine"
};

app.MapGet("/countries", () =>
{
    var random = new Random();
    var randomCountries = countries.OrderBy(x => random.Next()).Take(5).ToArray();
    return Results.Ok(new { countries = randomCountries });
})
.WithName("GetRandomCountries")
.WithOpenApi();

app.Run();