// namespace Schedule.Api;
// public static class Startup
// {
// public static IServiceCollection AddCustomAuthentication(this IServiceCollection services, IConfiguration configuration)
//     {
//         // prevent from mapping "sub" claim to nameidentifier.
//         JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("sub");

//         var identityUrl = configuration.GetValue<string>("IdentityUrl");

//         services.AddAuthentication("Bearer").AddJwtBearer(options =>
//         {
//             options.Authority = identityUrl;
//             options.RequireHttpsMetadata = false;
//             options.Audience = "orders";
//             options.TokenValidationParameters.ValidateAudience = false;
//         });

//         return services;
//     }
//     public static IServiceCollection AddCustomAuthorization(this IServiceCollection services, IConfiguration configuration)
//     {
//         services.AddAuthorization(options =>
//         {
//             options.AddPolicy("ApiScope", policy =>
//             {
//                 policy.RequireAuthenticatedUser();
//                 policy.RequireClaim("scope", "orders");
//             });
//         });
//         return services;
//     }

// }