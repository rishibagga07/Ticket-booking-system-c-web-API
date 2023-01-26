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
using Ticket_Booking_system.Data;
using Ticket_Booking_system.DTOMapping;
using Ticket_Booking_system.Model;
using Ticket_Booking_system.Repository;
using Ticket_Booking_system.Repository.IRepository;

namespace Ticket_Booking_system
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


            string cs = Configuration.GetConnectionString("constr");
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(cs));
            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));
            services.AddTransient<IMailService, MailService>();




            //services.AddDistributedSqlServerCache(options =>
            //{
            //    options.ConnectionString = "connection-string-to-sql-server";
            //    options.SchemaName = "schema-name";
            //    options.TableName = "table-name";
            //});

            // Add the session service
            //services.AddSession();





            services.AddAutoMapper(typeof(MappingProfile));
            services.AddControllers();
                
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ticket_Booking_system", Version = "v1" });
            });


            services.AddCors(options => {
                options.AddPolicy(name: "MyPolicy",
                    builder =>
                    {
                        builder.WithOrigins("https://localhost:44351/")
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();

                    });

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ticket_Booking_system v1"));
            }

            app.UseCors("MyPolicy");
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
