using API.IServices;
using API.Middlewares;
using API.Services;
using Data;
using Logic.Ilogic;
using Logic.ILogic;
using Logic.Logic;
using Microsoft.EntityFrameworkCore;
using Security.IServices;
using Security.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IRecipeItemLogic, RecipeItemLogic>();
builder.Services.AddScoped<IRecipeItemService, RecipeItemService>();

builder.Services.AddScoped<IUserLogic, UserLogic>();
builder.Services.AddScoped<IUserService, UserService>();


builder.Services.AddScoped<IUserSecurityLogic, UserSecurityLogic>();
builder.Services.AddScoped<IUserSecurityService, UserSecurityService>();









builder.Services.AddDbContext<ServiceContext>(
        options => options.UseSqlServer("name=ConnectionStrings:ServiceContext"));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});



var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.Use(async (context, next) => {
    var serviceScope = app.Services.CreateScope();
    var userSecurityService = serviceScope.ServiceProvider.GetRequiredService<IUserSecurityService>();
    var requestAuthorizationMiddleware = new RequestAuthorizationMiddleware(userSecurityService);
    requestAuthorizationMiddleware.ValidateRequestAutorizathion(context);
    await next();
});

app.UseHttpsRedirection();

app.UseAuthorization();



app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
