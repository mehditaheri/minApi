using BasicInformation.Application.Features;
using BasicInformation.Core.Caching;
using BasicInformation.Core.Repositories.Base;
using BasicInformation.Infrastructure;
using BasicInformation.Infrastructure.Data;
using BasicInformation.Infrastructure.Repositories.Base;
using MediatR;
using Microsoft.EntityFrameworkCore; 
using Microsoft.OpenApi.Models;
using System.Reflection; 

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<BasicInformatinContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddMediatR(typeof(GetAllLocation.QueryHandler).GetTypeInfo().Assembly);
builder.Services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>)); 

builder.Services.RegisterRepositories();

// For Identity
//builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
//    .AddEntityFrameworkStores<ApiIdentityDbContext>()
//    .AddDefaultTokenProviders();

//// Adding Authentication
//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
//})

//// Adding Jwt Bearer
//.AddJwtBearer(options =>
//{
//    options.SaveToken = true;
//    options.RequireHttpsMetadata = false;
//    options.TokenValidationParameters = new TokenValidationParameters()
//    {
//        ValidateIssuer = true,
//        ValidateAudience = true,
//        ValidAudience = builder.Configuration["JWT:ValidAudience"],
//        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
//        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
//    };
//});



//builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(swagger =>
{
    //This is to generate the Default UI of Swagger Documentation  
    swagger.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Basic Information Web API",
        Description = "Authentication and Authorization in Basic Information Web API with JWT and Swagger"
    });
    // To Enable authorization using Swagger (JWT)  
    swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
    });
    swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}

                    }
                });

    //swagger.EnableAnnotations();
    //swagger.IncludeXmlComments(filePath);
});

builder.Services.Configure<CacheConfiguration>(builder.Configuration.GetSection("CacheConfiguration"));

//For In-Memory Caching
builder.Services.AddMemoryCache();
builder.Services.AddTransient<MemoryCacheService>();
//services.AddTransient<RedisCacheService>();
builder.Services.AddTransient<Func<CacheTech, ICacheService>>(serviceProvider => key =>
{
    switch (key)
    {
        case CacheTech.Memory:
            return serviceProvider.GetService<MemoryCacheService>();
        //case CacheTech.Redis:
        //    return serviceProvider.GetService<RedisCacheService>();
        default:
            return serviceProvider.GetService<MemoryCacheService>();
    }
});
 
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Basic Information Web API v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
 
app.Run();
