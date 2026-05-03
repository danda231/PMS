using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PMS.Server.Entities;
using PMS.Server.IService;
using PMS.Server.Service;
using SqlSugar;
using System.Text;

namespace PMS.ServerInitial
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            RegistarClasses(builder.Services);
            
            // ����?
            ConfigAuthentication(builder.Services);

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthentication();
            app.UseAuthorization();
            

            app.MapControllers();

            app.Run();
        }

        private static void RegistarClasses(IServiceCollection services)
        {
            // 数据库绑定
            services.AddTransient<ISqlSugarClient>(client =>
            {
                string strConn = "Server=localhost;Port=3306;Database=PMS;Uid=root;Pwd=dd425235;Charset=utf8mb4;";
                ConnectionConfig config = new ConnectionConfig()
                {
                    DbType = DbType.MySql,
                    ConnectionString = strConn,
                    IsAutoCloseConnection = true
                };
                return new SqlSugarClient(config);
            });

            // 做好绑定
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<IRoleService, RoleService>();
        }

        private static void ConfigAuthentication(IServiceCollection services)
        {
            services
                .AddAuthentication(a =>
                {
                    a.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    a.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(jwt =>
                {
                    jwt.RequireHttpsMetadata = false;
                    jwt.SaveToken = true;
                    jwt.UseSecurityTokenValidators = true;
                    jwt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("123456123456123456luckyeggluckyegg")),
                        ValidIssuer = "webapi.cn",
                        ValidAudience = "WebApi",
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        // 与当前 JwtSecurityToken 签发方式配合，避免部分环境下被误判为“无过期时间”
                        ValidateLifetime = false
                    };

                    jwt.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            var authHeader = context.Request.Headers["Authorization"].ToString();

                            if (!string.IsNullOrEmpty(authHeader) && authHeader.StartsWith("Bearer "))
                            {
                                context.Token = authHeader.Substring("Bearer ".Length).Trim();
                            }

                         
                            return Task.CompletedTask;
                        },
                        OnAuthenticationFailed = context =>
                        {
                            
                            return Task.CompletedTask;
                        },
                        OnTokenValidated = context =>
                        {
                            
                            return Task.CompletedTask;
                        }
                    };
                });

            // ����Swgger��?
            services.AddSwaggerGen(option =>
            {
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "???token,??? Bearer xxxxxxxx",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"
                });

                option.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[]{}
                    }
                });
                
            });

            

        }
    }
}
