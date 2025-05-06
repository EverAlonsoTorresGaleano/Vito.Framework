using Asp.Versioning;
using Asp.Versioning.Builder;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.FeatureManagement;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using OpenTelemetry;
using OpenTelemetry.Metrics;
using OpenTelemetry.Trace;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using System.Text.Unicode;
using Vito.Framework.Api.Swagger;
using Vito.Framework.Common.Constants;
using Vito.Framework.Common.Options;

namespace Vito.Framework.Api.Extensions;

// Adds common .NET Aspire services: service discovery, resilience, health checks, and OpenTelemetry.
// This project should be referenced by each service project in your solution.
// To learn more about using this project, see https://aka.ms/dotnet/aspire/service-defaults
public static class ApiDefaultsExtensions
{

    #region Pre-Build
    public static IHostApplicationBuilder AddPreBuildServiceDefaults(this IHostApplicationBuilder builder)
    {
        builder.ConfigureOpenTelemetry();

        builder.AddDefaultHealthChecks();

        builder.Services.AddServiceDiscovery();

        builder.AddDefaultHttpJsonOptions();

        builder.AddDefaultApiVersioning();

        builder.AddSwaggerInfo();

        builder.AddFeatureManagement();

        builder.Services.ConfigureHttpClientDefaults(http =>
        {
            // Turn on resilience by default
            http.AddStandardResilienceHandler();

            // Turn on service discovery by default
            http.AddServiceDiscovery();
        });

        builder.Services.AddOptions();
        return builder;
    }

    public static void AddServiceForMemoryCache(this IHostApplicationBuilder builder, int expirationScanFrequencyInSeconds)
    {
        builder.Services.AddMemoryCache(options =>
        {
            options.ExpirationScanFrequency = TimeSpan.FromSeconds(expirationScanFrequencyInSeconds);
        });
    }

    public static IHostApplicationBuilder ConfigureOpenTelemetry(this IHostApplicationBuilder builder)
    {
        builder.Logging.AddOpenTelemetry(logging =>
        {
            logging.IncludeFormattedMessage = true;
            logging.IncludeScopes = true;
        });

        builder.Services.AddOpenTelemetry()
            .WithMetrics(metrics =>
            {
                metrics.AddAspNetCoreInstrumentation()
                    .AddHttpClientInstrumentation()
                    .AddRuntimeInstrumentation();
            })
            .WithTracing(tracing =>
            {
                tracing.AddAspNetCoreInstrumentation()
                    // Uncomment the following line to enable gRPC instrumentation (requires the OpenTelemetry.Instrumentation.GrpcNetClient package)
                    //.AddGrpcClientInstrumentation()
                    .AddHttpClientInstrumentation();
            });

        builder.AddOpenTelemetryExporters();

        return builder;
    }

    private static IHostApplicationBuilder AddOpenTelemetryExporters(this IHostApplicationBuilder builder)
    {
        var useOtlpExporter = !string.IsNullOrWhiteSpace(builder.Configuration["OTEL_EXPORTER_OTLP_ENDPOINT"]);

        if (useOtlpExporter)
        {
            builder.Services.AddOpenTelemetry().UseOtlpExporter();
        }

        // Uncomment the following lines to enable the Azure Monitor exporter (requires the Azure.Monitor.OpenTelemetry.AspNetCore package)
        //if (!string.IsNullOrEmpty(builder.Configuration["APPLICATIONINSIGHTS_CONNECTION_STRING"]))
        //{
        //    builder.Services.AddOpenTelemetry()
        //       .UseAzureMonitor();
        //}

        return builder;
    }

    public static IHostApplicationBuilder AddDefaultHealthChecks(this IHostApplicationBuilder builder)
    {
        builder.Services.AddHealthChecks()
            // Add a default liveness check to ensure app is responsive
            .AddCheck("self", () => HealthCheckResult.Healthy(), ["live"]);

        return builder;
    }



    public static IHostApplicationBuilder AddDefaultHsts(this IHostApplicationBuilder builder, bool enableHsts = true)
    {
        if (enableHsts)
        {
            builder.Services.AddHsts(options =>
            {
                options.Preload = true;
                options.IncludeSubDomains = true;
                options.MaxAge = TimeSpan.FromDays(365);
            });
        }
        return builder;
    }

    public static IHostApplicationBuilder AddDefaultHttpJsonOptions(this IHostApplicationBuilder builder)
    {
        builder.Services.ConfigureHttpJsonOptions(static options =>
        {
            options.SerializerOptions.PropertyNameCaseInsensitive = true;
            options.SerializerOptions.TypeInfoResolverChain.Add(new DefaultJsonTypeInfoResolver().WithAddedModifier(ApiJsonExtensions.AddNativePolymorphicTypInfo));
            options.SerializerOptions.TypeInfoResolver = new DefaultJsonTypeInfoResolver().WithAddedModifier(ApiJsonExtensions.AddNativePolymorphicTypInfo);
            options.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            options.SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            options.SerializerOptions.WriteIndented = true;
            options.SerializerOptions.IncludeFields = true;
            options.SerializerOptions.Encoder = JavaScriptEncoder.Create(UnicodeRanges.All);
            options.SerializerOptions.AllowTrailingCommas = true;
            options.SerializerOptions.NumberHandling = JsonNumberHandling.AllowReadingFromString;
            options.SerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        });
        return builder;
    }

    public static IHostApplicationBuilder AddDefaultApiVersioning(this IHostApplicationBuilder builder)
    {
        builder.Services.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new ApiVersion(1.0);
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.ApiVersionReader = new UrlSegmentApiVersionReader();
            options.ReportApiVersions = true;
        }).AddApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'VVV";
            options.SubstituteApiVersionInUrl = true;
        });
        builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();
        return builder;
    }

    public static IHostApplicationBuilder AddSwaggerInfo(this IHostApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen(options =>
        {
            options.UseInlineDefinitionsForEnums();

            //options.DocumentFilter<SwagerGenEnumSchemaFilter>();
            //options.UseAllOfToExtendReferenceSchemas();
            //options.CustomSchemaIds(type => type.ToString());
            //options.UseInlineDefinitionsForEnums();
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
            });
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
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
                    new string[] {}

                }
            });
        });
        return builder;
    }

    public static IHostApplicationBuilder AddFeatureManagement(this IHostApplicationBuilder builder, string FeatureFlagSettings_SectionName = FrameworkConstants.AppSettings_SectionName_FeatureFlagSettings)
    {
        builder.Services.AddFeatureManagement(builder.Configuration.GetSection(FeatureFlagSettings_SectionName));
        return builder;
    }

    public static IHostApplicationBuilder AddCorsOnlyForAuthorizedUrls(this IHostApplicationBuilder builder, string[] authorizedUrls)
    {
        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(p => p.WithOrigins(authorizedUrls)
                .AllowAnyMethod()
                .AllowCredentials()
                .AllowAnyHeader());
        });
        return builder;
    }

    public static IHostApplicationBuilder AddAuthenticationForJwtServer(this IHostApplicationBuilder builder, IdentityServiceServerSettingsOptions serverOptions)
    {
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(serverOptions.Key)),
                ValidIssuer = serverOptions.Issuer,
                ValidAudience = serverOptions.Audience,
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,

                ClockSkew = TimeSpan.Zero,
            };
        });

        return builder;
    }

    public static IHostApplicationBuilder AddAuthenticationForJwtClient(this IHostApplicationBuilder builder, IdentityServiceClientSettingsOptions clientOptions)
    {
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(clientOptions.ServerKey!)),
                ValidIssuer = clientOptions.ServerIssuer,
                ValidAudience = clientOptions.ServerAudience,
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
            };
        });

        return builder;
    }


    public static IHostApplicationBuilder AddSQLServerDbContextPool<T>(this IHostApplicationBuilder builder, ConnectionStringOptions connectionStringOptions) where T : DbContext
    {
        builder.Services.AddDbContextPool<T>(options =>
        {
            options.UseSqlServer(connectionStringOptions!.ConnectionString, sqlOptions =>
            {
                sqlOptions.EnableRetryOnFailure(connectionStringOptions.RetryCount, TimeSpan.FromSeconds(connectionStringOptions.MaxRetryDelay), null);
                sqlOptions.CommandTimeout(connectionStringOptions.TimeOut);
            });
        });
        return builder;
    }

    #endregion

    #region Post-Build 


    public static WebApplication UsePostBuildApplicationDefaults(this WebApplication app)
    {
        return app;
    }

    public static WebApplication UsePostBuildApplicationDefaultsDevelopment(this WebApplication app)
    {
        app.UseSwaggerInfo();
        return app;
    }

    public static ApiVersionSet UseApiVersionSet(this WebApplication app, double currentVersion, List<double> allVersionsList)
    {
        var versionSetBuilder = app.NewApiVersionSet();
        allVersionsList.ForEach(version =>
        {
            versionSetBuilder.HasApiVersion(new ApiVersion(version));
            if (version != currentVersion)
            {
                versionSetBuilder.HasDeprecatedApiVersion(new ApiVersion(version));
            }
        });
        versionSetBuilder.ReportApiVersions();
        var versionSet = versionSetBuilder.Build();
        return versionSet;
    }

    public static WebApplication MapDefaultEndpoints(this WebApplication app)
    {
        // Adding health checks endpoints to applications in non-development environments has security implications.
        // See https://aka.ms/dotnet/aspire/healthchecks for details before enabling these endpoints in non-development environments.
        if (app.Environment.IsDevelopment())
        {
            // All health checks must pass for app to be considered ready to accept traffic after starting
            app.MapHealthChecks("/health");

            // Only health checks tagged with the "live" tag must pass for app to be considered alive
            app.MapHealthChecks("/alive", new HealthCheckOptions
            {
                Predicate = r => r.Tags.Contains("live")
            });
        }

        return app;
    }

    public static WebApplication UseSwaggerInfo(this WebApplication app)
    {
        const string SwaggerRoutePrefix = "api-docs";
        app.UseSwagger(options =>
        {
            options.RouteTemplate = $"{SwaggerRoutePrefix}/{{documentName}}/wadl.json";
        });

        app.UseSwaggerUI(options =>
        {
            options.RoutePrefix = SwaggerRoutePrefix;
            foreach (var description in app.DescribeApiVersions())
            {
                //Web Application Description Language (WADL) 
                var url = $"/{SwaggerRoutePrefix}/{description.GroupName}/wadl.json";
                var name = description.GroupName.ToUpperInvariant();
                options.SwaggerEndpoint(url, name);
            }
        });
        return app;
    }
    #endregion
}