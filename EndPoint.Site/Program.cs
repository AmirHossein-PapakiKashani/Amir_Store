
using Amir_Store.Application.Interfaces.Context;
using Amir_Store.Application.Services.Command.EditUser;
using Amir_Store.Application.Services.Command.RegisterUser;
using Amir_Store.Application.Services.Command.RemoveUser;
using Amir_Store.Application.Services.Command.UserLogin;
using Amir_Store.Application.Services.Command.UserStatusChange;
using Amir_Store.Application.Services.Queries.GetRoles;
using Amir_Store.Application.Services.Queries.GetUsers;
using Amir_Store.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
string connectionstring = "Data Source= DESKTOP-QC21EP7;Initial Catalog= Amir_StoreDb;Integrated Security= True;Encrypt=False";
builder.Services.AddEntityFrameworkSqlServer().AddDbContext<Amir_Store.Persistence.Contexts.DataBaseContext>(option => option.UseSqlServer(connectionstring));
builder.Services.AddScoped<IDataBaseContext, DataBaseContext>();
builder.Services.AddScoped<IGetUsersService, GetUsersService>();
builder.Services.AddScoped<IRegisterUserService, RegisterUserService>();
builder.Services.AddScoped<IUserStatusChangeService, UserStatusChangeService>();
builder.Services.AddScoped<IGetRolesService, GetRolesService>();
builder.Services.AddScoped<IRemoveUserService,  RemoveUserService>();
builder.Services.AddScoped<IUserLoginService,  UserLoginService>();
builder.Services.AddScoped<IEditUserService,  EditUserService>();
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
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});


app.Run();
