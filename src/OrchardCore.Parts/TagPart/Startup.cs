using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Handlers;
using OrchardCore.ContentTypes.Editors;
using OrchardCore.Data.Migration;
using OrchardCore.Indexing;
using OrchardCore.Modules;
using System;
using Tags.OrchardCore.Drivers;
using Tags.OrchardCore.Handlers;
using Tags.OrchardCore.Indexing;
using Tags.OrchardCore.Models;
using Tags.OrchardCore.Settings;

namespace Tags.OrchardCore
{
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IContentPartDisplayDriver, TagsPartDisplayDriver>();
            services.AddSingleton<ContentPart, TagsPart>();
            services.AddScoped<IContentPartDefinitionDisplayDriver, TagsPartSettingsDisplayDriver>();
            services.AddScoped<IContentPartIndexHandler, TagsIndexHandler>();
            services.AddScoped<IDataMigration, Migrations>();
            services.AddScoped<IContentPartHandler, TagsPartHandler>();
        }

        public override void Configure(IApplicationBuilder app, IEndpointRouteBuilder routes, IServiceProvider serviceProvider)
        {
            routes.MapAreaControllerRoute(
                name: "Home",
                areaName: "Tags.OrchardCore",
                pattern: "Home/Index",
                defaults: new { controller = "Home", action = "Index" }
            );
        }
    }
}