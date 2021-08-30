using Microsoft.Extensions.DependencyInjection;
using Shop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.API.Core
{
    public static class ContExtn
    {



        public static void AddJwt(this IServiceCollection services, AppSettings appSettings)
        {
            services.AddTransient<JWTManager>(x =>
            {
                var context = x.GetService<ShopContext>();

                return new JWTManager(context, appSettings.JwtIssuer, appSettings.JwtSecretKey);
            });

         //   services.AddAuthentication(options =>
           // {
              //  options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
           //     options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
           //     options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
          //  }).AddJwtBearer(cfg =>
         //   {
         //       cfg.RequireHttpsMetadata = false;
          //      cfg.SaveToken = true;
          //      cfg.TokenValidationParameters = new TokenValidationParameters
          //      {
           //         ValidIssuer = appSettings.JwtIssuer,
           //         ValidateIssuer = true,
           //         ValidAudience = "Any",
           //         ValidateAudience = true,
           //         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appSettings.JwtSecretKey)),
            //        ValidateIssuerSigningKey = true,
            //        ValidateLifetime = true,
            //        ClockSkew = TimeSpan.Zero
            //    };
          //  });
        }
    }

}
