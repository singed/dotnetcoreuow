using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Northwind.DataAccess;
using Northwind.DataAccess.Models;
using Repository.Pattern.DataContext;
using Repository.Pattern.EfCore.Factories;
using Repository.Pattern.Repositories;
using WebApi.DataAccess;
using Repository.Pattern.EfCore;

namespace WebApi
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
            var sqlConnectionString = Configuration.GetConnectionString("DefaultConnection");

            var ops = new DbContextOptionsBuilder().UseSqlServer(sqlConnectionString).Options;

            services.AddDbContext<DbContext>(options =>
                options.UseSqlServer(
                    sqlConnectionString
                )
            );

            services
                .AddTransient<IDataContextAsync, NorthwindDataContext>()
                .AddTransient<IDataContext, NorthwindDataContext>()
                .AddTransient<INorthwindUnitOfWork, NorthwindUnitOfWork>()
                .AddTransient<IRepositoryProvider>(provider => new RepositoryProvider(new RepositoryFactories()))
                .AddTransient<IRepositoryAsync<Product>, Repository<Product>>()
                .AddTransient<IRepositoryAsync<Category>, Repository<Category>>()
                .AddTransient<IRepositoryAsync<Supplier>, Repository<Supplier>>();
            
            //services.AddTransient<NamosDataContext>(provider => new NamosDataContext(ops));
           /* services
               // .AddTransient<IDataContextAsync, NamosDataContext>()
                .AddTransient<INamosDataContext, NamosDataContext>()
                .AddTransient<INamosUnitOfWork, NamosUnitOfWork>()
                .AddTransient<IRepositoryProvider>(provider => new RepositoryProvider(new RepositoryFactories()))
                .AddTransient<IRepositoryAsync<Employee>, Repository<Employee>>();*/


            services.AddMvc().AddJsonOptions(options => {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}