using Microsoft.EntityFrameworkCore;

using Scorpion.Template.AspNet_EfCore.Repository;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.Edm;
using GraphQL.Server.Ui.Altair;
using GraphQL;
using GraphQL.SystemTextJson;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using HotChocolate.AspNetCore.Extensions;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Instrumentation;
using HotChocolate.AspNetCore.Subscriptions;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddControllers().AddOData(opt =>
{
  
    opt.Select();

}
);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<ApplicationDbContext>((options) =>
{
    options.LogTo(Console.WriteLine);
    options.UseSqlite("Data Source=ApplicaitonDb.db");
});


//Used by graphQL
//builder.Services.AddPooledDbContextFactory<ApplicationDbContext>((options) => {
//    options.LogTo(Console.WriteLine);
//    options.UseSqlite("Data Source=ApplicaitonDb.db");
//});




//Used by graphQL
builder.Services.AddGraphQLServer()
    .AddQueryType<Scorpion.Template.AspNet_EfCore.Repository.Query>()
    .AddFiltering();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();

//To Enable GraphQL Endpoint
app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL(path: "/graphql");
});


app.MapControllers();

app.Run();
 