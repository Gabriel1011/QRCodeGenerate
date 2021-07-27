using Microsoft.Extensions.DependencyInjection;
using QRCodeGenerate.Services;
using QRCodeGenerator.Services;

namespace QRCodeGenerate.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            services.AddTransient<TokenService, TokenService>();
            services.AddTransient<QrCodeGeneratorService, QrCodeGeneratorService>();
        }
    }
}
