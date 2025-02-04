using DomainDeveloper = Match.Domain.Developer.Developer;
namespace Match.Infrastructure.Graphql
{
    public class Query
    {
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<DomainDeveloper> GetDevelopers([Service] AppDbContext context) =>
            context.Developer;
    }
}
