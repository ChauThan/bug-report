namespace Proj.Types;

public class Query
{
    
}

public class QueryType : ObjectType<Query>
{
    protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
    {
        descriptor.Field("authors")
            .Type<ListType<AuthorType>>()
            .Resolve(ctx => ctx.Services.GetRequiredService<AuthorRepository>().GetAuthors());
        
    }
}