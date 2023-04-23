using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Schedule.Api.Controllers;
using Schedule.Api.Infrastructure.AutofacModules;
using Schedule.Api.Infrastructure.Services;
using Schedule.Infrastructure;
using System.Data.Common;
using System.Reflection;

namespace Schedule.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            //loggerFactory.AddAzureWebAppDiagnostics();
            //loggerFactory.AddApplicationInsights(app.ApplicationServices, LogLevel.Trace);

            //var pathBase = Configuration["PATH_BASE"];
            //if (!string.IsNullOrEmpty(pathBase))
            //{
            //    loggerFactory.CreateLogger<Startup>().LogDebug("Using PATH BASE '{pathBase}'", pathBase);
            //    app.UsePathBase(pathBase);
            //}

            //app.UseSwagger()
            //    .UseSwaggerUI(c =>
            //    {
            //        c.SwaggerEndpoint($"{(!string.IsNullOrEmpty(pathBase) ? pathBase : string.Empty)}/swagger/v1/swagger.json", "Ordering.API V1");
            //        c.OAuthClientId("orderingswaggerui");
            //        c.OAuthAppName("Ordering Swagger UI");
            //    });

            app.UseRouting();
            app.UseCors("CorsPolicy");
            //ConfigureAuth(app);

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapGrpcService<OrderingService>();
                endpoints.MapDefaultControllerRoute();
                endpoints.MapControllers();
                //endpoints.MapGet("/_proto/", async ctx =>
                //{
                //    ctx.Response.ContentType = "text/plain";
                //    using var fs = new FileStream(Path.Combine(env.ContentRootPath, "Proto", "basket.proto"), FileMode.Open, FileAccess.Read);
                //    using var sr = new StreamReader(fs);
                //    while (!sr.EndOfStream)
                //    {
                //        var line = await sr.ReadLineAsync();
                //        if (line != "/* >>" || line != "<< */")
                //        {
                //            await ctx.Response.WriteAsync(line);
                //        }
                //    }
                //});
                //endpoints.MapHealthChecks("/hc", new HealthCheckOptions()
                //{
                //    Predicate = _ => true,
                //    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                //});
                //endpoints.MapHealthChecks("/liveness", new HealthCheckOptions
                //{
                //    Predicate = r => r.Name.Contains("self")
                //});
            });

            //ConfigureEventBus(app);
        }

        public virtual IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services
                .AddCustomMvc()
                      //.AddHealthChecks(Configuration)
                .AddCustomIntegrations(Configuration)
                .AddCustomDbContext(Configuration);
            //.AddGrpc(options =>
            //{
            //    options.EnableDetailedErrors = true;
            //})
            //.Services
            //    .AddApplicationInsights(Configuration)
            //    .AddCustomMvc()
            //    .AddHealthChecks(Configuration)

            //.AddCustomSwagger(Configuration)
            //.AddCustomAuthentication(Configuration)
            //.AddCustomAuthorization(Configuration)
              
            //    .AddCustomConfiguration(Configuration)
            //    .AddEventBus(Configuration);
            //configure autofac

            var container = new ContainerBuilder();
            container.Populate(services);

            container.RegisterModule(new MediatorModule());
            container.RegisterModule(new ApplicationModule(Configuration["ConnectionString"]));

            return new AutofacServiceProvider(container.Build());
        }
    }
    static class CustomExtensionsMethods
    {
        public static IServiceCollection AddCustomMvc(this IServiceCollection services)
        {
            // Add framework services.
            services.AddControllers(options =>
            {
                //options.Filters.Add(typeof(HttpGlobalExceptionFilter));
            })
                // Added for functional tests
                //.AddApplicationPart(typeof(CalendarController).Assembly)
                .AddJsonOptions(options => options.JsonSerializerOptions.WriteIndented = true);

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                    .SetIsOriginAllowed((host) => true)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            return services;
        }
        public static IServiceCollection AddCustomIntegrations(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IIdentityService, IdentityService>();
            //services.AddTransient<Func<DbConnection, IIntegrationEventLogService>>(
            //    sp => (DbConnection c) => new IntegrationEventLogService(c));

            //services.AddTransient<IOrderingIntegrationEventService, OrderingIntegrationEventService>();

            //if (configuration.GetValue<bool>("AzureServiceBusEnabled"))
            //{
            //    services.AddSingleton<IServiceBusPersisterConnection>(sp =>
            //    {
            //        var serviceBusConnectionString = configuration["EventBusConnection"];

            //        var subscriptionClientName = configuration["SubscriptionClientName"];

            //        return new DefaultServiceBusPersisterConnection(serviceBusConnectionString);
            //    });
            //}
            //else
            //{
            //    services.AddSingleton<IRabbitMQPersistentConnection>(sp =>
            //    {
            //        var logger = sp.GetRequiredService<ILogger<DefaultRabbitMQPersistentConnection>>();


            //        var factory = new ConnectionFactory()
            //        {
            //            HostName = configuration["EventBusConnection"],
            //            DispatchConsumersAsync = true
            //        };

            //        if (!string.IsNullOrEmpty(configuration["EventBusUserName"]))
            //        {
            //            factory.UserName = configuration["EventBusUserName"];
            //        }

            //        if (!string.IsNullOrEmpty(configuration["EventBusPassword"]))
            //        {
            //            factory.Password = configuration["EventBusPassword"];
            //        }

            //        var retryCount = 5;
            //        if (!string.IsNullOrEmpty(configuration["EventBusRetryCount"]))
            //        {
            //            retryCount = int.Parse(configuration["EventBusRetryCount"]);
            //        }

            //        return new DefaultRabbitMQPersistentConnection(factory, logger, retryCount);
            //    });
            //}

            return services;
        }

        public static IServiceCollection AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ScheduleContext>(options =>
            {
                options.UseSqlServer(configuration["ConnectionString"],
                    sqlServerOptionsAction: sqlOptions =>
                    {
                        sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
                        sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                    });
            },
                        ServiceLifetime.Scoped  //Showing explicitly that the DbContext is shared across the HTTP request scope (graph of objects started in the HTTP request)
                    );

            // Should use with Integration Events 
            //services.AddDbContext<IntegrationEventLogContext>(options =>
            //{
            //    options.UseSqlServer(configuration["ConnectionString"],
            //                            sqlServerOptionsAction: sqlOptions =>
            //                            {
            //                                sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
            //                                //Configuring Connection Resiliency: https://docs.microsoft.com/en-us/ef/core/miscellaneous/connection-resiliency 
            //                                sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
            //                            });
            //});

            return services;
        }
    }
}
