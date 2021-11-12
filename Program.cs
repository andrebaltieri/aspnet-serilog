using System.Net;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Email;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.UseSerilog((ctx, lc) => lc
    .WriteTo.Console()
    .WriteTo.Email(new EmailConnectionInfo
    {
        Port = 587,
        EmailSubject = "TESTE",
        EnableSsl = true,
        FromEmail = "hello@balta.io",
        MailServer = "smtp.sendgrid.net",
        NetworkCredentials = new NetworkCredential("apikey", "pwd"),
        ToEmail = "hello@balta.io",
        IsBodyHtml = true
    }));
// .WriteTo.File("log.txt",
//     LogEventLevel.Error,
//     rollingInterval: RollingInterval.Day));

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