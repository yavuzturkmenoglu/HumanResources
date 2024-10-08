﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace HumanResources.Api.Utility.Extensions
{
    public static class SwaggerAuthExtension
    {
        private static readonly string authType = "Bearer JWT";

        private static readonly OpenApiSecurityRequirement requirement = new()
        {{
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = authType
                }
            },
            new string[]{}
        }};

        private static readonly OpenApiSecurityScheme scheme = new()
        {
            In = ParameterLocation.Header,
            Description = "Please enter a valid token",
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Scheme = "Bearer"
        };

        public static void AddJWTAuth(this SwaggerGenOptions option)
        {
            option.AddSecurityDefinition(authType, scheme);
            option.OperationFilter<SecurityRequirementsOperationFilter>();
        }

        public static void AddSwaggerGenWithJWTAuth(this IServiceCollection services)
        {
            services.AddSwaggerGen(opt => opt.AddJWTAuth());
        }

        private class SecurityRequirementsOperationFilter : IOperationFilter
        {
            public void Apply(OpenApiOperation operation, OperationFilterContext context)
            {
                var containsAuthorizeAttribute = context.MethodInfo.GetCustomAttributes(true).Any(x => x is AuthorizeAttribute) || (context.MethodInfo.DeclaringType?.GetCustomAttributes(true).Any(x => x is AuthorizeAttribute) ?? false);
                var containsAllowAnonymous = context.MethodInfo.GetCustomAttributes(true).Any(x => x is AllowAnonymousAttribute);
                if (containsAuthorizeAttribute && !containsAllowAnonymous)
                {
                    operation.Security = new List<OpenApiSecurityRequirement>
                    {
                        requirement
                    };
                }
            }
        }
    }
}
