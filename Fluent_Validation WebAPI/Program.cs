using Fluent_Validation_WebAPI.Data;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



#region Connection String


builder.Services.AddDbContext<ApplicationDbContext>(options =>
{

	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
#endregion

#region Mapping

builder.Services.AddAutoMapper(typeof(Program));

#endregion

#region Fluent Validation

builder.Services.AddControllers()
			.AddFluentValidation(v =>
			{
				v.ImplicitlyValidateChildProperties = true;
				v.ImplicitlyValidateRootCollectionElements = true;
				v.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
			});

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
