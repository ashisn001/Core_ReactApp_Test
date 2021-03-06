using System.Net;

var builder = WebApplication.CreateBuilder(args);


//#if !DEBUG
//        builder.WebHost.ConfigureKestrel(options =>
//                    {
//                        var port = Convert.ToInt32(Environment.GetEnvironmentVariable("PORT") ?? "8080");
//                        options.Listen(IPAddress.Any, port);
//                    });
//#endif

builder.WebHost.ConfigureKestrel(serverOptions =>
{
    var port = Convert.ToInt32("8080");
    serverOptions.Listen(IPAddress.Any, port);
});

// Add services to the container.

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
