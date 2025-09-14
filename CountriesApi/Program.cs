using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add CORS for better API accessibility
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Use CORS
app.UseCors();

// Use HTTPS redirection for production security
app.UseHttpsRedirection();

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
.WithOpenApi()
.WithSummary("Get random countries")
.WithDescription("Returns 5 randomly selected countries from a predefined list")
.Produces<object>(StatusCodes.Status200OK);

app.Run();