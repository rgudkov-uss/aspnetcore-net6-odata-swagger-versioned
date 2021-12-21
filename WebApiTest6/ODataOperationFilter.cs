using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

/// <summary>
/// Filter to include OData parameters (ex, $select, $filter, etc) to Swagger.
/// Shows only parameters specified in EnableQueryAttribute.AllowedQueryOptions on a controller's action
/// </summary>
public class ODataOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        if (operation.Parameters == null) operation.Parameters = new List<OpenApiParameter>();

        var descriptor = context.ApiDescription.ActionDescriptor as ControllerActionDescriptor;
        var queryAttr = descriptor?.FilterDescriptors
            .Where(fd => fd.Filter is EnableQueryAttribute)
            .Select(fd => fd.Filter as EnableQueryAttribute)
            .FirstOrDefault();

        if (queryAttr == null)
            return;

        if (queryAttr.AllowedQueryOptions.HasFlag(AllowedQueryOptions.Select))
            operation.Parameters.Add(new OpenApiParameter()
            {
                Name = "$select",
                In = ParameterLocation.Query,
                Schema = new OpenApiSchema
                {
                    Type = "string",
                },
                Required = false
            });

        if (queryAttr.AllowedQueryOptions.HasFlag(AllowedQueryOptions.Expand))
            operation.Parameters.Add(new OpenApiParameter()
            {
                Name = "$expand",
                In = ParameterLocation.Query,
                Schema = new OpenApiSchema
                {
                    Type = "string",
                },
                Required = false
            });


        if (queryAttr.AllowedQueryOptions.HasFlag(AllowedQueryOptions.Filter))
            operation.Parameters.Add(new OpenApiParameter()
            {
                Name = "$filter",
                In = ParameterLocation.Query,
                Schema = new OpenApiSchema
                {
                    Type = "string",
                },
                Required = false
            });


        if (queryAttr.AllowedQueryOptions.HasFlag(AllowedQueryOptions.Top))
            operation.Parameters.Add(new OpenApiParameter()
            {
                Name = "$top",
                In = ParameterLocation.Query,
                Schema = new OpenApiSchema
                {
                    Type = "string",
                },
                Required = false
            });

        if (queryAttr.AllowedQueryOptions.HasFlag(AllowedQueryOptions.Skip))
            operation.Parameters.Add(new OpenApiParameter()
            {
                Name = "$skip",
                In = ParameterLocation.Query,
                Schema = new OpenApiSchema
                {
                    Type = "string",
                },
                Required = false
            });


        if (queryAttr.AllowedQueryOptions.HasFlag(AllowedQueryOptions.OrderBy))
            operation.Parameters.Add(new OpenApiParameter()
            {
                Name = "$orderby",
                In = ParameterLocation.Query,
                Schema = new OpenApiSchema
                {
                    Type = "string",
                },
                Required = false
            });

        if (queryAttr.AllowedQueryOptions.HasFlag(AllowedQueryOptions.Count))
            operation.Parameters.Add(new OpenApiParameter()
            {
                Name = "$count",
                In = ParameterLocation.Query,
                Schema = new OpenApiSchema
                {
                    Type = "boolean",
                },
                Required = false,
            });
    }
}
