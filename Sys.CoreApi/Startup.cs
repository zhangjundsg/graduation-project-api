using Autofac;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Sys.CoreApi.AutoFuc;
using Sys.CoreApi.SetUpApiService;
using Sys.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;
using System.Threading.Tasks;

namespace Sys.CoreApi
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
            services.Configure<TokenManagement>(Configuration.GetSection("tokenConfig"));

            var token = Configuration.GetSection("tokenConfig").Get<TokenManagement>();
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    //��ȡ������Ҫʹ�õ�Microsoft.IdentityModel.Tokens.SecurityKey����ǩ����֤��
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.
                    GetBytes(token.Secret)),
                    //��ȡ������һ��System.String������ʾ��ʹ�õ���Ч�����߼����ҵķ����ߡ�
                    ValidIssuer = token.Issuer,
                    //��ȡ������һ���ַ��������ַ�����ʾ�����ڼ�����Ч�����Ƶ������ߡ�
                    ValidAudience = token.Audience,
                };
            });

            //ע��swagger����
            services.AddSwaggerSetup();

        }
        //autofucע��
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new AutoFacModule());
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/V1/swagger.json","System Api V1");
                c.RoutePrefix = "";
            });
            app.UseAuthentication();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
