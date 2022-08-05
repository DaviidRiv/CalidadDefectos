using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CalidadDefectos.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Hosting;

var builder = WebApplication.CreateBuilder(args);

var initialScopes = builder.Configuration["DownstreamApi:Scopes"]?.Split(' ') ?? builder.Configuration["MicrosoftGraph:Scopes"]?.Split(' ');

builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAd"))
        .EnableTokenAcquisitionToCallDownstreamApi(initialScopes)
            .AddMicrosoftGraph(builder.Configuration.GetSection("MicrosoftGraph"))
            .AddInMemoryTokenCaches();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Usuarios_Defectos", policyBuilder => policyBuilder.RequireClaim("groups",builder.Configuration.GetValue<string>("AzureSecurityGroup:UserObjectId")));
    options.AddPolicy("Administradores_Defectos", policyBuilder => policyBuilder.RequireClaim("groups", builder.Configuration.GetValue<string>("AzureSecurityGroup:AdminObjectId")));

});

//builder = WebApplication.CreateBuilder(new WebApplicationOptions
//{
//    EnvironmentName = Environments.Development
//});

// Add services to the container.
builder.Services.AddRazorPages().AddMicrosoftIdentityUI();
builder.Services.AddDbContext<CalidadDefectosContext>(options =>    options.UseSqlServer(builder.Configuration.GetConnectionString("CalidadDefectosContext") ?? throw new InvalidOperationException("Connection string 'CalidadDefectosContext' not found.")));
builder.Services.AddApplicationInsightsTelemetry(builder.Configuration["APPLICATIONINSIGHTS_CONNECTION_STRING"]);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

app.Run();
