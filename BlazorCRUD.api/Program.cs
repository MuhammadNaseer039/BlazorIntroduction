using BlazorCRUD.api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorCRUD.api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var connection = builder.Configuration.GetConnectionString("myconstring");
            builder.Services.AddDbContext<Datadbcontext>(options=>options.UseSqlServer(connection));

            builder.Services.AddCors(options => options.AddPolicy("BlazorCRUDPolicy", policyBuilder =>
            {
                policyBuilder.WithOrigins("https://localhost:7072");
                policyBuilder.AllowAnyHeader();
                policyBuilder.AllowAnyMethod();
            }));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("BlazorCRUDPolicy");

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
