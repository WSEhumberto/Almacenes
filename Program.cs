using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Almacenes.Data;
using Almacenes.Interfaces;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<AlmacenesContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AlmacenesContext") ?? throw new InvalidOperationException("Connection string 'AlmacenesContext' not found.")));

//builder.Services.AddDbContext<AlmacenesContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING") ?? throw new InvalidOperationException("Connection string '\"AZURE_SQL_CONNECTIONSTRING\"' not found.")));


builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddTransient<IMaterialBalance, MaterialBalance>();
//builder.Services.AddScoped<AlmacenesContext, AlmacenesContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();

    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;

        var context = services.GetRequiredService<AlmacenesContext>();
        context.Database.EnsureCreated();
        DbInitializer.Initialize(context);
    }
}



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
