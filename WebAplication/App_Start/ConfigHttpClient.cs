using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAplication
{
    public static class ConfigHttpClient
    {
        public static IServiceCollection AddConfigHttpClient(this IServiceCollection services, IConfiguration Configuration)
        {

            return services;
        }


    }
}
