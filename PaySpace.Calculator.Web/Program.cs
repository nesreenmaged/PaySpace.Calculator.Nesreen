using PaySpace.Calculator.Web.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddCalculatorHttpServices();


// Configure HttpClient with base URL from the configuration
builder.Services.AddHttpClient("PostalClient", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["CalculatorSettings:ApiUrl"]);
});


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(name: "default", pattern: "{controller=Calculator}/{action=Index}/{id?}");

app.Run();