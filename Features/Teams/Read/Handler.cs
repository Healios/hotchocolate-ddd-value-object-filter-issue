using API.Domain.Entities;
using Wolverine;

namespace API.Features.Teams.Read
{
    // Inputs.
    public record ReadTeamsInput();

    // GraphQL.
    [QueryType]
    public class Query
    {
        [UseFiltering]
        [UseSorting]
        public async Task<IEnumerable<Team>> ReadTeams([Service] IMessageBus messageBus) => await messageBus.InvokeAsync<IEnumerable<Team>>(new ReadTeamsInput());
    }

    // Handler.
    public class Handler
    {
        public IEnumerable<Team> Handle(ReadTeamsInput input)
        {
            return [ Team.Create(TeamName.From("Team A"), TeamDescription.From("Just a simple team")) ];
        }
    }
}
