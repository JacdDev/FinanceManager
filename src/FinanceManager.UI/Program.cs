using FinanceManager.Application;
using FinanceManager.Infrastructure;
using FinanceManager.UI;
using Microsoft.AspNetCore.Localization;
using Microsoft.IdentityModel.Tokens;
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
        string cultureCookie = CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(cultureQuery));
        context.Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, cultureCookie);
    }

    // Call the next delegate/middleware in the pipeline.
    await next(context);
});

//middleware to refresh auth cookies with remember me functionality
app.Use(async (context, next) =>
{
    //if rememberMe cookie is set to 1 and authToken cookie is set, refresh it
    if (context.Request.Cookies.ContainsKey("rememberMe") && context.Request.Cookies["rememberMe"] == "1"
        && context.Request.Cookies.ContainsKey("authToken") && !context.Request.Cookies["authToken"].IsNullOrEmpty())
    {
        context.Response.Cookies.Append("authToken", context.Request.Cookies?["authToken"]?.ToString() ?? "", new CookieOptions()
        {
            Expires = DateTimeOffset.MaxValue
        });

        context.Response.Cookies.Append("rememberMe", context.Request.Cookies?["rememberMe"]?.ToString() ?? "", new CookieOptions()
        {
            Expires = DateTimeOffset.MaxValue
        });
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
