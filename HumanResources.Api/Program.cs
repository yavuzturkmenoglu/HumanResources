using HumanResources.Api.Utility.Extensions;
using HumanResources.Api.Utility.Middlewares;
using HumanResources.Business.Utility.Extensions;
using HumanResources.Core.Constants;
using HumanResources.Data.Internal.AppSettings;
using HumanResources.DataAccess.Utility;
using HumanResources.DataAccess.Utility.Extensions;
using Microsoft.OpenApi.Models;
using Serilog;

namespace HumanResources.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var appSettings = new AppSettings();
            builder.Configuration.Bind(appSettings);
            builder.Services.AddSingleton(appSettings);

            #region Logger Configuration
            builder.Host.UseSerilog((ctx, lc) =>
            {
                lc.ReadFrom.Configuration(ctx.Configuration);
            });
            #endregion

            #region Layer Extensions
            builder.Services.AddBusinessServices();
            builder.Services.AddDataAccessServices(appSettings.ConnectionStrings.Database);
            #endregion

            builder.Services.AddCors();

            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });

            builder.Services.AddRouting(options => options.LowercaseUrls = true);

            builder.Services.AddHttpContextAccessor();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(appSettings.ApplicationName, new OpenApiInfo { Title = appSettings.ApplicationName, Version = "v1" });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.RoutePrefix = string.Empty;
                    c.SwaggerEndpoint($"/swagger/{appSettings.ApplicationName}/swagger.json", $"{appSettings.ApplicationName}.Api");
                });
            }

            #region Middleware
            app.UseMiddleware<RequestLoggerMiddleware>();
            app.UseMiddleware<ExceptionMiddleware>();
            #endregion

            app.UseHttpsRedirection();

            app.UseCors(builder =>
            {
                builder.WithOrigins(appSettings.WebClientUrl)
                    .AllowAnyHeader()
                    .WithMethods(HttpRequestMethod.Get, HttpRequestMethod.Post, HttpRequestMethod.Put, HttpRequestMethod.Patch, HttpRequestMethod.Delete)
                    .AllowCredentials();
            });

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();
            app.Run();

            //Apply migrations 
            MigrationHelper.UpdateDatabase(appSettings.ConnectionStrings.Database);
        }
    }
}
