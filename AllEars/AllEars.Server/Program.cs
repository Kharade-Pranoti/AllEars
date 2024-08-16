using AllEars.Server.Services; 
using AllEars.Server.Repositories;
using Microsoft.EntityFrameworkCore;
using AllEars.Server.Entities;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    app.UseCors("AllowAll");
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

    if (env.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }
    else
    {
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles(); // Ensure this is included

    app.UseRouting();

    app.UseAuthorization();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
        endpoints.MapRazorPages();
    });
}

void ConfigureServices(IServiceCollection services)
{
    services.AddControllersWithViews();
    services.Configure<StaticFileOptions>(options =>
    {
        options.OnPrepareResponse = ctx =>
        {
            var filePath = ctx.File.Name;

            if (filePath.EndsWith(".jsx"))
            {
                ctx.Context.Response.Headers.Append("Content-Type", "application/javascript");
            }
            else if (ctx.File.Name.EndsWith(".css"))
            {
                ctx.Context.Response.Headers.Append("Content-Type", "text/css");
            }
        };
    });

    services.AddCors(options =>
    {
        options.AddPolicy("AllowAll", builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
    });

    services.AddControllers();
}

//void Configure(IApplicationBuilder app, IWebHostEnvironment env)
//{
//    app.UseCors("AllowAll");
//    app.UseRouting();
//    app.UseEndpoints(endpoints =>
//    {
//        endpoints.MapControllers();
//    });
//}


builder.Services.AddControllers();
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

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors();
app.UseAuthorization();


app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
