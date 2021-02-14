using System;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MagicOnionMac.Server
{
    public class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddGrpc();
            services.AddMagicOnion();
        }

        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var magicOnionServiceDefinition =
                app.ApplicationServices.GetService<MagicOnion.Server.MagicOnionServiceDefinition>();
            if (magicOnionServiceDefinition == null)
                throw new NullReferenceException("magicOnionServiceDefinition is null");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapMagicOnionHttpGateway("_", magicOnionServiceDefinition.MethodHandlers, 
                    GrpcChannel.ForAddress("http://localhost:5000"));
                endpoints.MapMagicOnionSwagger("swagger", magicOnionServiceDefinition.MethodHandlers, "/_/");

                endpoints.MapMagicOnionService();

                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
                });
            });
        }
    }
}