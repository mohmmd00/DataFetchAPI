using AM.Configuration;
using DotNetEnv;
using SM.Configuration;

var builder = WebApplication.CreateBuilder(args);



//loading env file 
Env.TraversePath().Load();
var ConnectionString01 = System.Environment.GetEnvironmentVariable("CONNECTION_STRING01");
var ConnectionString02 = System.Environment.GetEnvironmentVariable("CONNECTION_STRING02");




// Add services to the container.
StoreManagementBootstrapper.Configure(builder.Services , ConnectionString01);
AccountManagementBootstrapper.Configure(builder.Services, ConnectionString02);
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
