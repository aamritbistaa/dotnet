var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    // builder.Services.AddSingleton<IBreakfastService, BreakfastService>(); //create one object that should be valid for the life time of the application

    // builder.Services.AddScoped<IBreakfastService, BreakfastService>();   - this interface object just for the service

    // builder.Services.AddTransient<IBreakfastService,BreakfastService>(); -create a new breakfast service for request

    builder.Services.AddScoped<IBreakfastService, BreakfastService>();
}
var app = builder.Build();
{
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}