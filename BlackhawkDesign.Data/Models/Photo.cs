using Azure.Core;
using Azure.Identity;
using IntelliTect.Coalesce.Models;
using IntelliTect.Coalesce.Utilities;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using BlackhawkDesign.Data;

namespace BlackhawkDesign.Data.Models;

#nullable disable

public class Photo
{
    [DefaultOrderBy(OrderByDirection = DefaultOrderByAttribute.OrderByDirections.Descending)]
    public int PhotoId { get; set; }

    [Read]
    public DateTimeOffset UploadDate { get; set; }

    [InternalUse]
    public string OriginalFileName { get; set; }
    [InternalUse]
    public string StorageUrl { get; set; }

    [Read]
    public bool IsPublic { get; set; }

    [Search, ManyToMany("Tags")]
    public ICollection<PhotoTag> PhotoTags { get; set; }

    
}

public class PhotoTag
{
    public int PhotoTagId { get; set; }

    public int PhotoId { get; set; }
    public Photo Photo { get; set; }

    public string TagId { get; set; }
    [Search]
    public Tag Tag { get; set; }
}

public class Tag
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public string Name { get; set; }

    [DataType("Color")]
    public string Color { get; set; }
    [Read]
    public DateTimeOffset CreatedOn  { get; set; }
    [Required]
    public string Description { get; set; }


}