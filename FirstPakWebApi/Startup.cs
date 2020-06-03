using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FirstPakWebApi.Data;
using FirstPakWebApi.IService;
using FirstPakWebApi.Service;
using FirstPakWebApi.Transform;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace FirstPakWebApi
{
    public class Startup
    {

        private readonly IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        /// <summary>
        /// 此方法由运行时调用，使用此方法将服务添加到容器
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
            .AddNewtonsoftJson(options =>
            {
                //options.SerializerSettings.ContractResolver = new DefaultContractResolver();//不使用驼峰样式的key
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver(); //序列化时key为驼峰样式
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;//设置忽略循环引用;
                options.SerializerSettings.DateFormatString = "yyyy/MM/dd";
            });

            #region 数据库连接字符串 && 使用延迟加载
            services.AddDbContext<FirstPakDbContext>(options => options.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("FirstPak")));
            #endregion

            #region 注册配置跨域服务服务
            services.AddCors(options =>
            {
                options.AddPolicy("all",
                builder =>
                {
                    builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });
            #endregion

            #region 注册JWT认证授权服务
            services.AddAuthorization(options =>
            {
                options.AddPolicy(JwtBearerDefaults.AuthenticationScheme, policy =>
                {
                    policy.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme);
                    policy.RequireClaim(ClaimTypes.Role);
                });
            });
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetValue<string>("SecurityKey"))),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            #endregion

            #region 注册配置swagger服务服务
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("1.0.0", new OpenApiInfo { Title = "福斯派API", Version = "1.0.0" });
                // c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "CaseCenter.xml"));
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT  Bearer { token }",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    }, new List<string>()
                }
                });
                // Set the comments path for the Swagger JSON and UI.(为 Swagger JSON and UI设置xml文档注释路径)
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
            #endregion

            #region 注册AutoMapper
            services.AddAutoMapper(typeof(ToViewModelProfile));
            #endregion

            #region 依赖注入
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<IJWTService, JWTService>();
            services.AddScoped<IPostionsService, PostionsService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IEmployeeInfoService, EmployeeInfoService>();
            services.AddScoped<IRoleService, RoleService>();
            #endregion


        }

        /// <summary>
        /// 此方法由运行时调用，使用此方法配置HTTP请求管道
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();//添加鉴权
            app.UseAuthorization();

            //全局跨域服务
            app.UseCors("all");

            //使用swagger服务
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.DocumentTitle = "福斯派API";
                c.SwaggerEndpoint("/swagger/1.0.0/swagger.json", "福斯派API-1.0.0");
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    context.Response.Redirect("/swagger");
                    await context.Response.CompleteAsync();
                });
                endpoints.MapControllers();
            });

        }
    }
}
