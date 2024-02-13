using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ToDoList.Domain.Entities;
using ToDoList.Domain.IRepositories;
using ToDoList.Domain.IServices;
using ToDoList.Infrastructure.Persistance;
using ToDoList.Infrastructure.Persistance.Database;
using ToDoList.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);
//var connectionString = builder.Configuration.GetConnectionString("TaskToDoContextConnection") ?? throw new InvalidOperationException("Connection string 'TaskToDoContextConnection' not found.");

var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
var url = Environment.GetEnvironmentVariable("LOCALRUN") ?? $"http://0.0.0.0:{port}";

#region Cors
var corsSpecificOrigins = "ToDoList";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: corsSpecificOrigins, policy =>
    {
        policy.WithOrigins("*")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin();
    });
});
#endregion

// Add services to the container.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

var connectionString = Environment.GetEnvironmentVariable("DATABASE_CONNECTION");

builder.Services.AddDbContext<DbContext, TaskToDoContext>(options => options.UseLazyLoadingProxies().UseNpgsql(connectionString, b => b.MigrationsAssembly("ToDoList.Migrations")));

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<TaskToDoContext>();

builder.Services.AddIdentity<User, IdentityRole>()
       .AddEntityFrameworkStores<TaskToDoContext>()
       .AddDefaultTokenProviders();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(setup =>
{
    // Include 'SecurityScheme' to use JWT Authentication
    var jwtSecurityScheme = new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        Name = "JWT Authentication",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };
    setup.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);
    setup.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { jwtSecurityScheme, Array.Empty<string>() }
    });
});

builder.Services.AddTransient<ITaskToDoService, TaskToDoService>();
builder.Services.AddTransient<ITaskToDoRepository, TaskToDoRepository>();


builder.Services.AddAuthentication().AddJwtBearer();
builder.Services.AddAuthorization();

var app = builder.Build();

app.UseCors(corsSpecificOrigins);
//app.MapHealthChecks("/health-check");

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
