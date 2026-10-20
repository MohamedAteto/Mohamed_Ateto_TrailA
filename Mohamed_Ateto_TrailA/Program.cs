using System.Text;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Mohamed_Ateto_TrailA.Data;
using Mohamed_Ateto_TrailA.Mapping;
using Mohamed_Ateto_TrailA.Reposatories.Implmentation;
using Mohamed_Ateto_TrailA.Reposatories.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(s => 
s.UseSqlServer(builder.Configuration.GetConnectionString("DefualtConnection")));
builder.Services.AddAutoMapper(typeof(MappingProfiles));

builder.Services.AddScoped<IAuthRepo, AuthRepo>();
builder.Services.AddScoped<IJobRepo, JobRepo>();
builder.Services.AddScoped<IApplicationRepo, ApplicationRepo>();
builder.Services.AddScoped<ICompanyRepo, CompanyRepo>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));


var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]));

builder.Services.AddAuthentication(s =>
{
    s.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    s.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(m =>
    {
        m.RequireHttpsMetadata = false;
        m.SaveToken = true;

        m.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = builder.Configuration["JWT:Issuer"],
            ValidAudience = builder.Configuration["JWT:Audience"],
            IssuerSigningKey = key

        };
    });

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
