using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MatchOddsApi.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;

namespace MatchOddsApi {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            
            services.AddDbContext<MatchOddsApiContext>(opt => opt.UseSqlServer
            (Configuration.GetConnectionString("MatchOddsApiConnection")));

            //services.AddControllers();

            services.AddControllers().AddNewtonsoftJson(s => { 
                //s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();//didn't work, why?
                s.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });
                        
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());            
            services.AddScoped<IMatchRepo, SqlMatchOddsApiRepo>();
            services.AddScoped<IMatchOddRepo, SqlMatchOddsApiRepo>();

            services.AddSwaggerGen();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {
                    Version = "v1",
                    Title = "MatchOddsAPI using Swagger",
                    Description = "An ASP.NET.Core 3.1 API to handle matches and match odds",
                });
            });
        }
                
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MatchOddsApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}