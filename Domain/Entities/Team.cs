using Ardalis.GuardClauses;
using Vogen;

namespace API.Domain.Entities
{
    [ValueObject<Guid>]
    public partial struct TeamId { }

    [ValueObject<string>]
    public partial struct TeamName { }

    [ValueObject<string>]
    public partial struct TeamDescription { }

    public class Team
    {
        // Constructors.
        private Team(TeamId id, TeamName name, TeamDescription? description)
        {
            Guard.Against.NullOrEmpty(id.Value);
            Guard.Against.NullOrEmpty(name.Value);

            Id = id;
            Name = name;
            Description = description;
        }

        // Properties.
        public TeamId Id { get; private set; }

        public TeamName Name { get; private set; }

        public TeamDescription? Description { get; private set; }

        // Methods.
        public static Team Create(TeamName name, TeamDescription? description) => new Team(TeamId.From(Guid.NewGuid()), name, description);

        public void Update(TeamName? name, TeamDescription? description)
        {
            if (name != null) Name = (TeamName)name;
            if (description != null) Description = description;
        }
    }
}
