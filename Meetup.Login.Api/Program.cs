using Meetup.Auth.Common;
using Meetup.Login.Api.Data;
using Meetup.Login.Api.Interfaces;
using Meetup.Login.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<ILoginService, LoginService>();
builder.Services.AddTransient<IUserRepository, UserRepository>();


builder.Services.Configure<AuthOptions>(builder.Configuration.GetSection("Auth"));

builder.Services.AddDbContext<DataContext>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

using var scope = app.Services.CreateScope();
DataContext context = scope.ServiceProvider.GetRequiredService<DataContext>();
await DbInitializer.SeedData(context);

app.MapControllers();

app.Run();
