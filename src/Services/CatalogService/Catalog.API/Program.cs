using Catalog.API.Context;
using Catalog.API.Services;
using MassTransit;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddMassTransit(options =>
{
    options.AddEntityFrameworkOutbox<ApplicationDbContext>(x =>
    {
        x.QueryDelay = TimeSpan.FromSeconds(10);
        x.UsePostgres();
        x.UseBusOutbox();
    });

    options.SetEndpointNameFormatter(new KebabCaseEndpointNameFormatter("product", false));
    options.UsingRabbitMq((context, config) =>
    {
        config.Host("localhost", "/", host =>
        {
            host.Username("guest");
            host.Password("guest");
        });
        config.ConfigureEndpoints(context);
    });
});

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
