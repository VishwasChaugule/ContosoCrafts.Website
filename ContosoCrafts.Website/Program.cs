using System.Text.Json;
using ContosoCrafts.Website.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddControllers();
builder.Services.AddTransient<JsonFileProductService>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.MapBlazorHub();

app.MapControllers();
//app.MapGet("/products", (JsonFileProductService productService) =>
//{
//    var products = productService.GetProducts();
//    var json = JsonSerializer.Serialize(products);
//    return json;
//});

app.Run();