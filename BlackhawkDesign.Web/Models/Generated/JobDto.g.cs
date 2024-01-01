using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace BlackhawkDesign.Web.Models
{
    public partial class JobDtoGen : GeneratedDto<BlackhawkDesign.Data.Models.Job>
    {
        public JobDtoGen() { }

        private string _JobName;
        private string _JobImage;
        private string _JobDesc;
        private string _JobBenefit;
        private string _Qualifications;

        public string JobName
        {
            get => _JobName;
            set { _JobName = value; Changed(nameof(JobName)); }
        }
        public string JobImage
        {
            get => _JobImage;
            set { _JobImage = value; Changed(nameof(JobImage)); }
        }
        public string JobDesc
        {
            get => _JobDesc;
            set { _JobDesc = value; Changed(nameof(JobDesc)); }
        }
        public string JobBenefit
        {
            get => _JobBenefit;
            set { _JobBenefit = value; Changed(nameof(JobBenefit)); }
        }
        public string Qualifications
        {
            get => _Qualifications;
            set { _Qualifications = value; Changed(nameof(Qualifications)); }
        }

        /// <summary>
        /// Map from the domain object to the properties of the current DTO instance.
        /// </summary>
        public override void MapFrom(BlackhawkDesign.Data.Models.Job obj, IMappingContext context, IncludeTree tree = null)
        {
            if (obj == null) return;
            var includes = context.Includes;

            this.JobName = obj.JobName;
            this.JobImage = obj.JobImage;
            this.JobDesc = obj.JobDesc;
            this.JobBenefit = obj.JobBenefit;
            this.Qualifications = obj.Qualifications;
        }

        /// <summary>
        /// Map from the current DTO instance to the domain object.
        /// </summary>
        public override void MapTo(BlackhawkDesign.Data.Models.Job entity, IMappingContext context)
        {
            var includes = context.Includes;

            if (OnUpdate(entity, context)) return;

            if (ShouldMapTo(nameof(JobName))) entity.JobName = JobName;
            if (ShouldMapTo(nameof(JobImage))) entity.JobImage = JobImage;
            if (ShouldMapTo(nameof(JobDesc))) entity.JobDesc = JobDesc;
            if (ShouldMapTo(nameof(JobBenefit))) entity.JobBenefit = JobBenefit;
            if (ShouldMapTo(nameof(Qualifications))) entity.Qualifications = Qualifications;
        }

        /// <summary>
        /// Map from the current DTO instance to a new instance of the domain object.
        /// </summary>
        public override BlackhawkDesign.Data.Models.Job MapToNew(IMappingContext context)
        {
            var entity = new BlackhawkDesign.Data.Models.Job();
            MapTo(entity, context);
            return entity;
        }
    }
}
