using API.Domain.Entities;
using Wolverine;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseWolverine();
builder.Services.AddGraphQLServer()
    .AddFiltering()
    .AddSorting()
    .AddAPITypes()
    
    .AddTypeConverter<TeamId, Guid>(change => change.Value)
    .AddTypeConverter<Guid, TeamId>(TeamId.From)
    .BindRuntimeType<TeamId, UuidType>()

    .AddTypeConverter<TeamName, string>(change => change.Value)
    .AddTypeConverter<string, TeamName>(TeamName.From)
    .BindRuntimeType<TeamName, StringType>()

    .AddTypeConverter<TeamDescription, string>(change => change.Value)
    .AddTypeConverter<string, TeamDescription>(TeamDescription.From)
    .BindRuntimeType<TeamDescription, StringType>();

var app = builder.Build();
app.UseHttpsRedirection();
app.MapGraphQL();
app.Run();
