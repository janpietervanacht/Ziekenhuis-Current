using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Ziekenhuis.Business;
using Ziekenhuis.Business.Interfaces;
using Ziekenhuis.Business.Managers;
using Ziekenhuis.DataAccess.ApplicDbContext;
using Ziekenhuis.DataAccess.Interfaces;
using Ziekenhuis.DataAccess.Repositories;

namespace Ziekenhuis.Ziekenhuis
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // IServiceCollection: specifies the contract for a collection of service descriptions.

        public void ConfigureServices(IServiceCollection services)
        {
            // AddDbContext: Registers the given context as a service in the IServiceCollection
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer( // configures the context to connect to a MSSM database
                    Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Scoped);

            // Gebruik Scoped en AddScoped om bij iedere instantiatie van onderstaande classes
            // een nieuw object aan te maken. Als je AddSingleTon zou gebruiken, gaat het FOUT,
            // dan wordt maar ??n keer een instantie aangemaakt en worden de 2e keer de gegevens niet meer
            // uit de database gehaald.

            services.AddScoped<IClientRepository, ClientRepository>(); // hier maak je een reference naar de instance
            services.AddScoped<IPrescrRepository, PrescrRepository>();
            services.AddScoped<IConsultRepository, ConsultRepository>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();

            services.AddScoped<IClientManager, ClientManager>();
            services.AddScoped<IDoctorManager, DoctorManager>();
            services.AddScoped<IPrescrManager, PrescrManager>();
            services.AddScoped<IConsultManager, ConsultManager>();
            services.AddScoped<IInvoiceManager, InvoiceManager>();
            services.AddScoped<ICountryManager, CountryManager>();

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                // CODE BEWAREN, DIT IS DE STANDAARD (HOME CONTROLLER)

                //endpoints.MapControllerRoute(
                //    name: "default",
                //    pattern: "{controller=Home}/{action=Index}/{id?}");

                //  https://localhost:44316/Client/UpdateWithStyling?clientId=1

                // CODE BEWAREN, IK SPRING VOOR HET GEMAK METEEN NAAR DE CLIENTEN-LIJST:

                endpoints.MapControllerRoute(
                   name: "default",
                   pattern: "{controller=Client}/{action=Index}/{id?}");

                // CODE BEWAREN, IK SPRING VOOR HET GEMAK METEEN NAAR CLIENT NUMMER 1

                //endpoints.MapControllerRoute(
                //   name: "default",
                //   pattern: "{controller=Client}/{action=UpdateWithStyling}/{clientId=1}");


                endpoints.MapRazorPages();
            });
        }
    }
}
