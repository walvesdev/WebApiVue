using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WebApiVueJs.AcessoDados;
using WebApiVueJs.AcessoDados.Repositorios;

namespace WebApiVueJs
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

            string connectionSrting = Configuration.GetConnectionString("ApplicationContext");
            services.AddDbContext<ApplicationContext>((optBuilder) => { optBuilder.UseNpgsql(connectionSrting); });


            services.AddTransient<ClienteRepositorio>();


            services.AddCors();
            services.AddMvc();
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(option => option
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()); 

            app.UseMvc();

            //serviceProvider.GetService<PreencherDados>().InicializaDB();
        }

    }
}
