using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Infrastructure.Persistence;
using Domain.Repositories;
using Application.Services;
using Application.Interfaces;
using Infrastructure.Persistence.Config;
using Domain.Entities;

namespace Supermarket
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
            services.Configure<CookiePolicyOptions>(options =>  
            {  
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.  
                options.CheckConsentNeeded = context => true;  
                options.MinimumSameSitePolicy = SameSiteMode.None;  
            });  
            
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-Gb");
            services.AddDbContext<SupermarketDbContext>(options
             => options.UseSqlServer(Configuration.GetConnectionString("Default")));
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

            //Architecture's Infrastructure Repositories
            services.AddScoped(typeof(IRepository<>),typeof(EFRepository<>));
            services.AddScoped<IEmployeeRepository,EmployeeRepository>();
            services.AddScoped<IEmployeeGroupRepository,EmployeeGroupRepository>();
            services.AddScoped<IBrandRepository,BrandRepository>();
            services.AddScoped<ICustomerGroupRepository,CustomerGroupRepository>();
            services.AddScoped<ICustomerRepository,CustomerRepository>();
            services.AddScoped<ICategoryRepository,CategoryRepository>();
            services.AddScoped<IVendorRepository,VendorRepository>();
            services.AddScoped<IProductRepository,ProductRepository>();
            services.AddScoped<IImportingOrderRepository,ImportingOrderRepository>();
            services.AddScoped<IImportingTransactionRepository,ImportingTransactionRepository>();
            services.AddScoped<ISellingOrderRepository, SellingOrderRepository>();
            services.AddScoped<ISellingTransactionRepository, SellingTransactionRepository>();

            //Architecture's Application Services
            services.AddScoped<ICustomerGroupService,CustomerGroupService>();
            services.AddScoped<ICustomerService,CustomerService>();
            services.AddScoped<IBrandService,BrandService>();
            services.AddScoped<IEmployeeService,EmployeeService>();
            services.AddScoped<IEmployeeGroupService,EmployeeGroupService>();
            services.AddScoped<ICategoryService,CategoryService>();
            services.AddScoped<IVendorService,VendorService>();
            services.AddScoped<IProductService,ProductService>();
            services.AddScoped<IImportingOrderService,ImportingOrderService>();
            services.AddScoped<ISellingOrderService, SellingOrderService>();
            //services.AddScoped<ISellingTransactionService, SellingTransactionService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseCookiePolicy(); 
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
