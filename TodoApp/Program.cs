using Microsoft.EntityFrameworkCore;

using TodoApp.Core.Entity;
using TodoApp;
using Microsoft.AspNetCore.SignalR;
using TodoApp.Core.Interfaces;
using TodoApp.Core.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));
builder.Services.AddMvcCore().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
builder.Services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
               //.AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
builder.Services.AddScoped<DbContext, AppDbContext>();
builder.Services.AddScoped<ITaskService, TaskService>();
var app = builder.Build();
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mgo+DSMBaFt/QHRqVVhkX1pGaV5DQmFJfFBmRGJTfl56d1xWESFaRnZdQV1iSHxSd0ZhXX9aeXdU;Mgo+DSMBPh8sVXJ0S0J+XE9AdVRAQmJIYVF2R2BJfl96dVVMY1VBNQtUQF1hSn5Sd0diWHxcdHRQR2Bd;ORg4AjUWIQA/Gnt2VVhkQlFaclxJX3xIf0x0RWFab19xflRGal9YVAciSV9jS31Td0RhWH5dcnBVQ2JZUA==;OTI4NTczQDMyMzAyZTM0MmUzMEVydzY3VmlRMkgxbjE5L2VFbGxqUHFPaFpGOFI2QW9rM09lcENXeDhxNG89;OTI4NTc0QDMyMzAyZTM0MmUzMFJLUmpaMlJ3R0RCL1lZR2V2MlV0S2pwMTZsdTQ5d3pQZElDYndBZjFUWkE9;NRAiBiAaIQQuGjN/V0Z+WE9EaFtBVmFWf1JpR2NbfE5xdV9HYFZSTWYuP1ZhSXxQdkRiW35fc3ZRRmVVUkU=;OTI4NTc2QDMyMzAyZTM0MmUzMFZOR2NTY2UxMTJ2WnE5alI1eWhhMEQvL1RBRmFGRXlNWGIrZkJRNWJXRms9;OTI4NTc3QDMyMzAyZTM0MmUzMFJhOTF6b0x0Mzg1cXNqTng4KzZFL1RBbVRiRXNTWFRRVmQyUnR3VVZVRms9;Mgo+DSMBMAY9C3t2VVhkQlFaclxJX3xIf0x0RWFab19xflRGal9YVAciSV9jS31Td0RhWH5dcnBVQGVaUA==;OTI4NTc5QDMyMzAyZTM0MmUzMGxwY29pYkdWNmM1RmxTOElzbkJHSEs0OUJGRVJPMXJXVFJWeTRjYnYxUDQ9;OTI4NTgwQDMyMzAyZTM0MmUzMERhUTZjV3ZmZWp2cVoyVlpvVzBxemZQS0hORkRnVVVYME93RktsbXpjS2c9;OTI4NTgxQDMyMzAyZTM0MmUzMFZOR2NTY2UxMTJ2WnE5alI1eWhhMEQvL1RBRmFGRXlNWGIrZkJRNWJXRms9");
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Tasks}/{action=Index}/{id?}");

app.Run();
