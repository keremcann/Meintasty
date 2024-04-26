using Meintasty.Application;
using Meintasty.Application.Login;
using Meintasty.Application.Register;
using Meintasty.Data;
using Meintasty.Domain.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(ApplicationAutoMapper));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetLoginQueryHandler).Assembly));
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateUserCommandHandler).Assembly));

#region Dependency Injection

builder.Services.AddScoped<IUserRepositoryAsync, UserRepositoryAsync>();
builder.Services.AddScoped<ICantonRepositoryAsync, CantonRepositoryAsync>();
builder.Services.AddScoped<ICityRepositoryAsync, CityRepositoryAsync>();

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
