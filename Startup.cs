using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using stock_app.Facades;
using stock_app.Interfaces;
using stock_app.Models.Databases;

namespace stock_app
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
            

            services.AddSingleton(Configuration);
            services.AddControllers();
            services.AddDbContext<StockContext>(options => 
                options.UseSqlite("Data Source =Stock.db")
            );
            // var options = new DbContextOptionsBuilder<StockContext>();
            // var context = new StockContext(options.UseSqlite("Data Source =Stock.db").Options);
            // services.AddSingleton(context);
            services.AddScoped<IProductsFacade, ProductsFacade>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseExceptionHandler("/Error");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
