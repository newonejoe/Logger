using Microsoft.EntityFrameworkCore;
using Logger;
using Logger.Data;

var builder = WebApplication.CreateBuilder(args);

// This workaround is necessary for initializing SQLite drivers in NativeAOT
SQLitePCL.Batteries_V2.Init();

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("SQLiteConnection")));

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    // options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
    options.SerializerSettings.ContractResolver = null;
});

builder.Services.AddCors(options => options.AddPolicy("AllowCors", builder =>
{
    builder
        .SetIsOriginAllowed(builder => true)
        .AllowCredentials()
        .AllowAnyHeader()
        .AllowAnyMethod();
}));


var app = builder.Build();

// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

EnsureDatabase(app);

void EnsureDatabase(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();
    using (var scope = scopedFactory.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetService<ApplicationDbContext>();
        dbContext.Database.EnsureCreated();
    }
}

app.UseRouting();

app.UseAuthorization();

app.UseCors("AllowCors");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();

