using NetCore.Services.Interfaces;
using NetCore.Services.Svcs;

var builder = WebApplication.CreateBuilder(args);

#region 강의내용A

//껍데기               내용물
//IUser 인터페이스가 UserService 클래스를 받기 위해 services에 등록해야 함.
builder.Services.AddScoped<IUser, UserService>();
builder.Services.AddMvc();

#endregion

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
