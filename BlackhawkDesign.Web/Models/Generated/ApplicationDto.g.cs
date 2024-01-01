using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace BlackhawkDesign.Web.Models
{
    public partial class ApplicationDtoGen : GeneratedDto<BlackhawkDesign.Data.Models.Application>
    {
        public ApplicationDtoGen() { }

        private string _NormalizedName;
        private string _FirstName;
        private string _LastName;
        private string _Email;
        private string _PhoneNumber;
        private System.Collections.Generic.ICollection<BlackhawkDesign.Web.Models.JobApplicationDtoGen> _JobApplied;
        private string _CoverLetter;
        private System.DateTimeOffset? _Applied;
        private string _AttachmentName;
        private long? _AttachmentSize;
        private string _AttachmentType;
        private byte[] _AttachmentHash;

        public string NormalizedName
        {
            get => _NormalizedName;
            set { _NormalizedName = value; Changed(nameof(NormalizedName)); }
        }
        public string FirstName
        {
            get => _FirstName;
            set { _FirstName = value; Changed(nameof(FirstName)); }
        }
        public string LastName
        {
            get => _LastName;
            set { _LastName = value; Changed(nameof(LastName)); }
        }
        public string Email
        {
            get => _Email;
            set { _Email = value; Changed(nameof(Email)); }
        }
        public string PhoneNumber
        {
            get => _PhoneNumber;
            set { _PhoneNumber = value; Changed(nameof(PhoneNumber)); }
        }
        public System.Collections.Generic.ICollection<BlackhawkDesign.Web.Models.JobApplicationDtoGen> JobApplied
        {
            get => _JobApplied;
            set { _JobApplied = value; Changed(nameof(JobApplied)); }
        }
        public string CoverLetter
        {
            get => _CoverLetter;
            set { _CoverLetter = value; Changed(nameof(CoverLetter)); }
        }
        public System.DateTimeOffset? Applied
        {
            get => _Applied;
            set { _Applied = value; Changed(nameof(Applied)); }
        }
        public string AttachmentName
        {
            get => _AttachmentName;
            set { _AttachmentName = value; Changed(nameof(AttachmentName)); }
        }
        public long? AttachmentSize
        {
            get => _AttachmentSize;
            set { _AttachmentSize = value; Changed(nameof(AttachmentSize)); }
        }
        public string AttachmentType
        {
            get => _AttachmentType;
            set { _AttachmentType = value; Changed(nameof(AttachmentType)); }
        }
        public byte[] AttachmentHash
        {
            get => _AttachmentHash;
            set { _AttachmentHash = value; Changed(nameof(AttachmentHash)); }
        }

        /// <summary>
        /// Map from the domain object to the properties of the current DTO instance.
        /// </summary>
        public override void MapFrom(BlackhawkDesign.Data.Models.Application obj, IMappingContext context, IncludeTree tree = null)
        {
            if (obj == null) return;
            var includes = context.Includes;

            this.NormalizedName = obj.NormalizedName;
            this.FirstName = obj.FirstName;
            this.LastName = obj.LastName;
            this.Email = obj.Email;
            this.PhoneNumber = obj.PhoneNumber;
            this.CoverLetter = obj.CoverLetter;
            this.Applied = obj.Applied;
            this.AttachmentName = obj.AttachmentName;
            this.AttachmentSize = obj.AttachmentSize;
            this.AttachmentType = obj.AttachmentType;
            this.AttachmentHash = obj.AttachmentHash;
            var propValJobApplied = obj.JobApplied;
            if (propValJobApplied != null && (tree == null || tree[nameof(this.JobApplied)] != null))
            {
                this.JobApplied = propValJobApplied
                    .OrderBy(f => f.JobApplicationId)
                    .Select(f => f.MapToDto<BlackhawkDesign.Data.Models.JobApplication, JobApplicationDtoGen>(context, tree?[nameof(this.JobApplied)])).ToList();
            }
            else if (propValJobApplied == null && tree?[nameof(this.JobApplied)] != null)
            {
                this.JobApplied = new JobApplicationDtoGen[0];
            }

        }

        /// <summary>
        /// Map from the current DTO instance to the domain object.
        /// </summary>
        public override void MapTo(BlackhawkDesign.Data.Models.Application entity, IMappingContext context)
        {
            var includes = context.Includes;

            if (OnUpdate(entity, context)) return;

            if (ShouldMapTo(nameof(NormalizedName))) entity.NormalizedName = NormalizedName;
            if (ShouldMapTo(nameof(FirstName))) entity.FirstName = FirstName;
            if (ShouldMapTo(nameof(LastName))) entity.LastName = LastName;
            if (ShouldMapTo(nameof(Email))) entity.Email = Email;
            if (ShouldMapTo(nameof(PhoneNumber))) entity.PhoneNumber = PhoneNumber;
            if (ShouldMapTo(nameof(CoverLetter))) entity.CoverLetter = CoverLetter;
        }

        /// <summary>
        /// Map from the current DTO instance to a new instance of the domain object.
        /// </summary>
        public override BlackhawkDesign.Data.Models.Application MapToNew(IMappingContext context)
        {
            var entity = new BlackhawkDesign.Data.Models.Application();
            MapTo(entity, context);
            return entity;
        }
    }
}
