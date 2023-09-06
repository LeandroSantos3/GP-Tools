using Microsoft.EntityFrameworkCore;
using backend_API.Data;
using System.Text.Json.Serialization;
using backend_API.Services.WorkerProfile;
using System.Reflection;
using backend_API.Services.ActivityCategory;
using backend_API.Services.ActivityCategoryState;
using backend_API.Services.Activity;
using backend_API.Services.ActivityWorkerProfile;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Controlador de 'Cycle detected'
builder.Services.AddControllers().AddJsonOptions(x =>
        x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


//Acesso a base de dados usando o Entity Framework Core
//Abordagem ORM (Object Relational Mapping)
builder.Services.AddDbContext<CCGToolsDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DatabaseConnectionString"),
        new MySqlServerVersion(new Version(10, 4, 24))));

//DEPENDENCY INJECTION 
builder.Services.AddScoped<IWorkerProfileService, WorkerProfileService>();
builder.Services.AddScoped<IActivityCategoryService, ActivityCategoryService>();
builder.Services.AddScoped<IActivityCategoryStateService,  ActivityCategoryStateService>();
builder.Services.AddScoped<IActivityService, ActivityService>();
builder.Services.AddScoped<IActivityWorkerProfileService, ActivityWorkerProfileService>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add SwaggerGen for Documentation
builder.Services.AddSwaggerGen(s =>
{
    s.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "V1",
        Title = "GP Tools",
        Description = "API para gerenciar a camada de interação"
    });


    // invocar o metodo para comentar o XML file
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    s.IncludeXmlComments(xmlPath);
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Backend API");
        //c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

//Enables CORS API
app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();

app.Run();
