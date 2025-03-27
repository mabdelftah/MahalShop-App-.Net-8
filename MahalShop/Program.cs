
using Infrastructure_Layer;
using MahalShop.ApplicationLayer.Mapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//                              options.UseSqlServer(builder.Configuration.GetConnectionString("DefaulteConnection")));
builder.Services.InfrastructureConfiguration(builder.Configuration);

builder.Services.AddAutoMapper(typeof(MappingProfile));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(corsOptions =>
{
    corsOptions.AddPolicy("MyPolicy", policyBuilder =>
    {
        policyBuilder.AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader();
    });
});





var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("MyPolicy");
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
