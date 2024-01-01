using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace BlackhawkDesign.Web.Models
{
    public partial class JobApplicationDtoGen : GeneratedDto<BlackhawkDesign.Data.Models.JobApplication>
    {
        public JobApplicationDtoGen() { }

        private int? _JobApplicationId;
        private string _ApplicationId;
        private BlackhawkDesign.Web.Models.ApplicationDtoGen _Application;
        private string _JobId;
        private BlackhawkDesign.Web.Models.JobDtoGen _Job;

        public int? JobApplicationId
        {
            get => _JobApplicationId;
            set { _JobApplicationId = value; Changed(nameof(JobApplicationId)); }
        }
        public string ApplicationId
        {
            get => _ApplicationId;
            set { _ApplicationId = value; Changed(nameof(ApplicationId)); }
        }
        public BlackhawkDesign.Web.Models.ApplicationDtoGen Application
        {
            get => _Application;
            set { _Application = value; Changed(nameof(Application)); }
        }
        public string JobId
        {
            get => _JobId;
            set { _JobId = value; Changed(nameof(JobId)); }
        }
        public BlackhawkDesign.Web.Models.JobDtoGen Job
        {
            get => _Job;
            set { _Job = value; Changed(nameof(Job)); }
        }

        /// <summary>
        /// Map from the domain object to the properties of the current DTO instance.
        /// </summary>
        public override void MapFrom(BlackhawkDesign.Data.Models.JobApplication obj, IMappingContext context, IncludeTree tree = null)
        {
            if (obj == null) return;
            var includes = context.Includes;

            this.JobApplicationId = obj.JobApplicationId;
            this.ApplicationId = obj.ApplicationId;
            this.JobId = obj.JobId;
            if (tree == null || tree[nameof(this.Application)] != null)
                this.Application = obj.Application.MapToDto<BlackhawkDesign.Data.Models.Application, ApplicationDtoGen>(context, tree?[nameof(this.Application)]);

            if (tree == null || tree[nameof(this.Job)] != null)
                this.Job = obj.Job.MapToDto<BlackhawkDesign.Data.Models.Job, JobDtoGen>(context, tree?[nameof(this.Job)]);

        }

        /// <summary>
        /// Map from the current DTO instance to the domain object.
        /// </summary>
        public override void MapTo(BlackhawkDesign.Data.Models.JobApplication entity, IMappingContext context)
        {
            var includes = context.Includes;

            if (OnUpdate(entity, context)) return;

            if (ShouldMapTo(nameof(JobApplicationId))) entity.JobApplicationId = (JobApplicationId ?? entity.JobApplicationId);
            if (ShouldMapTo(nameof(ApplicationId))) entity.ApplicationId = ApplicationId;
            if (ShouldMapTo(nameof(JobId))) entity.JobId = JobId;
        }

        /// <summary>
        /// Map from the current DTO instance to a new instance of the domain object.
        /// </summary>
        public override BlackhawkDesign.Data.Models.JobApplication MapToNew(IMappingContext context)
        {
            var entity = new BlackhawkDesign.Data.Models.JobApplication();
            MapTo(entity, context);
            return entity;
        }
    }
}
