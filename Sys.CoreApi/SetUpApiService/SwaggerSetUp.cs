using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace Sys.CoreApi.SetUpApiService
{
    public static class SwaggerSetUp
    {
        public static void AddSwaggerSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            var ApiName = "System Api";

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("V1", new OpenApiInfo
                {
                    Version = "V1",
                    Title = $"{ApiName} 接口文档",
                    Description = $"{ApiName} API V1",

                });
                c.OrderActionsBy(o => o.RelativePath);
                // 获取Api xml注释文件的目录
                var xmlPath = Path.Combine(AppContext.BaseDirectory, "Sys.CoreApi.xml");
                c.IncludeXmlComments(xmlPath, true);

                // 获取Model xml注释文件的目录
                var xmlPathModel = Path.Combine(AppContext.BaseDirectory, "Sys.Model.xml");
                c.IncludeXmlComments(xmlPathModel, true);
                //添加设置Token的按钮
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Value: Bearer {token}",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                //添加Jwt验证设置
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                },
                                Scheme = "oauth2",
                                Name = "Bearer",
                                In = ParameterLocation.Header,
                            },
                            new List<string>()
                        }
                    });
            });

        }
    }
}
