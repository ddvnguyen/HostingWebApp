using Microsoft.Extensions.FileProviders;
using Microsoft.Net.Http.Headers;
using Omnia.Fx.NetCore.Features.TargetResolvers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDirectoryBrowser();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(new StaticFileOptions
{
    OnPrepareResponse = ctx =>
    {
        const int durationInSeconds = 1;
        ctx.Context.Response.Headers[HeaderNames.CacheControl] =
            "public,max-age=" + durationInSeconds;
    },
    ServeUnknownFileTypes = true,
    DefaultContentType = "application/javascript"
});
app.UseFileServer(enableDirectoryBrowsing: true);
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();
app.Run();


string b = "Omnia.Fx.NetCore.Features.TargetResolvers.IFeatureTargetResolver";
switch (b)
{
    case nameof(IBusinessProfileFeatureTargetResolver):
        break;
    case nameof(IFeatureTargetResolver):
        break;
    case nameof(IAppInstanceFeatureTargetResolver):
        break;
}