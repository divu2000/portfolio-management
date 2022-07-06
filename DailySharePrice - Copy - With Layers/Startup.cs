using DailySharePrice.Models;
using DailySharePrice.Respository;
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DailySharePrice.Service;


namespace DailySharePrice
{
    public class Startup
    {
        public string ConnectionString { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            ConnectionString = Configuration.GetConnectionString("DefaultConnectionString");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(ConnectionString));

            //Configure services
            services.AddTransient<IStockRepository<StockDetail>, StockRepository>();
            services.AddScoped<IStockService<StockDetail>, StockService>();

            services.AddCors();
            //services.AddCors(options => options.AddPolicy("AllowAccess_To_API",
            //policy => policy
            //.AllowAnyOrigin()
            //.AllowAnyMethod()
            //.AllowAnyHeader()
            //));


           services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DailySharePrice", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {

            app.UseCors(options => options.WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader());
            
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DailySharePrice v1"));
        
            loggerFactory.AddLog4Net();

            // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
