using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using QTBWebBackend.Authorization;
using QTBWebBackend.Interfaces;
using QTBWebBackend.Models;
using QTBWebBackend.Repositories;
using QTBWebBackend.Services;

namespace QTBWebBackend
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
            services.AddCors();
            services.AddControllersWithViews();

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            services.AddDbContext<QTBWebDBContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("ConnessioneDefault")));  // Scorciatoia perché la sezione in appsettings si chiama "ConnectionStrings"

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "QTBWeb", Version = "v1" });
            });
            services.AddDbContext<QTBWebDBContext>();
            services.AddScoped<IAeroportiRepository, AeroportiRepository>();
            services.AddScoped<ITipiManutenzioniRepository, TipiManutenzioniRepository>();
            services.AddScoped<IPersoneRepository, PersoneRepository>();
            services.AddScoped<IVoliRepository, VoliRepository>();
            services.AddScoped<IAereiRepository, AereiRepository>();
            services.AddScoped<IScadenzeRepository, ScadenzeRepository>();
            services.AddScoped<IManutenzioniRepository, ManutenzioniRepository>();
            services.AddScoped<IDashboardRepository, DashboardRepository>();
            services.AddScoped<ILoginService, LoginService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "QTBWeb v1"));
            }

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthorization();

            // custom jwt auth middleware
            app.UseMiddleware<JwtMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
