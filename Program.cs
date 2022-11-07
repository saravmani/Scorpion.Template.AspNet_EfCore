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
//builder.Services.AddControllers().AddOData(opt => opt.AddRouteComponents("odata", GetEdmModel()));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddPooledDbContextFactory<ApplicationDbContext>((options) => {
    options.LogTo(Console.WriteLine);
    options.UseSqlite("Data Source=ApplicaitonDb.db");
});



//builder.Services
//    .AddGraphQL((builder) =>
//    {
//        builder.ConfigureExecutionOptions(opt =>
//        {
//            opt.EnableMetrics = true;

//            //opt.UnhandledExceptionDelegate = ctx => logger.LogError("{Error} occurred", ctx.OriginalException.Message);
//        });
//        builder.AddGraphTypes().AddSystemTextJson();


//    });

builder.Services.AddGraphQLServer()
    .AddQueryType<Scorpion.Template.AspNet_EfCore.Repository.Query>()    
    .AddFiltering()
    
    ;
    


//(options, provider) =>
//{
//            // Load GraphQL Server configurations
//            var graphQLOptions = Configuration
//        .GetSection("GraphQL")
//        .Get<GraphQLOptions>();
//    options.ComplexityConfiguration = graphQLOptions.ComplexityConfiguration;
//    options.EnableMetrics = graphQLOptions.EnableMetrics;
//            // Log errors
//            var logger = provider.GetRequiredService<ILogger<Startup>>();
//    options.UnhandledExceptionDelegate = ctx =>
//        logger.LogError("{Error} occurred", ctx.OriginalException.Message);
//})
//    // Adds all graph types in the current assembly with a singleton lifetime.
//    .AddGraphTypes()
//    // Add GraphQL data loader to reduce the number of calls to our repository. https://graphql-dotnet.github.io/docs/guides/dataloader/
//    .AddDataLoader()
//    .AddSystemTextJson();






var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//GraphQL.Server.Ui.Altair.AltairOptions
//app.UseAuthorization();
//app.UseGraphQLAltair("ui/altair");
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL(path:"/graphql");
});


app.MapControllers();

app.Run();


//static IEdmModel GetEdmModel()
//{
//    return null;
//}