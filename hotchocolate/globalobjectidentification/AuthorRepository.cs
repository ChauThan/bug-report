using Proj.Types;

namespace Proj;

public class AuthorRepository
{
    private readonly ICollection<Author> _authors =
    [
        new(1, "Author 1"),
        new(2, "Author 2")
    ];
    
    public ICollection<Author> GetAuthors()  => _authors;
    
    public Author? GetAuthorById(int id)  => _authors.FirstOrDefault(a => a.Id == id);
}