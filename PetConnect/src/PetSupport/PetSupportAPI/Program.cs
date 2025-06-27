using PetSupportApplication;
using PetSupportApplication.Adoption.Commands.CreateAdoption;
using PetSupportInfra.Persistence.Repositories.Base;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(CreateAdoptionCommandHandler).Assembly));

builder.Services.AddScoped(typeof(IBaseCommandRepository<>), typeof(BaseCommandRepository<>));
builder.Services.AddScoped(typeof(IBaseQueryRepository<>), typeof(BaseQueryRepository<>));



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
