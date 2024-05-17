using Microsoft.EntityFrameworkCore;
using Project.Controllers;
using Project.Data;

namespace Project;

public class Startup(IWebHostEnvironment env, IConfiguration configuration)
{
    string  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
    public IConfiguration Configuration { get; } = configuration;
    public IWebHostEnvironment Environment { get; } = env;

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddSingleton<IGreetingDependency>(new GreetingDependency());
        if (Environment.IsDevelopment())
        {
            services.AddDbContext<BioscoopContext>(options =>
            {
                options.UseSqlite("Data Source=bioscoop.db");
                options.EnableSensitiveDataLogging();
                options.EnableDetailedErrors();
            });
        }

        services.AddCors(options => options.AddPolicy(MyAllowSpecificOrigins, policy => { 
            policy.WithOrigins("http://localhost:3000");
            policy.AllowAnyHeader();
        }));

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }

    public void Configure(IApplicationBuilder app)
    {
        if (Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseCors(MyAllowSpecificOrigins);

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        }
        );
    }
}