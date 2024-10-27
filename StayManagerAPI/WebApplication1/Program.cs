using StayManager.Core.Interfaces;
using StayManager.Core.Services;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

            var builder = WebApplication.CreateBuilder(args);
            var sqlConnection = builder.Configuration["AppConfiguration:ConnectionString"];

            builder.Services.AddSingleton<WebSocketNotificationService>();


            // Add services to the container.
            //builder.Services.AddScoped<IFazerReservaService>(provider => new FazerReservaService(sqlConnection));
            builder.Services.AddTransient<IFazerReservaService>(provider =>
            {
                var notificationService = provider.GetRequiredService<WebSocketNotificationService>();
                var strConnection = sqlConnection;
                return new FazerReservaService(strConnection, notificationService);
            });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                    corsPolicyBuilder =>
                    {
                        corsPolicyBuilder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    });
            });


            // Add services to the container.

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

            app.UseHttpsRedirection();
            app.UseCors(MyAllowSpecificOrigins);

            app.UseWebSockets();
            app.Map("/ws", async (HttpContext context, WebSocketNotificationService notificationService) =>
            {
                if (context.WebSockets.IsWebSocketRequest)
                {
                    var webSocket = await context.WebSockets.AcceptWebSocketAsync();
                    await notificationService.HandleWebSocketAsync(webSocket);
                }
                else
                {
                    context.Response.StatusCode = 400;
                }
            });

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}