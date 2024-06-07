using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using MultiShop.Catalog.Services.CategoryServices;
using MultiShop.Catalog.Services.FeatureSliderServices;
using MultiShop.Catalog.Services.ProductDetailDetailDetailService;
using MultiShop.Catalog.Services.ProductDetailServices;
using MultiShop.Catalog.Services.ProductImageService;
using MultiShop.Catalog.Services.ProductServices;
using MultiShop.Catalog.Services.SpecialOffer;
using MultiShop.Catalog.Settings;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt=>
{
    opt.Authority = builder.Configuration["IdentityServerUrl"];
    opt.Audience = "ResourceCatalog";
    opt.RequireHttpsMetadata = false;
});

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService,ProductService>();
builder.Services.AddScoped<IProductImageService,ProductImageService>();
builder.Services.AddScoped<IProductDetailService,ProductDetailService>();
builder.Services.AddScoped<IFeatureSliderService,FeatureSliderService>();
builder.Services.AddScoped<ISpecialOfferService,SpecialOfferService>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection(nameof(DatabaseSettings)));
builder.Services.AddScoped<IDatabaseSettings>(sp =>
{                                                                                                                           //////
    return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;                                                       //////  Options Design Pattern
});                                                                                                                         //////

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("Cors", builder => {
//        //builder.WithOrigins("http://localhost:800").AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
//        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
//        //builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost");
//        //builder.SetIsOriginAllowed(origin => true);
//    });
//});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app.UseCors("Cors");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();