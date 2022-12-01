namespace DemoApplication.Infrastructure.Configurations
{
    public static class MvcConfigurations
    {
        public static void ConfigureMvc(this IServiceCollection services)
        {
            services
               .AddMvc()
               .AddRazorRuntimeCompilation();
        }
    }
}
