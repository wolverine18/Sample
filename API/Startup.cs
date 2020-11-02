using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sample.Domain.Abstract;
using Sample.Infrastructure.Repositories;
using SimpleInjector;

namespace API
{
    public class Startup
    {
        private Container container = new SimpleInjector.Container();

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
                options.AddPolicy("Presentation",
                    builder =>
                    {
                        builder.WithOrigins("*")
                                            .AllowAnyHeader()
                                            .AllowAnyMethod();
                    });
            });

            services.AddControllers();

            services.AddSimpleInjector(container, options =>
            {
                options.AddAspNetCore().AddControllerActivation();
            });

            container.Register<IHelloWorld, HelloWorld>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSimpleInjector(container);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
