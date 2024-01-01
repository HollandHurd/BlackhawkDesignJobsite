using IntelliTect.Coalesce.Models;
using IntelliTect.Coalesce.Utilities;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.Security.Cryptography;

namespace BlackhawkDesign.Data.Models;
#nullable disable
public class Application
{
    [DefaultOrderBy(OrderByDirection = DefaultOrderByAttribute.OrderByDirections.Descending)]
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public string NormalizedName { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required, EmailAddress]
    public string Email { get; set; }
    [Required, Phone]
    public string PhoneNumber { get; set; }
    [Search, ManyToMany("Jobs")]
    public ICollection<JobApplication> JobApplied { get; set; }
    public string CoverLetter { get; set; }
    [Read]
    public DateTimeOffset Applied { get; set; }

    [Read]
    public string AttachmentName { get; set; }

    [Read]
    public long AttachmentSize { get; set; }

    [Read]
    public string AttachmentType { get; set; }

    [Read, MaxLength(32)]
    public byte[] AttachmentHash { get; set; }

    [InternalUse]
    public ApplicationAttachmentContent AttachmentContent { get; set; } = new();


    [Coalesce]
    public async Task UploadAttachment(AppDbContext db, IFile file)
    {
        if (file.Content == null) return;

        var content = new byte[file.Length];
        await file.Content.ReadAsync(content.AsMemory());

        AttachmentContent = new() { NormalizedName = NormalizedName, Content = content };
        AttachmentName = file.Name;
        AttachmentSize = file.Length;
        AttachmentType = file.ContentType;
        AttachmentHash = SHA256.HashData(content);
        Applied = DateTimeOffset.Now;
        
    }

    [Coalesce]
    [ControllerAction(IntelliTect.Coalesce.DataAnnotations.HttpMethod.Get, VaryByProperty = nameof(AttachmentHash))]
    public IFile DownloadAttachment(AppDbContext db)
    {
        return new IntelliTect.Coalesce.Models.File(db.Applications
            .Where(c => c.NormalizedName == this.NormalizedName)
            .Select(c => c.AttachmentContent.Content))
        {
            Name = AttachmentName,
            ContentType = AttachmentType,
        };
    }
}

public class JobApplication
{
    public int JobApplicationId { get; set; }

    public string ApplicationId { get; set; }
    public Application Application { get; set; }

    public string JobId { get; set; }
    [Search]
    public Job Job { get; set; }
}


public class Job
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public string JobName { get; set; }
    [Required]
    public string JobImage { get; set; }
    [Required]
    public string JobDesc { get; set; }
    [Required]
    public string JobBenefit { get; set; }

    public string Qualifications { get; set; }
}


public class ApplicationAttachmentContent
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public string NormalizedName { get; set; }

    [Required]
    public byte[] Content { get; set; }
}