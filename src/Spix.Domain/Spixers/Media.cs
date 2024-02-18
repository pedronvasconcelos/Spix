using Spix.Domain.Core;
namespace Spix.Domain.Spixers;

public class Media : Entity
{
    public Guid Id { get; set; }
    public string Link { get; set; } 
    public string ContentType { get; set; }
    public string FileName { get; set; }

    public Media(string link, string contentType, string fileName)
    {
         Link = link;
        ContentType = contentType;
        FileName = fileName;
    }

    public Media()
    {
        Link = string.Empty;
        ContentType = string.Empty;
        FileName = string.Empty;

    }

}
