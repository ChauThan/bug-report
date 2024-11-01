namespace Proj.Types;

public record Author(int Id, string Name);

public class AuthorType : ObjectType<Author>
{
    protected override void Configure(IObjectTypeDescriptor<Author> descriptor)
    {
        descriptor.ImplementsNode()
            .IdField(s => s.Id)
            .ResolveNode((ctx, id) =>
            {
                var author = ctx.Services.GetRequiredService<AuthorRepository>().GetAuthorById(id);
                ctx.SetScopedState("AdditionalData", "This is the additional data of " + author?.Name);
                return Task.FromResult(author);
            });
        
        descriptor.Field("AdditionalData")
            .Type<StringType>()
            .Resolve<string>(ctx => ctx.ScopedContextData.TryGetValue("AdditionalData", out var scopedContextData) 
                ? scopedContextData.ToString() 
                : "Data not found.");
    }
}