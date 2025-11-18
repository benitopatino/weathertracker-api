namespace weatherapp_api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        // cors
        
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAngularDevClient", policy =>
            {
                policy
                    .WithOrigins(
                        "http://localhost:4200",  
                        "https://localhost:4200"   
                    )
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });

        // Add services to the container.

        builder.Services.AddControllers();

        var app = builder.Build();

        // Configure the HTTP request pipeline.

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.UseCors("AllowAngularDevClient");
        app.MapControllers();

        app.Run();
    }
}
