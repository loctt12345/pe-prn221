using BussinessObject.Models;
using CartoonFilm_TranThienLoc;
using DataAccessObject;
using Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<CartoonFilm2023DbContext>();
builder.Services.AddScoped<ICartoonFilmInformationDAO, CartoonFilmInformationDAO>();
builder.Services.AddScoped<IProducerDAO, ProducerDAO>();
builder.Services.AddScoped<IMemberAccountDAO, MemberAccountDAO>();
builder.Services.AddScoped<ICartoonFilmInformationRepository, CartoonFilmInformationRepository>();
builder.Services.AddScoped<IProducerRepository, ProducerRepository>();
builder.Services.AddScoped<IMemberAccountRepository, MemberAccountRepository>();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
});

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
app.UseSession();
app.UseRouting();
app.UseLoginMiddleware();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
