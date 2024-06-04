using DotNetEnv;
using SM.Configuration;

var builder = WebApplication.CreateBuilder(args);



//loading env file 
Env.TraversePath().Load();
var ConnectionString = System.Environment.GetEnvironmentVariable("CONNECTION_STRING");




// Add services to the container.
StoreManagementBootstrapper.Configure(builder.Services , ConnectionString);
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
