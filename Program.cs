using devpro_project.Service;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
//Thêm dòng d??i ?? add bi?n session
builder.Services.AddSession();
builder.Services.AddSingleton<IVnPayService, VnPayService>();
var app = builder.Build();
//?? s? d?ng bi?n session thì khái báo dòng sau
//app.MapGet("/", () => "Hello World!");
app.UseSession();

//khai báo thư mục wwwroot thành thư mục ảo
app.UseStaticFiles();
app.MapControllerRoute(
    name: "area",
    pattern: "{area}/{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
