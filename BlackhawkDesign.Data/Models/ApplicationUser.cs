using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackhawkDesign.Data.Models;
public class ApplicationUser
{
#nullable disable
    public int ApplicationUserId { get; set; }
    [Required]
    public string Name { get; set; }
#nullable restore
}
