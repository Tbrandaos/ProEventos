using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain.Request.Evento;
using ProEventos.Domain.Response.Evento;
using ProEventos.Domain.Response.Palestrante;
using AutoMapper;
using ProEventos.Domain.Services;
using ProEventos.Infra.Entities;
using ProEventos.Infra.Services;
using ProEventos.Infra.Context;
using ProEventos.Domain.Request.Lote;
using ProEventos.Domain.Response.Lote;
using ProEventos.Domain.Response.RedeSocial;
using ProEventos.Domain.Request.RedeSocial;

namespace ProEventos.API
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
            services.AddDbContext<DataContext>(
                context => context.UseSqlite(Configuration.GetConnectionString("Default"))
            );
            services.AddControllers()
                .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = 
                    Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );
            services.AddCors();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProEventos.API", Version = "v1" });
            });

            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                #region Eventos
                cfg.CreateMap<EventoResponse, Evento>().ReverseMap();
                cfg.CreateMap<EventoRequest, Evento>().ReverseMap();
                #endregion

                #region Palestrantes
                cfg.CreateMap<PalestranteResponse, Palestrante>().ReverseMap();
                #endregion

                #region Lotes
                cfg.CreateMap<LoteRequest, Lote>().ReverseMap();
                cfg.CreateMap<LoteResponse, Lote>().ReverseMap();
                #endregion

                #region RedesSociais
                cfg.CreateMap<RedeSocialRequest, RedeSocial>().ReverseMap();
                cfg.CreateMap<RedeSocialResponse, RedeSocial>().ReverseMap();
                #endregion
            });
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            services.AddScoped<IEventoService, EventoService>();
            services.AddScoped<IPalestranteService, PalestranteService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProEventos.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(c => c.AllowAnyHeader()
                              .AllowAnyMethod()
                              .AllowAnyOrigin()  

            );  

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
