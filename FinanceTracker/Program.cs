using FinanceTracker.Data;
using FinanceTracker.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Подключаем базу и сервис
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<FinanceService>();

var app = builder.Build();

// Автоматическое применение миграций при запуске (нужно для Docker)
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

// Вот эта строчка в .NET 8 заменяет сломанный MapStaticAssets
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<FinanceTracker.Components.App>()
    .AddInteractiveServerRenderMode();

app.Run();