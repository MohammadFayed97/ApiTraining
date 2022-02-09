namespace ApiTraining.Extensions;

public static class ApplicationMiddlewares
{

    public static void ConfigureApplicationMiddlewares(this WebApplication app, IWebHostEnvironment environment)
    {
        if (environment.IsDevelopment())
            app.UseDeveloperExceptionPage();
        else
            app.UseHsts();

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