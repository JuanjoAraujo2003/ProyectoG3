using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using ProyectoG3.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddHttpClient("ApiService", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ApiSettings:BaseUrl"]);
});

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<API>();


var app = builder.Build();


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
