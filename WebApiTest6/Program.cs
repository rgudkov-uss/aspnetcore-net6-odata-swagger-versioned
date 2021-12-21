using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData;
using Microsoft.AspNetCore.OData.Batch;
using Microsoft.AspNetCore.OData.NewtonsoftJson;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;
using WebApiTest6;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var model1 = EdmBuilder.BuildV1();
var model2 = EdmBuilder.BuildV2();

builder.Services
    .AddControllers()
    .AddODataNewtonsoftJson()
    .AddOData(options =>
    {
        var defaultBatchHandler = new DefaultODataBatchHandler();
        defaultBatchHandler.MessageQuotas.MaxNestingDepth = 2;
        defaultBatchHandler.MessageQuotas.MaxOperationsPerChangeset = 10;
        defaultBatchHandler.MessageQuotas.MaxReceivedMessageSize = 100;

        options.Select().Filter().OrderBy().Count().SetMaxTop(5000).Expand();
        options.AddRouteComponents("api/v1", model1, defaultBatchHandler);
        options.AddRouteComponents("api/v2", model2);
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Weather API",
        Description = "A simple example ASP.NET Core Web API",
    });
    options.SwaggerDoc("v2", new OpenApiInfo
    {
        Version = "v2",
        Title = "Weather API",
        Description = "A simple example ASP.NET Core Web API",
    });

    // maps api/v1 to v1. skips /$metadata, /$count
    options.DocInclusionPredicate((docName, apiDesc) =>
    {
        if (apiDesc.RelativePath.Contains('$')) return false;
        if (!apiDesc.TryGetMethodInfo(out MethodInfo methodInfo)) return false;

        var routeAttrs = methodInfo.DeclaringType
            .GetCustomAttributes(true)
            .OfType<ODataRouteComponentAttribute>();
        var versions = routeAttrs.Select(i => i.RoutePrefix.Split('/').Last());
        return versions.Any(v => string.Equals(v, docName, StringComparison.CurrentCultureIgnoreCase));
    });

    options.CustomSchemaIds(type => type.FullName);
    options.OperationFilter<ODataOperationFilter>();
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseODataRouteDebug();
}


app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.SwaggerEndpoint("/swagger/v2/swagger.json", "v2");
    options.RoutePrefix = string.Empty;

    options.DefaultModelsExpandDepth(-1); // hides schemas dropdown
    options.EnableTryItOutByDefault();
});

app.UseODataBatching();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


