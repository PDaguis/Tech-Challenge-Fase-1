using Fase1.Web.Interfaces;
using Fase1.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddScoped(hc => new HttpClient { BaseAddress = new Uri(builder.Configuration["BaseAddress"]) });
builder.Services.AddScoped<IRegiaoService, RegiaoService>();
builder.Services.AddScoped<IContatoService, ContatoService>();

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

app.UseAuthorization();

app.MapRazorPages();

app.Run();
