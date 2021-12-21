using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

namespace WebApiTest6
{
    public static class EdmBuilder
    {
        public static IEdmModel BuildV1()
        {
            var builder = new ODataConventionModelBuilder();

            builder.EntitySet<Models.V1.WeatherForecast>("WeatherForecast");

            return builder.GetEdmModel();
        }

        public static IEdmModel BuildV2()
        {
            var builder = new ODataConventionModelBuilder();

            builder.EntitySet<Models.V2.WeatherForecast>("WeatherForecast");

            return builder.GetEdmModel();
        }
    }
}