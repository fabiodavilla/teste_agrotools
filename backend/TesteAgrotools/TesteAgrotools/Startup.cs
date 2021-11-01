using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TesteAgrotools.Controllers;
using TesteAgrotools.Infrastructure.Model;
using TesteAgrotools.Persistance;
using TesteAgrotools.Services;

namespace TesteAgrotools
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

            services.AddControllers();

            services.AddDbContext<ProjectModel>(option => option.UseSqlite(Configuration["SQLiteConnection:SQLiteConnectionString"]));

            services.AddScoped<FormController, FormController>();
            services.AddScoped<FormFieldController, FormFieldController>();
            services.AddScoped<UserController, UserController>();
            services.AddScoped<AnswerController, AnswerController>();

            services.AddScoped<FormServices, FormServices>();
            services.AddScoped<FormFieldServices, FormFieldServices>();
            services.AddScoped<UserServices, UserServices>();
            services.AddScoped<AnswerServices, AnswerServices>();

            services.AddScoped<FormRepository, FormRepository>();
            services.AddScoped<FormFieldRepository, FormFieldRepository>();
            services.AddScoped<UserRepository, UserRepository>();
            services.AddScoped<AnswerRepository, AnswerRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("CorsPolicy");

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
