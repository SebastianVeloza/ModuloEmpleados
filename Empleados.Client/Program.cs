using CurrieTechnologies.Razor.SweetAlert2;
using Empleados.Client;
using Empleados.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5041") });

//Llamo a los servicios
builder.Services.AddScoped<IDepartamentoService,DepartamentoService>();
builder.Services.AddScoped<IEmpleadoService,EmpleadoService>();

//llamando al servicio del nugget sweetAlert
builder.Services.AddSweetAlert2();

await builder.Build().RunAsync();
