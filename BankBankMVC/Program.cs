using BankBankApp.BLL;
using BankBankApp.BLL.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

//register session
builder.Services.AddSession();
//options =>
//{
//	options.IdleTimeout = TimeSpan.FromMinutes(30);
//	options.Cookie.HttpOnly = true;
//	options.Cookie.IsEssential = true;
//}

builder.Services.AddScoped<ITransactionCategory, TransactionCategoryBLL>();
builder.Services.AddScoped<ITransaction, TransactionBLL>();
builder.Services.AddScoped<IUser, UserBLL>();
builder.Services.AddScoped<IAccount, AccountBLL>();
builder.Services.AddScoped<ICard, CardBLL>();

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();
app.UseSession();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
