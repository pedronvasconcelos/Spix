
using Spix.Api.Configuration;

using Spix.Application.Spixers.Create;

namespace Spix.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.ConfigureDbContext(builder.Configuration); 
        builder.Services.AddRepositories();
        builder.Services.AddServices();
        builder.Services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(typeof(CreateSpixerCommand).Assembly);
        });

        builder.Services.AddEventBus();
        builder.Services.AddBackgroundJobs();
        builder.Services.BindAppSettings(builder.Configuration);        
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}