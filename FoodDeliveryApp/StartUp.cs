using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using RepositoryLayer;
using ServiceLayer;
using ServiceLayer.Implementation;
using ServiceLayer.Interface;

public class Startup
{
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly IConfiguration Configuration;
    private readonly string? _feUrl;

    public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
    {
        Configuration = configuration;
        _webHostEnvironment = webHostEnvironment;
        _feUrl = Configuration.GetValue<string>("feUrl");
    }

    private readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

    public void ConfigureServices(IServiceCollection services)
    {
        string[]? initialScopes = Configuration.GetValue<string>("DownstreamApi:Scopes")?.Split(' ');


        services.AddHttpContextAccessor();

        var sqlConnectionString = Configuration.GetConnectionString("Connection");
        services.AddDbContext<AppDbContext>(options => options.UseNpgsql(sqlConnectionString));

        services.AddScoped<IUser, UserService>();
        services.AddScoped<IRestaurant, RestaurantService>();
        services.AddScoped<IMenuItem, MenuItemService>();
        services.AddScoped<IAddress, AddressService>();



        services.AddEndpointsApiExplorer();

        services.AddCors(options =>
        {
          

            options.AddPolicy("AllowSwagger", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyHeader()
                       .AllowAnyMethod();
            });

        });

        services.AddMvc(options =>
        {
            options.MaxModelValidationErrors = 50;
            options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(
                _ => "The field is required.");
        });
       
        services.AddSwaggerGen(options =>
        {
            options.CustomSchemaIds(type => type.FullName);
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPIv6", Version = "v1" });
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n
                   Enter 'Bearer' [space] and then your token in the text input below.
                   \r\n\r\nExample: 'Bearer 12345abcdef'",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement()
             {
                     {
                         new OpenApiSecurityScheme
                         {
                             Reference = new OpenApiReference
                             {
                                 Type = ReferenceType.SecurityScheme,
                                 Id = "Bearer"
                             },
                             Scheme = "oauth2",
                             Name = "Bearer",
                             In = ParameterLocation.Header,

                         },
                         new List<string>()
                     }
             });
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPIv6 V1");
                c.RoutePrefix = "swagger";
            });
        }
        else
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseStaticFiles();
        app.UseRouting();
        app.UseCors(MyAllowSpecificOrigins);
        app.UseAuthentication();
        app.UseAuthorization();


        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}"
                ).RequireCors(MyAllowSpecificOrigins);
        });
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPIv6 V1");
            c.RoutePrefix = "swagger";
        });


    }
}