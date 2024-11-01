using Proj;
using Proj.Types;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<AuthorRepository>();

builder.Services
    .AddGraphQLServer()
    .AddGlobalObjectIdentification()
    .AddQueryType<QueryType>();

var app = builder.Build();

app.MapGraphQL();

app.Run();
