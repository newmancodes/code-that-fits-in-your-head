using Restaurant.RestAPI.Domain;

namespace Restaurant.RestAPI;

public sealed class Startup
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();

        services.AddSingleton<IReservationRepository>(new NullRepository());
    }

    public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }

    private class NullRepository : IReservationRepository
    {
        public Task Create(Reservation reservation)
        {
            return Task.CompletedTask;
        }
    }
}