var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddScoped<IMinimalApiService, MinimalApiService>();
builder.Services.AddCors();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setupSwagger =>
{
    setupSwagger.SwaggerDoc("v1", new OpenApiInfo()
    {
        Description = "Minimal Api in .NET 6",
        Title = "Minimal Api",
        Version = "v1"
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

//Add Swagger
app.UseSwagger();
app.UseSwaggerUI(swagger => swagger.SwaggerEndpoint("/swagger/v1/swagger.json", "Api v1"));
app.UseHttpsRedirection();
app.UseRouting();

//Add Cors
app.UseCors(p =>
{
    p.AllowAnyOrigin();
    p.AllowAnyMethod();
    p.AllowAnyHeader();
});

//Request List
app.MapGet("/hellodotnetsix", () =>
{
    return Results.Ok("Hello .NET 6");
});

app.MapPost("/isdotnetsix", (bool? dotnet, IMinimalApiService minimalApiService) =>
{
    if (dotnet is null)
        return Results.BadRequest("Please selected a boolean value");

    return Results.Ok(minimalApiService.CheckDotNet((bool)dotnet));
});

//Run App
app.Run();