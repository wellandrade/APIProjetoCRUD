using AutoMapper;
using CRUD.Negocio.Interfaces;
using CRUD.Negocio.Interfaces.Repositorios;
using CRUD.Negocio.Interfaces.Servicos;
using CRUD.Negocio.Modelos;
using CRUD.Negocio.Repositorios.Interfaces;
using CRUD.Negocio.Servico;
using CRUD.Repositorio.Context;
using CRUD.Repositorio.Repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace CRUD.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CRUDContext>(o =>
            {
                o.UseSqlServer(Configuration.GetConnectionString("CRUDConnection"));
            });

            services.AddAutoMapper(typeof(Startup));
            services.AddControllers();

            services.AddScoped<CRUDContext>();
            services.AddTransient<IClienteServico, ClienteServico>();
            services.AddTransient<IClienteRepositorio, ClienteRepositorio>();

            services.AddTransient<IPedidoServico, PedidoServico>();
            services.AddTransient<IPedidoRepositorio, PedidoRepositorio>();

            services.AddControllers().AddNewtonsoftJson(o =>
            {
                o.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "CRUD",
                    Version = "v1",
                    Description = "API REST com o ASP.NET Core 3.1"
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API CRUD");
            });

        }
    }
}
