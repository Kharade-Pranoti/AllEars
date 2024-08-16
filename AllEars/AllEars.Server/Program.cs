using AllEars.Server.Services; 
using AllEars.Server.Repositories;
using Microsoft.EntityFrameworkCore;
using AllEars.Server.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "JWTToken_Auth_API",
        Version = "v1"
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                }
            },
            new string[] {}
        }
    });

});

builder.Services.AddLogging();
builder.Services.AddScoped<IAuthService, AuthService>();

// Register other dependencies
builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();

// Register the AdminRepository and AdminService
builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<IAdminService, AdminService>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IPatientService, PatientService>();

builder.Services.AddScoped<ICounsellingPsychologistRepository, CounsellingPsychologistRepository>();
builder.Services.AddScoped<ICounsellingPsychologistService, CounsellingPsychologistService>();

// Register the CounsellingDoctorAvailabilityRepository and CounsellingDoctorAvailabilityService
builder.Services.AddScoped<ICounsellingDoctorAvailabilityRepository, CounsellingDoctorAvailabilityRepository>();
builder.Services.AddScoped<ICounsellingDoctorAvailabilityService, CounsellingDoctorAvailabilityService>();

builder.Services.AddScoped<IClinicalPsychologistRepository, ClinicalPsychologistRepository>();
builder.Services.AddScoped<IClinicalPsychologistService, ClinicalPsychologistService>();

// Register the ClinicalDoctorAvailabilityRepository and ClinicalDoctorAvailabilityService
builder.Services.AddScoped<IClinicalDoctorAvailabilityRepository, ClinicalDoctorAvailabilityRepository>();
builder.Services.AddScoped<IClinicalDoctorAvailabilityService, ClinicalDoctorAvailabilityService>();

// Register the BookAppointmentRepository and BookAppointmentService
builder.Services.AddScoped<IBookAppointmentRepository, BookAppointmentRepository>();
builder.Services.AddScoped<IBookAppointmentService, BookAppointmentService>();

builder.Services.AddScoped<IBillingRepository, BillingRepository>();
builder.Services.AddScoped<IBillingService, BillingService>();
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//{
//    var connectionString = builder.Configuration.GetConnectionString("MySQL");
//    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
//});

//builder.Services.AddDbContext<BusinessDbContext>(options =>
//{
//    var connectionString = builder.Configuration.GetConnectionString("MySQL");
//    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
//});

//builder.Services.AddTransient<IAuthService, AuthService>();

//// For Identity
//builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
//    .AddEntityFrameworkStores<ApplicationDbContext>()
//    .AddDefaultTokenProviders();
//// Adding Authentication
//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
//})
// Adding JWT bearer
//.AddJwtBearer(options =>
//{
//    options.SaveToken = true;
//    options.RequireHttpsMetadata = false;
//    options.TokenValidationParameters = new TokenValidationParameters()
//    {
//        ValidateIssuer = true,
//        ValidateAudience = true,
//        ValidAudience = builder.Configuration["JWT:ValidAudience"],
//        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
//        ClockSkew = TimeSpan.Zero,
//        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
//    };

//});


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllRequest",
        policy => policy.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("AllowAllRequest");
app.UseHttpsRedirection();
app.UseAuthentication();

app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    _ = app.MapControllers();
    _ = endpoints.MapFallbackToFile("/index.html");
});

app.Run();
