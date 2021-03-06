using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Net.Mail;
using Abp.Net.Mail.Smtp;
using Lucene.Net.Support;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Shop.Application.Commands;
using Shop.Application.Queries;
using Shop.Implementation.Queries;
using Shop.DataAccess;
using Shop.Implementation.Commands;
using Shop.Implementation.Commands.OrderStatusCommands;
using Shop.Implementation.Validations;
using Shop.Application.Mail;
using Shop.Implementation.SMTPMail;
using Shop.Application;
using Microsoft.AspNetCore.Http;
using Shop.API.Core;
using Newtonsoft.Json;

namespace Shop.API
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
            services.AddControllers();
            var appSettings = new AppSettings();
            Configuration.Bind(appSettings);

            services.AddTransient<ICreateOrderStatus, CrateOrderStatusCommand>();
            services.AddTransient<ShopContext>();
            services.AddTransient<ICreateCategoryCommand, CreateCategoryCommand>();
            services.AddTransient<CategoryVal>();

            services.AddTransient<IGetBrends,GetBrendsQuery >();
            services.AddTransient<IGetLogsQuery, GetLogsQuery>();
            services.AddTransient<IGetProducts, GetProducts>();
            services.AddTransient<IGetBrends, IGetBrends>();

            services.AddTransient<NewProdVal>();
            services.AddTransient<BrendVal>();
            services.AddTransient<CategoryVal>();
            services.AddTransient<RegisterVal>();
            services.AddTransient<OrderVal>();
            // services.AddTransient<IMailSender, SmtpEmailSender>(x => new SMPTMail(AppSettings.EmailFrom, appSettings.EmailPassword));

            services.AddTransient<IAppActor>(x =>
            {
                var accessor = x.GetService<IHttpContextAccessor>();


                var user = accessor.HttpContext.User;

                if (user.FindFirst("ActorData") == null)
                {
                    return new UnauthrorizedActor();
                }

                var actorString = user.FindFirst("ActorData").Value;

                var actor = JsonConvert.DeserializeObject<JwtActor>(actorString);

                return actor;

            });
            services.AddJwt(appSettings);




            services.AddTransient<IGetCategories, GetCatsQuery>();
            services.AddTransient<IGetBrends, GetBrendsQuery>();
            services.AddTransient<IGetLogsQuery, GetLogsQuery>();
            services.AddTransient<IGetProducts, GetProducts>();
            services.AddTransient<IGetOrdersQuery, GetOrdersQuery>();
            services.AddTransient<IGetLogsQuery, GetLogsQuery>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
