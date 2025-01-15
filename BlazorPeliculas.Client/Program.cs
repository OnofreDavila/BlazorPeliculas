using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
;
//-----------Agregar Servicio HTTP-------------------//
builder.Services.AddScoped(sp =>
new HttpClient
{
    BaseAddress = new Uri(builder.Configuration["FrontendUrl"] ?? "https://localhost:7150")
});
//---------------------------------------------------//

//-------------------------------------
//Add Servicio Bootstrap
builder.Services.AddBlazorBootstrap();
//-------------------------------------


await builder.Build().RunAsync();
