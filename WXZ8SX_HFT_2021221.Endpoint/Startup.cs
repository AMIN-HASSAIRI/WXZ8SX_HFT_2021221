using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WXZ8SX_HFT_2021221.Data;
using WXZ8SX_HFT_2021221.Endpoint.Services;
using WXZ8SX_HFT_2021221.Logic;
using WXZ8SX_HFT_2021221.Repository;

namespace WXZ8SX_HFT_2021221.Endpoint
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddTransient<IAlbumLogic, AlbumLogic>();
            services.AddTransient<IAlbumRepository, AlbumRepository>();

            services.AddTransient<IGenreLogic, GenreLogic>();
            services.AddTransient<IGenreRepository, GenreRepository>();

            services.AddTransient<ISongLogic, SongLogic>();
            services.AddTransient<ISongRepository, SongRepository>();

            services.AddTransient<IArtistLogic, ArtistLogic>();
            services.AddTransient<IArtistRepository, ArtistRepository>();

            services.AddTransient<MusicDbContext, MusicDbContext>();

            //new
            services.AddSignalR();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MusicDbApplication.Endpoint", Version = "v1" });
            });
            //
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                //new
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WXZ8SX_HFT_2021221.Endpoint v1"));
                //
            }

            //new
            app.UseExceptionHandler(c => c.Run(async context =>
            {
                var exception = context.Features
                    .Get<IExceptionHandlerPathFeature>()
                    .Error;
                var response = new { Msg = exception.Message };
                await context.Response.WriteAsJsonAsync(response);
            }));
            //

            //JS
            app.UseCors(x => x
                .AllowCredentials()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithOrigins("http://localhost:12307")
            );
            //

            app.UseRouting();

            //new
            app.UseAuthorization();
            //

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //new
                endpoints.MapHub<SignalRHub>("/hub");
                //
            });
        }
    }
}
