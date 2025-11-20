using Microsoft.EntityFrameworkCore;
using QR_Digital_Entry_Log.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

// 🔹 SQL Server 연결
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"))
);

//API컨트롤러 사용
builder.Services.AddControllers();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.MapRazorPages();
app.MapControllers();

app.Run();
