namespace ApiTraining.Extensions;

using Abstractions;

public static class ApplicationMiddlewares
{

    public static void ConfigureApplicationMiddlewares(this WebApplication app, IWebHostEnvironment environment, ILoggerManager? logger)
    {
        if (environment.IsDevelopment())
            app.UseDeveloperExceptionPage();
        else
            app.UseHsts();

        app.ConfigureExceptionHandler(logger);
        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseCors("CorsPolicy");

        app.UseRouting();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

    }
}