using FinanceManager.Application;
using FinanceManager.Infrastructure;
using FinanceManager.UI;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration)
    .AddPresentation(builder.Configuration);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error");
}

app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

//middleware to manage culture cookie
app.Use(async (context, next) =>
{
    var cultureQuery = context.Request.Query["culture"];
    if (!string.IsNullOrWhiteSpace(cultureQuery))
    {
        context.Response.Cookies.Append(
            CookieRequestCultureProvider.DefaultCookieName,
            CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(cultureQuery)), 
            new CookieOptions() { Expires = DateTimeOffset.UtcNow.AddYears(1) });
    }

    // Call the next delegate/middleware in the pipeline.
    await next(context);
});

app.UseRequestLocalization(new RequestLocalizationOptions
{
    SupportedCultures = new List<CultureInfo>() { CultureInfo.GetCultureInfo("en"), CultureInfo.GetCultureInfo("es") },
    SupportedUICultures = new List<CultureInfo>() { CultureInfo.GetCultureInfo("en"), CultureInfo.GetCultureInfo("es") },
    ApplyCurrentCultureToResponseHeaders = true
});

app.Run();
