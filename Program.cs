using BaiTapOceanTech.DB;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using BaiTapOceanTech.Utility;
using BaiTapOceanTech.Services;
using BaiTapOceanTech.Mapper;
using BaiTapOceanTech.Mapper.impl;
using BaiTapOceanTech.Services.impl;
using Quartz;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionStr = builder.Configuration.GetConnectionString("MySQL");

builder.Services.AddDbContext<ApplicationDbContext>(o =>
    o.UseMySql(connectionStr, new MySqlServerVersion(new Version(8, 0, 33))));
//chuyen enum
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddScoped(typeof(Validation<>));

builder.Services.AddScoped<ITinhMapper, TinhMapper>();
builder.Services.AddScoped<ITinhService, TinhService>();
builder.Services.AddScoped<IHuyenMapper, HuyenMapper>();
builder.Services.AddScoped<IHuyenService, HuyenService>();
builder.Services.AddScoped<IXaMapper, XaMapper>();
builder.Services.AddScoped<IXaService, XaService>();
builder.Services.AddScoped<IEmployeeMapper, EmployeeMapper>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<ICertificateMapper, CertificateMapper>();
builder.Services.AddScoped<ICertificateService, CertificateService>();
builder.Services.AddScoped<IEmployeeCertificateMapper, EmployeeCertificateMapper>();
builder.Services.AddScoped<IEmployeeCertificateService, EmployeeCertificateService>();
//Quazt
builder.Services.AddQuartz(q =>
{
    var jobKey = new JobKey("MyCronJob");

    q.AddJob<MyCronJob>(opts => opts.WithIdentity(jobKey));

    q.AddTrigger(opts => opts
        .ForJob(jobKey)
        .WithIdentity("MyCronTrigger")
        .WithSimpleSchedule(x => x.WithIntervalInSeconds(60).RepeatForever()));
});
// Đăng ký Hosted Service cho Quartz
builder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);
//  CORS service
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder
                .AllowAnyOrigin()     //  origin
                .AllowAnyMethod()      //  HTTP methods
                .AllowAnyHeader();     //  headers
        });
});

var app = builder.Build();
app.UseCors("AllowAll");
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
