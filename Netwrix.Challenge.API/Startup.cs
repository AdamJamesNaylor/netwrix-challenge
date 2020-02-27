
namespace Netwrix.Challenge.API {
    using Business.Services;
    using Data.Repositories;
    using Data.Sql;
    using Data.Sql.Repositories;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.EntityFrameworkCore;

    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddDbContext<INetwrixDbContext, NetwrixDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("NetwrixDatabase")));
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IInvoiceService, InvoiceService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}