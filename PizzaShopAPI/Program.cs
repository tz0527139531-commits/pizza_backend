using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using PizzaShopCore.Mapping;
using PizzaShopCore.Repositiers;
using PizzaShopCore.Services;
using PizzaShopData;
using PizzaShopData.Repositories;
using PizzaShopService;
using System.Text;


System.Globalization.CultureInfo.DefaultThreadCurrentCulture = new System.Globalization.CultureInfo("en-US");
System.Globalization.CultureInfo.DefaultThreadCurrentUICulture = new System.Globalization.CultureInfo("en-US");
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPizzaService, PizzaService>();
builder.Services.AddScoped<IPizzaRepositery, PizzaRepository>();

builder.Services.AddScoped<IOrderService,OrderService>();
builder.Services.AddScoped<IOrderRepositiers,OrderRepository>();

builder.Services.AddScoped<IClientRepositery,ClientRepository>();
builder.Services.AddScoped<IClientService,ClientService>();


//geminy אמר שלא צריך את השורה הזאת לבדוק!
//builder.Services.AddSingleton<DataContext>();

builder.Services.AddDbContext<DataContext>();

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<MappingProfile>();
}, typeof(Program));

//לבדוק האם זה מחליף את מה שכתבתי למעלה 
//builder.Services.AddCustomAutoMapper();


var key = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});
builder.Services.AddScoped<JwtService>();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//????
app.UseCors("AllowAll");
//הוספתי בשביל ה-JWT
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
