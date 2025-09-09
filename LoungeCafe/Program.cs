using LoungeCafe.Database;
using LoungeCafe.Handlers;
using LoungeCafe.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<ApplicationDbContext>();

builder.Services.AddScoped<NavLinksHandler>();
builder.Services.AddScoped<ILoungecafeRepository, LoungecafeRepository>();
builder.Services.AddScoped<SiteInfoHandler>();
builder.Services.AddScoped<ImagesHandler>();
builder.Services.AddScoped<IntroHandler>();
builder.Services.AddScoped<SocialMediaHandler>();
builder.Services.AddScoped<AboutHandler>();
builder.Services.AddScoped<CategoriesHandler>();
builder.Services.AddScoped<ProductsHandler>();
builder.Services.AddScoped<GalleryHandler>();
builder.Services.AddScoped<ClientsHandler>();
builder.Services.AddScoped<FooterHandler>();
builder.Services.AddScoped<IconsHandler>();
builder.Services.AddScoped<AdditionalInfoHandler>();
builder.Services.AddScoped<SubscriptionHandler>();
builder.Services.AddScoped<EmailHandler>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:3000") 
              .AllowCredentials()                   
              .AllowAnyHeader()                     
              .AllowAnyMethod();                    
    });
});



var app = builder.Build();
app.UseCors();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
