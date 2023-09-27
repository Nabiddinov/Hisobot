using Report.API.Extensions;
using Report.API.Middlewares;

namespace Report.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services
            .AddDbContexts(builder.Configuration)
            .AddAuthentication(builder.Configuration)
            .AddInfrastructure()
            .AddApplication()
            .AddSwagger()
            .AddControllerMapping();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseMiddleware<GlobalExceptionHandlingMiddleware>();
        app.MapControllers();

        app.Run();
    }
}

