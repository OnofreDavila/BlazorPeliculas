using BlazorPeliculas.Components;
using BlazorPeliculas.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

//-------------------------------------
//Add Servicios: Controller y HTTPClient
builder.Services.AddControllers();
builder.Services.AddHttpClient();
//-------------------------------------

//-------------------------------------
//Add Servicio Bootstrap
builder.Services.AddBlazorBootstrap();
//-------------------------------------

//add Sericio PeliculaDBContext
builder.Services.AddDbContext<PeliculaDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
}
);
//-------------------------------------

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();
//-------------------------------------
//Agregar el mapeo del controlador
app.MapControllers();
//-------------------------------------
app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(BlazorPeliculas.Client._Imports).Assembly);

app.Run();
