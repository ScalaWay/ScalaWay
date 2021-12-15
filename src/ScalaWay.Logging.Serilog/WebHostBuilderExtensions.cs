using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucius.Logging.Serilog.Extensions
{
    /// <summary>
    /// https://docs.microsoft.com/fr-fr/dotnet/api/microsoft.extensions.logging.iloggingbuilder?view=dotnet-plat-ext-6.0
    /// </summary>
    public static class WebHostBuilderExtensions
    {
        public static ILoggingBuilder UseSerilog(this ILoggingBuilder builder, IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

            return builder;
        }

    }
}
