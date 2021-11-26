using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using JeuDeCarte.Models;
using JeuDeCarte.Services;
using System.Collections.Generic;

namespace JeuDeCarte
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
            
            services.AddControllers();
            services.AddDbContext<CarteContext>(opt =>
                                               opt.UseInMemoryDatabase("CarteList1"));
            services.AddScoped<CarteContext>();
            services.AddScoped<CarteService>();
            services.AddScoped<JeuDeCarteService>();
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "JeuDeCarte", Version = "v1" });
            //});
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseSwagger();
                //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "JeuDeCarte v1"));
            }

            

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetService<CarteContext>();
            AddCartesData(context);
        }
        private static void AddCartesData(CarteContext context)
        {
            List<string> LettreDeCategory = new List<string>() { "Clubs", "Diamonds", "Hearts", "Spades" };
            List<string> Values = new List<string>() { "A", "2", "3", "4", "5", "6", "7", "8", "9", "0", "J", "Q", "K" };
            foreach (string Lettre in LettreDeCategory)
            {
                foreach (string value in Values)
                {
                    var Carte = new ModeleCarte();
                    Carte.CardValue = $"{value}{Lettre.Substring(0, 1)}";
                    Carte.CardCategory = Lettre;
                    Carte.Image = $"https://deckofcardsapi.com/static/img/{Carte.CardValue}.png";
                    context.ModeleCartes.Add(Carte);
                }
            }

            context.SaveChanges();
        }
    }
}