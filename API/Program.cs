using Core.CQRS.Examples.Requests;
using Infrastructure; // assuming your AddDbContext extensions live here
using MediatR;
using AutoMapper;
using ShardKernel.Modules.DB.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Infrastructure.Data.Readonly;
using Core.Aggregate.Entities;

namespace API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // 1. Connection string
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnectionString");

        // 2. DbContext and Readonly context (if you have your custom setup)
        builder.Services.AddDbContext(connectionString);
        builder.Services.AddReadonlyDbContext(connectionString);

        // 3. Register MediatR handlers Getting error here
        builder.Services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblyContaining<GetExampleRequest>();
        });

        // 4. Register AutoMapper
        builder.Services.AddAutoMapper(typeof(Program));

        // 5. Register HTTP context accessor
        builder.Services.AddHttpContextAccessor();

        // 6. Register Generic Repository if not already in AddDbContext methods
        builder.Services.AddScoped(typeof(IReadRepository<>), typeof(ReadonlyRepository<>));
        // Add EfReadRepository<> only if your AddDbContext() method doesn’t already register it.

        // 7. API + Swagger
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
        });

        var app = builder.Build();

        // 8. Middleware
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