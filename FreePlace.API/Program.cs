using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();



builder.Services.AddSwaggerGen(options =>
    {
        // Add API Documentation Information
        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "FreePlace API",
            Description = "FreePlace RESTful API",
            TermsOfService = new Uri("https://freeplace.com"),
            Contact = new OpenApiContact
            {
                Name = "FreePlace.studio",
                Url = new Uri("https://FreePlace.studio")
            },
            License = new OpenApiLicense
            {
                Name = "FreePlace Resources License",
                Url = new Uri("https://FreePlace.com/license")
            }
        });
        options.EnableAnnotations();
    }
);

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