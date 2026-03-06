 var builder =WebApplication.CreateBuilder(args);
 builder.Services.AddScoped<IProductService, ProductServices>();// register the service with di 
    builder.Services.AddControllers(); // add controller services to the container
var app = builder.Build();
app.MapControllers(); // map controller routes
app.Run();


