using PMS.Server.Entities;
using PMS.Server.IService;
using PMS.Server.Service;
using SqlSugar;

namespace PMS.ServerInitial
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            RegistarClasses(builder.Services);
            
            

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

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }

        private static void RegistarClasses(IServiceCollection services)
        {
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

            // Ìí¼ÓServiceÈÝÆ÷
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IFileService, FileService>(); ;
        }
    }
}
