using Microsoft.EntityFrameworkCore;
using SessionService.Context;
using SessionService.Interfaces;
using SessionService.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SessionServiceDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:50421")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddScoped(typeof(ISessionRepository), typeof(SessionRepository));
builder.Services.AddScoped(typeof(IOrganizationRepository), typeof(OrganizationRepository));
builder.Services.AddScoped(typeof(INpcRepository), typeof(NpcRepository));
builder.Services.AddScoped(typeof(ILocationRepository), typeof(LocationRepository));
builder.Services.AddScoped(typeof(ICampaignRepository), typeof(CampaignRepository));
builder.Services.AddScoped(typeof(IPlayerRepository), typeof(PlayerRepository));
builder.Services.AddScoped(typeof(IDMRepository), typeof(DMRepository));
builder.Services.AddScoped(typeof(ICharacterRepository), typeof(CharacterRepository));
builder.Services.AddScoped(typeof(INoteRepository), typeof(NoteRepository));

//builder.Services.AddHttpClient<AuthServiceApiClient>(client =>
//{
//    var authServiceUrl = builder.Configuration.GetSection("AutService:BaseUrl").Value;
//    client.BaseAddress = new Uri(authServiceUrl ?? "http://auth-api:8002");
//});

builder.Services.AddControllersWithViews()
    .AddJsonOptions(options =>
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
